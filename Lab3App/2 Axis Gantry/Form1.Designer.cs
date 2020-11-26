namespace _2_Axis_Gantry
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
            System.Windows.Forms.Label label1;
            this.comboBoxCOMPorts = new System.Windows.Forms.ComboBox();
            this.btnDisconnectSerial = new System.Windows.Forms.Button();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.buttonPositionCommand = new System.Windows.Forms.Button();
            this.textBoxPositionFinal = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.txtItemsInQueue = new System.Windows.Forms.TextBox();
            this.txtBytesToRead = new System.Windows.Forms.TextBox();
            this.txtSerialData = new System.Windows.Forms.TextBox();
            label8 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label8.Location = new System.Drawing.Point(18, 128);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(62, 18);
            label8.TabIndex = 73;
            label8.Text = "Position";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label1.Location = new System.Drawing.Point(18, 128);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(59, 18);
            label1.TabIndex = 73;
            label1.Text = "Go To: ";
            label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // comboBoxCOMPorts
            // 
            this.comboBoxCOMPorts.FormattingEnabled = true;
            this.comboBoxCOMPorts.Location = new System.Drawing.Point(13, 14);
            this.comboBoxCOMPorts.Name = "comboBoxCOMPorts";
            this.comboBoxCOMPorts.Size = new System.Drawing.Size(121, 21);
            this.comboBoxCOMPorts.TabIndex = 8;
            // 
            // btnDisconnectSerial
            // 
            this.btnDisconnectSerial.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDisconnectSerial.Location = new System.Drawing.Point(148, 12);
            this.btnDisconnectSerial.Name = "btnDisconnectSerial";
            this.btnDisconnectSerial.Size = new System.Drawing.Size(117, 23);
            this.btnDisconnectSerial.TabIndex = 7;
            this.btnDisconnectSerial.Text = "Connect Serial";
            this.btnDisconnectSerial.UseVisualStyleBackColor = true;
            this.btnDisconnectSerial.Click += new System.EventHandler(this.btnDisconnectSerial_Click);
            // 
            // serialPort1
            // 
            this.serialPort1.PortName = "COM3";
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // buttonPositionCommand
            // 
            this.buttonPositionCommand.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPositionCommand.Location = new System.Drawing.Point(330, 128);
            this.buttonPositionCommand.Name = "buttonPositionCommand";
            this.buttonPositionCommand.Size = new System.Drawing.Size(117, 23);
            this.buttonPositionCommand.TabIndex = 74;
            this.buttonPositionCommand.Text = "Send Position";
            this.buttonPositionCommand.UseVisualStyleBackColor = true;
            // 
            // textBoxPositionFinal
            // 
            this.textBoxPositionFinal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPositionFinal.Location = new System.Drawing.Point(128, 127);
            this.textBoxPositionFinal.Name = "textBoxPositionFinal";
            this.textBoxPositionFinal.Size = new System.Drawing.Size(64, 22);
            this.textBoxPositionFinal.TabIndex = 72;
            this.textBoxPositionFinal.Text = "0";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(128, 127);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(64, 22);
            this.textBox1.TabIndex = 72;
            this.textBox1.Text = "0";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(330, 128);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(117, 23);
            this.button1.TabIndex = 74;
            this.button1.Text = "Send Position";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // txtItemsInQueue
            // 
            this.txtItemsInQueue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtItemsInQueue.Location = new System.Drawing.Point(21, 416);
            this.txtItemsInQueue.Name = "txtItemsInQueue";
            this.txtItemsInQueue.Size = new System.Drawing.Size(64, 22);
            this.txtItemsInQueue.TabIndex = 76;
            // 
            // txtBytesToRead
            // 
            this.txtBytesToRead.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBytesToRead.Location = new System.Drawing.Point(21, 365);
            this.txtBytesToRead.Name = "txtBytesToRead";
            this.txtBytesToRead.Size = new System.Drawing.Size(64, 22);
            this.txtBytesToRead.TabIndex = 75;
            // 
            // txtSerialData
            // 
            this.txtSerialData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSerialData.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSerialData.Location = new System.Drawing.Point(287, 228);
            this.txtSerialData.Multiline = true;
            this.txtSerialData.Name = "txtSerialData";
            this.txtSerialData.Size = new System.Drawing.Size(419, 148);
            this.txtSerialData.TabIndex = 77;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtSerialData);
            this.Controls.Add(this.txtItemsInQueue);
            this.Controls.Add(this.txtBytesToRead);
            this.Controls.Add(this.button1);
            this.Controls.Add(label1);
            this.Controls.Add(this.buttonPositionCommand);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(label8);
            this.Controls.Add(this.textBoxPositionFinal);
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
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button buttonPositionCommand;
        private System.Windows.Forms.TextBox textBoxPositionFinal;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtItemsInQueue;
        private System.Windows.Forms.TextBox txtBytesToRead;
        private System.Windows.Forms.TextBox txtSerialData;
    }
}

