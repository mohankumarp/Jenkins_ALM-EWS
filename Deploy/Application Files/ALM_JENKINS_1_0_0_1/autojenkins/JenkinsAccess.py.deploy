import jenkinsapi
from jenkinsapi.jenkins import Jenkins
from selenium import webdriver
from  googlesheet import GoogleDoc
import logging

class Jenkins_Access(object):

    def get_server_instance(self, jenkins_server):
        server = Jenkins(jenkins_server)
        print server.base_server_url()
        logging.info(server.base_server_url())
        return server

    def get_all_jobs(self, job_name, jenkins_server):
        """Get job details of each job that is running on the Jenkins instance"""
        server = self.get_server_instance(jenkins_server)
        for j in server.get_jobs():
            job_instance = server.get_job(j[0])
            if job_instance.name == job_name :
                print 'Job Name:%s' %(job_instance.name)
                logging.info('Job Name:%s' %(job_instance.name))
                return job_instance.get_downstream_jobs()

    def get_string_status(self, status):
        if status == "1":
            return "Passed"
        else:
            return "Failed"

    def get_script_status(self, inner_jobname, job_name, jenkins_server, googledoc):
       for job in self.get_all_jobs(job_name, jenkins_server):
            if job.name == inner_jobname :
                print job.name
                logging.info('Job Name:%s' %(job.name))
                glb = job.get_last_build()
                logfile = glb.baseurl + '/robot/report/log.html'
                print 'Log url of job: %s' %logfile
                logging.info('Log url of job: %s' %logfile)
                driver = webdriver.Firefox()
                driver.get(logfile)
                script_Names = googledoc.GetAllScripts(inner_jobname)
                for script_name in script_Names :
                    status = driver.find_element_by_xpath('//a[text()="' + script_name + '"]/../../../td[3]')
                    print ('Status of %s script is : %s' %(script_name, status.text))
                    logging.info('Status of %s script is : %s' %(script_name, status.text))
                next

                self.keep_build_forever(glb, driver)
                driver.close()
       next

    def keep_build_forever(self, glb, driver):
        driver.get(glb.baseurl)
        keepbuild = driver.find_element_by_xpath("//button[@id='yui-gen1-button']")
        print keepbuild.text
        if keepbuild.text == 'Keep this build forever':
           keepbuild.click()
