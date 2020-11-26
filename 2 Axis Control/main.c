#include <stdio.h>
#include<string.h>
#include <msp430.h>
const unsigned int sizeOfBuffer = 280, sizeOfBufferMotor = 40;
unsigned int state = 6, dataByteDC_H, dataByteDC_L, dataByteStepper_H, dataByteStepper_L, escByte, startByteFlag = 0,setFrequencyFlag = 0, flagACW = 0, flagCW = 1;
unsigned int dataWordDC, dataWordStepper, posDesiredDC = 0, stepsDesiredStepper;
volatile unsigned int bufferLength = 0, bufferLengthMotor =0, readIndex = 0, writeIndex = 0, flagByteRx = 0,steps=0,stepsDesired = 0, moveStepperFlag = 1 ;
volatile unsigned int  readIndexMotor=0, writeIndexMotor =0;
volatile unsigned int setSpeedFlag = 0 , setPositionFlag = 0, setDataFlag;
volatile unsigned char RxByte;
volatile unsigned int buffer[sizeOfBuffer],bufferDC[sizeOfBufferMotor],bufferStepper[sizeOfBufferMotor] ;
char byteRemoved[]=" \n\r";//,byteRemovedMotorDC[]=" \n\r";//byteRemovedMotorStepper[]=" \n\r" ;
unsigned int byteRemovedMotorStepper, byteRemovedMotorDC;
char message[] = "Data is ready";
char messageBufferOverrun[]= "\n\rBuffer is Full. Can not add more elements!!\n\r";
char messageBufferUnderrun[]= "\n\rBuffer is Empty. Can not remove any elements\n\r";
unsigned int stepperState,i,j;
int positionCurrent, error = 0, CO = 0;
unsigned const int stepperStateTable[] =  { 1, 0, 0, 0,  //State 1
                                            1, 0, 1, 0,  //State 2
                                            0, 0, 1, 0,  //State 3
                                            0, 1, 1, 0,  //State 4
                                            0, 1, 0, 0,  //State 5
                                            0, 1, 0, 1,  //State 6
                                            0, 0, 0, 1,  //State 7
                                            1, 0, 0, 1 }; //State 8

int main(void)
{

     WDTCTL = WDTPW | WDTHOLD;   // stop watchdog timer


    //_______________Setup UART for user input______________________________
    // Configure clocks
    CSCTL0 = 0xA500;                        // Write password to modify CS registers
    CSCTL1 = DCORSEL;           // DCO = 16 MHz, DCOFSEL0 =0, DCOFSEL1 =0
    CSCTL2 = SELM0 + SELM1 + SELA0 + SELA1 + SELS0 + SELS1; // MCLK = DCO, ACLK = DCO, SMCLK = DCO
    CSCTL3 =  DIVA__2 ; //ACLK = 8MHz

    // Configure ports for UCA0
    P2SEL0 &= ~(BIT0 + BIT1);
    P2SEL1 |= BIT0 + BIT1;

    //Configure UCA0
    UCA0CTLW0 = UCSSEL__ACLK; //ACLK
    UCA0BRW = 52;
    UCA0MCTLW = 0x4900 + UCOS16 + UCBRF0;
    UCA0IE |= UCRXIE; //eUSCI_A interrupt enable for when a byte is received


    //_______________________Setting TImerB1 (TA0.1) for stepper_____________________________

    TA0CCTL1 |= CCIE; // TBCCR0 interrupt enabled
    TA0CCR0 = 0x3C00;
//    TA0CCR1 = 0xFFFF/8;
    TA0CTL = TASSEL__SMCLK + MC_1 + ID_0; // AMCLK, UP mode
    TA0CCTL1 |=  OUTMOD_4;// Toggle Mode
    __no_operation();

    //Setting port P1.3, P1.4, P1.5 and P1.6 as output
    P1DIR |= BIT3;
    P1DIR |= BIT4;
    P1DIR |= BIT5;
    P1DIR |= BIT6;
//    P1OUT |= BIT3 + BIT4 + BIT5 + BIT6;
    stepperState = 1;

    //Setting port P4.0 as output for solonoid mosfet
    P4DIR |= BIT0;
    P4OUT &= ~BIT0; //Turn solenoid on
    P4OUT = BIT0;   //Turn solenoid off

    //_________Code for DC Motor____________

    //______Setting P1.1 and P3.4 to read encoder via D flip flop______
    // Make Port 1.1 as TA1CLK
    P1DIR  &= ~BIT1; //0
    P1SEL1 |=  BIT1; //1
    P1SEL0 &= ~BIT1; //0
    //Setting TA1
    TA1CTL |=  TASSEL_0 + MC_2 ; //TA1CLK , Continuous Mode

    // Make Port 3.4 as TB2CLK
    P3DIR  &= ~BIT4; //0
    P3SEL1 |=  BIT4; //1
    P3SEL0 |=  BIT4; //1
    //Setting TB1
    TB2CTL |= TASSEL_0 + MC_2 ; //TB2CLK , Continuous Mode


    //____________________________DC Motor Control________________________________
    //______________Setting TImerB1 (TB1.2) for generating PWM
    // P3.5 = TB1.2
    P3DIR  |= BIT5;
    P3SEL0 |= BIT5;

    TB1CCR0 = 0xFFFF;
    TB1CCR2 = 0xEFFF;//Motor Stopped by default
    TB1CTL = TBSSEL_1 + MC_1 + ID_0;    // AMCLK, UP mode, /1
    TB1CCTL2 |=  OUTMOD_3;// Toggle Mode

    //_____________Setting TImerB0 (TB0.2) for regularly sending reading over UART
    TB0CCTL2 = CCIE; // TBCCR1 interrupt enabled
//    TB0CCR0 = 20000;
    TB0CCR0 = 0xFFFF;;
    TB0CTL = TBSSEL_1 + MC_1 + ID_3; // AMCLK, UP mode(counts up to TBCCR0, /8)

    //Setting Port 3.6 as output for CW rotation
    P3DIR |= BIT6;
    P3OUT &= ~BIT6;

    //Setting Port 3.7 as output for ACW rotation
    P3DIR |=  BIT7;
    P3OUT &= ~BIT7;

    _EINT();

    while(1)
    {

        positionCurrent = TA1R-TB2R;
        if(positionCurrent < posDesiredDC)
        {
            error = posDesiredDC-positionCurrent;
            if(error>1)
            {
                P3OUT |= BIT6;
                P3OUT &= ~BIT7;
                TB1CCR2 = 0xFFFF;
            }
        }
        else
        {
            error=positionCurrent-posDesiredDC;
            if(error>1)
            {
                P3OUT &= ~BIT6;
                P3OUT |= BIT7;
                TB1CCR2 = 0xFFFF;
            }
        }

        MPYS = 2500;
        OP2 = error;
        CO = RES0;

        if(error>25)
            TB1CCR2 = 0;
        else
            TB1CCR2 = 0xFFFF - CO;




        if(flagByteRx == 1 && setDataFlag == 0)
        {
            __no_operation();                       // For debug only
            if(bufferLength > 0)
            {
                byteRemoved[0] = buffer[readIndex];
                readIndex++;
                bufferLength--;

                if(readIndex == sizeOfBuffer)
                    readIndex=0;

                if(bufferLength == 0)
                    flagByteRx = 0;


                // Move to a state based on the byte read
                if(byteRemoved[0] == 255)
                    state = 0;
                else
                    switch(state)
                    {
                        case 0:  //Differentiate between position and speed data
                            switch(byteRemoved[0])
                            {
                                case 1:  //Position Related Data
                                    state = 1;
                                    setPositionFlag = 1;
                                    setSpeedFlag = 0;
                                    __no_operation();                       // For debug only
                                    break;
                                case 2: //Speed Related Data
                                    state = 1;
                                    setPositionFlag = 0;
                                    setSpeedFlag = 1;
                                    __no_operation();                       // For debug only
                                    break;
                                default:
                                    if(byteRemoved[0] == 255)
                                        state = 0;
                                    else
                                        state = 6; //Undefined state
                                    break;
                            }
                            break;

                        case 1:
                            dataByteDC_H = byteRemoved[0];
                            state = 2;
                            break;

                        case 2:
                            dataByteDC_L = byteRemoved[0];
                            state = 3;
                            break;

                        case 3:
                            dataByteStepper_H = byteRemoved[0];
                            state = 4;
                            break;

                        case 4:
                            dataByteStepper_L = byteRemoved[0];
                            state = 5;
                            break;

                        case 5:
                            state = 6; //This is an undefined state
                            escByte = byteRemoved[0];
                            //Convert Data Bytes back to 255
                            if (escByte >=8)
                            {
                                dataByteDC_H = 255;
                                escByte -= 8;
                            }
                            if (escByte >=4)
                            {
                                dataByteDC_L = 255;
                                escByte -= 4;
                            }
                            if (escByte >= 2)
                            {
                                dataByteStepper_H = 255;
                                escByte -= 2;
                            }
                            if (escByte >= 1)
                            {
                                dataByteStepper_L = 255;
                                escByte -= 1;
                            }
                            if(escByte!=0)
                            {
                                //error here
                                __no_operation();                       // For debug only
                            }

                            dataWordDC = (dataByteDC_H<<8 | dataByteDC_L);
                            dataWordStepper = (dataByteStepper_H<<8 | dataByteStepper_L);
//                            setDataFlag = 1;
                            __no_operation();                       // For debug only


                            if(setSpeedFlag == 1)
                            {
                                setSpeedFlag = 0;
                                TA0CCR0 = dataWordStepper; //Stepper Speed; set 0x3C00 or more
                            }
                            else if (bufferLengthMotor <= sizeOfBufferMotor)
                            {
                                if(bufferLength == sizeOfBuffer)
                                {
                                    __no_operation;
                                    //Code should not be reaching here
                                }
                                else
                                {
                                    bufferDC[writeIndexMotor]=dataWordDC;
                                    bufferStepper[writeIndexMotor]=dataWordStepper;
                                    writeIndexMotor++;
                                    bufferLengthMotor++;
                                    if(writeIndexMotor == sizeOfBufferMotor)
                                        writeIndexMotor = 0;
                                }
                            }

                            break;

                        default:
                            //Some Data loss has taken Place to reach here
                            __no_operation();                       // For debug only
                            break;
                    }

            }

        __no_operation;
        }

        if(bufferLengthMotor >= 1 && stepsDesired == steps && error<6)
        {
            setDataFlag = 0;

            byteRemovedMotorDC = bufferDC[readIndexMotor];
            byteRemovedMotorStepper = bufferStepper[readIndexMotor];

            readIndexMotor++;
            bufferLengthMotor--;

            if(readIndexMotor == sizeOfBufferMotor)
                readIndexMotor=0;



            if(setPositionFlag == 1)
            {
                //setPositionFlag = 0 ;
                posDesiredDC = byteRemovedMotorDC;
                stepsDesired = byteRemovedMotorStepper ;
                TA0CCTL1 |= CCIE; // TACCR0 interrupt enabled for stepper
            }

            else
            {
                //Code should not be reaching here
                __no_operation();                       // For debug only
            }
        }


    }

    return 0;
}


//ISR
#pragma vector = USCI_A0_VECTOR
__interrupt void USCI_A0_ISR(void)
{
    __no_operation();                       // For debug only
    RxByte = UCA0RXBUF; //store byte in RX buffer in a variable RxByte
//    while ((UCA0IFG & UCTXIFG)==0); //Check if no transmission is taking place ie. if transmit flag is clear
//            UCA0TXBUF =RxByte;
    //Add element to the buffer
    if (bufferLength <= sizeOfBuffer)
    {
        if(bufferLength == sizeOfBuffer)
        {
            __no_operation;
            //Code should not be reaching here
        }
        else
        {
            buffer[writeIndex]=RxByte;
            writeIndex++;
            bufferLength++;
            if(writeIndex == sizeOfBuffer)
                writeIndex = 0;
        }
    }
    flagByteRx = 1;
    __no_operation();                       // For debug only
}

#pragma vector = TIMER0_A1_VECTOR
__interrupt void Timer_A0 (void)
{
    if(stepsDesired > steps)
    {
        flagCW = 1;
        moveStepperFlag = 1;
    }
    else if(stepsDesired < steps)
    {
        moveStepperFlag = 1;
        flagACW = 1;
    }
    else if(stepsDesired == steps)
    {
        moveStepperFlag = 0;
        flagACW = 0;
        __no_operation();
        TA0CCTL1 &= ~CCIE; // TBCCR0 interrupt disabled

    }

    if(moveStepperFlag == 1)
    {
      switch( TA0IV )
      {
          case 2:
              if(flagACW == 1){
                  stepperState--;
                  steps--;
              }
              else{
                  stepperState++;
                  steps++;
              }
              if(stepperState == 9)
                  stepperState=1;
              if(stepperState == 0)
                  stepperState=8;

              j= (stepperState - 1) * 4;
//
//              P1OUT &= ~BIT3 + ~BIT4 + ~BIT5 + ~BIT6;
//              P1OUT |= BIT3 & stepperStateTable[j + 0]<<3 ; //Blue
//              P1OUT |= BIT4 & stepperStateTable[j + 2]<<4 ;
//              P1OUT |= BIT5 & stepperStateTable[j + 1]<<5 ;
//              P1OUT |= BIT6 & stepperStateTable[j + 3]<<6 ;

              if(BIT3 & stepperStateTable[j + 0]<<3)
                  P1OUT |= BIT3;
              else
                  P1OUT &= ~BIT3;

              if(BIT4 & stepperStateTable[j + 2]<<4 )
                  P1OUT |= BIT4;
              else
                  P1OUT &= ~BIT4;

              if( BIT5 & stepperStateTable[j + 1]<<5 )
                  P1OUT |= BIT5;
              else
                  P1OUT &= ~BIT5 ;

              if(BIT6 & stepperStateTable[j + 3]<<6 )
                  P1OUT |= BIT6 ;
              else
                  P1OUT &= ~BIT6 ;


//              TB1CTL |= TBCLR;
              __no_operation();                       // For debug only
              break;

          default:
              __no_operation();                       // For debug only
                  break;
      }
    }
}

#pragma vector = TIMER0_B1_VECTOR
__interrupt void Timer0_B1 (void)

{
    P3OUT ^= BIT1;
    int escVar =0;

    switch( TB0IV )
    {
      case 4:

          while ((UCA0IFG & UCTXIFG)==0); //Check if no transmission is taking place ie. if transmit flag is clear
                  UCA0TXBUF = 255;
          while ((UCA0IFG & UCTXIFG)==0); //Check if no transmission is taking place ie. if transmit flag is clear
          if(TA1R>>8 == 255)
          {
              UCA0TXBUF = 0;
              escVar +=8;
          }
          else
              UCA0TXBUF = TA1R>>8;

          while ((UCA0IFG & UCTXIFG)==0); //Check if no transmission is taking place ie. if transmit flag is clear
          if((TA1R<<8)>>8 == 255)
            {
                UCA0TXBUF = 0;
                escVar +=4;
            }
          else
              UCA0TXBUF = TA1R;

          while ((UCA0IFG & UCTXIFG)==0); //Check if no transmission is taking place ie. if transmit flag is clear
          if(TB2R>>8 == 255)
          {
              UCA0TXBUF = 0;
              escVar +=2;
          }
          else
              UCA0TXBUF =TB2R>>8;

          while ((UCA0IFG & UCTXIFG)==0); //Check if no transmission is taking place ie. if transmit flag is clear
          if((TB2R<<8)>>8 == 255)
            {
                UCA0TXBUF = 0;
                escVar +=1;
            }
          else
                  UCA0TXBUF =TB2R;
          while ((UCA0IFG & UCTXIFG)==0); //Check if no transmission is taking place ie. if transmit flag is clear
                  UCA0TXBUF = escVar;
          break;
      default:
          __no_operation;
              break;
    }
    P3OUT ^= BIT2;
}

