
import unittest
import getpass
from  googlesheet import Error
from  googlesheet import GoogleDoc
import logging

username = 'jenkinsalm@gmail.com'
password = 'ews12345'
spreadsheet_name = 'JenkinsLog_V17_EQ1_800_Patch9'
worksheet_name = 'DCA01'


class GoogleDocTest(unittest.TestCase):

  def setUp(self):
    self.logsetting()
    self.googledoc = GoogleDoc(self.logger)
    self.error = Error()
    

      #Negative Test
#  def testBadCredentials(self):
#    try:
#      self.googledoc.SetCredentials('foo', 'bar')
#      self.fail()
#    except self.error, e:
#      pass

  def testSetCredentials(self):
      self.googledoc.SetCredentials(username, password, spreadsheet_name, worksheet_name)
      #self.googledoc.GetAllJob()
      #self.googledoc.GetAllScripts('euHReka_GLO_FWK_MyCollaboration')
      self.googledoc.UpdateStatus('FWK MyCalendar Display HRA', '1', 'logfile')
      pass
  
  
  def logsetting(self):
        # create logger with 'spam_application'
        self.logger = logging.getLogger('Alm-Access-Test')
        self.logger.setLevel(logging.DEBUG)
        # create file handler which logs even debug messages
        fh = logging.FileHandler('GoogleSheet_Test.log')
        fh.setLevel(logging.DEBUG)
        # create console handler with a higher log level
        ch = logging.StreamHandler()
        ch.setLevel(logging.DEBUG)
        # create formatter and add it to the handlers
        formatter = logging.Formatter('%(asctime)s - %(name)s - %(levelname)s - %(message)s')
        fh.setFormatter(formatter)
        ch.setFormatter(formatter)
        # add the handlers to the logger
        self.logger.addHandler(fh)
        self.logger.addHandler(ch)
  
  
if __name__ == '__main__':
    if not username:
      username = raw_input('Spreadsheets API | Text DB Tests\n'
                         'Please enter your username: ')
    if not password:
      password = getpass.getpass()  
    unittest.main()