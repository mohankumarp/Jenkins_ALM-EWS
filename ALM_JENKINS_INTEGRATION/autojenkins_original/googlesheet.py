#import gdata
#import gdata.service
#import gdata.spreadsheet
import gdata.spreadsheet.service
#import gdata.docs
import gdata.docs.service


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
  
    If the username and password are present, the constructor  will contact
    the Google servers to authenticate.

    Args:
      username: str (optional) Example: jo@example.com
      password: str (optional)
    """
    self.__docs_client = gdata.docs.service.DocsService()
    self.__spreadsheets_client = gdata.spreadsheet.service.SpreadsheetsService()
    self.logger = logger
     
  def SetCredentials(self, username, password, spreadsheet_name, worksheet_name):
    """Attempts to log in to Google APIs using the provided credentials.

    If the username or password are None, the client will not request auth 
    tokens.

    Args:
      username: str (optional) Example: jo@example.com
      password: str (optional)
    """
    self.__docs_client.email = username
    self.__docs_client.password = password
    self.__spreadsheets_client.email = username
    self.__spreadsheets_client.password = password

    if username and password:
      try:
        self.__docs_client.ProgrammaticLogin()
        self.__spreadsheets_client.ProgrammaticLogin()
        
        q = gdata.spreadsheet.service.DocumentQuery()
        q['title'] = spreadsheet_name
        q['title-exact'] = 'true'
        
        spreadheets_feed = self.__spreadsheets_client.GetSpreadsheetsFeed(query=q)
        self._spreadsheet_id = spreadheets_feed.entry[0].id.text.rsplit('/',1)[1]
        
        worksheets_feed = self.__spreadsheets_client.GetWorksheetsFeed(self._spreadsheet_id)
        #self._worksheet_id = worksheets_feed.entry[11].id.text.rsplit('/',1)[1]
        for entry in worksheets_feed.entry:
            if entry.title.text == worksheet_name:
                self._worksheet_id = entry.id.text.rsplit('/',1)[1]
                break
        #self.GetAllJob()
        #self.GetAllScripts('v15 Framework-BasicNavigation')
        
      except gdata.service.CaptchaRequired:
        raise CaptchaRequired('Please visit https://www.google.com/accounts/'
                            'DisplayUnlockCaptcha to unlock your account.')
      except gdata.service.BadAuthentication:
        raise BadCredentials('Username or password incorrect.')

  def UpdateStatus(self, script_name, status, logfile):
    cells = self.__spreadsheets_client.GetCellsFeed(self._spreadsheet_id,self._worksheet_id).entry
    for cell in cells:
        if cell.cell.text == script_name:
            c = int(cell.cell.col) + 2
            r = cell.cell.row
            entry = self.__spreadsheets_client.UpdateCell(r, c, status, self._spreadsheet_id,self._worksheet_id)
            c = int(cell.cell.col) + 3
            r = cell.cell.row
            entry = self.__spreadsheets_client.UpdateCell(r, c, logfile, self._spreadsheet_id,self._worksheet_id)
            #print  'Worksheet Updated!' 
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
        for key in row.custom:
            #print key
            if key == 'jobname':
                if row.custom['jobname'].text == job_name and row.custom['scope'].text == 'Yes' :
                    #print 'JobName: ' + row.custom['jobname'].text
                    #print 'ScriptName: ' + row.custom['scriptname'].text
                    #scripts[row.custom['jobname'].text] = row.custom['scriptname'].text
                    #if not scripts.__contains__(row.custom['scriptname'].text)
                    scripts[row.custom['testname'].text] = row.custom['alm'].text
    #self.logger.info(scripts)
    return scripts

