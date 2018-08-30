
import os
import pywintypes
import win32com
from win32com.client import Dispatch
import unittest
from AlmAccess import ALM_Access
import logging


qcfolderpath = "Workforce_Admin\Time\TimeViews\Flexflows"
status = "Passed"
qcurl = "http://entqcpci01.northgatearinso.erp:8080/qcbin/"
qcuname = "mohankumarp"
qcpwd = "test"
qcdomain = "CORE_PRODUCTS"
qcproject = "euHReka"
qcrootpath="Root\EuHReka\Version-17\Patch_Releases\RegressionAutoSuite"
jenkinslog = "http://dcb-v-scl-0001.user.arinso/job/euHReka_GLO_WFAdmin_TimeMgmt_TimeViews_FlexFlows_Absence_Group2/13/robot/report/log.html"

script_Names = ['[1]FWK_BasicNavigation_NavigateToTabNormalNavigation_HRA',
                '[1]FWK_BasicNavigation_SubmenuOrder_TKP',
                '[1]FWK_BasicNavigation_WidgetCollapseExpand_EMP',
                '[1]FWK_BasicNavigation_WidgetDisplay_HRA',
                '[1]FWK_BasicNavigation_WidgetLabelsDisplay_EMP',
                '[1]FWK_BasicNavigation_LandingPage_MyActivities_MyAttendanceRequests_MGR',
                '[1]FWK_BasicNavigation_LandingPage_MyDetailsDisplay_TKP',
                '[1]FWK_BasicNavigation_LeftMenu_DisplayCollapseExpandWidget_HRA']

script_Names_format = ['FWK BasicNavigation NavigateToTabNormalNavigation HRA',
                       'FWK BasicNavigation SubmenuOrder TKP',
                       'FWK BasicNavigation WidgetCollapseExpand EMP',
                       'FWK BasicNavigation WidgetDisplay HRA',
                       'FWK BasicNavigation WidgetLabelsDisplay EMP',
                       'FWK BasicNavigation LandingPage MyActivities MyAttendanceRequests MGR',
                       'FWK BasicNavigation LandingPage MyDetailsDisplay TKP',
                       'FWK BasicNavigation LeftMenu DisplayCollapseExpandWidget HRA']

script_Name_format = 'WA TMN Flexflows TimeView(Monthly) Absence(HolidayPaidQuota) Approve(NewTask) By MGR'
                     #'WA TMN Flexflows TimeView(Monthly) Absence(HolidayPaidQuota) Approve(NewTask) By MGR'
class AlmAccessTest(unittest.TestCase):

  def setUp(self):
    self.logsetting()
    self.alm_access = ALM_Access(self.logger, qcurl, qcuname,qcpwd,qcdomain,qcproject,qcrootpath)

  def testUpdateTestInstance(self):
      self.alm_access.UpdateOneTestInstance(qcfolderpath, status, script_Name_format, jenkinslog)
      pass

  def logsetting(self):
        # create logger with 'spam_application'
        self.logger = logging.getLogger('Alm-Access-Test')
        self.logger.setLevel(logging.DEBUG)
        # create file handler which logs even debug messages
        fh = logging.FileHandler('AlmAccess_Test.log')
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
  unittest.main()