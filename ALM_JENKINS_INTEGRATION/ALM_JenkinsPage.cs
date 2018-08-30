using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TDAPIOLELib;
using System.Collections;
using System.Reflection;
using DgvFilterPopup;
using Google.GData.Spreadsheets;
using Google.GData.Client;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Security.Cryptography.X509Certificates;
using Google.GData.Client;
using Google.GData.Extensions;
using Google.GData.Spreadsheets;
using Google.Apis.Auth.OAuth2;

namespace ALMJENKINS
{
    public partial class Form1 : Form
    {
        #region Global Variables
        TDAPIOLELib.TDConnection conn = null;
        DataTable dtALMTestDetails = null;
        DataTable dtJenkinsTestDetails = null;
        Dictionary<string, List<string>> JenkinServers = null;
        SpreadsheetsService spreadsheetsService = null;
        SpreadsheetFeed spreadsheetFeed = null;
        WorksheetFeed worksheetFeed = null;
        ListFeed listFeed = null;
        string cmd = string.Empty;
        string username = string.Empty;
        string password = string.Empty;
        string jenkins_server = string.Empty;
        string jobname = string.Empty;
        List<string> joblist = new List<string>();
        string authorizationUrl = string.Empty;
        int jenkinsCheckedNodeCount = 0;

        #endregion

        #region UI Form

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Initialize Global Variables
            dgvALM.AutoGenerateColumns = dgvJenkins.AutoGenerateColumns = false;
            //cmd = @"C:\PythonWorkspace\ALM_Jenkins_Integration\autojenkins\StartApp.py";
            cmd = Path.Combine(Environment.CurrentDirectory, "..\\..\\autojenkins\\StartApp.py");

            username = txtUserName.Text;
            password = txtPasswpord.Text;

            FormatWorkSheetName();
        }
        #endregion

        #region ALM Access Events

        private void btnConnectQc_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            dgvALM.AutoGenerateColumns = false;

            dtALMTestDetails = BuildDataTable();
            treeViewALM.Nodes.Clear();
            progressBar1.Value = 0;
            btnConnectALM.Enabled = false;

            if (conn == null)
            {
                connectToQC();
            }
            if (conn != null)
            {
                if (conn.Connected)
                    showTestLabTree();
                else
                    MessageBox.Show("QC Connection Failed!");
            }

            btnConnectALM.Enabled = true;
            DgvFilterManager filterManager = new DgvFilterManager(dgvALM, true);
            Cursor.Current = Cursors.Default;
        }

        private void treeViewALM_AfterSelect(object sender, TreeViewEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            if (e.Node.Tag != null)
            {
                if (e.Node.Tag.ToString().ToLower() == "testset")
                {
                    TestSetTreeManager testSetTreeMgr = (TestSetTreeManager)conn.TestSetTreeManager;

                    var path = BuildPath(e.Node);
                    TestSetFolder rootTestSetFolder = (TestSetFolder)testSetTreeMgr.get_NodeByPath(path);
                    List testSetList = rootTestSetFolder.FindTestSets(e.Node.Text, false, string.Empty);
                    IEnumerator enumerator = testSetList.GetEnumerator();
                    if (enumerator.MoveNext())
                    {
                        TestSet testSet = (TestSet)enumerator.Current;
                        TSTestFactory tsTestFactory = (TSTestFactory)testSet.TSTestFactory;
                        ListClass testList = (ListClass)tsTestFactory.NewList(string.Empty);

                        IEnumerator testListEnum = testList.GetEnumerator();
                        if (dtALMTestDetails == null)
                        {
                            dtALMTestDetails = BuildDataTable();
                        }
                        else
                        {
                            dtALMTestDetails.Clear();
                        }
                        List TSSetFields = tsTestFactory.Fields;
                        while (testListEnum.MoveNext())
                        {
                            DataRow drTestDetails = dtALMTestDetails.NewRow();
                            object item = testListEnum.Current;
                            TSTest atest = (TSTest)testListEnum.Current;

                            drTestDetails["TestName"] = atest.TestName;
                            drTestDetails["Status"] = atest.Status;
                            drTestDetails["FailureReason"] = atest["TC_USER_01"];
                            drTestDetails["JenkinsLog"] = atest["TC_USER_09"];

                            dtALMTestDetails.Rows.Add(drTestDetails);
                        }
                    }

                    dgvALM.DataSource = dtALMTestDetails;
                }
                else
                {
                    dtALMTestDetails.Clear();
                    dgvALM.DataSource = dtALMTestDetails;
                }
            }
            else
            {
                dtALMTestDetails.Clear();
                dgvALM.DataSource = dtALMTestDetails;
            }
            Cursor.Current = Cursors.Default;
        }

        private void treeViewALM_AfterCheck(object sender, TreeViewEventArgs e)
        {
            foreach (TreeNode Node in e.Node.Nodes)
            {
                Node.Checked = e.Node.Checked;
            }
        }

        private void btnUploadALM_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            bool check = false;

            foreach (DataGridViewRow Row in dgvALM.Rows)
            {
                if (Row.Cells[0].Value != null && Row.Cells[0].Value.ToString().ToLower() == "true")
                {
                    UploadALM(Row.Cells[1].Value.ToString(), Row.Cells[2].Value.ToString(), Row.Cells[3].Value.ToString(), Row.Cells[4].Value.ToString());
                    check = true;
                }
            }

            if (check)
                MessageBox.Show("ALM Uploaed Succeeded!", "Message");
            else
                MessageBox.Show("Please select a test case to upload!", "Message");

            Cursor.Current = Cursors.Default;

        }
        #endregion

        #region ALM Access Methods

        private string BuildPath(TreeNode treenode)
        {
            string rootfullpath = txtQCFolderPath.Text;
            string treepath = treenode.FullPath;

            string[] pathList = treepath.Split('\\');

            for (var i = 0; i < pathList.Length - 1; i++)
            {
                if (!txtQCFolderPath.Text.Contains(pathList[i]))
                    rootfullpath = rootfullpath + "\\" + pathList[i];
            }
            return rootfullpath;

        }

        private void showTestLabTree()
        {
            TestSetTreeManager testSetTreeMgr = (TestSetTreeManager)conn.TestSetTreeManager;
            TestSetFolder rootTestSetFolder = (TestSetFolder)testSetTreeMgr.get_NodeByPath(txtQCFolderPath.Text);
            TreeNode rootThreadNode = new TreeNode();

            rootThreadNode.Tag = "rootfolder";
            rootThreadNode.Text = rootThreadNode.ToolTipText = rootTestSetFolder.Name;
            treeViewALM.Nodes.Add(rootThreadNode);
            progressBar1.Maximum = rootTestSetFolder.Count;
            progressBar1.PerformStep();

            for (int i = 1; i <= rootTestSetFolder.Count; i++)
            {
                TreeNode parentThreadNode = new TreeNode();
                SysTreeNode tNode = (SysTreeNode)rootTestSetFolder.get_Child(i);
                parentThreadNode.Name = parentThreadNode.Text = rootTestSetFolder.get_Child(i).Name;
                parentThreadNode.Tag = "testsetfolder";
                rootThreadNode.Nodes.Add(parentThreadNode);

                AddChildNodes(tNode, parentThreadNode);

                AddTestSetToNodes(parentThreadNode, tNode);

                progressBar1.PerformStep();
            }


            treeViewALM.ShowNodeToolTips = true;
            treeViewALM.TopNode.Expand();
        }

        private void AddChildNodes(SysTreeNode tNode, TreeNode node)
        {
            List tList = tNode.NewList();
            for (int i = 1; i <= tList.Count; i++)
            {
                TreeNode childNode = new TreeNode();
                SysTreeNode tNode1 = (SysTreeNode)tNode.get_Child(i);
                childNode.Tag = "testsetfolder";
                childNode.Name = childNode.Text = tNode1.Name;
                node.Nodes.Add(childNode);

                if (tNode1.Count > 0)
                {
                    AddChildNodes(tNode1, childNode);
                }
                else
                {
                    AddTestSetToNodes(childNode, tNode1);
                }
            }
        }

        private void AddTestSetToNodes(TreeNode childNode, SysTreeNode tNode1)
        {
            TestSetFolder tsF = ((TestSetFolder)tNode1);
            ListClass testSetList = (ListClass)((TestSetFactory)tsF.TestSetFactory).NewList(string.Empty);
            IEnumerator testSetListEnum = testSetList.GetEnumerator();

            while (testSetListEnum.MoveNext())
            {
                TestSet atestset = (TestSet)testSetListEnum.Current;
                TreeNode tN = new TreeNode();

                tN.Name = tN.Text = tN.ToolTipText = atestset.Name;
                tN.Tag = "testset";

                childNode.Nodes.Add(tN);
            }
        }

        private void connectToQC()
        {
            conn = new TDConnectionClass();
            conn.InitConnection(txtQCUrl.Text, txtQCDomName.Text, string.Empty);
            conn.ConnectProject(txtQCProjName.Text, txtQCUname.Text, txtQCPwd.Text);

        }

        private DataTable BuildDataTable()
        {
            DataTable dtTests = new DataTable();
            DataColumn dc1 = new DataColumn("TestName", Type.GetType("System.String"));
            DataColumn dc2 = new DataColumn("Status", Type.GetType("System.String"));
            DataColumn dc3 = new DataColumn("FailureReason", Type.GetType("System.String"));
            DataColumn dc4 = new DataColumn("JenkinsLog", Type.GetType("System.String"));

            dtTests.Columns.Add(dc1);
            dtTests.Columns.Add(dc2);
            dtTests.Columns.Add(dc3);
            dtTests.Columns.Add(dc4);

            return dtTests;
        }

        private void UploadALM(string strSelectedScriptName, string strStatus, string strFailureReason, string strJenkinsLog)
        {
            string strSelectedTestSetName = treeViewALM.SelectedNode.Name;

            string strSelectedTestSetFullPath = BuildPath(treeViewALM.SelectedNode); ;
            TestSetTreeManager testSetTreeMgr = (TestSetTreeManager)conn.TestSetTreeManager;
            TestSetFolder rootTestSetFolder = (TestSetFolder)testSetTreeMgr.get_NodeByPath(strSelectedTestSetFullPath);
            List testSetList = rootTestSetFolder.FindTestSets(strSelectedTestSetName, false, string.Empty);
            IEnumerator enumerator = testSetList.GetEnumerator(); ;

            if (enumerator.MoveNext())
            {
                TestSet testSet = (TestSet)enumerator.Current;
                TSTestFactory tsTestFactory = (TSTestFactory)testSet.TSTestFactory;
                ListClass testList = (ListClass)tsTestFactory.NewList(string.Empty);

                IEnumerator testListEnum = testList.GetEnumerator();
                while (testListEnum.MoveNext())
                {
                    object item = testListEnum.Current;
                    TSTest atest = (TSTest)testListEnum.Current;
                    if (atest.TestName.ToLower() == strSelectedScriptName.ToLower())
                    {
                        atest.Status = strStatus;
                        atest["TC_USER_01"] = strFailureReason;
                        atest["TC_USER_09"] = strJenkinsLog;
                        atest.Post();
                    }
                }
            }



        }
        #endregion

        #region Jenkins Access Events

        private void btnConnectJenkins_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            username = txtUserName.Text;
            password = txtPasswpord.Text;

            btnConnectJenkins.Enabled = false;
            dgvJenkins.AutoGenerateColumns = false;
            progressBar2.Value = 0;
            joblist = new List<string>();
            JenkinServers = new Dictionary<string, List<string>>();
            spreadsheetsService = new SpreadsheetsService("AlmJenkinsIntegration");

            if (txtUserName.Text.Contains("ngahr"))
            {
                //oAuth2();
                NGAMail();
            }
            else
            {
                oAuth2();
                //spreadsheetsService.setUserCredentials(txtUserName.Text, txtPasswpord.Text);
            }

            //Passing Spreadsheet Name
            SpreadsheetQuery spreadsheetQuery = new SpreadsheetQuery();
            spreadsheetQuery.Title = txtSpreadSheetName.Text;
            spreadsheetFeed = spreadsheetsService.Query(spreadsheetQuery);

            if (spreadsheetFeed.Entries.Count != 1)
            {
                MessageBox.Show("Invallid Spreadsheet Name!");
                btnConnectJenkins.Enabled = true;
                return;
            }

            AtomLink link = spreadsheetFeed.Entries[0].Links.FindService(GDataSpreadsheetsNameTable.WorksheetRel, null);
            WorksheetQuery worksheetQuery = new WorksheetQuery(link.HRef.ToString());

            //Passing Worksheet Name
            worksheetQuery.Title = txtWorkSheetName.Text;
            worksheetFeed = spreadsheetsService.Query(worksheetQuery);
            if (worksheetFeed.Entries.Count != 1)
            {
                MessageBox.Show("Invallid Worksheet Name!");
                btnConnectJenkins.Enabled = true;
                return;
            }

            UpdateListFeed();


            // define the table's schema
            dtJenkinsTestDetails = new DataTable();
            dtJenkinsTestDetails.Columns.Add(new DataColumn("TestName", typeof(string)));
            dtJenkinsTestDetails.Columns.Add(new DataColumn("Result", typeof(string)));
            dtJenkinsTestDetails.Columns.Add(new DataColumn("JenkinsLog", typeof(string)));
            dtJenkinsTestDetails.Columns.Add(new DataColumn("ALM", typeof(string)));

            foreach (ListEntry worksheetRow in listFeed.Entries)
            {
                string serverName = worksheetRow.Elements[0].Value.ToString();

                if (serverName != string.Empty && serverName.ToLower() != "server" && !JenkinServers.ContainsKey(serverName))
                    JenkinServers.Add(serverName, GetInnerJobs(serverName, listFeed.Entries));

                DataRow dr = dtJenkinsTestDetails.NewRow();
                dr["TestName"] = worksheetRow.Elements[3].Value.ToString();
                dr["Result"] = worksheetRow.Elements[4].Value.ToString();
                dr["JenkinsLog"] = worksheetRow.Elements[6].Value.ToString();
                dr["ALM"] = worksheetRow.Elements[7].Value.ToString();

                dtJenkinsTestDetails.Rows.Add(dr);
            }

            progressBar2.Maximum = JenkinServers.Count;
            progressBar2.PerformStep();

            BuildJenkinsTree();

            dgvJenkins.DataSource = dtJenkinsTestDetails;
            lblTestsCount.Text = dtJenkinsTestDetails.Rows.Count.ToString();
            lblJobTitle.Text = string.Empty;
            DgvFilterManager filterManager = new DgvFilterManager(dgvJenkins, true);

            btnConnectJenkins.Enabled = true;
            Cursor.Current = Cursors.Default;
        }

        private void btnUpdateALM_Click(object sender, EventArgs e)
        {

            if (jenkinsCheckedNodeCount == 0)
            {
                MessageBox.Show("There are no items selected to update ALM!", "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                //Assign Job node text value to  python parameter "jobname"
                if (treeViewJenkins != null && treeViewJenkins.SelectedNode != null && treeViewJenkins.SelectedNode.Nodes.Count == 0)
                {
                    jobname = treeViewJenkins.SelectedNode.Text; //.Replace(' ', '_');
                    //if (!joblist.Contains(jobname)) joblist.Add(jobname);

                    if (treeViewJenkins.SelectedNode.Checked)
                    {
                        if (!joblist.Contains(jobname)) joblist.Add(jobname);
                    }
                    else
                    {
                        if (joblist.Contains(jobname)) joblist.Remove(jobname);
                    }

                    jenkins_server = getJenkinsBaseURL(treeViewJenkins.SelectedNode.Parent.Text);
                }

                //Serial Execution of Jobs on Python Shell
                /*
                string strjoblist = string.Empty;
                foreach (string job in joblist)
                {
                    strjoblist = strjoblist + job + ",";
                }
                strjoblist = strjoblist.Remove(strjoblist.Length - 1);

                var param = string.Format("{0} {1} {2} {3} {4} {5} {6} {7} {8} {9} {10} {11} {12} {13}",
                                            cmd, username, password, jenkins_server, strjoblist,
                                            txtQCUrl.Text, txtQCUname.Text, txtQCPwd.Text, txtQCDomName.Text, txtQCProjName.Text,
                                            txtQCFolderPath.Text, txtSpreadSheetName.Text, txtWorkSheetName.Text, txtBatchJobName.Text);
                Process.Start("cmd.exe", "/k " + Environment.CurrentDirectory + "\\PythonShell.exe " + param);
                */
                //jenkins_server = "http://dcb-v-scl-0002.user.arinso/";
                
                //Parallel Execution of Jobs on Python Shell
                foreach (string job in joblist)
                {
                    var param = string.Format("{0} {1} {2} {3} {4} {5} {6} {7} {8} {9} {10} {11} {12} {13}",
                                          cmd, username, password, jenkins_server, job,
                                          txtQCUrl.Text, txtQCUname.Text, txtQCPwd.Text, txtQCDomName.Text, txtQCProjName.Text,
                                          txtQCFolderPath.Text, txtSpreadSheetName.Text, txtWorkSheetName.Text, txtBatchJobName.Text);
                    Process.Start("cmd.exe", "/k " + Environment.CurrentDirectory + "\\PythonShell.exe " + param);
                    //Wait 3 sec to launch another python shell
                    Thread.Sleep(3000);
                }
            }
        }

        private void treeViewJenkins_AfterSelect(object sender, TreeViewEventArgs e)
        {
            RefreshJenkinsGrid(e.Node);
        }

        private void btnRefreshTable_Click(object sender, EventArgs e)
        {
            if (treeViewJenkins.Nodes.Count == 0)
            {
                MessageBox.Show("Pleasae select a Job from Jenkins Tree!", "ALM_Jenkins", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                RefreshJenkinsGrid(treeViewJenkins.SelectedNode);
            }
        }

        private void treeViewJenkins_AfterCheck(object sender, TreeViewEventArgs e)
        {
            foreach (TreeNode Node in e.Node.Nodes)
                Node.Checked = e.Node.Checked;

            //Assign Job node text value to  python parameter "jobname"
            if (e.Node.Nodes.Count == 0)
            {
                jobname = e.Node.Text; //.Replace(' ', '_');
                if (e.Node.Checked)
                {
                    if (!joblist.Contains(jobname)) joblist.Add(jobname);
                }
                else
                {
                    if (joblist.Contains(jobname)) joblist.Remove(jobname);
                }

                jenkins_server = getJenkinsBaseURL(e.Node.Parent.Text);
            }

            jenkinsCheckedNodeCount = CountCheckedNodes();
        }

        private void txtWorkSheetName_Leave(object sender, EventArgs e)
        {
            FormatWorkSheetName();
        }

        private void txtWorkSheetName_Validating(object sender, CancelEventArgs e)
        {
            if (txtWorkSheetName.Text.Length != 5)
            {
                var errorMessage = "Invalid Worksheet Name!";
                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(txtWorkSheetName, errorMessage);
                e.Cancel = true;
            }
        }

        private void txtWorkSheetName_Validated(object sender, EventArgs e)
        {
            // If all conditions have been met, clear the ErrorProvider of errors.
            this.errorProvider1.SetError(txtWorkSheetName, string.Empty);
        }

        private void txtBatchJobName_Validating(object sender, CancelEventArgs e)
        {
            var batchJobName = txtWorkSheetName.Text.Insert(3, "-");
            if (!txtBatchJobName.Text.StartsWith(batchJobName))
            {
                var errorMessage = "Batch Job name do not match with Work sheet name!";
                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(txtBatchJobName, errorMessage);
                e.Cancel = true;
            }
        }

        private void txtBatchJobName_Validated(object sender, EventArgs e)
        {
            // If all conditions have been met, clear the ErrorProvider of errors.
            this.errorProvider1.SetError(txtBatchJobName, string.Empty);
        }

        #endregion

        #region Jenkins Access Methods

        private void RefreshJenkinsGrid(TreeNode node)
        {
            Cursor.Current = Cursors.WaitCursor;

            if (node != null && node.Tag != null)
            {
                if (node.Tag.ToString().ToLower() == "jobs")
                {
                    UpdateListFeed();

                    Dictionary<string, List<string>> AllTests = new Dictionary<string, List<string>>();
                    AllTests = GetInnerTests(node.Text, listFeed.Entries);
                    string jobname = lblJobTitle.Text = node.Text;
                    List<string> testList = new List<string>();

                    dtJenkinsTestDetails.Clear();

                    foreach (var atest in AllTests)
                    {
                        AllTests.TryGetValue(atest.Key, out testList);
                        DataRow drTestDetails = dtJenkinsTestDetails.NewRow();

                        drTestDetails["TestName"] = atest.Key;
                        drTestDetails["Result"] = testList[0];
                        drTestDetails["JenkinsLog"] = testList[1];
                        drTestDetails["ALM"] = testList[2];

                        dtJenkinsTestDetails.Rows.Add(drTestDetails);
                    }

                    dgvJenkins.DataSource = dtJenkinsTestDetails;
                    lblTestsCount.Text = dtJenkinsTestDetails.Rows.Count.ToString();
                }
                else
                {
                    dtJenkinsTestDetails.Clear();
                    dgvJenkins.DataSource = dtJenkinsTestDetails;
                    lblTestsCount.Text = dtJenkinsTestDetails.Rows.Count.ToString();
                }
            }
            else
            {
                dtJenkinsTestDetails.Clear();
                dgvJenkins.DataSource = dtJenkinsTestDetails;
                lblTestsCount.Text = dtJenkinsTestDetails.Rows.Count.ToString();
            }
            Cursor.Current = Cursors.Default;
        }

        private void UpdateListFeed()
        {
            WorksheetEntry worksheet = (WorksheetEntry)worksheetFeed.Entries[0];
            AtomLink listFeedLink = worksheet.Links.FindService(GDataSpreadsheetsNameTable.ListRel, null);
            ListQuery listQuery = new ListQuery(listFeedLink.HRef.ToString());
            listFeed = spreadsheetsService.Query(listQuery);
        }

        private void BuildJenkinsTree()
        {
            treeViewJenkins.Nodes.Clear();
            TreeNode rootThreadNode = new TreeNode();
            rootThreadNode.Tag = rootThreadNode.Text = rootThreadNode.ToolTipText = "euHReka Jenkins Server";

            foreach (var server in JenkinServers)
            {
                TreeNode parentThreadNode = new TreeNode();
                parentThreadNode.Tag = parentThreadNode.Name = parentThreadNode.Text = server.Key;

                rootThreadNode.Nodes.Add(parentThreadNode);
                AddJobNodes(server.Value, parentThreadNode);
                progressBar2.PerformStep();
            }

            treeViewJenkins.Nodes.Add(rootThreadNode);
            treeViewJenkins.ShowNodeToolTips = true;
            treeViewJenkins.TopNode.Expand();
        }

        private void AddJobNodes(List<string> jobList, TreeNode node)
        {
            for (int i = 0; i < jobList.Count; i++)
            {
                TreeNode childNode = new TreeNode();

                childNode.Tag = "Jobs";
                childNode.Name = childNode.Text = jobList[i].ToString();

                node.Nodes.Add(childNode);
            }
        }

        private List<string> GetInnerJobs(string server, AtomEntryCollection worksheetRows)
        {
            List<string> JobList = new List<string>();
            foreach (ListEntry worksheetRow in worksheetRows)
            {
                string serverName = worksheetRow.Elements[0].Value.ToString();
                string jobName = worksheetRow.Elements[2].Value.ToString();

                if (serverName != string.Empty && serverName == server && !JobList.Contains(jobName))
                    JobList.Add(jobName);
            }
            return JobList;
        }

        private Dictionary<string, List<string>> GetInnerTests(string job, AtomEntryCollection worksheetRows)
        {
            Dictionary<string, List<string>> JenkinTests = new Dictionary<string, List<string>>();
            foreach (ListEntry worksheetRow in worksheetRows)
            {
                string jobname = worksheetRow.Elements[2].Value.ToString();
                string testname = worksheetRow.Elements[3].Value.ToString();
                string result = worksheetRow.Elements[4].Value.ToString();
                string jenkinslog = worksheetRow.Elements[6].Value.ToString();
                string alm = worksheetRow.Elements[7].Value.ToString();

                if (jobname != string.Empty && jobname == job && !JenkinTests.ContainsKey(testname))
                {
                    List<string> testDetails = new List<string>();

                    //testDetails.Add(testname);
                    testDetails.Add(result);
                    testDetails.Add(jenkinslog);
                    testDetails.Add(alm);

                    JenkinTests.Add(testname, testDetails);
                }
            }
            return JenkinTests;
        }

        private string getJenkinsBaseURL(string server)
        {
            //e.g. server = "DCB01";
            if (server.Length == 5 && server.Contains("DCB"))
            {
                string domain = server.Substring(0, 3);
                string serverNo = "00" + server.Substring(3, 2);
                //return string.Format("http://{0}-v-scl-{1}.user.arinso/jenkins/", domain.ToLower(), serverNo);
                return string.Format("http://{0}-v-scl-{1}.user.arinso/", domain.ToLower(), serverNo);
            }
            else if (server.Length == 5 && server.Contains("DCA"))
            {
                string domain = server.Substring(0, 3);
                string serverNo = "00" + server.Substring(3, 2);
                //return string.Format("http://{0}-v-qtp-{1}.user.arinso:8080/", domain.ToLower(), serverNo);
                return string.Format("http://{0}-v-qtp-{1}.user.arinso/", domain.ToLower(), serverNo);
            }
            else
            { return "Invalid server Name!"; }

        }

        private bool HasCheckedChildNodes(TreeNode node)
        {
            // Returns a value indicating whether the specified  
            // TreeNode has checked child nodes. 
            if (node.Nodes.Count == 0) return false;

            foreach (TreeNode childNode in node.Nodes)
            {
                if (childNode.Checked) return true;
                // Recursively check the children of the current child node. 
                if (HasCheckedChildNodes(childNode)) return true;
            }
            return false;
        }

        public int CountCheckedNodes()
        {
            int countIndex = 0;
            foreach (TreeNode serverNode in treeViewJenkins.Nodes[0].Nodes)
            {
                // Check whether the tree node is checked. 
                if (serverNode.Checked)
                {
                    serverNode.BackColor = Color.Yellow;
                    countIndex++;
                }
                else
                    serverNode.BackColor = Color.White;

                foreach (TreeNode jobNode in serverNode.Nodes)
                {
                    if (jobNode.Checked)
                    {
                        jobNode.BackColor = Color.Yellow;
                        countIndex++;
                    }
                    else
                        jobNode.BackColor = Color.White;

                }
            }

            return countIndex;
            //return (countIndex > 0);
        }

        private void oAuth2()
        {
            //euHReka
            string keyFilePath = Path.Combine(Environment.CurrentDirectory, @"..\..\Key.p12");// found in developer console
            //string keyFilePath = @"D:\PEX\PEX_ALM_JENKINS_INTEGRATION\ALM_JENKINS_INTEGRATION\Key.p12";    // found in developer console
            string serviceAccountEmail = "284081438460-7e7i3em23apiehkd7bj8dit3703eirqs@developer.gserviceaccount.com";   // found in developer console
            var certificate = new X509Certificate2(keyFilePath, "notasecret", X509KeyStorageFlags.Exportable);

            //create credential using certificate
            ServiceAccountCredential credential = new ServiceAccountCredential(new ServiceAccountCredential.Initializer(serviceAccountEmail)
            {
                Scopes = new[] { "https://spreadsheets.google.com/feeds/" } //this scopr is for spreadsheets, check google scope FAQ for others
            }.FromCertificate(certificate));

            credential.RequestAccessTokenAsync(System.Threading.CancellationToken.None).Wait(); //request token

            var requestFactory = new GDataRequestFactory("AlmJenkinsIntegration");
            requestFactory.CustomHeaders.Add(string.Format("Authorization: Bearer {0}", credential.Token.AccessToken));
            spreadsheetsService.RequestFactory = requestFactory; //add new request factory to your old service
        }

        private void NGAMail()
        {
            //One time Initialization across the entire session required
            //if (authorizationUrl == null || authorizationUrl == string.Empty)
            //{
                string CLIENT_ID = "284081438460-sdg3dn9tt80huceeb9v4n833n97lmtlu.apps.googleusercontent.com";
                string CLIENT_SECRET = "HNb2txJ2QpK0amd4IR7HAxZK";
                string SCOPE = "https://spreadsheets.google.com/feeds";
                string REDIRECT_URI = "urn:ietf:wg:oauth:2.0:oob";
                OAuth2Parameters parameters = new OAuth2Parameters();
                parameters.ClientId = CLIENT_ID;
                parameters.ClientSecret = CLIENT_SECRET;
                parameters.RedirectUri = REDIRECT_URI;
                parameters.Scope = SCOPE;
                authorizationUrl = OAuthUtil.CreateOAuth2AuthorizationUrl(parameters);

                if (InputBox("AccessCode", "Input AccessCode from Browser", ref authorizationUrl) == DialogResult.OK)
                {
                    parameters.AccessCode = authorizationUrl;
                }
                else
                {
                    MessageBox.Show("Invallid Access Code!");
                    btnConnectJenkins.Enabled = true;
                    return;
                }

                OAuthUtil.GetAccessToken(parameters);
                GOAuth2RequestFactory requestFactory = new GOAuth2RequestFactory(null, "AlmJenkinsIntegration", parameters);
                spreadsheetsService.RequestFactory = requestFactory;
            //}

        }

        public static DialogResult InputBox(string title, string promptText, ref string value)
        {
            Form form = new Form();
            Label label = new Label();
            TextBox textBox = new TextBox();
            Button buttonOk = new Button();
            Button buttonCancel = new Button();

            form.Text = title;
            label.Text = promptText;
            textBox.Text = value;

            buttonOk.Text = "OK";
            buttonCancel.Text = "Cancel";
            buttonOk.DialogResult = DialogResult.OK;
            buttonCancel.DialogResult = DialogResult.Cancel;

            label.SetBounds(9, 20, 372, 13);
            textBox.SetBounds(12, 36, 372, 20);
            buttonOk.SetBounds(228, 72, 75, 23);
            buttonCancel.SetBounds(309, 72, 75, 23);

            label.AutoSize = true;
            textBox.Anchor = textBox.Anchor | AnchorStyles.Right;
            buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            form.ClientSize = new Size(396, 107);
            form.Controls.AddRange(new Control[] { label, textBox, buttonOk, buttonCancel });
            form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = buttonOk;
            form.CancelButton = buttonCancel;

            DialogResult dialogResult = form.ShowDialog();
            value = textBox.Text;
            return dialogResult;
        }

        private void FormatWorkSheetName()
        {
            if (txtWorkSheetName.Text.Length == 5)
            {
                var batchJobName = txtWorkSheetName.Text.Insert(3, "-");
                txtBatchJobName.Text = txtBatchJobName.Text.Replace(txtBatchJobName.Text.Substring(0, 6), batchJobName);
            }

        }
        #endregion

    }
}
