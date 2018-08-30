from jenkinsapi.jenkins import Jenkins
from datetime import datetime
from selenium import webdriver
from  googlesheet import GoogleDoc
from AlmAccess import ALM_Access
import logging
import sys


class Start:

    def __init__(self, args):
        self.logsetting(args[3])
        self.username = args[0]
        self.password = args[1]
        self.jenkins_server = args[2]
        #self.jobname = args[3].replace ("_", " ")
        joblist = args[3]
        self.joblistformated = []
        
        for job in joblist:
		    self.joblistformated.append(job) 
            #self.joblistformated.append(job.replace ("_", " ")) 
        
        self.qcurl = args[4]
        self.qcuname = args[5]
        self.qcpwd = args[6]
        self.qcdomain = args[7]
        self.qcproject = args[8]
        self.qcrootfolderpath = args[9]
        self.spreadsheet_name = args[10]
        self.worksheet_name = args[11]
        self.batch_job_name = args[12]

        self.logger.info(self.username)
        #self.logger.info(self.password)
        self.logger.info('*******')
        self.logger.info(self.jenkins_server)
        #self.logger.info(self.jobname)
        self.logger.info(self.joblistformated)
        self.logger.info(self.qcurl)
        self.logger.info(self.qcuname)
        #self.logger.info(self.qcpwd)
        self.logger.info('*****')
        self.logger.info(self.qcdomain)
        self.logger.info(self.qcproject)
        self.logger.info(self.qcrootfolderpath)
        self.logger.info(self.spreadsheet_name)
        self.logger.info(self.worksheet_name)
        self.logger.info(self.batch_job_name)

        #self.batch_job_name = 'DCB-01_EQ1-800_BatchRun'
        self.driver = None
        #self.Update_ALM_Jenkins()



    def get_server_instance(self):
        server = Jenkins(self.jenkins_server)
        return server


    def get_all_jobs(self):
        """Get job details of each job that is running on the Jenkins instance"""
        # Refer Example #1 for definition of function 'get_server_instance'
        server = self.get_server_instance()
        #print server.version()
        #print server.views()
        for j in server.get_jobs():
            job_instance = server.get_job(j[0])
            if job_instance.name == self.batch_job_name :
                #print 'Job Name:%s' %(job_instance.name)
                return job_instance.get_downstream_jobs()


    def get_string_status(self, status):
        if status == "1":
            return "Passed"
        else:
            return "Not Completed"


    def logsetting(self, jobname):
        # create logger with 'spam_application'
        self.logger = logging.getLogger('ALM-Jenkins')
        self.logger.setLevel(logging.DEBUG)
        # create file handler which logs even debug messages
        #fh = logging.FileHandler('euhreka.log')
        logfilename = datetime.now().strftime(jobname[0] + '_%H_%M_%S_%d_%m_%Y.log')
        fh = logging.FileHandler(logfilename)
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


    def Update_All(self):

        #logging.basicConfig(level=logging.DEBUG, 
             #               format='%(asctime)s %(levelname)s %(message)s',
             #               datefmt='%a, %d %b %Y %H:%M:%S',
             #               filename='ALMJenkinsIntegration.log',
             #               filemode='w')

        googledoc = GoogleDoc(self.logger)
        googledoc.SetCredentials(self.username, self.password, self.spreadsheet_name, self.worksheet_name)
        alm_access = ALM_Access(self.logger, self.qcurl, self.qcuname, self.qcpwd, self.qcdomain, self.qcproject, self.qcrootfolderpath )
        
        self.logger.info('-----------START----------------')
    
        for job in self.get_all_jobs():
            if job.name == self.jobname :
                #print job.name
                self.logger.info('Job Name: %s' %job.name)
                glb = job.get_last_build()
                logfile = glb.baseurl + '/robot/report/log.html'
                #print 'Log url of job: %s' %logfile
                self.logger.info('Log url of job: %s' %logfile)
                self.driver = webdriver.Firefox()
                self.driver.get(logfile)
                script_Names = googledoc.GetAllScripts(self.jobname)
    
                for script_name in script_Names :
                    status = self.driver.find_element_by_xpath('//a[text()="' + script_name + '"]/../../../td[3]')
                    #print ('Status of %s script is : %s' %(script_name, status.text))
                    self.logger.info('Status of %s script is : %s' %(script_name, status.text))
                    googledoc.UpdateStatus(script_name, status.text)
                    self.almlocation = script_Names[script_name]
                    self.logger.info('ALM Location Path : %s' %(self.almlocation))
                    alm_access.UpdateOneTestInstance(self.almlocation, self.get_string_status(status.text), script_name, logfile )
                next
                self.driver.get(glb.baseurl)
                keepbuild = self.driver.find_element_by_xpath("//button[@id='yui-gen1-button']")
                if keepbuild.text == 'Keep this build forever':
                    keepbuild.click()
                self.driver.close()
        next
        self.logger.info('----------END----------------')


    def Update_ALM_Jenkins(self):
        googledoc = GoogleDoc(self.logger)
        googledoc.SetCredentials(self.username, self.password, self.spreadsheet_name, self.worksheet_name)
        alm_access = ALM_Access(self.logger, self.qcurl, self.qcuname, self.qcpwd, self.qcdomain, self.qcproject, self.qcrootfolderpath )
        self.logger.info('-----------START JOB----------------------')
    
        for job in self.get_all_jobs():
            if job.name in self.joblistformated :
                #print job.name
                self.logger.info('Job Name: %s' %job.name)

                glb = job.get_last_build()
                baseurl = glb.baseurl
                #Commented out below code as we are no more using port 8080 in DCA and /Jenkins in DCA and DCB servers
                #if 'dca' in baseurl and ':8080' not in baseurl :
                #    index = baseurl.find('/job')
                #    baseurl = baseurl[:index] + ':8080' + baseurl[index:]
                #if 'dcb' in baseurl :
                #    index = baseurl.find('/job')
                #    baseurl = baseurl[:index] + '/jenkins' + baseurl[index:]
                
                logfile = baseurl + '/robot/report/log.html'
                #print 'Log url of job: %s' %logfile
                self.logger.info('Log url of job: %s' %logfile)

                #self.driver = webdriver.Firefox()
                #self.driver = webdriver.PhantomJS(executable_path='C:\bin\PhantomJS')
                self.driver = webdriver.PhantomJS()
                self.driver.get(logfile)
                script_Names = googledoc.GetAllScripts(job.name)

                for script_name in script_Names :
                    status = self.driver.find_element_by_xpath('//a[text()="' + script_name + '"]/../../../td[3]')
                    #print ('Status of %s script is : %s' %(script_name, status.text))
                    self.logger.info('-----------START TEST-----------')
                    self.logger.info('Status of %s script is : %s' %(script_name, status.text))
                    googledoc.UpdateStatus(script_name, status.text, logfile)
                    self.almlocation = script_Names[script_name]
                    #self.logger.info('ALM Location Path : %s' %(self.almlocation))
                    alm_access.UpdateOneTestInstance(self.almlocation, self.get_string_status(status.text), script_name, logfile )
                    self.logger.info('-----------END TEST-----------')
                next
                self.driver.get(baseurl)
                keepbuild = self.driver.find_element_by_xpath("//button[@id='yui-gen1-button']")
                if keepbuild.text == 'Keep this build forever':
                    keepbuild.click()
                    self.logger.info('Keep this build forever : SUCCESS')
                self.driver.close()
        next
        self.logger.info('-----------END JOB----------------------')




    #def __del__(self):
        #self.driver.quit()


if __name__ == '__main__':
    username = str(sys.argv[1])
    password = str(sys.argv[2])
    jenkins_server = str(sys.argv[3])
    #jobname = str(sys.argv[4])
    joblist = [x.strip() for x in  sys.argv[4].split(',')]
    #joblist = sys.argv[4]
    
    qcurl= str(sys.argv[5])
    qcuname= str(sys.argv[6])
    qcpwd= str(sys.argv[7])
    qcdomain= str(sys.argv[8])
    qcproject= str(sys.argv[9])
    qcrootfolderpath= str(sys.argv[10])
    spreadsheet_name= str(sys.argv[11])
    worksheet_name= str(sys.argv[12])
    batch_job_name= str(sys.argv[13])
    
    args = [username, password, jenkins_server, joblist, qcurl, qcuname, qcpwd, qcdomain, qcproject, qcrootfolderpath, spreadsheet_name, worksheet_name, batch_job_name]
    start = Start(args)
    start.Update_ALM_Jenkins()
