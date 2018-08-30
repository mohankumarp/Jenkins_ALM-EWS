#import os
import string
#import pywintypes
#import win32com
from win32com.client import Dispatch
import logging
#import sys

class ALM_Access:

  def __init__(self,logger, qcurl, qcuname,qcpwd,qcdomain,qcproject,qcrootfolderpath):
    #print ("ALM_Access constructor")
    #logging.basicConfig(filename='ALMAccess_test.log', filemode='w', level=logging.INFO)
    #logging.basicConfig(stream=sys.stderr, level=logging.DEBUG, 
    #                format='%(asctime)s %(levelname)s %(message)s',
    #                datefmt='%a, %d %b %Y %H:%M:%S',
    #                filename='ALMAccess_test.log',
    #                filemode='w')
    

    #self.qcServer = "http://entqcpci01.northgatearinso.erp:8080/qcbin/"
    #self.qcUser = "mohankumarp"
    #self.qcPassword = ""
    #self.qcDomain = "CORE_PRODUCTS"
    #self.qcProject = "euHReka"
    #self.rootpath="Root\EuHReka\Patch Release\Patch Dummy"
    self.logger = logger
    #self.logsetting()
    self.qcServer = qcurl
    self.qcUser = qcuname
    self.qcPassword = qcpwd
    self.qcDomain = qcdomain
    self.qcProject = qcproject
    self.rootpath = qcrootfolderpath


    self.tdConnection = Dispatch("TDApiOle80.TDConnection")
    self.tdConnection.InitConnectionEx(self.qcServer)
    self.tdConnection.Login(self.qcUser,self.qcPassword)
    self.tdConnection.Connect(self.qcDomain,self.qcProject)
    
    if self.tdConnection.Connected:
        #printt("Logged in to " + self.qcProject)
        self.logger.info("Logged in to ALM Project " + str(self.qcProject))
    else:
        self.logger.info("ERROR: Connect failed to ALM Project" + str(self.qcProject))
        #print("ERROR: Connect failed to " + qcProject)

  def logsetting(self):
    # create logger with 'spam_application'
    self.logger = logging.getLogger('ALM_Access')
    self.logger.setLevel(logging.DEBUG)
    # create file handler which logs even debug messages
    fh = logging.FileHandler('ALM_Access.log')
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


  def UpdateTestInstance(self, folderpath, status, script_Names):

    testsetpath = self.rootpath + folderpath
    #print testsetpath
    self.logger.debug("TestSet Path :" + str(testsetpath))
    self.tsFolder = self.tdConnection.TestSetTreeManager.NodeByPath(testsetpath)
    #print self.tsFolder
    self.logger.debug("Test Folder :" + str(self.tsFolder))
    self.tsFactory=self.tsFolder.TestSetFactory
    filter= self.tsFactory.Filter
    testsets=filter.NewList()
    
    for testset in testsets:
        #print testset.Name
        #self.logger.info("TestSet Name " + str(testset.Name))
        tsTestSetFactory = testset.TSTestFactory
        testcases = tsTestSetFactory.NewList("")
    
        for scriptname in script_Names:
            #print "script name Jenkins:" + scriptname
            for testcase in testcases:
                #print "testcase name ALM:" + testcase.Name
                if testcase.Name ==  self._FormatScriptName(scriptname) :
                    #print "testcase name : " + testcase.Name
                    self.logger.info("testcase name : " + str(testcase.Name))
                    runFactory = testcase.RunFactory
                    theRun = runFactory.AddItem("testrun")
                    theRun.Status = status
                    testcase.Status= status
                    theRun.Post()
                    #print testcase.Status
                    #print "ALM Update Completed!"
                    self.logger.info("Test Case Status After Update : " + str(testcase.Status ))
                    self.logger.info("ALM Update Completed!")
                next
        next
    next

  def UpdateOneTestInstance(self, folderpath, status, scriptname, jenkinslog):

    folders = folderpath.split('\\')
    testsetpath = ""
    for i in range(0, len(folders)):
        if i < len(folders)-1:
            if self.rootpath not in testsetpath:
                testsetpath = string.join([self.rootpath,folders[i]], '\\')
            else:
                testsetpath = string.join([testsetpath,folders[i]], '\\')
        else:
            testsetname = folders[i]
            
    #self.logger.info("Root Path " + str(self.rootpath))
    #self.logger.info("TestSet Path " + str(testsetpath))
    tsFolder = self.tdConnection.TestSetTreeManager.NodeByPath(testsetpath)
    #print tsFolder
    #self.logger.info("Test Folder " + str(tsFolder))
    tsFactory=tsFolder.TestSetFactory
    filter= tsFactory.Filter
    testsets=filter.NewList()
    
    for testset in testsets:
        if testset.Name == testsetname:
            #print testset.Name
            #self.logger.info("TestSet Name " + str(testset.Name))
            tsTestSetFactory = testset.TSTestFactory
            testcases = tsTestSetFactory.NewList("")
            for testcase in testcases:
               #print "testcase name ALM:" + testcase.Name
               if testcase.Name ==  self._FormatScriptName(scriptname) :
                  #print "testcase name : " + testcase.Name
                  #self.logger.info("testcase name : " + str(testcase.Name))
                  runFactory = testcase.RunFactory
                  theRun = runFactory.AddItem("testrun")
                  theRun.Status = status
                  #theRun.SetField("TC_USER_09", jenkinslog)    #Throwing Exception
                  #theRun.Field("TC_USER_09") = jenkinslog     #Compilation Error
                  testcase.Status= status
                  testcase.SetField("TC_USER_09", jenkinslog)
                  testcase.Post()
                  theRun.Post()
                  #print testcase.Status
                  #print "ALM Update Completed!"
                  #self.logger.info("Test Case Status After Update : " + str(testcase.Status))
                  self.logger.info("ALM Updated!")
            next
    next


  def _FormatScriptName(self, scriptname):
      testname = '[1]' + scriptname.replace (" ", "_")
      #print scriptname
      return testname

  def __del__(self):
    #print ("ALM_Access destructor")
    if self.tdConnection.Connected:
        self.tdConnection.Disconnect
        self.tdConnection.Logout
        #print("Logged out from " + self.qcProject)
        self.logger.info("Logged out from ALM Project " + str(self.qcProject))

    self.tdConnection = None
    logging.shutdown()
