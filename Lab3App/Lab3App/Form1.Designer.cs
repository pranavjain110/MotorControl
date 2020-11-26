namespace Lab3App
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
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label label5;
            System.Windows.Forms.Label label6;
            System.Windows.Forms.Label label7;
            System.Windows.Forms.Label label8;
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint1 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 0D);
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint2 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 0D);
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint3 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 0D);
            this.comboBoxCOMPorts = new System.Windows.Forms.ComboBox();
            this.btnDisconnectSerial = new System.Windows.Forms.Button();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.textBoxSteps = new System.Windows.Forms.TextBox();
            this.checkBoxCW = new System.Windows.Forms.CheckBox();
            this.checkBoxACW = new System.Windows.Forms.CheckBox();
            this.hScrollBarDC = new System.Windows.Forms.HScrollBar();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.txtBytesToRead = new System.Windows.Forms.TextBox();
            this.txtItemsInQueue = new System.Windows.Forms.TextBox();
            this.txtSerialData = new System.Windows.Forms.TextBox();
            this.textBoxCW = new System.Windows.Forms.TextBox();
            this.textBoxACW = new System.Windows.Forms.TextBox();
            this.trialtext = new System.Windows.Forms.TextBox();
            this.textTimeRev = new System.Windows.Forms.TextBox();
            this.textTimeFwd = new System.Windows.Forms.TextBox();
            this.textBoxVelACW = new System.Windows.Forms.TextBox();
            this.textBoxVelCW = new System.Windows.Forms.TextBox();
            this.chartPosition = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.textBoxPosition = new System.Windows.Forms.TextBox();
            this.textBoxFreq = new System.Windows.Forms.TextBox();
            this.chartVelocity = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.buttonPWM0 = new System.Windows.Forms.Button();
            this.buttonPWM25 = new System.Windows.Forms.Button();
            this.buttonPWM50 = new System.Windows.Forms.Button();
            this.buttonPWM100 = new System.Windows.Forms.Button();
            this.buttonPWM75 = new System.Windows.Forms.Button();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.btnSelectFilename = new System.Windows.Forms.Button();
            this.checkBoxSaveFile = new System.Windows.Forms.CheckBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.textBoxPositionFinal = new System.Windows.Forms.TextBox();
            this.buttonPositionCommand = new System.Windows.Forms.Button();
            this.chartPosAbs = new System.Windows.Forms.DataVisualization.Charting.Chart();
            label2 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chartPosition)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartVelocity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartPosAbs)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label2.Location = new System.Drawing.Point(9, 85);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(120, 18);
            label2.TabIndex = 34;
            label2.Text = "DC Motor Speed";
            label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label1.Location = new System.Drawing.Point(16, 455);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(104, 18);
            label1.TabIndex = 36;
            label1.Text = "Steps to Move";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label3.Location = new System.Drawing.Point(9, 154);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(67, 18);
            label3.TabIndex = 39;
            label3.Text = "Direction";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label4.Location = new System.Drawing.Point(22, 324);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(104, 18);
            label4.TabIndex = 56;
            label4.Text = "Encoder Ticks";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label5.Location = new System.Drawing.Point(25, 357);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(42, 18);
            label5.TabIndex = 57;
            label5.Text = "RPM";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label6.Location = new System.Drawing.Point(225, 420);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(120, 18);
            label6.TabIndex = 58;
            label6.Text = "Debugging Tools";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label7.Location = new System.Drawing.Point(25, 384);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(75, 18);
            label7.TabIndex = 59;
            label7.Text = "Freq. (Hz)";
            label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label8.Location = new System.Drawing.Point(22, 259);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(62, 18);
            label8.TabIndex = 70;
            label8.Text = "Position";
            label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // comboBoxCOMPorts
            // 
            this.comboBoxCOMPorts.FormattingEnabled = true;
            this.comboBoxCOMPorts.Location = new System.Drawing.Point(12, 12);
            this.comboBoxCOMPorts.Name = "comboBoxCOMPorts";
            this.comboBoxCOMPorts.Size = new System.Drawing.Size(121, 21);
            this.comboBoxCOMPorts.TabIndex = 6;
            this.comboBoxCOMPorts.SelectedIndexChanged += new System.EventHandler(this.comboBoxCOMPorts_SelectedIndexChanged);
            // 
            // btnDisconnectSerial
            // 
            this.btnDisconnectSerial.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDisconnectSerial.Location = new System.Drawing.Point(147, 10);
            this.btnDisconnectSerial.Name = "btnDisconnectSerial";
            this.btnDisconnectSerial.Size = new System.Drawing.Size(117, 23);
            this.btnDisconnectSerial.TabIndex = 5;
            this.btnDisconnectSerial.Text = "Connect Serial";
            this.btnDisconnectSerial.UseVisualStyleBackColor = true;
            this.btnDisconnectSerial.Click += new System.EventHandler(this.btnDisconnectSerial_Click);
            // 
            // serialPort1
            // 
            this.serialPort1.PortName = "COM3";
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(205, 197);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(117, 23);
            this.button1.TabIndex = 35;
            this.button1.Text = "Send Command";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBoxSteps
            // 
            this.textBoxSteps.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxSteps.Location = new System.Drawing.Point(211, 454);
            this.textBoxSteps.Name = "textBoxSteps";
            this.textBoxSteps.Size = new System.Drawing.Size(64, 22);
            this.textBoxSteps.TabIndex = 37;
            // 
            // checkBoxCW
            // 
            this.checkBoxCW.AutoSize = true;
            this.checkBoxCW.Checked = true;
            this.checkBoxCW.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxCW.Location = new System.Drawing.Point(197, 157);
            this.checkBoxCW.Name = "checkBoxCW";
            this.checkBoxCW.Size = new System.Drawing.Size(74, 17);
            this.checkBoxCW.TabIndex = 38;
            this.checkBoxCW.Text = "Clockwise";
            this.checkBoxCW.UseVisualStyleBackColor = true;
            this.checkBoxCW.CheckedChanged += new System.EventHandler(this.checkBoxCW_CheckedChanged);
            // 
            // checkBoxACW
            // 
            this.checkBoxACW.AutoSize = true;
            this.checkBoxACW.Location = new System.Drawing.Point(402, 160);
            this.checkBoxACW.Name = "checkBoxACW";
            this.checkBoxACW.Size = new System.Drawing.Size(101, 17);
            this.checkBoxACW.TabIndex = 40;
            this.checkBoxACW.Text = "Anti - Clockwise";
            this.checkBoxACW.UseVisualStyleBackColor = true;
            this.checkBoxACW.CheckedChanged += new System.EventHandler(this.checkBoxACW_CheckedChanged);
            // 
            // hScrollBarDC
            // 
            this.hScrollBarDC.LargeChange = 2;
            this.hScrollBarDC.Location = new System.Drawing.Point(200, 85);
            this.hScrollBarDC.Maximum = 65535;
            this.hScrollBarDC.Name = "hScrollBarDC";
            this.hScrollBarDC.Size = new System.Drawing.Size(319, 20);
            this.hScrollBarDC.TabIndex = 41;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // txtBytesToRead
            // 
            this.txtBytesToRead.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBytesToRead.Location = new System.Drawing.Point(36, 499);
            this.txtBytesToRead.Name = "txtBytesToRead";
            this.txtBytesToRead.Size = new System.Drawing.Size(64, 22);
            this.txtBytesToRead.TabIndex = 42;
            // 
            // txtItemsInQueue
            // 
            this.txtItemsInQueue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtItemsInQueue.Location = new System.Drawing.Point(36, 550);
            this.txtItemsInQueue.Name = "txtItemsInQueue";
            this.txtItemsInQueue.Size = new System.Drawing.Size(64, 22);
            this.txtItemsInQueue.TabIndex = 43;
            // 
            // txtSerialData
            // 
            this.txtSerialData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSerialData.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSerialData.Location = new System.Drawing.Point(300, 450);
            this.txtSerialData.Multiline = true;
            this.txtSerialData.Name = "txtSerialData";
            this.txtSerialData.Size = new System.Drawing.Size(419, 148);
            this.txtSerialData.TabIndex = 44;
            // 
            // textBoxCW
            // 
            this.textBoxCW.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxCW.Location = new System.Drawing.Point(132, 323);
            this.textBoxCW.Name = "textBoxCW";
            this.textBoxCW.Size = new System.Drawing.Size(64, 22);
            this.textBoxCW.TabIndex = 45;
            this.textBoxCW.Text = "0";
            // 
            // textBoxACW
            // 
            this.textBoxACW.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxACW.Location = new System.Drawing.Point(244, 324);
            this.textBoxACW.Name = "textBoxACW";
            this.textBoxACW.Size = new System.Drawing.Size(64, 22);
            this.textBoxACW.TabIndex = 46;
            this.textBoxACW.Text = "0";
            // 
            // trialtext
            // 
            this.trialtext.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.trialtext.Location = new System.Drawing.Point(211, 499);
            this.trialtext.Name = "trialtext";
            this.trialtext.Size = new System.Drawing.Size(64, 22);
            this.trialtext.TabIndex = 47;
            // 
            // textTimeRev
            // 
            this.textTimeRev.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textTimeRev.Location = new System.Drawing.Point(214, 550);
            this.textTimeRev.Name = "textTimeRev";
            this.textTimeRev.Size = new System.Drawing.Size(64, 22);
            this.textTimeRev.TabIndex = 49;
            // 
            // textTimeFwd
            // 
            this.textTimeFwd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textTimeFwd.Location = new System.Drawing.Point(119, 549);
            this.textTimeFwd.Name = "textTimeFwd";
            this.textTimeFwd.Size = new System.Drawing.Size(64, 22);
            this.textTimeFwd.TabIndex = 48;
            // 
            // textBoxVelACW
            // 
            this.textBoxVelACW.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxVelACW.Location = new System.Drawing.Point(244, 352);
            this.textBoxVelACW.Name = "textBoxVelACW";
            this.textBoxVelACW.Size = new System.Drawing.Size(64, 22);
            this.textBoxVelACW.TabIndex = 51;
            this.textBoxVelACW.Text = "0";
            // 
            // textBoxVelCW
            // 
            this.textBoxVelCW.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxVelCW.Location = new System.Drawing.Point(132, 351);
            this.textBoxVelCW.Name = "textBoxVelCW";
            this.textBoxVelCW.Size = new System.Drawing.Size(64, 22);
            this.textBoxVelCW.TabIndex = 50;
            this.textBoxVelCW.Text = "0";
            // 
            // chartPosition
            // 
            chartArea1.AxisY.Maximum = 1D;
            chartArea1.AxisY.Minimum = -1D;
            chartArea1.Name = "ChartArea1";
            this.chartPosition.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartPosition.Legends.Add(legend1);
            this.chartPosition.Location = new System.Drawing.Point(552, 21);
            this.chartPosition.Name = "chartPosition";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            series1.Points.Add(dataPoint1);
            this.chartPosition.Series.Add(series1);
            this.chartPosition.Size = new System.Drawing.Size(371, 232);
            this.chartPosition.TabIndex = 52;
            this.chartPosition.Text = "chart1";
            this.chartPosition.Click += new System.EventHandler(this.chartPosition_Click);
            // 
            // textBoxPosition
            // 
            this.textBoxPosition.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPosition.Location = new System.Drawing.Point(123, 499);
            this.textBoxPosition.Name = "textBoxPosition";
            this.textBoxPosition.Size = new System.Drawing.Size(64, 22);
            this.textBoxPosition.TabIndex = 53;
            this.textBoxPosition.Text = "0";
            // 
            // textBoxFreq
            // 
            this.textBoxFreq.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxFreq.Location = new System.Drawing.Point(132, 383);
            this.textBoxFreq.Name = "textBoxFreq";
            this.textBoxFreq.Size = new System.Drawing.Size(64, 22);
            this.textBoxFreq.TabIndex = 54;
            this.textBoxFreq.Text = "0";
            // 
            // chartVelocity
            // 
            chartArea2.AxisY.Maximum = 300D;
            chartArea2.AxisY.Minimum = -300D;
            chartArea2.Name = "ChartArea1";
            this.chartVelocity.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chartVelocity.Legends.Add(legend2);
            this.chartVelocity.Location = new System.Drawing.Point(747, 267);
            this.chartVelocity.Name = "chartVelocity";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            series2.Points.Add(dataPoint2);
            this.chartVelocity.Series.Add(series2);
            this.chartVelocity.Size = new System.Drawing.Size(542, 243);
            this.chartVelocity.TabIndex = 55;
            this.chartVelocity.Text = "chart1";
            // 
            // buttonPWM0
            // 
            this.buttonPWM0.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPWM0.Location = new System.Drawing.Point(12, 117);
            this.buttonPWM0.Name = "buttonPWM0";
            this.buttonPWM0.Size = new System.Drawing.Size(78, 23);
            this.buttonPWM0.TabIndex = 60;
            this.buttonPWM0.Text = "PWM 0%";
            this.buttonPWM0.UseVisualStyleBackColor = true;
            this.buttonPWM0.Click += new System.EventHandler(this.buttonPWM0_Click);
            // 
            // buttonPWM25
            // 
            this.buttonPWM25.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPWM25.Location = new System.Drawing.Point(126, 117);
            this.buttonPWM25.Name = "buttonPWM25";
            this.buttonPWM25.Size = new System.Drawing.Size(78, 23);
            this.buttonPWM25.TabIndex = 62;
            this.buttonPWM25.Text = "PWM 25%";
            this.buttonPWM25.UseVisualStyleBackColor = true;
            this.buttonPWM25.Click += new System.EventHandler(this.buttonPWM25_Click);
            // 
            // buttonPWM50
            // 
            this.buttonPWM50.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPWM50.Location = new System.Drawing.Point(244, 117);
            this.buttonPWM50.Name = "buttonPWM50";
            this.buttonPWM50.Size = new System.Drawing.Size(78, 23);
            this.buttonPWM50.TabIndex = 63;
            this.buttonPWM50.Text = "PWM 50%";
            this.buttonPWM50.UseVisualStyleBackColor = true;
            this.buttonPWM50.Click += new System.EventHandler(this.buttonPWM50_Click);
            // 
            // buttonPWM100
            // 
            this.buttonPWM100.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPWM100.Location = new System.Drawing.Point(457, 117);
            this.buttonPWM100.Name = "buttonPWM100";
            this.buttonPWM100.Size = new System.Drawing.Size(89, 23);
            this.buttonPWM100.TabIndex = 64;
            this.buttonPWM100.Text = "PWM 100%";
            this.buttonPWM100.UseVisualStyleBackColor = true;
            this.buttonPWM100.Click += new System.EventHandler(this.buttonPWM100_Click);
            // 
            // buttonPWM75
            // 
            this.buttonPWM75.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPWM75.Location = new System.Drawing.Point(350, 117);
            this.buttonPWM75.Name = "buttonPWM75";
            this.buttonPWM75.Size = new System.Drawing.Size(78, 23);
            this.buttonPWM75.TabIndex = 65;
            this.buttonPWM75.Text = "PWM 75%";
            this.buttonPWM75.UseVisualStyleBackColor = true;
            this.buttonPWM75.Click += new System.EventHandler(this.buttonPWM75_Click);
            // 
            // txtFilePath
            // 
            this.txtFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFilePath.Location = new System.Drawing.Point(467, 335);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.Size = new System.Drawing.Size(244, 20);
            this.txtFilePath.TabIndex = 68;
            // 
            // btnSelectFilename
            // 
            this.btnSelectFilename.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelectFilename.Location = new System.Drawing.Point(352, 333);
            this.btnSelectFilename.Name = "btnSelectFilename";
            this.btnSelectFilename.Size = new System.Drawing.Size(99, 23);
            this.btnSelectFilename.TabIndex = 67;
            this.btnSelectFilename.Text = "Select Filename";
            this.btnSelectFilename.UseVisualStyleBackColor = true;
            this.btnSelectFilename.Click += new System.EventHandler(this.btnSelectFilename_Click);
            // 
            // checkBoxSaveFile
            // 
            this.checkBoxSaveFile.AutoSize = true;
            this.checkBoxSaveFile.Location = new System.Drawing.Point(352, 309);
            this.checkBoxSaveFile.Name = "checkBoxSaveFile";
            this.checkBoxSaveFile.Size = new System.Drawing.Size(88, 17);
            this.checkBoxSaveFile.TabIndex = 66;
            this.checkBoxSaveFile.Text = "Save to a file";
            this.checkBoxSaveFile.UseVisualStyleBackColor = true;
            this.checkBoxSaveFile.CheckedChanged += new System.EventHandler(this.checkBoxSaveFile_CheckedChanged);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.InitialDirectory = "C:\\";
            // 
            // textBoxPositionFinal
            // 
            this.textBoxPositionFinal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPositionFinal.Location = new System.Drawing.Point(132, 258);
            this.textBoxPositionFinal.Name = "textBoxPositionFinal";
            this.textBoxPositionFinal.Size = new System.Drawing.Size(64, 22);
            this.textBoxPositionFinal.TabIndex = 69;
            this.textBoxPositionFinal.Text = "0";
            this.textBoxPositionFinal.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // buttonPositionCommand
            // 
            this.buttonPositionCommand.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPositionCommand.Location = new System.Drawing.Point(334, 259);
            this.buttonPositionCommand.Name = "buttonPositionCommand";
            this.buttonPositionCommand.Size = new System.Drawing.Size(117, 23);
            this.buttonPositionCommand.TabIndex = 71;
            this.buttonPositionCommand.Text = "Send Position";
            this.buttonPositionCommand.UseVisualStyleBackColor = true;
            this.buttonPositionCommand.Click += new System.EventHandler(this.buttonPositionCommand_Click);
            // 
            // chartPosAbs
            // 
            chartArea3.AxisY.Maximum = 400D;
            chartArea3.AxisY.Minimum = 0D;
            chartArea3.Name = "ChartArea1";
            this.chartPosAbs.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.chartPosAbs.Legends.Add(legend3);
            this.chartPosAbs.Location = new System.Drawing.Point(905, 21);
            this.chartPosAbs.Name = "chartPosAbs";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            series3.Points.Add(dataPoint3);
            this.chartPosAbs.Series.Add(series3);
            this.chartPosAbs.Size = new System.Drawing.Size(384, 232);
            this.chartPosAbs.TabIndex = 72;
            this.chartPosAbs.Text = "chart1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1289, 610);
            this.Controls.Add(this.chartPosAbs);
            this.Controls.Add(this.buttonPositionCommand);
            this.Controls.Add(label8);
            this.Controls.Add(this.textBoxPositionFinal);
            this.Controls.Add(this.txtFilePath);
            this.Controls.Add(this.btnSelectFilename);
            this.Controls.Add(this.checkBoxSaveFile);
            this.Controls.Add(this.buttonPWM75);
            this.Controls.Add(this.buttonPWM100);
            this.Controls.Add(this.buttonPWM50);
            this.Controls.Add(this.buttonPWM25);
            this.Controls.Add(this.buttonPWM0);
            this.Controls.Add(label7);
            this.Controls.Add(label6);
            this.Controls.Add(label5);
            this.Controls.Add(label4);
            this.Controls.Add(this.chartVelocity);
            this.Controls.Add(this.textBoxFreq);
            this.Controls.Add(this.textBoxPosition);
            this.Controls.Add(this.chartPosition);
            this.Controls.Add(this.textBoxVelACW);
            this.Controls.Add(this.textBoxVelCW);
            this.Controls.Add(this.textTimeRev);
            this.Controls.Add(this.textTimeFwd);
            this.Controls.Add(this.trialtext);
            this.Controls.Add(this.textBoxACW);
            this.Controls.Add(this.textBoxCW);
            this.Controls.Add(this.txtSerialData);
            this.Controls.Add(this.txtItemsInQueue);
            this.Controls.Add(this.txtBytesToRead);
            this.Controls.Add(this.hScrollBarDC);
            this.Controls.Add(this.checkBoxACW);
            this.Controls.Add(label3);
            this.Controls.Add(this.checkBoxCW);
            this.Controls.Add(this.textBoxSteps);
            this.Controls.Add(label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(label2);
            this.Controls.Add(this.comboBoxCOMPorts);
            this.Controls.Add(this.btnDisconnectSerial);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartPosition)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartVelocity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartPosAbs)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxCOMPorts;
        private System.Windows.Forms.Button btnDisconnectSerial;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBoxSteps;
        private System.Windows.Forms.CheckBox checkBoxCW;
        private System.Windows.Forms.CheckBox checkBoxACW;
        private System.Windows.Forms.HScrollBar hScrollBarDC;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox txtBytesToRead;
        private System.Windows.Forms.TextBox txtItemsInQueue;
        private System.Windows.Forms.TextBox txtSerialData;
        private System.Windows.Forms.TextBox textBoxCW;
        private System.Windows.Forms.TextBox textBoxACW;
        private System.Windows.Forms.TextBox trialtext;
        private System.Windows.Forms.TextBox textTimeRev;
        private System.Windows.Forms.TextBox textTimeFwd;
        private System.Windows.Forms.TextBox textBoxVelACW;
        private System.Windows.Forms.TextBox textBoxVelCW;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartPosition;
        private System.Windows.Forms.TextBox textBoxPosition;
        private System.Windows.Forms.TextBox textBoxFreq;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartVelocity;
        private System.Windows.Forms.Button buttonPWM0;
        private System.Windows.Forms.Button buttonPWM25;
        private System.Windows.Forms.Button buttonPWM50;
        private System.Windows.Forms.Button buttonPWM100;
        private System.Windows.Forms.Button buttonPWM75;
        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.Button btnSelectFilename;
        private System.Windows.Forms.CheckBox checkBoxSaveFile;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.TextBox textBoxPositionFinal;
        private System.Windows.Forms.Button buttonPositionCommand;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartPosAbs;
    }
}

