namespace ET_Project_GUI
{
    partial class MainForm
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
            //call this before killing program
            onProgramClose();


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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.Obs_TrackingMonitor_Button = new System.Windows.Forms.Button();
            this.Obs_EyeImageMonitor_Button = new System.Windows.Forms.Button();
            this.observationMonitorPictureBox = new System.Windows.Forms.PictureBox();
            this.App_SimonSays_Button = new System.Windows.Forms.Button();
            this.App_OtherApps_Button = new System.Windows.Forms.Button();
            this.App_Maze_Button = new System.Windows.Forms.Button();
            this.DataRec_SaveCalAcc_Button = new System.Windows.Forms.Button();
            this.DataRec_StartDataRec_Button = new System.Windows.Forms.Button();
            this.DataRec_StopDataRec_Button = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dataSampleRateComboBox = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.dataExportComboBox = new System.Windows.Forms.ComboBox();
            this.customPanel10 = new ET_Project_GUI.CustomPanel();
            this.customPanel9 = new ET_Project_GUI.CustomPanel();
            this.customPanel8 = new ET_Project_GUI.CustomPanel();
            this.customPanel7 = new ET_Project_GUI.CustomPanel();
            this.customPanel6 = new ET_Project_GUI.CustomPanel();
            this.customPanel5 = new ET_Project_GUI.CustomPanel();
            this.customPanel4 = new ET_Project_GUI.CustomPanel();
            this.customPanel3 = new ET_Project_GUI.CustomPanel();
            this.customPanel2 = new ET_Project_GUI.CustomPanel();
            this.customPanel1 = new ET_Project_GUI.CustomPanel();
            this.panel1 = new ET_Project_GUI.CustomPanel();
            this.targetShapeComboBox = new System.Windows.Forms.ComboBox();
            this.callibrationPointComboBox = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new ET_Project_GUI.CustomPanel();
            this.label6 = new ET_Project_GUI.CustomPanel();
            this.calibrationAccuracyPictureBox = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Cal_CheckAccuracy_Button = new System.Windows.Forms.Button();
            this.Cal_Validate_Button = new System.Windows.Forms.Button();
            this.Cal_Calibrate_Button = new System.Windows.Forms.Button();
            this.Cal_Connect_Button = new System.Windows.Forms.Button();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.lineShape1 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            ((System.ComponentModel.ISupportInitialize)(this.observationMonitorPictureBox)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.calibrationAccuracyPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // Obs_TrackingMonitor_Button
            // 
            this.Obs_TrackingMonitor_Button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(172)))), ((int)(((byte)(203)))));
            this.Obs_TrackingMonitor_Button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Obs_TrackingMonitor_Button.Enabled = false;
            this.Obs_TrackingMonitor_Button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(145)))), ((int)(((byte)(160)))));
            this.Obs_TrackingMonitor_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Obs_TrackingMonitor_Button.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Obs_TrackingMonitor_Button.ForeColor = System.Drawing.Color.White;
            this.Obs_TrackingMonitor_Button.Location = new System.Drawing.Point(476, 51);
            this.Obs_TrackingMonitor_Button.Name = "Obs_TrackingMonitor_Button";
            this.Obs_TrackingMonitor_Button.Size = new System.Drawing.Size(169, 31);
            this.Obs_TrackingMonitor_Button.TabIndex = 9;
            this.Obs_TrackingMonitor_Button.Text = "Tracking Monitor";
            this.Obs_TrackingMonitor_Button.UseVisualStyleBackColor = false;
            this.Obs_TrackingMonitor_Button.Click += new System.EventHandler(this.Obs_TrackingMonitor_Button_Click);
            // 
            // Obs_EyeImageMonitor_Button
            // 
            this.Obs_EyeImageMonitor_Button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(172)))), ((int)(((byte)(203)))));
            this.Obs_EyeImageMonitor_Button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Obs_EyeImageMonitor_Button.Enabled = false;
            this.Obs_EyeImageMonitor_Button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(145)))), ((int)(((byte)(160)))));
            this.Obs_EyeImageMonitor_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Obs_EyeImageMonitor_Button.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Obs_EyeImageMonitor_Button.ForeColor = System.Drawing.Color.White;
            this.Obs_EyeImageMonitor_Button.Location = new System.Drawing.Point(476, 88);
            this.Obs_EyeImageMonitor_Button.Name = "Obs_EyeImageMonitor_Button";
            this.Obs_EyeImageMonitor_Button.Size = new System.Drawing.Size(169, 31);
            this.Obs_EyeImageMonitor_Button.TabIndex = 10;
            this.Obs_EyeImageMonitor_Button.Text = "Eye Image Monitor";
            this.Obs_EyeImageMonitor_Button.UseVisualStyleBackColor = false;
            this.Obs_EyeImageMonitor_Button.Click += new System.EventHandler(this.Obs_EyeImageMonitor_Button_Click);
            // 
            // observationMonitorPictureBox
            // 
            this.observationMonitorPictureBox.BackColor = System.Drawing.Color.White;
            this.observationMonitorPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.observationMonitorPictureBox.Location = new System.Drawing.Point(666, 51);
            this.observationMonitorPictureBox.Name = "observationMonitorPictureBox";
            this.observationMonitorPictureBox.Size = new System.Drawing.Size(180, 137);
            this.observationMonitorPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.observationMonitorPictureBox.TabIndex = 12;
            this.observationMonitorPictureBox.TabStop = false;
            // 
            // App_SimonSays_Button
            // 
            this.App_SimonSays_Button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(172)))), ((int)(((byte)(203)))));
            this.App_SimonSays_Button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.App_SimonSays_Button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(145)))), ((int)(((byte)(160)))));
            this.App_SimonSays_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.App_SimonSays_Button.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.App_SimonSays_Button.ForeColor = System.Drawing.Color.White;
            this.App_SimonSays_Button.Location = new System.Drawing.Point(533, 247);
            this.App_SimonSays_Button.Name = "App_SimonSays_Button";
            this.App_SimonSays_Button.Size = new System.Drawing.Size(263, 31);
            this.App_SimonSays_Button.TabIndex = 14;
            this.App_SimonSays_Button.Text = "Cicero Game";
            this.App_SimonSays_Button.UseVisualStyleBackColor = false;
            this.App_SimonSays_Button.Click += new System.EventHandler(this.App_SimonSays_Button_Click);
            // 
            // App_OtherApps_Button
            // 
            this.App_OtherApps_Button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(172)))), ((int)(((byte)(203)))));
            this.App_OtherApps_Button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.App_OtherApps_Button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(145)))), ((int)(((byte)(160)))));
            this.App_OtherApps_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.App_OtherApps_Button.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.App_OtherApps_Button.ForeColor = System.Drawing.Color.White;
            this.App_OtherApps_Button.Location = new System.Drawing.Point(533, 321);
            this.App_OtherApps_Button.Name = "App_OtherApps_Button";
            this.App_OtherApps_Button.Size = new System.Drawing.Size(263, 31);
            this.App_OtherApps_Button.TabIndex = 17;
            this.App_OtherApps_Button.Text = "Other Applications";
            this.App_OtherApps_Button.UseVisualStyleBackColor = false;
            this.App_OtherApps_Button.Click += new System.EventHandler(this.App_OtherApps_Button_Click);
            // 
            // App_Maze_Button
            // 
            this.App_Maze_Button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(172)))), ((int)(((byte)(203)))));
            this.App_Maze_Button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.App_Maze_Button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(145)))), ((int)(((byte)(160)))));
            this.App_Maze_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.App_Maze_Button.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.App_Maze_Button.ForeColor = System.Drawing.Color.White;
            this.App_Maze_Button.Location = new System.Drawing.Point(533, 284);
            this.App_Maze_Button.Name = "App_Maze_Button";
            this.App_Maze_Button.Size = new System.Drawing.Size(263, 31);
            this.App_Maze_Button.TabIndex = 18;
            this.App_Maze_Button.Text = "Gaze Maze Game";
            this.App_Maze_Button.UseVisualStyleBackColor = false;
            this.App_Maze_Button.Click += new System.EventHandler(this.App_Maze_Button_Click);
            // 
            // DataRec_SaveCalAcc_Button
            // 
            this.DataRec_SaveCalAcc_Button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(172)))), ((int)(((byte)(203)))));
            this.DataRec_SaveCalAcc_Button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DataRec_SaveCalAcc_Button.Enabled = false;
            this.DataRec_SaveCalAcc_Button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(145)))), ((int)(((byte)(160)))));
            this.DataRec_SaveCalAcc_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DataRec_SaveCalAcc_Button.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DataRec_SaveCalAcc_Button.ForeColor = System.Drawing.Color.White;
            this.DataRec_SaveCalAcc_Button.Location = new System.Drawing.Point(48, 362);
            this.DataRec_SaveCalAcc_Button.Name = "DataRec_SaveCalAcc_Button";
            this.DataRec_SaveCalAcc_Button.Size = new System.Drawing.Size(361, 31);
            this.DataRec_SaveCalAcc_Button.TabIndex = 19;
            this.DataRec_SaveCalAcc_Button.Text = "Save Calibration Accuracy";
            this.DataRec_SaveCalAcc_Button.UseVisualStyleBackColor = false;
            this.DataRec_SaveCalAcc_Button.Click += new System.EventHandler(this.DataRec_SaveCalAcc_Button_Click);
            // 
            // DataRec_StartDataRec_Button
            // 
            this.DataRec_StartDataRec_Button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(172)))), ((int)(((byte)(203)))));
            this.DataRec_StartDataRec_Button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DataRec_StartDataRec_Button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(145)))), ((int)(((byte)(160)))));
            this.DataRec_StartDataRec_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DataRec_StartDataRec_Button.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DataRec_StartDataRec_Button.ForeColor = System.Drawing.Color.White;
            this.DataRec_StartDataRec_Button.Location = new System.Drawing.Point(48, 431);
            this.DataRec_StartDataRec_Button.Name = "DataRec_StartDataRec_Button";
            this.DataRec_StartDataRec_Button.Size = new System.Drawing.Size(361, 31);
            this.DataRec_StartDataRec_Button.TabIndex = 20;
            this.DataRec_StartDataRec_Button.Text = "Start Data Recording";
            this.DataRec_StartDataRec_Button.UseVisualStyleBackColor = false;
            this.DataRec_StartDataRec_Button.Click += new System.EventHandler(this.DataRec_StartDataRec_Button_Click);
            // 
            // DataRec_StopDataRec_Button
            // 
            this.DataRec_StopDataRec_Button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(172)))), ((int)(((byte)(203)))));
            this.DataRec_StopDataRec_Button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DataRec_StopDataRec_Button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(145)))), ((int)(((byte)(160)))));
            this.DataRec_StopDataRec_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DataRec_StopDataRec_Button.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DataRec_StopDataRec_Button.ForeColor = System.Drawing.Color.White;
            this.DataRec_StopDataRec_Button.Location = new System.Drawing.Point(48, 468);
            this.DataRec_StopDataRec_Button.Name = "DataRec_StopDataRec_Button";
            this.DataRec_StopDataRec_Button.Size = new System.Drawing.Size(361, 31);
            this.DataRec_StopDataRec_Button.TabIndex = 21;
            this.DataRec_StopDataRec_Button.Text = "Stop Data Recording";
            this.DataRec_StopDataRec_Button.UseVisualStyleBackColor = false;
            this.DataRec_StopDataRec_Button.Click += new System.EventHandler(this.DataRec_StopDataRec_Button_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(48, 396);
            this.label1.MinimumSize = new System.Drawing.Size(2, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 31);
            this.label1.TabIndex = 23;
            this.label1.Text = "Data Sample Rate";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dataSampleRateComboBox
            // 
            this.dataSampleRateComboBox.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.dataSampleRateComboBox.FormattingEnabled = true;
            this.dataSampleRateComboBox.Items.AddRange(new object[] {
            "1 Data Point/Second",
            "2 Data Points/Second",
            "5 Data Points/Second",
            "7 Data Points/Second",
            "10 Data Points/Second",
            "20 Data Points/Second"});
            this.dataSampleRateComboBox.Location = new System.Drawing.Point(193, 398);
            this.dataSampleRateComboBox.Name = "dataSampleRateComboBox";
            this.dataSampleRateComboBox.Size = new System.Drawing.Size(216, 27);
            this.dataSampleRateComboBox.TabIndex = 24;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(172)))), ((int)(((byte)(203)))));
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(145)))), ((int)(((byte)(160)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(666, 425);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(169, 31);
            this.button1.TabIndex = 27;
            this.button1.Text = "Export";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // dataExportComboBox
            // 
            this.dataExportComboBox.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.dataExportComboBox.FormattingEnabled = true;
            this.dataExportComboBox.Items.AddRange(new object[] {
            "TODO - CSV",
            "TODO - SQL",
            "TODO - ACCESS",
            "TODO - ETC",
            "TODO - ETC",
            ""});
            this.dataExportComboBox.Location = new System.Drawing.Point(476, 427);
            this.dataExportComboBox.Name = "dataExportComboBox";
            this.dataExportComboBox.Size = new System.Drawing.Size(181, 27);
            this.dataExportComboBox.TabIndex = 28;
            // 
            // customPanel10
            // 
            this.customPanel10.BackColor = System.Drawing.Color.White;
            this.customPanel10.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(172)))), ((int)(((byte)(198)))));
            this.customPanel10.BorderWidth = 2;
            this.customPanel10.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.customPanel10.Location = new System.Drawing.Point(476, 376);
            this.customPanel10.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.customPanel10.Name = "customPanel10";
            this.customPanel10.PanelText = "DATA EXPORT";
            this.customPanel10.Size = new System.Drawing.Size(153, 26);
            this.customPanel10.TabIndex = 26;
            // 
            // customPanel9
            // 
            this.customPanel9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(150)))), ((int)(((byte)(70)))));
            this.customPanel9.BorderColor = System.Drawing.Color.White;
            this.customPanel9.BorderWidth = 2;
            this.customPanel9.Location = new System.Drawing.Point(466, 388);
            this.customPanel9.Name = "customPanel9";
            this.customPanel9.PanelText = "";
            this.customPanel9.Size = new System.Drawing.Size(400, 96);
            this.customPanel9.TabIndex = 25;
            // 
            // customPanel8
            // 
            this.customPanel8.AutoSize = true;
            this.customPanel8.BackColor = System.Drawing.Color.White;
            this.customPanel8.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(172)))), ((int)(((byte)(198)))));
            this.customPanel8.BorderWidth = 3;
            this.customPanel8.Font = new System.Drawing.Font("Arial Narrow", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customPanel8.ForeColor = System.Drawing.Color.Black;
            this.customPanel8.Location = new System.Drawing.Point(666, 20);
            this.customPanel8.Margin = new System.Windows.Forms.Padding(4);
            this.customPanel8.MinimumSize = new System.Drawing.Size(170, 26);
            this.customPanel8.Name = "customPanel8";
            this.customPanel8.PanelText = "Observation Monitor";
            this.customPanel8.Size = new System.Drawing.Size(180, 29);
            this.customPanel8.TabIndex = 13;
            // 
            // customPanel7
            // 
            this.customPanel7.BackColor = System.Drawing.Color.White;
            this.customPanel7.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(172)))), ((int)(((byte)(198)))));
            this.customPanel7.BorderWidth = 2;
            this.customPanel7.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.customPanel7.Location = new System.Drawing.Point(20, 329);
            this.customPanel7.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.customPanel7.Name = "customPanel7";
            this.customPanel7.PanelText = "DATA RECORDING";
            this.customPanel7.Size = new System.Drawing.Size(181, 26);
            this.customPanel7.TabIndex = 8;
            // 
            // customPanel6
            // 
            this.customPanel6.BackColor = System.Drawing.Color.White;
            this.customPanel6.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(172)))), ((int)(((byte)(198)))));
            this.customPanel6.BorderWidth = 2;
            this.customPanel6.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.customPanel6.Location = new System.Drawing.Point(476, 210);
            this.customPanel6.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.customPanel6.Name = "customPanel6";
            this.customPanel6.PanelText = "APPLICATIONS";
            this.customPanel6.Size = new System.Drawing.Size(153, 26);
            this.customPanel6.TabIndex = 7;
            // 
            // customPanel5
            // 
            this.customPanel5.BackColor = System.Drawing.Color.White;
            this.customPanel5.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(172)))), ((int)(((byte)(198)))));
            this.customPanel5.BorderWidth = 2;
            this.customPanel5.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.customPanel5.Location = new System.Drawing.Point(476, 5);
            this.customPanel5.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.customPanel5.Name = "customPanel5";
            this.customPanel5.PanelText = "OBSERVATION";
            this.customPanel5.Size = new System.Drawing.Size(153, 26);
            this.customPanel5.TabIndex = 6;
            // 
            // customPanel4
            // 
            this.customPanel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(150)))), ((int)(((byte)(70)))));
            this.customPanel4.BorderColor = System.Drawing.Color.White;
            this.customPanel4.BorderWidth = 2;
            this.customPanel4.Location = new System.Drawing.Point(466, 223);
            this.customPanel4.Name = "customPanel4";
            this.customPanel4.PanelText = "";
            this.customPanel4.Size = new System.Drawing.Size(400, 146);
            this.customPanel4.TabIndex = 5;
            // 
            // customPanel3
            // 
            this.customPanel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(150)))), ((int)(((byte)(70)))));
            this.customPanel3.BorderColor = System.Drawing.Color.White;
            this.customPanel3.BorderWidth = 2;
            this.customPanel3.Location = new System.Drawing.Point(9, 341);
            this.customPanel3.Name = "customPanel3";
            this.customPanel3.PanelText = "";
            this.customPanel3.Size = new System.Drawing.Size(441, 174);
            this.customPanel3.TabIndex = 4;
            // 
            // customPanel2
            // 
            this.customPanel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(150)))), ((int)(((byte)(70)))));
            this.customPanel2.BorderColor = System.Drawing.Color.White;
            this.customPanel2.BorderWidth = 2;
            this.customPanel2.Location = new System.Drawing.Point(466, 15);
            this.customPanel2.Name = "customPanel2";
            this.customPanel2.PanelText = "";
            this.customPanel2.Size = new System.Drawing.Size(400, 187);
            this.customPanel2.TabIndex = 3;
            // 
            // customPanel1
            // 
            this.customPanel1.BackColor = System.Drawing.Color.White;
            this.customPanel1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(172)))), ((int)(((byte)(198)))));
            this.customPanel1.BorderWidth = 3;
            this.customPanel1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customPanel1.ForeColor = System.Drawing.Color.Black;
            this.customPanel1.Location = new System.Drawing.Point(21, 5);
            this.customPanel1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.customPanel1.Name = "customPanel1";
            this.customPanel1.PanelText = "CALIBRATION";
            this.customPanel1.Size = new System.Drawing.Size(153, 26);
            this.customPanel1.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(150)))), ((int)(((byte)(70)))));
            this.panel1.BorderColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.BorderWidth = 2;
            this.panel1.Controls.Add(this.targetShapeComboBox);
            this.panel1.Controls.Add(this.callibrationPointComboBox);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.calibrationAccuracyPictureBox);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.Cal_CheckAccuracy_Button);
            this.panel1.Controls.Add(this.Cal_Validate_Button);
            this.panel1.Controls.Add(this.Cal_Calibrate_Button);
            this.panel1.Controls.Add(this.Cal_Connect_Button);
            this.panel1.Controls.Add(this.shapeContainer1);
            this.panel1.Location = new System.Drawing.Point(9, 14);
            this.panel1.Name = "panel1";
            this.panel1.PanelText = "";
            this.panel1.Size = new System.Drawing.Size(442, 308);
            this.panel1.TabIndex = 0;
            // 
            // targetShapeComboBox
            // 
            this.targetShapeComboBox.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.targetShapeComboBox.FormattingEnabled = true;
            this.targetShapeComboBox.Items.AddRange(new object[] {
            "Circle",
            "Cross"});
            this.targetShapeComboBox.Location = new System.Drawing.Point(228, 267);
            this.targetShapeComboBox.Name = "targetShapeComboBox";
            this.targetShapeComboBox.Size = new System.Drawing.Size(121, 27);
            this.targetShapeComboBox.TabIndex = 15;
            this.targetShapeComboBox.SelectedIndexChanged += new System.EventHandler(this.callibrationDataChanged);
            // 
            // callibrationPointComboBox
            // 
            this.callibrationPointComboBox.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.callibrationPointComboBox.FormattingEnabled = true;
            this.callibrationPointComboBox.Items.AddRange(new object[] {
            "1 Point",
            "2 Point",
            "5 Point",
            "9 Point"});
            this.callibrationPointComboBox.Location = new System.Drawing.Point(228, 231);
            this.callibrationPointComboBox.Name = "callibrationPointComboBox";
            this.callibrationPointComboBox.Size = new System.Drawing.Size(121, 27);
            this.callibrationPointComboBox.TabIndex = 14;
            this.callibrationPointComboBox.SelectedIndexChanged += new System.EventHandler(this.callibrationDataChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.White;
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label9.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(82, 232);
            this.label9.MinimumSize = new System.Drawing.Size(140, 25);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(140, 25);
            this.label9.TabIndex = 13;
            this.label9.Text = "Calibration Points";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.White;
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label8.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(82, 268);
            this.label8.MinimumSize = new System.Drawing.Size(140, 25);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(140, 25);
            this.label8.TabIndex = 12;
            this.label8.Text = "Target Shape";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.White;
            this.label7.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(172)))), ((int)(((byte)(198)))));
            this.label7.BorderWidth = 3;
            this.label7.Font = new System.Drawing.Font("Arial Narrow", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(141, 193);
            this.label7.Margin = new System.Windows.Forms.Padding(4);
            this.label7.MinimumSize = new System.Drawing.Size(160, 28);
            this.label7.Name = "label7";
            this.label7.PanelText = "Calibration Options";
            this.label7.Size = new System.Drawing.Size(160, 28);
            this.label7.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.White;
            this.label6.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(172)))), ((int)(((byte)(198)))));
            this.label6.BorderWidth = 3;
            this.label6.Font = new System.Drawing.Font("Arial Narrow", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(245, 5);
            this.label6.Margin = new System.Windows.Forms.Padding(4);
            this.label6.MinimumSize = new System.Drawing.Size(170, 26);
            this.label6.Name = "label6";
            this.label6.PanelText = "Calibration Accuracy ";
            this.label6.Size = new System.Drawing.Size(180, 29);
            this.label6.TabIndex = 9;
            // 
            // calibrationAccuracyPictureBox
            // 
            this.calibrationAccuracyPictureBox.BackColor = System.Drawing.Color.White;
            this.calibrationAccuracyPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.calibrationAccuracyPictureBox.Location = new System.Drawing.Point(245, 36);
            this.calibrationAccuracyPictureBox.Name = "calibrationAccuracyPictureBox";
            this.calibrationAccuracyPictureBox.Size = new System.Drawing.Size(180, 137);
            this.calibrationAccuracyPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.calibrationAccuracyPictureBox.TabIndex = 8;
            this.calibrationAccuracyPictureBox.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(11, 147);
            this.label5.MinimumSize = new System.Drawing.Size(0, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 25);
            this.label5.TabIndex = 7;
            this.label5.Text = "Step 4";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(11, 111);
            this.label4.MinimumSize = new System.Drawing.Size(0, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 25);
            this.label4.TabIndex = 6;
            this.label4.Text = "Step 3";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(11, 73);
            this.label3.MinimumSize = new System.Drawing.Size(0, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 25);
            this.label3.TabIndex = 5;
            this.label3.Text = "Step 2";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(11, 36);
            this.label2.MinimumSize = new System.Drawing.Size(0, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 25);
            this.label2.TabIndex = 4;
            this.label2.Text = "Step 1";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Cal_CheckAccuracy_Button
            // 
            this.Cal_CheckAccuracy_Button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(172)))), ((int)(((byte)(203)))));
            this.Cal_CheckAccuracy_Button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Cal_CheckAccuracy_Button.Enabled = false;
            this.Cal_CheckAccuracy_Button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(145)))), ((int)(((byte)(160)))));
            this.Cal_CheckAccuracy_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Cal_CheckAccuracy_Button.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.Cal_CheckAccuracy_Button.ForeColor = System.Drawing.Color.White;
            this.Cal_CheckAccuracy_Button.Location = new System.Drawing.Point(80, 144);
            this.Cal_CheckAccuracy_Button.Name = "Cal_CheckAccuracy_Button";
            this.Cal_CheckAccuracy_Button.Size = new System.Drawing.Size(158, 29);
            this.Cal_CheckAccuracy_Button.TabIndex = 3;
            this.Cal_CheckAccuracy_Button.Text = "Check Accuracy";
            this.Cal_CheckAccuracy_Button.UseVisualStyleBackColor = false;
            this.Cal_CheckAccuracy_Button.Click += new System.EventHandler(this.Cal_CheckAccuracy_Button_Click);
            // 
            // Cal_Validate_Button
            // 
            this.Cal_Validate_Button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(172)))), ((int)(((byte)(203)))));
            this.Cal_Validate_Button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Cal_Validate_Button.Enabled = false;
            this.Cal_Validate_Button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(145)))), ((int)(((byte)(160)))));
            this.Cal_Validate_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Cal_Validate_Button.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.Cal_Validate_Button.ForeColor = System.Drawing.Color.White;
            this.Cal_Validate_Button.Location = new System.Drawing.Point(80, 108);
            this.Cal_Validate_Button.Name = "Cal_Validate_Button";
            this.Cal_Validate_Button.Size = new System.Drawing.Size(158, 29);
            this.Cal_Validate_Button.TabIndex = 2;
            this.Cal_Validate_Button.Text = "Validate";
            this.Cal_Validate_Button.UseVisualStyleBackColor = false;
            this.Cal_Validate_Button.Click += new System.EventHandler(this.Cal_Validate_Button_Click);
            // 
            // Cal_Calibrate_Button
            // 
            this.Cal_Calibrate_Button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(172)))), ((int)(((byte)(203)))));
            this.Cal_Calibrate_Button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Cal_Calibrate_Button.Enabled = false;
            this.Cal_Calibrate_Button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(145)))), ((int)(((byte)(160)))));
            this.Cal_Calibrate_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Cal_Calibrate_Button.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.Cal_Calibrate_Button.ForeColor = System.Drawing.Color.White;
            this.Cal_Calibrate_Button.Location = new System.Drawing.Point(80, 73);
            this.Cal_Calibrate_Button.Name = "Cal_Calibrate_Button";
            this.Cal_Calibrate_Button.Size = new System.Drawing.Size(158, 29);
            this.Cal_Calibrate_Button.TabIndex = 1;
            this.Cal_Calibrate_Button.Text = "Calibrate";
            this.Cal_Calibrate_Button.UseVisualStyleBackColor = false;
            this.Cal_Calibrate_Button.Click += new System.EventHandler(this.Cal_Calibrate_Button_Click);
            // 
            // Cal_Connect_Button
            // 
            this.Cal_Connect_Button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(172)))), ((int)(((byte)(203)))));
            this.Cal_Connect_Button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Cal_Connect_Button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(145)))), ((int)(((byte)(160)))));
            this.Cal_Connect_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Cal_Connect_Button.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cal_Connect_Button.ForeColor = System.Drawing.Color.White;
            this.Cal_Connect_Button.Location = new System.Drawing.Point(80, 36);
            this.Cal_Connect_Button.Name = "Cal_Connect_Button";
            this.Cal_Connect_Button.Size = new System.Drawing.Size(158, 31);
            this.Cal_Connect_Button.TabIndex = 0;
            this.Cal_Connect_Button.Text = "Connect";
            this.Cal_Connect_Button.UseVisualStyleBackColor = false;
            this.Cal_Connect_Button.Click += new System.EventHandler(this.Cal_Connect_Button_Click);
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.lineShape1});
            this.shapeContainer1.Size = new System.Drawing.Size(440, 306);
            this.shapeContainer1.TabIndex = 10;
            this.shapeContainer1.TabStop = false;
            // 
            // lineShape1
            // 
            this.lineShape1.BorderWidth = 2;
            this.lineShape1.Name = "lineShape1";
            this.lineShape1.X1 = 10;
            this.lineShape1.X2 = 427;
            this.lineShape1.Y1 = 186;
            this.lineShape1.Y2 = 186;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(129)))), ((int)(((byte)(189)))));
            this.ClientSize = new System.Drawing.Size(876, 527);
            this.Controls.Add(this.dataExportComboBox);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.customPanel10);
            this.Controls.Add(this.customPanel9);
            this.Controls.Add(this.dataSampleRateComboBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DataRec_StopDataRec_Button);
            this.Controls.Add(this.DataRec_StartDataRec_Button);
            this.Controls.Add(this.DataRec_SaveCalAcc_Button);
            this.Controls.Add(this.App_Maze_Button);
            this.Controls.Add(this.App_OtherApps_Button);
            this.Controls.Add(this.App_SimonSays_Button);
            this.Controls.Add(this.customPanel8);
            this.Controls.Add(this.observationMonitorPictureBox);
            this.Controls.Add(this.Obs_EyeImageMonitor_Button);
            this.Controls.Add(this.Obs_TrackingMonitor_Button);
            this.Controls.Add(this.customPanel7);
            this.Controls.Add(this.customPanel6);
            this.Controls.Add(this.customPanel5);
            this.Controls.Add(this.customPanel4);
            this.Controls.Add(this.customPanel3);
            this.Controls.Add(this.customPanel2);
            this.Controls.Add(this.customPanel1);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Text = "At A Glance";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.observationMonitorPictureBox)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.calibrationAccuracyPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        //private System.Windows.Forms.Panel panel1;
        private CustomPanel panel1;
        private CustomPanel label6;
        private System.Windows.Forms.PictureBox calibrationAccuracyPictureBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Cal_CheckAccuracy_Button;
        private System.Windows.Forms.Button Cal_Validate_Button;
        private System.Windows.Forms.Button Cal_Calibrate_Button;
        private System.Windows.Forms.Button Cal_Connect_Button;
        private CustomPanel label7;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape1;
        private System.Windows.Forms.ComboBox targetShapeComboBox;
        private System.Windows.Forms.ComboBox callibrationPointComboBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private CustomPanel customPanel1;
        private CustomPanel customPanel2;
        private CustomPanel customPanel3;
        private CustomPanel customPanel4;
        private CustomPanel customPanel5;
        private CustomPanel customPanel6;
        private CustomPanel customPanel7;
        private System.Windows.Forms.Button Obs_TrackingMonitor_Button;
        private System.Windows.Forms.Button Obs_EyeImageMonitor_Button;
        private CustomPanel customPanel8;
        private System.Windows.Forms.PictureBox observationMonitorPictureBox;
        private System.Windows.Forms.Button App_SimonSays_Button;
        private System.Windows.Forms.Button App_OtherApps_Button;
        private System.Windows.Forms.Button App_Maze_Button;
        private System.Windows.Forms.Button DataRec_SaveCalAcc_Button;
        private System.Windows.Forms.Button DataRec_StartDataRec_Button;
        private System.Windows.Forms.Button DataRec_StopDataRec_Button;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox dataSampleRateComboBox;
        private CustomPanel customPanel9;
        private CustomPanel customPanel10;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox dataExportComboBox;


    }
}

