namespace Gantry
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
            System.Windows.Forms.Label label8;
            System.Windows.Forms.Label label5;
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label2;
            this.comboBoxCOMPorts = new System.Windows.Forms.ComboBox();
            this.btnDisconnectSerial = new System.Windows.Forms.Button();
            this.txtSerialData = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.buttonPositionCommand = new System.Windows.Forms.Button();
            this.textBoxPositionFinal = new System.Windows.Forms.TextBox();
            this.textBoxVelACW = new System.Windows.Forms.TextBox();
            this.textBoxVelCW = new System.Windows.Forms.TextBox();
            this.textBoxACW = new System.Windows.Forms.TextBox();
            this.textBoxCW = new System.Windows.Forms.TextBox();
            this.txtItemsInQueue = new System.Windows.Forms.TextBox();
            this.txtBytesToRead = new System.Windows.Forms.TextBox();
            this.textBoxPosition = new System.Windows.Forms.TextBox();
            this.textBoxSteps = new System.Windows.Forms.TextBox();
            this.textBoxTest = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.textBoxStepperSpeed = new System.Windows.Forms.TextBox();
            label8 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label8.Location = new System.Drawing.Point(12, 159);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(62, 18);
            label8.TabIndex = 73;
            label8.Text = "Position";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label5.Location = new System.Drawing.Point(12, 223);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(42, 18);
            label5.TabIndex = 80;
            label5.Text = "RPM";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label4.Location = new System.Drawing.Point(12, 190);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(104, 18);
            label4.TabIndex = 79;
            label4.Text = "Encoder Ticks";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label1.Location = new System.Drawing.Point(12, 251);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(115, 18);
            label1.TabIndex = 84;
            label1.Text = "Current Position";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label2.Location = new System.Drawing.Point(12, 112);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(105, 18);
            label2.TabIndex = 90;
            label2.Text = "Stepper Speed";
            label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // comboBoxCOMPorts
            // 
            this.comboBoxCOMPorts.FormattingEnabled = true;
            this.comboBoxCOMPorts.Location = new System.Drawing.Point(15, 36);
            this.comboBoxCOMPorts.Name = "comboBoxCOMPorts";
            this.comboBoxCOMPorts.Size = new System.Drawing.Size(121, 21);
            this.comboBoxCOMPorts.TabIndex = 8;
            // 
            // btnDisconnectSerial
            // 
            this.btnDisconnectSerial.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDisconnectSerial.Location = new System.Drawing.Point(150, 34);
            this.btnDisconnectSerial.Name = "btnDisconnectSerial";
            this.btnDisconnectSerial.Size = new System.Drawing.Size(117, 23);
            this.btnDisconnectSerial.TabIndex = 7;
            this.btnDisconnectSerial.Text = "Connect Serial";
            this.btnDisconnectSerial.UseVisualStyleBackColor = true;
            this.btnDisconnectSerial.Click += new System.EventHandler(this.btnDisconnectSerial_Click);
            // 
            // txtSerialData
            // 
            this.txtSerialData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSerialData.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSerialData.Location = new System.Drawing.Point(181, 327);
            this.txtSerialData.Multiline = true;
            this.txtSerialData.Name = "txtSerialData";
            this.txtSerialData.Size = new System.Drawing.Size(223, 85);
            this.txtSerialData.TabIndex = 45;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // serialPort1
            // 
            this.serialPort1.PortName = "COM3";
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // buttonPositionCommand
            // 
            this.buttonPositionCommand.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPositionCommand.Location = new System.Drawing.Point(284, 158);
            this.buttonPositionCommand.Name = "buttonPositionCommand";
            this.buttonPositionCommand.Size = new System.Drawing.Size(117, 23);
            this.buttonPositionCommand.TabIndex = 74;
            this.buttonPositionCommand.Text = "Send Position";
            this.buttonPositionCommand.UseVisualStyleBackColor = true;
            this.buttonPositionCommand.Click += new System.EventHandler(this.buttonPositionCommand_Click);
            // 
            // textBoxPositionFinal
            // 
            this.textBoxPositionFinal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPositionFinal.Location = new System.Drawing.Point(202, 158);
            this.textBoxPositionFinal.Name = "textBoxPositionFinal";
            this.textBoxPositionFinal.Size = new System.Drawing.Size(64, 22);
            this.textBoxPositionFinal.TabIndex = 72;
            this.textBoxPositionFinal.Text = "0";
            // 
            // textBoxVelACW
            // 
            this.textBoxVelACW.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxVelACW.Location = new System.Drawing.Point(203, 223);
            this.textBoxVelACW.Name = "textBoxVelACW";
            this.textBoxVelACW.Size = new System.Drawing.Size(64, 22);
            this.textBoxVelACW.TabIndex = 78;
            this.textBoxVelACW.Text = "0";
            // 
            // textBoxVelCW
            // 
            this.textBoxVelCW.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxVelCW.Location = new System.Drawing.Point(132, 223);
            this.textBoxVelCW.Name = "textBoxVelCW";
            this.textBoxVelCW.Size = new System.Drawing.Size(64, 22);
            this.textBoxVelCW.TabIndex = 77;
            this.textBoxVelCW.Text = "0";
            // 
            // textBoxACW
            // 
            this.textBoxACW.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxACW.Location = new System.Drawing.Point(202, 191);
            this.textBoxACW.Name = "textBoxACW";
            this.textBoxACW.Size = new System.Drawing.Size(64, 22);
            this.textBoxACW.TabIndex = 76;
            this.textBoxACW.Text = "0";
            // 
            // textBoxCW
            // 
            this.textBoxCW.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxCW.Location = new System.Drawing.Point(132, 190);
            this.textBoxCW.Name = "textBoxCW";
            this.textBoxCW.Size = new System.Drawing.Size(64, 22);
            this.textBoxCW.TabIndex = 75;
            this.textBoxCW.Text = "0";
            // 
            // txtItemsInQueue
            // 
            this.txtItemsInQueue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtItemsInQueue.Location = new System.Drawing.Point(53, 390);
            this.txtItemsInQueue.Name = "txtItemsInQueue";
            this.txtItemsInQueue.Size = new System.Drawing.Size(64, 22);
            this.txtItemsInQueue.TabIndex = 82;
            // 
            // txtBytesToRead
            // 
            this.txtBytesToRead.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBytesToRead.Location = new System.Drawing.Point(53, 339);
            this.txtBytesToRead.Name = "txtBytesToRead";
            this.txtBytesToRead.Size = new System.Drawing.Size(64, 22);
            this.txtBytesToRead.TabIndex = 81;
            // 
            // textBoxPosition
            // 
            this.textBoxPosition.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPosition.Location = new System.Drawing.Point(132, 251);
            this.textBoxPosition.Name = "textBoxPosition";
            this.textBoxPosition.Size = new System.Drawing.Size(64, 22);
            this.textBoxPosition.TabIndex = 83;
            this.textBoxPosition.Text = "0";
            // 
            // textBoxSteps
            // 
            this.textBoxSteps.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxSteps.Location = new System.Drawing.Point(132, 159);
            this.textBoxSteps.Name = "textBoxSteps";
            this.textBoxSteps.Size = new System.Drawing.Size(64, 22);
            this.textBoxSteps.TabIndex = 85;
            this.textBoxSteps.Text = "0";
            // 
            // textBoxTest
            // 
            this.textBoxTest.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxTest.Location = new System.Drawing.Point(519, 261);
            this.textBoxTest.Name = "textBoxTest";
            this.textBoxTest.Size = new System.Drawing.Size(64, 22);
            this.textBoxTest.TabIndex = 87;
            this.textBoxTest.Text = "0";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(645, 260);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(117, 23);
            this.button1.TabIndex = 86;
            this.button1.Text = "Send Position";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(284, 107);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(117, 23);
            this.button2.TabIndex = 89;
            this.button2.Text = "Send Speed";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBoxStepperSpeed
            // 
            this.textBoxStepperSpeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxStepperSpeed.Location = new System.Drawing.Point(202, 107);
            this.textBoxStepperSpeed.Name = "textBoxStepperSpeed";
            this.textBoxStepperSpeed.Size = new System.Drawing.Size(64, 22);
            this.textBoxStepperSpeed.TabIndex = 88;
            this.textBoxStepperSpeed.Text = "100";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(432, 450);
            this.Controls.Add(label2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBoxStepperSpeed);
            this.Controls.Add(this.textBoxTest);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBoxSteps);
            this.Controls.Add(label1);
            this.Controls.Add(this.textBoxPosition);
            this.Controls.Add(this.txtItemsInQueue);
            this.Controls.Add(this.txtBytesToRead);
            this.Controls.Add(label5);
            this.Controls.Add(label4);
            this.Controls.Add(this.textBoxVelACW);
            this.Controls.Add(this.textBoxVelCW);
            this.Controls.Add(this.textBoxACW);
            this.Controls.Add(this.textBoxCW);
            this.Controls.Add(this.buttonPositionCommand);
            this.Controls.Add(label8);
            this.Controls.Add(this.textBoxPositionFinal);
            this.Controls.Add(this.txtSerialData);
            this.Controls.Add(this.comboBoxCOMPorts);
            this.Controls.Add(this.btnDisconnectSerial);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxCOMPorts;
        private System.Windows.Forms.Button btnDisconnectSerial;
        private System.Windows.Forms.TextBox txtSerialData;
        private System.Windows.Forms.Timer timer1;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Button buttonPositionCommand;
        private System.Windows.Forms.TextBox textBoxPositionFinal;
        private System.Windows.Forms.TextBox textBoxVelACW;
        private System.Windows.Forms.TextBox textBoxVelCW;
        private System.Windows.Forms.TextBox textBoxACW;
        private System.Windows.Forms.TextBox textBoxCW;
        private System.Windows.Forms.TextBox txtItemsInQueue;
        private System.Windows.Forms.TextBox txtBytesToRead;
        private System.Windows.Forms.TextBox textBoxPosition;
        private System.Windows.Forms.TextBox textBoxSteps;
        private System.Windows.Forms.TextBox textBoxTest;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBoxStepperSpeed;
    }
}

