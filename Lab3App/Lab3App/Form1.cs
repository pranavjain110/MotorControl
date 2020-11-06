using System;
using System.Collections.Concurrent;
using System.Text;
using System.Windows.Forms;

namespace Lab3App
{
    public partial class Form1 : Form
    {

        ConcurrentQueue<Int32> dataQueue = new ConcurrentQueue<Int32>();
        ConcurrentQueue<string> timeQueue = new ConcurrentQueue<string>();
        ConcurrentQueue<Int32> CWPos = new ConcurrentQueue<Int32>();
        ConcurrentQueue<Int32> ACWPos = new ConcurrentQueue<Int32>();
        ConcurrentQueue<string> CWTime = new ConcurrentQueue<string>();
        ConcurrentQueue<string> ACWTime = new ConcurrentQueue<string>();

        int countCW_H, countCW_L, countCW, countACW_H, countACW_L, countACW;
        int dataState = 0;
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

        private void chartPosition_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var a = hScrollBarDC.Value;

            char character = (char)hScrollBarDC.Value;
            textBoxSteps.Text = (a.ToString());
            serialPort1.Encoding = Encoding.Default;
            serialPort1.Write(((char)255).ToString());  //1 255
            if (checkBoxCW.Checked == true)
                serialPort1.Write(((char)1).ToString());    //2 Dir
            else
                serialPort1.Write(((char)2).ToString());    //2 Dir

            serialPort1.Write(character.ToString());    //3


            serialPort1.Write(((char)254).ToString());  //4



            serialPort1.Write(((char)0).ToString());  //5

        }

        private void checkBoxCW_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxCW.Checked == true)
                checkBoxACW.Checked = false;
            else
                checkBoxACW.Checked = true;

        }

        private void checkBoxACW_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxACW.Checked == true)
                checkBoxCW.Checked = false;
            else
                checkBoxCW.Checked = true;
        }

        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            int newByte = 0;
            int bytesToRead;


            bytesToRead = serialPort1.BytesToRead;
            while (bytesToRead != 0)
            {
                newByte = serialPort1.ReadByte();
                //serialDataString = serialDataString + newByte.ToString() + ", ";
                dataQueue.Enqueue(newByte);
                timeQueue.Enqueue(DateTime.Now.ToString("h:mm:ss.fff"));
                bytesToRead = serialPort1.BytesToRead;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {




            if (serialPort1.IsOpen)
                txtBytesToRead.Text = serialPort1.BytesToRead.ToString();
            txtItemsInQueue.Text = dataQueue.Count.ToString();

            while (dataQueue.Count > 0)
            {

                double valueToPrint;
                bool flagPlot = false;

                if (dataQueue.TryDequeue(out int dequeuedElement))
                {
                    timeQueue.TryDequeue(out string dequeuedTime);
                    txtSerialData.AppendText(" , " + dequeuedElement.ToString());

                    if (dequeuedElement == 255)
                    {
                        dataState = 1;
                        flagPlot = false;
                    }
                    else if (dataState == 1)
                    {
                        dataState = 2;
                        countCW_H = dequeuedElement;
                        flagPlot = false;

                    }
                    else if (dataState == 2)
                    {
                        flagPlot = true;
                        dataState = 3;

                        countCW_L = dequeuedElement;
                        countCW = countCW_H * 256 + countCW_L;
                        textBoxCW.Text = countCW.ToString();
                        CWPos.Enqueue(countCW);
                        int countDiff = 0;
                        if (CWPos.Count > 2)
                        {
                            CWPos.TryDequeue(out int elementRemoved);
                            countDiff = (countCW - elementRemoved);
                        }
                        CWTime.Enqueue(dequeuedTime);
                        if (CWTime.Count > 2)
                        {
                            CWTime.TryDequeue(out var timeRemoved);

                            var diffInSeconds = (Convert.ToDateTime(dequeuedTime) - Convert.ToDateTime(timeRemoved)).TotalSeconds;
                            textTimeFwd.Text = diffInSeconds.ToString();

                            var velocityCW = (countDiff * 60) / (diffInSeconds * 125);
                            textBoxVelCW.Text = velocityCW.ToString();
                        }

                    }
                    else if (dataState == 3)
                    {
                        flagPlot = false;
                        dataState = 4;
                        countACW_H = dequeuedElement;
                    }
                    else if (dataState == 4)
                    {
                        flagPlot = true;
                        dataState = 5;
                        countACW_L = dequeuedElement;
                        countACW = countACW_H * 256 + countACW_L;
                        textBoxACW.Text = countACW.ToString();
                        ACWPos.Enqueue(countACW);
                        int countDiff = 0;
                        if (ACWPos.Count > 2)
                        {
                            ACWPos.TryDequeue(out int elementRemoved);
                            countDiff = (countACW - elementRemoved);
                        }
                        ACWTime.Enqueue(dequeuedTime);
                        if (ACWTime.Count > 2)
                        {
                            ACWTime.TryDequeue(out var timeRemoved);

                            var diffInSeconds = (Convert.ToDateTime(dequeuedTime) - Convert.ToDateTime(timeRemoved)).TotalSeconds;
                            textTimeRev.Text = diffInSeconds.ToString();

                            var velocityACW = (countDiff * 60) / (diffInSeconds * 125);
                            textBoxVelACW.Text = velocityACW.ToString();


                        }

                    }

                    if (flagPlot == true)
                    {
                        valueToPrint = Math.Sin(Convert.ToInt32(textBoxPosition.Text) * 360 * Math.PI / (125 * 180));
                        chartPosition.Series["Series1"].Points.AddXY(dequeuedTime, valueToPrint);
                        if (chartPosition.Series["Series1"].Points.Count > 150)
                            chartPosition.Series["Series1"].Points.RemoveAt(0);
                    }
                }

                var posoition = Convert.ToInt32(textBoxCW.Text) - Convert.ToInt32(textBoxACW.Text);
                textBoxPosition.Text = posoition.ToString();

                var frequency = Math.Abs(Convert.ToDouble(textBoxVelACW.Text) - Convert.ToDouble(textBoxVelCW.Text)) / 60;
                textBoxFreq.Text = frequency.ToString();
                var Vel = (Convert.ToDouble(textBoxVelACW.Text) - Convert.ToDouble(textBoxVelCW.Text));
                chartVelocity.Series["Series1"].Points.AddXY( DateTime.Now.ToString("h:mm:ss.fff"), Vel);
                if (chartVelocity.Series["Series1"].Points.Count > 150)
                    chartVelocity.Series["Series1"].Points.RemoveAt(0);

            }
        }
    }
}
