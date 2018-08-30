namespace ALMJENKINS
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnConnectALM = new System.Windows.Forms.Button();
            this.treeViewALM = new System.Windows.Forms.TreeView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblQCUrl = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.lblPwd = new System.Windows.Forms.Label();
            this.lblProjName = new System.Windows.Forms.Label();
            this.lblDomName = new System.Windows.Forms.Label();
            this.txtQCUrl = new System.Windows.Forms.TextBox();
            this.txtQCUname = new System.Windows.Forms.TextBox();
            this.txtQCPwd = new System.Windows.Forms.TextBox();
            this.txtQCDomName = new System.Windows.Forms.TextBox();
            this.txtQCProjName = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.dgvALM = new System.Windows.Forms.DataGridView();
            this.Hired = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.TestName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.FailureReason = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.JenkinsLog = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.txtQCFolderPath = new System.Windows.Forms.TextBox();
            this.labFolderPath = new System.Windows.Forms.Label();
            this.lblALMHeader = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnUploadALM = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabJenkins = new System.Windows.Forms.TabPage();
            this.lblJobTitle = new System.Windows.Forms.Label();
            this.lblJobName = new System.Windows.Forms.Label();
            this.lblTestsCount = new System.Windows.Forms.Label();
            this.lblNoOfTests = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnUpdateALM = new System.Windows.Forms.Button();
            this.treeViewJenkins = new System.Windows.Forms.TreeView();
            this.btnConnectJenkins = new System.Windows.Forms.Button();
            this.panel6 = new System.Windows.Forms.Panel();
            this.lblBatchJobName = new System.Windows.Forms.Label();
            this.txtBatchJobName = new System.Windows.Forms.TextBox();
            this.lblSpreadSheetName = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSpreadSheetName = new System.Windows.Forms.TextBox();
            this.txtWorkSheetName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lbPasswordJenkins = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtPasswpord = new System.Windows.Forms.TextBox();
            this.panel7 = new System.Windows.Forms.Panel();
            this.btnRefreshTable = new System.Windows.Forms.Button();
            this.panel8 = new System.Windows.Forms.Panel();
            this.lalJenkins = new System.Windows.Forms.Label();
            this.progressBar2 = new System.Windows.Forms.ProgressBar();
            this.lblJenkinsHeader = new System.Windows.Forms.Label();
            this.dgvJenkins = new System.Windows.Forms.DataGridView();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.TestName1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Result = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.JenkinsLog1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ALM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabALM = new System.Windows.Forms.TabPage();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvALM)).BeginInit();
            this.panel3.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabJenkins.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvJenkins)).BeginInit();
            this.tabALM.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnConnectALM
            // 
            this.btnConnectALM.Location = new System.Drawing.Point(338, 141);
            this.btnConnectALM.Name = "btnConnectALM";
            this.btnConnectALM.Size = new System.Drawing.Size(96, 23);
            this.btnConnectALM.TabIndex = 0;
            this.btnConnectALM.Text = "Connect ALM";
            this.btnConnectALM.UseVisualStyleBackColor = true;
            this.btnConnectALM.Click += new System.EventHandler(this.btnConnectQc_Click);
            // 
            // treeViewALM
            // 
            this.treeViewALM.BackColor = System.Drawing.SystemColors.MenuBar;
            this.treeViewALM.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.treeViewALM.CheckBoxes = true;
            this.treeViewALM.Location = new System.Drawing.Point(7, 22);
            this.treeViewALM.Name = "treeViewALM";
            this.treeViewALM.Size = new System.Drawing.Size(312, 626);
            this.treeViewALM.TabIndex = 1;
            this.treeViewALM.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.treeViewALM_AfterCheck);
            this.treeViewALM.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewALM_AfterSelect);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(330, 131);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(692, 1);
            this.panel1.TabIndex = 3;
            // 
            // lblQCUrl
            // 
            this.lblQCUrl.AutoSize = true;
            this.lblQCUrl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQCUrl.Location = new System.Drawing.Point(38, 10);
            this.lblQCUrl.Name = "lblQCUrl";
            this.lblQCUrl.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblQCUrl.Size = new System.Drawing.Size(43, 13);
            this.lblQCUrl.TabIndex = 4;
            this.lblQCUrl.Text = "Qc Url";
            this.lblQCUrl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserName.Location = new System.Drawing.Point(385, 33);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblUserName.Size = new System.Drawing.Size(65, 13);
            this.lblUserName.TabIndex = 5;
            this.lblUserName.Text = "UserName";
            this.lblUserName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblPwd
            // 
            this.lblPwd.AutoSize = true;
            this.lblPwd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPwd.Location = new System.Drawing.Point(389, 55);
            this.lblPwd.Name = "lblPwd";
            this.lblPwd.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblPwd.Size = new System.Drawing.Size(61, 13);
            this.lblPwd.TabIndex = 6;
            this.lblPwd.Text = "Password";
            this.lblPwd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblProjName
            // 
            this.lblProjName.AutoSize = true;
            this.lblProjName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProjName.Location = new System.Drawing.Point(370, 11);
            this.lblProjName.Name = "lblProjName";
            this.lblProjName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblProjName.Size = new System.Drawing.Size(83, 13);
            this.lblProjName.TabIndex = 7;
            this.lblProjName.Text = "Project Name";
            this.lblProjName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDomName
            // 
            this.lblDomName.AutoSize = true;
            this.lblDomName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDomName.Location = new System.Drawing.Point(1, 59);
            this.lblDomName.Name = "lblDomName";
            this.lblDomName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblDomName.Size = new System.Drawing.Size(85, 13);
            this.lblDomName.TabIndex = 8;
            this.lblDomName.Text = "Domain Name";
            this.lblDomName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtQCUrl
            // 
            this.txtQCUrl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtQCUrl.Location = new System.Drawing.Point(88, 6);
            this.txtQCUrl.Name = "txtQCUrl";
            this.txtQCUrl.Size = new System.Drawing.Size(279, 20);
            this.txtQCUrl.TabIndex = 9;
            this.txtQCUrl.Text = "http://entqcpci01.northgatearinso.erp:8080/qcbin/";
            // 
            // txtQCUname
            // 
            this.txtQCUname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtQCUname.Location = new System.Drawing.Point(455, 30);
            this.txtQCUname.Name = "txtQCUname";
            this.txtQCUname.Size = new System.Drawing.Size(124, 20);
            this.txtQCUname.TabIndex = 10;
            this.txtQCUname.Text = "mohankumarp";
            // 
            // txtQCPwd
            // 
            this.txtQCPwd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtQCPwd.Location = new System.Drawing.Point(455, 53);
            this.txtQCPwd.Name = "txtQCPwd";
            this.txtQCPwd.PasswordChar = '*';
            this.txtQCPwd.Size = new System.Drawing.Size(124, 20);
            this.txtQCPwd.TabIndex = 11;
            this.txtQCPwd.Text = "test";
            // 
            // txtQCDomName
            // 
            this.txtQCDomName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtQCDomName.Location = new System.Drawing.Point(88, 54);
            this.txtQCDomName.Name = "txtQCDomName";
            this.txtQCDomName.Size = new System.Drawing.Size(279, 20);
            this.txtQCDomName.TabIndex = 12;
            this.txtQCDomName.Text = "CORE_PRODUCTS";
            // 
            // txtQCProjName
            // 
            this.txtQCProjName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtQCProjName.Location = new System.Drawing.Point(455, 8);
            this.txtQCProjName.Name = "txtQCProjName";
            this.txtQCProjName.Size = new System.Drawing.Size(124, 20);
            this.txtQCProjName.TabIndex = 13;
            this.txtQCProjName.Text = "euHReka";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Location = new System.Drawing.Point(327, 1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1, 640);
            this.panel2.TabIndex = 14;
            // 
            // progressBar1
            // 
            this.progressBar1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.progressBar1.Location = new System.Drawing.Point(442, 141);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(579, 23);
            this.progressBar1.Step = 1;
            this.progressBar1.TabIndex = 15;
            // 
            // dgvALM
            // 
            this.dgvALM.AllowUserToAddRows = false;
            this.dgvALM.AllowUserToDeleteRows = false;
            this.dgvALM.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Hired,
            this.TestName,
            this.Status,
            this.FailureReason,
            this.JenkinsLog});
            this.dgvALM.Location = new System.Drawing.Point(336, 176);
            this.dgvALM.Name = "dgvALM";
            this.dgvALM.Size = new System.Drawing.Size(984, 472);
            this.dgvALM.TabIndex = 18;
            // 
            // Hired
            // 
            this.Hired.HeaderText = "";
            this.Hired.Name = "Hired";
            this.Hired.Width = 25;
            // 
            // TestName
            // 
            this.TestName.DataPropertyName = "TestName";
            this.TestName.FillWeight = 11.27977F;
            this.TestName.HeaderText = "TestName";
            this.TestName.Name = "TestName";
            this.TestName.ReadOnly = true;
            this.TestName.Width = 300;
            // 
            // Status
            // 
            this.Status.DataPropertyName = "Status";
            this.Status.FillWeight = 11.27977F;
            this.Status.HeaderText = "Status";
            this.Status.Items.AddRange(new object[] {
            "Blocked",
            "Failed",
            "N/A",
            "No Run",
            "Not Completed",
            "Pass with Fix",
            "Passed"});
            this.Status.Name = "Status";
            this.Status.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Status.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Status.Width = 80;
            // 
            // FailureReason
            // 
            this.FailureReason.DataPropertyName = "FailureReason";
            this.FailureReason.FillWeight = 23.25581F;
            this.FailureReason.HeaderText = "FailureReason";
            this.FailureReason.Items.AddRange(new object[] {
            "Application Defect",
            "Application UI Change",
            "Auto log off issue",
            "Automation Framework Error",
            "Data Error",
            "eWS System Error",
            "Script Error",
            "Synchronization/Timing issue"});
            this.FailureReason.Name = "FailureReason";
            this.FailureReason.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.FailureReason.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.FailureReason.Width = 150;
            // 
            // JenkinsLog
            // 
            this.JenkinsLog.DataPropertyName = "JenkinsLog";
            this.JenkinsLog.FillWeight = 354.1847F;
            this.JenkinsLog.HeaderText = "JenkinsLog";
            this.JenkinsLog.Name = "JenkinsLog";
            this.JenkinsLog.Width = 500;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(663, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 19;
            this.button1.Text = "Test Bpt";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(0, 0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 0;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(0, 0);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 0;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(0, 0);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 0;
            // 
            // txtQCFolderPath
            // 
            this.txtQCFolderPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtQCFolderPath.Location = new System.Drawing.Point(88, 30);
            this.txtQCFolderPath.Name = "txtQCFolderPath";
            this.txtQCFolderPath.Size = new System.Drawing.Size(279, 20);
            this.txtQCFolderPath.TabIndex = 20;
            this.txtQCFolderPath.Text = "Root\\EuHReka\\Version19\\EOD\\06_Regression_Testing_Automation\\Cycle_01";
            // 
            // labFolderPath
            // 
            this.labFolderPath.AutoSize = true;
            this.labFolderPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labFolderPath.Location = new System.Drawing.Point(13, 31);
            this.labFolderPath.Name = "labFolderPath";
            this.labFolderPath.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.labFolderPath.Size = new System.Drawing.Size(72, 13);
            this.labFolderPath.TabIndex = 19;
            this.labFolderPath.Text = "Folder Path";
            this.labFolderPath.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblALMHeader
            // 
            this.lblALMHeader.AutoSize = true;
            this.lblALMHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblALMHeader.Location = new System.Drawing.Point(632, 8);
            this.lblALMHeader.Name = "lblALMHeader";
            this.lblALMHeader.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblALMHeader.Size = new System.Drawing.Size(280, 18);
            this.lblALMHeader.TabIndex = 21;
            this.lblALMHeader.Text = "euHReka Patch Regression Support";
            this.lblALMHeader.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 6);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 22;
            this.label1.Text = "ALM Tree";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnUploadALM
            // 
            this.btnUploadALM.Location = new System.Drawing.Point(824, 651);
            this.btnUploadALM.Name = "btnUploadALM";
            this.btnUploadALM.Size = new System.Drawing.Size(114, 28);
            this.btnUploadALM.TabIndex = 23;
            this.btnUploadALM.Text = "Update ALM";
            this.btnUploadALM.UseVisualStyleBackColor = true;
            this.btnUploadALM.Click += new System.EventHandler(this.btnUploadALM_Click);
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.txtQCUrl);
            this.panel3.Controls.Add(this.lblQCUrl);
            this.panel3.Controls.Add(this.lblUserName);
            this.panel3.Controls.Add(this.lblPwd);
            this.panel3.Controls.Add(this.txtQCFolderPath);
            this.panel3.Controls.Add(this.lblProjName);
            this.panel3.Controls.Add(this.labFolderPath);
            this.panel3.Controls.Add(this.lblDomName);
            this.panel3.Controls.Add(this.txtQCUname);
            this.panel3.Controls.Add(this.txtQCPwd);
            this.panel3.Controls.Add(this.txtQCDomName);
            this.panel3.Controls.Add(this.txtQCProjName);
            this.panel3.Location = new System.Drawing.Point(347, 38);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(591, 79);
            this.panel3.TabIndex = 24;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabJenkins);
            this.tabControl1.Controls.Add(this.tabALM);
            this.tabControl1.Location = new System.Drawing.Point(1, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1337, 740);
            this.tabControl1.TabIndex = 26;
            // 
            // tabJenkins
            // 
            this.tabJenkins.BackColor = System.Drawing.Color.LightGray;
            this.tabJenkins.Controls.Add(this.lblJobTitle);
            this.tabJenkins.Controls.Add(this.lblJobName);
            this.tabJenkins.Controls.Add(this.lblTestsCount);
            this.tabJenkins.Controls.Add(this.lblNoOfTests);
            this.tabJenkins.Controls.Add(this.pictureBox2);
            this.tabJenkins.Controls.Add(this.btnUpdateALM);
            this.tabJenkins.Controls.Add(this.treeViewJenkins);
            this.tabJenkins.Controls.Add(this.btnConnectJenkins);
            this.tabJenkins.Controls.Add(this.panel6);
            this.tabJenkins.Controls.Add(this.panel7);
            this.tabJenkins.Controls.Add(this.btnRefreshTable);
            this.tabJenkins.Controls.Add(this.panel8);
            this.tabJenkins.Controls.Add(this.lalJenkins);
            this.tabJenkins.Controls.Add(this.progressBar2);
            this.tabJenkins.Controls.Add(this.lblJenkinsHeader);
            this.tabJenkins.Controls.Add(this.dgvJenkins);
            this.tabJenkins.Location = new System.Drawing.Point(4, 22);
            this.tabJenkins.Name = "tabJenkins";
            this.tabJenkins.Padding = new System.Windows.Forms.Padding(3);
            this.tabJenkins.Size = new System.Drawing.Size(1329, 714);
            this.tabJenkins.TabIndex = 1;
            this.tabJenkins.Text = "Jenkins";
            // 
            // lblJobTitle
            // 
            this.lblJobTitle.AutoSize = true;
            this.lblJobTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJobTitle.Location = new System.Drawing.Point(677, 654);
            this.lblJobTitle.Name = "lblJobTitle";
            this.lblJobTitle.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblJobTitle.Size = new System.Drawing.Size(0, 13);
            this.lblJobTitle.TabIndex = 40;
            this.lblJobTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblJobName
            // 
            this.lblJobName.AutoSize = true;
            this.lblJobName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJobName.Location = new System.Drawing.Point(598, 654);
            this.lblJobName.Name = "lblJobName";
            this.lblJobName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblJobName.Size = new System.Drawing.Size(56, 13);
            this.lblJobName.TabIndex = 39;
            this.lblJobName.Text = "Of Job : ";
            this.lblJobName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTestsCount
            // 
            this.lblTestsCount.AutoSize = true;
            this.lblTestsCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTestsCount.Location = new System.Drawing.Point(567, 654);
            this.lblTestsCount.Name = "lblTestsCount";
            this.lblTestsCount.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblTestsCount.Size = new System.Drawing.Size(14, 13);
            this.lblTestsCount.TabIndex = 38;
            this.lblTestsCount.Text = "0";
            this.lblTestsCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblNoOfTests
            // 
            this.lblNoOfTests.AutoSize = true;
            this.lblNoOfTests.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoOfTests.Location = new System.Drawing.Point(439, 654);
            this.lblNoOfTests.Name = "lblNoOfTests";
            this.lblNoOfTests.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblNoOfTests.Size = new System.Drawing.Size(126, 13);
            this.lblNoOfTests.TabIndex = 37;
            this.lblNoOfTests.Text = "No Of Tests Found : ";
            this.lblNoOfTests.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::ALMJENKINS.Properties.Resources.NGA_Logo;
            this.pictureBox2.Location = new System.Drawing.Point(1110, 39);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(78, 76);
            this.pictureBox2.TabIndex = 36;
            this.pictureBox2.TabStop = false;
            // 
            // btnUpdateALM
            // 
            this.btnUpdateALM.Location = new System.Drawing.Point(137, 646);
            this.btnUpdateALM.Name = "btnUpdateALM";
            this.btnUpdateALM.Size = new System.Drawing.Size(114, 28);
            this.btnUpdateALM.TabIndex = 24;
            this.btnUpdateALM.Text = "Update ALM";
            this.btnUpdateALM.UseVisualStyleBackColor = true;
            this.btnUpdateALM.Click += new System.EventHandler(this.btnUpdateALM_Click);
            // 
            // treeViewJenkins
            // 
            this.treeViewJenkins.BackColor = System.Drawing.SystemColors.MenuBar;
            this.treeViewJenkins.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.treeViewJenkins.CheckBoxes = true;
            this.treeViewJenkins.Location = new System.Drawing.Point(6, 26);
            this.treeViewJenkins.Name = "treeViewJenkins";
            this.treeViewJenkins.Size = new System.Drawing.Size(419, 617);
            this.treeViewJenkins.TabIndex = 27;
            this.treeViewJenkins.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.treeViewJenkins_AfterCheck);
            this.treeViewJenkins.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewJenkins_AfterSelect);
            // 
            // btnConnectJenkins
            // 
            this.btnConnectJenkins.Location = new System.Drawing.Point(442, 129);
            this.btnConnectJenkins.Name = "btnConnectJenkins";
            this.btnConnectJenkins.Size = new System.Drawing.Size(104, 26);
            this.btnConnectJenkins.TabIndex = 26;
            this.btnConnectJenkins.Text = "Load Data";
            this.btnConnectJenkins.UseVisualStyleBackColor = true;
            this.btnConnectJenkins.Click += new System.EventHandler(this.btnConnectJenkins_Click);
            // 
            // panel6
            // 
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Controls.Add(this.lblBatchJobName);
            this.panel6.Controls.Add(this.txtBatchJobName);
            this.panel6.Controls.Add(this.lblSpreadSheetName);
            this.panel6.Controls.Add(this.label3);
            this.panel6.Controls.Add(this.txtSpreadSheetName);
            this.panel6.Controls.Add(this.txtWorkSheetName);
            this.panel6.Controls.Add(this.label4);
            this.panel6.Controls.Add(this.lbPasswordJenkins);
            this.panel6.Controls.Add(this.txtUserName);
            this.panel6.Controls.Add(this.txtPasswpord);
            this.panel6.Location = new System.Drawing.Point(442, 40);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(662, 80);
            this.panel6.TabIndex = 35;
            // 
            // lblBatchJobName
            // 
            this.lblBatchJobName.AutoSize = true;
            this.lblBatchJobName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBatchJobName.Location = new System.Drawing.Point(328, 56);
            this.lblBatchJobName.Name = "lblBatchJobName";
            this.lblBatchJobName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblBatchJobName.Size = new System.Drawing.Size(100, 13);
            this.lblBatchJobName.TabIndex = 16;
            this.lblBatchJobName.Text = "Batch Job Name";
            this.lblBatchJobName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtBatchJobName
            // 
            this.txtBatchJobName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBatchJobName.Location = new System.Drawing.Point(445, 54);
            this.txtBatchJobName.Name = "txtBatchJobName";
            this.txtBatchJobName.Size = new System.Drawing.Size(195, 20);
            this.txtBatchJobName.TabIndex = 17;
            this.txtBatchJobName.Text = "DCB-01_EQ1-800_BatchRun";
            this.txtBatchJobName.Validating += new System.ComponentModel.CancelEventHandler(this.txtBatchJobName_Validating);
            this.txtBatchJobName.Validated += new System.EventHandler(this.txtBatchJobName_Validated);
            // 
            // lblSpreadSheetName
            // 
            this.lblSpreadSheetName.AutoSize = true;
            this.lblSpreadSheetName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSpreadSheetName.Location = new System.Drawing.Point(320, 10);
            this.lblSpreadSheetName.Name = "lblSpreadSheetName";
            this.lblSpreadSheetName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblSpreadSheetName.Size = new System.Drawing.Size(116, 13);
            this.lblSpreadSheetName.TabIndex = 12;
            this.lblSpreadSheetName.Text = "SpreadSheet Name";
            this.lblSpreadSheetName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(328, 33);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label3.Size = new System.Drawing.Size(106, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "WorkSheet Name";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtSpreadSheetName
            // 
            this.txtSpreadSheetName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSpreadSheetName.Location = new System.Drawing.Point(445, 8);
            this.txtSpreadSheetName.Name = "txtSpreadSheetName";
            this.txtSpreadSheetName.Size = new System.Drawing.Size(195, 20);
            this.txtSpreadSheetName.TabIndex = 14;
            this.txtSpreadSheetName.Text = "JenkinsLog_V19_EQC_800_Cycle_01";
            // 
            // txtWorkSheetName
            // 
            this.txtWorkSheetName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtWorkSheetName.Location = new System.Drawing.Point(445, 31);
            this.txtWorkSheetName.Name = "txtWorkSheetName";
            this.txtWorkSheetName.Size = new System.Drawing.Size(195, 20);
            this.txtWorkSheetName.TabIndex = 15;
            this.txtWorkSheetName.Text = "DCB01";
            this.txtWorkSheetName.Leave += new System.EventHandler(this.txtWorkSheetName_Leave);
            this.txtWorkSheetName.Validating += new System.ComponentModel.CancelEventHandler(this.txtWorkSheetName_Validating);
            this.txtWorkSheetName.Validated += new System.EventHandler(this.txtWorkSheetName_Validated);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(20, 10);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "UserName";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbPasswordJenkins
            // 
            this.lbPasswordJenkins.AutoSize = true;
            this.lbPasswordJenkins.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPasswordJenkins.Location = new System.Drawing.Point(24, 33);
            this.lbPasswordJenkins.Name = "lbPasswordJenkins";
            this.lbPasswordJenkins.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbPasswordJenkins.Size = new System.Drawing.Size(61, 13);
            this.lbPasswordJenkins.TabIndex = 6;
            this.lbPasswordJenkins.Text = "Password";
            this.lbPasswordJenkins.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtUserName
            // 
            this.txtUserName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUserName.Location = new System.Drawing.Point(92, 8);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(206, 20);
            this.txtUserName.TabIndex = 10;
            this.txtUserName.Text = "jenkinsalm@gmail.com";
            // 
            // txtPasswpord
            // 
            this.txtPasswpord.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPasswpord.Location = new System.Drawing.Point(92, 31);
            this.txtPasswpord.Name = "txtPasswpord";
            this.txtPasswpord.PasswordChar = '*';
            this.txtPasswpord.Size = new System.Drawing.Size(206, 20);
            this.txtPasswpord.TabIndex = 11;
            this.txtPasswpord.Text = "ews12345";
            // 
            // panel7
            // 
            this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel7.Location = new System.Drawing.Point(433, 126);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(672, 2);
            this.panel7.TabIndex = 28;
            // 
            // btnRefreshTable
            // 
            this.btnRefreshTable.Location = new System.Drawing.Point(1111, 128);
            this.btnRefreshTable.Name = "btnRefreshTable";
            this.btnRefreshTable.Size = new System.Drawing.Size(104, 26);
            this.btnRefreshTable.TabIndex = 34;
            this.btnRefreshTable.Text = "Refresh Table";
            this.btnRefreshTable.UseVisualStyleBackColor = true;
            this.btnRefreshTable.Click += new System.EventHandler(this.btnRefreshTable_Click);
            // 
            // panel8
            // 
            this.panel8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel8.Location = new System.Drawing.Point(431, 3);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(1, 644);
            this.panel8.TabIndex = 29;
            // 
            // lalJenkins
            // 
            this.lalJenkins.AutoSize = true;
            this.lalJenkins.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lalJenkins.Location = new System.Drawing.Point(9, 8);
            this.lalJenkins.Name = "lalJenkins";
            this.lalJenkins.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lalJenkins.Size = new System.Drawing.Size(80, 13);
            this.lalJenkins.TabIndex = 33;
            this.lalJenkins.Text = "Jenkins Tree";
            this.lalJenkins.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // progressBar2
            // 
            this.progressBar2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.progressBar2.Location = new System.Drawing.Point(559, 132);
            this.progressBar2.Name = "progressBar2";
            this.progressBar2.Size = new System.Drawing.Size(546, 23);
            this.progressBar2.Step = 1;
            this.progressBar2.TabIndex = 30;
            // 
            // lblJenkinsHeader
            // 
            this.lblJenkinsHeader.AutoSize = true;
            this.lblJenkinsHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJenkinsHeader.ForeColor = System.Drawing.Color.Navy;
            this.lblJenkinsHeader.Location = new System.Drawing.Point(600, 8);
            this.lblJenkinsHeader.Name = "lblJenkinsHeader";
            this.lblJenkinsHeader.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblJenkinsHeader.Size = new System.Drawing.Size(303, 18);
            this.lblJenkinsHeader.TabIndex = 32;
            this.lblJenkinsHeader.Text = "euHReka-Jenkins-ALM Integration Tool";
            this.lblJenkinsHeader.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dgvJenkins
            // 
            this.dgvJenkins.AllowUserToAddRows = false;
            this.dgvJenkins.AllowUserToDeleteRows = false;
            this.dgvJenkins.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewCheckBoxColumn1,
            this.TestName1,
            this.Result,
            this.JenkinsLog1,
            this.ALM});
            this.dgvJenkins.Location = new System.Drawing.Point(440, 165);
            this.dgvJenkins.Name = "dgvJenkins";
            this.dgvJenkins.Size = new System.Drawing.Size(877, 475);
            this.dgvJenkins.TabIndex = 31;
            // 
            // dataGridViewCheckBoxColumn1
            // 
            this.dataGridViewCheckBoxColumn1.HeaderText = "";
            this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            this.dataGridViewCheckBoxColumn1.Width = 25;
            // 
            // TestName1
            // 
            this.TestName1.DataPropertyName = "TestName";
            this.TestName1.HeaderText = "TestName";
            this.TestName1.Name = "TestName1";
            this.TestName1.Width = 400;
            // 
            // Result
            // 
            this.Result.DataPropertyName = "Result";
            this.Result.HeaderText = "Result";
            this.Result.Name = "Result";
            this.Result.Width = 70;
            // 
            // JenkinsLog1
            // 
            this.JenkinsLog1.DataPropertyName = "JenkinsLog";
            this.JenkinsLog1.HeaderText = "JenkinsLog";
            this.JenkinsLog1.Name = "JenkinsLog1";
            this.JenkinsLog1.Width = 150;
            // 
            // ALM
            // 
            this.ALM.DataPropertyName = "ALM";
            this.ALM.HeaderText = "ALM";
            this.ALM.Name = "ALM";
            this.ALM.Width = 300;
            // 
            // tabALM
            // 
            this.tabALM.BackColor = System.Drawing.Color.LightGray;
            this.tabALM.Controls.Add(this.pictureBox1);
            this.tabALM.Controls.Add(this.treeViewALM);
            this.tabALM.Controls.Add(this.btnConnectALM);
            this.tabALM.Controls.Add(this.panel3);
            this.tabALM.Controls.Add(this.panel1);
            this.tabALM.Controls.Add(this.btnUploadALM);
            this.tabALM.Controls.Add(this.panel2);
            this.tabALM.Controls.Add(this.label1);
            this.tabALM.Controls.Add(this.progressBar1);
            this.tabALM.Controls.Add(this.lblALMHeader);
            this.tabALM.Controls.Add(this.dgvALM);
            this.tabALM.Location = new System.Drawing.Point(4, 22);
            this.tabALM.Name = "tabALM";
            this.tabALM.Padding = new System.Windows.Forms.Padding(3);
            this.tabALM.Size = new System.Drawing.Size(1329, 714);
            this.tabALM.TabIndex = 0;
            this.tabALM.Text = "ALM";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ALMJENKINS.Properties.Resources.NGA_Logo;
            this.pictureBox1.Location = new System.Drawing.Point(947, 38);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(78, 76);
            this.pictureBox1.TabIndex = 25;
            this.pictureBox1.TabStop = false;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1330, 721);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "euHReka ALM Update Tool";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvALM)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabJenkins.ResumeLayout(false);
            this.tabJenkins.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvJenkins)).EndInit();
            this.tabALM.ResumeLayout(false);
            this.tabALM.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnConnectALM;
        private System.Windows.Forms.TreeView treeViewALM;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblQCUrl;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label lblPwd;
        private System.Windows.Forms.Label lblProjName;
        private System.Windows.Forms.Label lblDomName;
        private System.Windows.Forms.TextBox txtQCUrl;
        private System.Windows.Forms.TextBox txtQCUname;
        private System.Windows.Forms.TextBox txtQCPwd;
        private System.Windows.Forms.TextBox txtQCDomName;
        private System.Windows.Forms.TextBox txtQCProjName;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.DataGridView dgvALM;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox txtQCFolderPath;
        private System.Windows.Forms.Label labFolderPath;
        private System.Windows.Forms.Label lblALMHeader;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnUploadALM;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Hired;
        private System.Windows.Forms.DataGridViewTextBoxColumn TestName;
        private System.Windows.Forms.DataGridViewComboBoxColumn Status;
        private System.Windows.Forms.DataGridViewComboBoxColumn FailureReason;
        private System.Windows.Forms.DataGridViewTextBoxColumn JenkinsLog;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabJenkins;
        private System.Windows.Forms.TabPage tabALM;
        private System.Windows.Forms.TreeView treeViewJenkins;
        private System.Windows.Forms.Button btnUpdateALM;
        private System.Windows.Forms.Button btnConnectJenkins;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbPasswordJenkins;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.TextBox txtPasswpord;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Button btnRefreshTable;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label lalJenkins;
        private System.Windows.Forms.ProgressBar progressBar2;
        private System.Windows.Forms.Label lblJenkinsHeader;
        private System.Windows.Forms.DataGridView dgvJenkins;
        private System.Windows.Forms.Label lblSpreadSheetName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSpreadSheetName;
        private System.Windows.Forms.TextBox txtWorkSheetName;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label lblBatchJobName;
        private System.Windows.Forms.TextBox txtBatchJobName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn TestName1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Result;
        private System.Windows.Forms.DataGridViewTextBoxColumn JenkinsLog1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ALM;
        private System.Windows.Forms.Label lblTestsCount;
        private System.Windows.Forms.Label lblNoOfTests;
        private System.Windows.Forms.Label lblJobTitle;
        private System.Windows.Forms.Label lblJobName;
        private System.Windows.Forms.ErrorProvider errorProvider1;

    }
}

