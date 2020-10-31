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
            this.comboBoxCOMPorts = new System.Windows.Forms.ComboBox();
            this.btnDisconnectSerial = new System.Windows.Forms.Button();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.trackBarStepper = new System.Windows.Forms.TrackBar();
            this.button1 = new System.Windows.Forms.Button();
            this.textBoxSteps = new System.Windows.Forms.TextBox();
            label2 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarStepper)).BeginInit();
            this.SuspendLayout();
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
            // 
            // trackBarStepper
            // 
            this.trackBarStepper.Location = new System.Drawing.Point(186, 85);
            this.trackBarStepper.Maximum = 60;
            this.trackBarStepper.Minimum = -60;
            this.trackBarStepper.Name = "trackBarStepper";
            this.trackBarStepper.Size = new System.Drawing.Size(348, 45);
            this.trackBarStepper.TabIndex = 33;
            this.trackBarStepper.TickFrequency = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label2.Location = new System.Drawing.Point(9, 85);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(149, 18);
            label2.TabIndex = 34;
            label2.Text = "Stepper Motor Speed";
            label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(402, 136);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(117, 23);
            this.button1.TabIndex = 35;
            this.button1.Text = "Send Command";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label1.Location = new System.Drawing.Point(29, 136);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(104, 18);
            label1.TabIndex = 36;
            label1.Text = "Steps to Move";
            // 
            // textBoxSteps
            // 
            this.textBoxSteps.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxSteps.Location = new System.Drawing.Point(200, 136);
            this.textBoxSteps.Name = "textBoxSteps";
            this.textBoxSteps.Size = new System.Drawing.Size(64, 22);
            this.textBoxSteps.TabIndex = 37;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(546, 342);
            this.Controls.Add(this.textBoxSteps);
            this.Controls.Add(label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(label2);
            this.Controls.Add(this.trackBarStepper);
            this.Controls.Add(this.comboBoxCOMPorts);
            this.Controls.Add(this.btnDisconnectSerial);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trackBarStepper)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxCOMPorts;
        private System.Windows.Forms.Button btnDisconnectSerial;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.TrackBar trackBarStepper;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBoxSteps;
    }
}

