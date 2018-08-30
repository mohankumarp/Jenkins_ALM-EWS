import unittest
from JenkinsAccess import Jenkins_Access
from jenkinsapi import jenkins
from googlesheet import GoogleDoc


jenkins_server = 'http://dcb-v-scl-0001.user.arinso/'
job_name = 'DCB-01 EQ1-800 Batch Run'
inner_jobname = 'v15 Framework-BasicNavigation'

username = 'mohan.panigrahi@gmail.com'
password = 'mohan7jan'

class JenkinsAccessTest(unittest.TestCase):

  def setUp(self):
    self.jenkins_access = Jenkins_Access()
    self.googledoc = GoogleDoc()
    self.googledoc.SetCredentials(username, password)


#  def test_get_server_instance(self):
#      self.jenkins_access.get_server_instance(jenkins_server)
#      pass

#  def test_get_all_jobs(self):
#      self.jenkins_access.get_all_jobs(job_name, jenkins_server)
#      pass
  
  def test_get_script_status(self):
      self.jenkins_access.get_script_status(inner_jobname, job_name, jenkins_server, self.googledoc)
      pass
  
  
  
if __name__ == '__main__':
  unittest.main()

