using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab3App
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnDisconnectSerial_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                serialPort1.Close();
                serialPort1.Dispose();
                btnDisconnectSerial.Text = "Connect Serial";
            }
            else
            {
                serialPort1.Open();
                btnDisconnectSerial.Text = "Disconnect Serial";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            updateSerial();
        }

        private void updateSerial()
        {
            comboBoxCOMPorts.Items.Clear();
            comboBoxCOMPorts.Items.AddRange(System.IO.Ports.SerialPort.GetPortNames());
            if (comboBoxCOMPorts.Items.Count == 0)
                comboBoxCOMPorts.Text = "No COM ports!";
            else
                comboBoxCOMPorts.SelectedIndex = 0;
        }

        private void comboBoxCOMPorts_SelectedIndexChanged(object sender, EventArgs e)
        {
            serialPort1.PortName = comboBoxCOMPorts.SelectedItem.ToString();

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var a = trackBarStepper.Value;

            serialPort1.Encoding = Encoding.UTF32;
            serialPort1.Write(textBoxSteps.Text);

        }
    }
}
