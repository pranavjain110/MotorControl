using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2_Axis_Gantry
{


    public partial class Form1 : Form
    {
        ConcurrentQueue<Int32> dataQueue = new ConcurrentQueue<Int32>();
        ConcurrentQueue<string> timeQueue = new ConcurrentQueue<string>();
        ConcurrentQueue<Int32> CWPos = new ConcurrentQueue<Int32>();
        ConcurrentQueue<Int32> ACWPos = new ConcurrentQueue<Int32>();
        ConcurrentQueue<string> CWTime = new ConcurrentQueue<string>();
        ConcurrentQueue<string> ACWTime = new ConcurrentQueue<string>();
        int dataState = 6;

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
                if (dataQueue.TryDequeue(out int dequeuedElement))
                {
                    timeQueue.TryDequeue(out string dequeuedTime);
                    txtSerialData.AppendText(" , " + dequeuedElement.ToString());

                    if (dequeuedElement == 255)
                        dataState = 0; 
                    else
                        switch(dataState)
                        {
                            case 1:
                                dataState = 2;
                                dataByte1_H = dequeuedElement;
                                break;
                            case 2:
                                dataState = 3;
                                dataByte1_L = dequeuedElement;
                                break;
                            case 3:
                                dataState = 4;
                                dataByte2_H = dequeuedElement;
                                break;
                            case 4:
                                dataState = 5;
                                dataByte2_L = dequeuedElement;
                                break;
                            case 5:
                                dataState = 6;
                                var escByte = dequeuedElement;
                                if (escByte >= 8)
                                {
                                    dataByte1_H = 255;
                                    escByte -= 8;
                                }
                                if (escByte >= 4)
                                {
                                    dataByte1_L = 255;
                                    escByte -= 4;
                                }
                                if (escByte >= 2)
                                {
                                    dataByte2_H = 255;
                                    escByte -= 2;
                                }
                                if (escByte >= 1)
                                {
                                    dataByte2_L = 255;
                                    escByte -= 1;
                                }
                                if (escByte != 0)
                                {
                                    //error here
                                    Console.WriteLine("check error here");
                                }
                                setDataFlag = 1;
                                break;
                            default:
                                break;
                        }

                    //All common code
                    countCW = countCW_H * 256 + countCW_L;
                    textBoxCW.Text = countCW.ToString();

                                            countACW = countACW_H * 256 + countACW_L;
                        textBoxACW.Text = countACW.ToString();



                        CWPos.Enqueue(countCW);
                        int countDiff = 0;
                        if (CWPos.Count > 20)
                        {
                            CWPos.TryDequeue(out int elementRemoved);
                            countDiff = (countCW - elementRemoved);
                        }
                        CWTime.Enqueue(dequeuedTime);
                        if (CWTime.Count > 20)
                        {
                            CWTime.TryDequeue(out var timeRemoved);

                            var diffInSeconds = (Convert.ToDateTime(dequeuedTime) - Convert.ToDateTime(timeRemoved)).TotalSeconds;
                            textTimeFwd.Text = diffInSeconds.ToString();

                            var velocityCW = (countDiff * 60) / (diffInSeconds * 125);
                            textBoxVelCW.Text = velocityCW.ToString();
                        }

                        //C2
                        countACW = countACW_H * 256 + countACW_L;
                        textBoxACW.Text = countACW.ToString();
                        ACWPos.Enqueue(countACW);

                        if (ACWPos.Count > 20)
                        {
                            ACWPos.TryDequeue(out int elementRemoved);
                            countDiff = (countACW - elementRemoved);
                        }
                        ACWTime.Enqueue(dequeuedTime);
                        if (ACWTime.Count > 20)
                        {
                            ACWTime.TryDequeue(out var timeRemoved);

                            var diffInSeconds = (Convert.ToDateTime(dequeuedTime) - Convert.ToDateTime(timeRemoved)).TotalSeconds;
                            textTimeRev.Text = diffInSeconds.ToString();

                            var velocityACW = (countDiff * 60) / (diffInSeconds * 125);
                            if (velocityACW > 500)
                            {
                                var b = 2222;
                            }
                            textBoxVelACW.Text = velocityACW.ToString();

                            RecordData(velocityACW, dequeuedTime);

                        }
                    }

                    }
                }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
