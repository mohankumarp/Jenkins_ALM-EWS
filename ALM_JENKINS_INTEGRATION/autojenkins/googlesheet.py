from oauth2client.client import SignedJwtAssertionCredentials
import gdata.spreadsheets.client
import gdata.gauth
import os
import httplib2

class GoogleDoc(object):

  _spreadsheet_id=None
  _worksheet_id = None


  def __init__(self, logger, username=None, password=None):
    """Constructor for a GoogleDoc. 
    """
    self.logger = logger

     
  def SetCredentials(self, username, password, spreadsheet_name, worksheet_name):
    """Attempts to log in to Google APIs using the provided credentials."""

    #h = httplib2.Http(".cache", disable_ssl_certificate_validation=True)
    #resp, content = h.request("https://site/whose/certificate/is/bad/", "GET")
    path = os.path.join(os.path.split(__file__)[0],'privatekey.pem')
    with open(path) as keyfile:
        private_key = keyfile.read()
    scope = ['https://spreadsheets.google.com/feeds']
    email = '284081438460-7e7i3em23apiehkd7bj8dit3703eirqs@developer.gserviceaccount.com'
    
    credentials = SignedJwtAssertionCredentials(email, private_key, scope,sub = username)
    self.logger.info(credentials.client_id)
    http = httplib2.Http()
    http = credentials.authorize(http)
    
    auth2token = gdata.gauth.OAuth2TokenFromCredentials(credentials)
    self.__spreadsheets_client = gdata.spreadsheets.client.SpreadsheetsClient()
    self.__spreadsheets_client = auth2token.authorize(self.__spreadsheets_client)

    squery = gdata.spreadsheets.client.SpreadsheetQuery(title=spreadsheet_name, title_exact=True)
    sfeed = self.__spreadsheets_client.get_spreadsheets(query = squery)
    self._spreadsheet_id = sfeed.entry[0].id.text.rsplit('/',1)[1]
    #print(self._spreadsheet_id)
    wquery = gdata.spreadsheets.client.WorksheetQuery(worksheet_name, 'true')
    ws =  self.__spreadsheets_client.GetWorksheets(self._spreadsheet_id, query=wquery)
    self._worksheet_id = ws.entry[0].id.text.rsplit('/',1)[1]
    #print(self._worksheet_id)

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

