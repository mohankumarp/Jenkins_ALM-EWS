#import gdata
#import gdata.service
#import gdata.spreadsheet
#import gdata.spreadsheet.service
#import gdata.docs
#import gdata.docs.service
import gdata.spreadsheets.client
#import gdata.spreadsheet.service
import gdata.gauth
import webbrowser

class Error(Exception):
  pass

class BadCredentials(Error):
  pass

class CaptchaRequired(Error):
  pass

class GoogleDoc(object):

  _spreadsheet_id=None
  _worksheet_id = None


  def __init__(self, logger, username=None, password=None):
    """Constructor for a GoogleDoc. 
      If the username and password are present, the constructor  will contact the Google servers to authenticate.
    """
    
    #self.__docs_client = gdata.docs.service.DocsService()
    self.__spreadsheets_client = gdata.spreadsheets.client.SpreadsheetsClient()
    self.logger = logger
     
  def SetCredentials(self, username, password, spreadsheet_name, worksheet_name):
    """Attempts to log in to Google APIs using the provided credentials."""

    self.__spreadsheets_client.email = username
    self.__spreadsheets_client.password = password
    client_id = "284081438460-sdg3dn9tt80huceeb9v4n833n97lmtlu.apps.googleusercontent.com";
    client_secret = "HNb2txJ2QpK0amd4IR7HAxZK";
    scope = "https://spreadsheets.google.com/feeds";
    redirect_uri = "urn:ietf:wg:oauth:2.0:oob";
    user_agent='myself'
    
    token = gdata.gauth.OAuth2Token(client_id=client_id,client_secret=client_secret,scope=scope,user_agent=user_agent)
    webbrowser.open(token.generate_authorize_url(redirect_uri=redirect_uri))
    self.logger.info(token.generate_authorize_url(redirect_uri=redirect_uri))
    self.logger.info('Enter the auth code:')
    #print token.generate_authorize_url(redirect_uri=redirect_uri)
    code = raw_input('Enter the auth code: ').strip()
    token.get_access_token(code)
    token.authorize(self.__spreadsheets_client)


    
    if username and password:
      try:
        #self.__docs_client.ProgrammaticLogin()
        #self.__spreadsheets_client.ProgrammaticLogin()
        #self.__docs_client.ClientLogin(username, password)
        #self.__spreadsheets_client.ClientLogin(username, password)
        
        #q = gdata.spreadsheet.service.DocumentQuery()
        #q['title'] = spreadsheet_name
        #q['title-exact'] = 'true'
        
        squery = gdata.spreadsheets.client.SpreadsheetQuery(title=spreadsheet_name, title_exact=True)
        sfeed = self.__spreadsheets_client.get_spreadsheets(query = squery)
        self._spreadsheet_id = sfeed.entry[0].id.text.rsplit('/',1)[1]
        #print(self._spreadsheet_id)
        
        
        wquery = gdata.spreadsheets.client.WorksheetQuery(worksheet_name, 'true')
        ws =  self.__spreadsheets_client.GetWorksheets(self._spreadsheet_id, query=wquery)
        self._worksheet_id = ws.entry[0].id.text.rsplit('/',1)[1]
        #print(self._worksheet_id)
        
        #spreadheets_feed = self.__spreadsheets_client.GetSpreadsheetsFeed(query=q)
        #self._spreadsheet_id = spreadheets_feed.entry[0].id.text.rsplit('/',1)[1]
        
        #worksheets_feed = self.__spreadsheets_client.GetWorksheetsFeed(self._spreadsheet_id)
        #self._worksheet_id = worksheets_feed.entry[11].id.text.rsplit('/',1)[1]
        #for entry in worksheets_feed.entry:
        #    if entry.title.text == worksheet_name:
        #        self._worksheet_id = entry.id.text.rsplit('/',1)[1]
        #        break
        #self.GetAllJob()
        #self.GetAllScripts('v15 Framework-BasicNavigation')
        
      except gdata.service.CaptchaRequired:
        raise CaptchaRequired('Please visit https://www.google.com/accounts/'
                            'DisplayUnlockCaptcha to unlock your account.')
      except gdata.service.BadAuthentication:
        raise BadCredentials('Username or password incorrect.')

  def UpdateStatus(self, script_name, status, logfile):
    cells = self.__spreadsheets_client.get_cells(self._spreadsheet_id,self._worksheet_id).entry
    for cell in cells:
        if cell.cell.text == script_name:
            c = int(cell.cell.col) + 2
            r = cell.cell.row
            #entry = self.__spreadsheets_client.UpdateCell(r, c, status, self._spreadsheet_id,self._worksheet_id)
            cq = gdata.spreadsheets.client.CellQuery(r, r, c, c)
            cs = self.__spreadsheets_client.GetCells(self._spreadsheet_id, self._worksheet_id, q=cq)
            cell_ent = cs.entry[0]
            cell_ent.cell.input_value = status
            self.__spreadsheets_client.Update(cell_ent)
            
            c = int(cell.cell.col) + 3
            r = cell.cell.row
            cq = gdata.spreadsheets.client.CellQuery(r, r, c, c)
            cs = self.__spreadsheets_client.GetCells(self._spreadsheet_id, self._worksheet_id, q=cq)
            cell_ent = cs.entry[0]
            cell_ent.cell.input_value = logfile
            self.__spreadsheets_client.Update(cell_ent)
            #entry = self.__spreadsheets_client.UpdateCell(r, c, logfile, self._spreadsheet_id,self._worksheet_id)
            self.logger.info('Worksheet Updated!')
            break

  def GetAllJob(self):
    #print "Get All jobs Method"
    jobs = {}
    rows = self.__spreadsheets_client.GetListFeed(self._spreadsheet_id,self._worksheet_id).entry
    for row in rows:
        for key in row.custom:
            #print key
            if key == 'jobname':
                #print 'JenkinsJobName: ' + row.custom['jobname'].text
                #print 'Server: ' + row.custom['server'].text
                jobs[row.custom['jobname'].text] = row.custom['server'].text
    self.logger.info(jobs)


  def GetAllScripts(self, job_name):
    #print "Get All Scripts Method"
    scripts = {}
    rows = self.__spreadsheets_client.GetListFeed(self._spreadsheet_id,self._worksheet_id).entry
    for row in rows:
        for key in row.children:
            #print key
            if key.tag == 'jobname':
                if row.children[3].text == job_name and row.children[9].text == 'Yes' :
                    #print 'JobName: ' + row.custom['jobname'].text
                    #print 'ScriptName: ' + row.custom['scriptname'].text
                    #scripts[row.custom['jobname'].text] = row.custom['scriptname'].text
                    #if not scripts.__contains__(row.custom['scriptname'].text)
                    scripts[row.children[4].text] = row.children[8].text
    #self.logger.info(scripts)
    return scripts

