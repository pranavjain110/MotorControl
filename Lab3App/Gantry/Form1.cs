using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gantry
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
        int dataByte1_H, dataByte1_L, countCW, dataByte2_H, dataByte2_L, countACW, setDataFlag = 0;
        ushort posDC_current = 0, posStepper_Current = 0;
        ushort posDC = 0, posStepper = 0;

        private void button1_Click(object sender, EventArgs e)
        {
            byte[] bytestosend = { Convert.ToByte(textBoxTest.Text), Convert.ToByte(textBoxTest.Text) };
            

            serialPort1.Encoding = Encoding.Default;
            serialPort1.Write(bytestosend,0,2);      //Byte3: 

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var speedStepperPercentage = Convert.ToUInt16(textBoxStepperSpeed.Text);

            var speedStepper = Convert.ToUInt16(35000 - (195 * speedStepperPercentage));
            sendViaUART(2, 0, speedStepper);
        }

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
                        dataState = 1;
                    else
                        switch (dataState)
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

                    if (setDataFlag == 1)
                    {
                        setDataFlag = 0;
                        //All common code
                        countCW = dataByte1_H * 256 + dataByte1_L;
                        textBoxCW.Text = countCW.ToString();

                        countACW = dataByte2_H * 256 + dataByte2_L;
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
                            var velocityCW = (countDiff * 60) / (diffInSeconds * 125);
                            textBoxVelCW.Text = velocityCW.ToString();
                        }

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
                            var velocityACW = (countDiff * 60) / (diffInSeconds * 125);
                            textBoxVelACW.Text = velocityACW.ToString();
                        }

                        var posoition = Convert.ToInt32(textBoxCW.Text) - Convert.ToInt32(textBoxACW.Text);
                        textBoxPosition.Text = posoition.ToString();

                    }

                }
            }
        }

        private void buttonPositionCommand_Click(object sender, EventArgs e)
        {

            int posDC_cm = Convert.ToInt16(textBoxPositionFinal.Text) + 8;
            int posStepper_cm = Convert.ToInt16(textBoxSteps.Text) + 8;

            var posDC_ticks = posDC_cm * 18.75;
            var posStepper_steps = posStepper_cm * 625;

            int subPointFactor_DC = Math.Abs(Convert.ToInt16((posDC_ticks - posDC_current) / 7));
            int subPointFactor_Stepper = Math.Abs(Convert.ToInt16((posStepper_steps - posStepper_Current )/ 250));

            var subPointFactor = subPointFactor_Stepper;
            if (subPointFactor_DC > subPointFactor_Stepper)
                subPointFactor = subPointFactor_DC;


            for (int i= 1; i <= subPointFactor; i++)
            {
                posDC =Convert.ToUInt16(((i *1.0/ subPointFactor) * (posDC_ticks - posDC_current)) + posDC_current);
                posStepper = Convert.ToUInt16(((i * 1.0 / subPointFactor) * (posStepper_steps - posStepper_Current)) + posStepper_Current);

                if(i%10 == 0 && posStepper_steps != posStepper_Current) 
                {
                    int milliseconds = 1000;
                    Thread.Sleep(milliseconds);
                }

                sendViaUART(1, posDC, posStepper);
            }
            posDC_current = posDC;
            posStepper_Current = posStepper;

        }

        private void sendViaUART(int applicationCode, ushort posDC, ushort posStepper)
        {
            int escByte = 0;

            byte upperDC = (byte)(posDC >> 8);
            byte lowerDC = (byte)(posDC & 0xff);

            byte upperStepper = (byte)(posStepper >> 8);
            byte lowerStepper = (byte)(posStepper & 0xff);
            //char character = (char)hScrollBarDC.Value;


            serialPort1.Encoding = Encoding.Default;
            if (upperDC == 255)
            {
                upperDC = 0;
                escByte += 8;
            }

            if (lowerDC == 255)
            {
                lowerDC = 0;
                escByte += 4;
            }
            if (upperStepper == 255)
            {
                upperStepper = 0;
                escByte += 2;
            }
            if (lowerStepper == 255)
            {
                lowerStepper = 0;
                escByte += 1;
            }
            serialPort1.Encoding = Encoding.Default;
            byte[] bytestosend = { upperDC, lowerDC, upperStepper, lowerStepper };

            serialPort1.Write(((char)255).ToString());          //Byte1: 255
            serialPort1.Write(((char)applicationCode).ToString());            //Byte2: 1 Represends Position command
            //serialPort1.Write(((char)upperDC).ToString());      //Byte3: 
            //serialPort1.Write(((char)lowerDC).ToString());      //Byte4:
            //serialPort1.Write(((char)upperStepper).ToString()); //Byte5:
            //serialPort1.Write(((char)lowerStepper).ToString()); //Byte6:
            serialPort1.Write(bytestosend, 0, 4);      //Byte3: 

            serialPort1.Write(((char)escByte).ToString());      //Byte7: 
        }
    }
}
