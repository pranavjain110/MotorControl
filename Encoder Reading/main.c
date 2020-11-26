#include <stdio.h>
#include<string.h>
#include <msp430.h> 
const unsigned int sizeOfBuffer =50;
unsigned int state = 0, dataByte1, dataByte2, dataWord, escByte, startByteFlag = 0,setFrequencyFlag = 0, flagACW = 0, flagCW = 0,flagPos =0;
volatile unsigned int bufferLength = 0, readIndex = 0, writeIndex = 0, flagByteRx = 0 ;
volatile signed int  posDC = 0;
volatile unsigned char RxByte;
volatile unsigned int buffer[sizeOfBuffer];
char byteRemoved[]=" \n\r";
char message[] = "Data is ready";
char messageBufferOverrun[]= "\n\rBuffer is Full. Can not add more elements!!\n\r";
char messageBufferUnderrun[]= "\n\rBuffer is Empty. Can not remove any elements\n\r";
int i,k, positionX = 0,error =0,positionCurrent,CO;

/**
 * main.c
 */
int main(void)
{
    WDTCTL = WDTPW | WDTHOLD;   // stop watchdog timer


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
    TB0CCR0 = 20000;
    TB0CTL = TBSSEL_1 + MC_1 + ID_3; // AMCLK, UP mode(counts up to TBCCR0, /8

    //Setting Port 3.6 as output for CW rotation
    P3DIR |= BIT6;
    P3OUT &= ~BIT6;

    //Setting Port 3.7 as output for ACW rotation
    P3DIR |=  BIT7;
    P3OUT &= ~BIT7;


    //Setting Port 3.2 & 3.3 for debugging
    P3DIR |=  BIT1;
    P3OUT &= ~BIT1;
    P3DIR |=  BIT2;
    P3OUT &= ~BIT2;


    _EINT();


    while(1)
    {
        __no_operation();                       // For debug only

        positionCurrent = TA1R-TB2R;
        if(positionCurrent < positionX)
        {
            error = positionX-positionCurrent;
            if(error>1)
            {
                P3OUT |= BIT6;
                P3OUT &= ~BIT7;
            }
        }
        else
        {
            error=positionCurrent-positionX;
            if(error>1)
            {
                P3OUT &= ~BIT6;
                P3OUT |= BIT7;
            }
        }

        MPYS = 400;
        OP2 = error;
        CO = RES0;

        if(error>160)
            TB1CCR2 = 0;
        else
            TB1CCR2 = 0xFFFF - CO;








        if(flagByteRx == 1)
        {


            __no_operation();                       // For debug only
            if(bufferLength >0)
            {
                __no_operation();                       // For debug only


                // Reading the buffer
                byteRemoved[0] = buffer[readIndex];
                readIndex++;
                bufferLength--;
                if(readIndex == sizeOfBuffer)
                    readIndex=0;
                //Indicate stop reading buffer
                if(bufferLength <= 0)
                    flagByteRx = 0;

                //State 0 - Start Byte
                if(byteRemoved[0] == 255 || state == 4)
                {
                    state = 0;
                    if(byteRemoved[0] == 255)
                        startByteFlag=1;
                    else
                        startByteFlag=1;
                }
                //State 1 - Byte to indicate direction
                else if ((byteRemoved[0] == 1 || byteRemoved[0] == 2 || byteRemoved[0] == 5)   && state == 0 && startByteFlag == 1)
                {
                    startByteFlag = 0;
                    state = 1;

                    if(byteRemoved[0] == 1)
                    {
                        flagACW =1;
                        flagCW =0;
                        flagPos=0;
                    }
                    if(byteRemoved[0] == 2)
                    {
                        flagACW =0;
                        flagCW =1;
                        flagPos=0;
                    }
                    if(byteRemoved[0] == 5)
                    {
                        flagACW =0;
                        flagCW =0;
                        flagPos=1;
                    }


                }
                //State 2 - Upper Data Byte
                else if (state == 1)
                {
                    dataByte1 = byteRemoved[0];
                    state = 2;
                }
                //State 3 - Lower Data Byte
                else if (state == 2)
                {
                    dataByte2 = byteRemoved[0];
                    state = 3;
                }
                //State 4 - ESC Byte
                else if (state == 3)
                {
                    escByte = byteRemoved[0];
                    __no_operation();

                    //Swtich byte to convert Data-byte from 0 to 255
                    switch( escByte )
                    {
                        case 1:
                            dataByte2 = 255;
                            break;
                        case 2:
                            dataByte1 = 255;
                            break;
                        case 3:
                            dataByte1 = 255;
                            dataByte2 = 255;
                            break;
                        default:
                            break;
                    }
                    __no_operation();

                    //Setting 16 bit register used to set TB1CCR2
                    dataWord = (dataByte1<<8 | dataByte2);
                    //Indicate new PWM to ready to set for DC Motor
                    state = 4;
                    __no_operation();

                    if(flagACW == 1)
                    {
                        P3OUT |=  BIT6;
                        P3OUT &= ~BIT7;
                        setFrequencyFlag =1;


                    }
                    else if(flagCW ==1)
                    {
                        P3OUT &= ~BIT6;
                        P3OUT |=  BIT7;
                        setFrequencyFlag =1;

                    }
                    else if(flagPos == 1)
                    {
                        positionX = dataWord;
                    }

                    __no_operation();
                }
                else
                {
                    startByteFlag=0;
                    __no_operation();
                }
            }
        }
        if(setFrequencyFlag == 1)
        {
            setFrequencyFlag = 0 ;
            TB1CCR2 = dataWord;
            __no_operation();
        }



    }
    return 0;
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
//            sendMessageOverUART(messageBufferOverrun);
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
