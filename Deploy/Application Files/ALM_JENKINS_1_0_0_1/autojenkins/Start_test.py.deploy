import unittest
from StartApp import Start


class StartTest(unittest.TestCase):

    def setUp(self):
       #args = ['mohan.panigrahi@gmail.com', 'mohan7jan', 
       #"http://dcb-v-scl-0007.user.arinso/jenkins/", ['euHReka_GLO_WFAdmin_EmployeeData_PersAction_Divorce'], 'http://entqcpci01.northgatearinso.erp:8080/qcbin',
       #'mohankumarp', 'test', 'CORE_PRODUCTS', 'euHReka', 'Root\EuHReka\Version17\Patch_Releases\RegressionAutoSuite',
       #'JenkinsLog_V17', 'DCB07', 'DCB-07_EQC-800_BatchRun']
       args = ['mohan.panigrahi@gmail.com', 'mohan7jan', 
       "http://dca-v-qtp-0001.user.arinso:8080/", ['euHReka_GLO_FWK_MyCollaboration'], 'http://entqcpci01.northgatearinso.erp:8080/qcbin',
       'mohankumarp', 'test', 'CORE_PRODUCTS', 'euHReka', 'Root\EuHReka\Version-17\Patch_Releases\RegressionAutoSuite',
       'JenkinsLog_V17', 'DCA01', 'DCA-01_EQ1-800_BatchRun']
       
       self.start = Start(args)


    def testUpdate_All(self):
        self.start.Update_ALM_Jenkins()
        pass


if __name__ == '__main__':
    unittest.main()



