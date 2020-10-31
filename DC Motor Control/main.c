#include <stdio.h>
#include<string.h>
#include <msp430.h> 
const unsigned int sizeOfBuffer =50;
unsigned int state = 0, dataByte1, dataByte2, dataWord, escByte, startByteFlag = 0,setFrequencyFlag = 0, flagACW = 0, flagCW = 0;
volatile unsigned int bufferLength = 0, readIndex = 0, writeIndex = 0, flagByteRx = 0 ;
volatile unsigned char RxByte;
volatile unsigned int buffer[sizeOfBuffer];
char byteRemoved[]=" \n\r";
char message[] = "Data is ready";
char messageBufferOverrun[]= "\n\rBuffer is Full. Can not add more elements!!\n\r";
char messageBufferUnderrun[]= "\n\rBuffer is Empty. Can not remove any elements\n\r";
int i;


/**
 * hello.c
 */

void sendMessageOverUART(char *ptr)
{

    __no_operation();                       // For debug only
    while (*ptr != '\x00') // Base case
    {
        while ((UCA0IFG & UCTXIFG)==0); //Check if no transmission is taking place ie. if transmit flag is clear
        UCA0TXBUF = *ptr; //echo byte to serial port
        ++ptr;
    }
    return;
}
int main(void)

{
    WDTCTL = WDTPW | WDTHOLD;   // stop watchdog timer
    __no_operation();                       // For debug only


//Setup UART for user input
    // Configure clocks
    CSCTL0 = 0xA500;                        // Write password to modify CS registers
    CSCTL1 = DCOFSEL0 + DCOFSEL1;           // DCO = 8 MHz
    CSCTL2 = SELM0 + SELM1 + SELA0 + SELA1 + SELS0 + SELS1; // MCLK = DCO, ACLK = DCO, SMCLK = DCO


    //For timer clock
    //CSCTL3 |= DIVA_4;    //fACLK/32 (therefore ACLK  = 250,000Hz)

    // Configure ports for UCA0
    P2SEL0 &= ~(BIT0 + BIT1);
    P2SEL1 |= BIT0 + BIT1;

    //Configure UCA0 on Port 2.0 and 2.1
    UCA0CTLW0 = UCSSEL0;
    UCA0BRW = 52;
    UCA0MCTLW = 0x4900 + UCOS16 + UCBRF0;

    UCA0IE |= UCRXIE; //eUSCI_A interrupt enable for when a byte is received



//    //Set up LED1
//    PJDIR |= BIT0;
//    PJOUT |= BIT0; //Turn on LED1

    //_______________________Setting TImerB1 (TB1.1)_____________________________

    //___________P3.4 = TB1.1
    P3DIR |= BIT4;
    P3SEL0 |= BIT4;

    __no_operation();
//  TB1CCTL0 = CCIE;
//    TB1CCTL1 = CCIE; // TBCCR0 interrupt enabled
    TB1CCR0 = 0xFFFF;
    TB1CCR1 = 0x7FFF;// Not required in
    TB1CTL = TBSSEL_1 + MC_1 + ID_0;                 // AMCLK, UP mode
//    __no_operation();
//    TB1CCR1 = 0x6FFF;
    TB1CCTL1 |=  OUTMOD_3;// Toggle Mode
    __no_operation();





    //Setting Port 3.5 as output
    P3DIR |= BIT5;
    P3OUT |= BIT5;

    //Setting Port 3.6 as output
    P3DIR |= BIT6;
    //P3OUT |= BIT5;




    _EINT();

    //______Code  to implement circular buffer_____

    while(1)
    {
        if(flagByteRx == 1)
        {
            __no_operation();                       // For debug only
            if(bufferLength >0)
            {
                __no_operation();                       // For debug only


                byteRemoved[0] = buffer[readIndex];

                readIndex++;
                bufferLength--;
                if(readIndex == sizeOfBuffer)
                    readIndex=0;
                __no_operation();                       // For debug only
                sendMessageOverUART("\n\rElement Removed: ");
                sendMessageOverUART(byteRemoved);
                if(bufferLength == 0)
                    flagByteRx = 0;



             //__________________________________Setting timer______________________________________________//
                if(byteRemoved[0] == 255 || state == 4)
                {
                    state = 0;
                    if(byteRemoved[0] == 255)
                        startByteFlag=1;
                    else
                        startByteFlag=1;

                }
                else if ((byteRemoved[0] == 1 || byteRemoved[0] == 2)   && state == 0 && startByteFlag == 1)
                {
                    startByteFlag = 0;
                    state = 1;

                    if(byteRemoved[0] == 1)
                    {
                        flagACW =1;
                        flagCW =0;
                    }
                    if(byteRemoved[0] == 2)
                    {
                        flagACW =0;
                        flagCW =1;
                    }
                }
                else if (state == 1)
                {
                    dataByte1 = byteRemoved[0];
                    state = 2;
                }
                else if (state == 2)
                {
                    dataByte2 = byteRemoved[0];
                    state = 3;
                }
                else if (state == 3)
                {
                    escByte = byteRemoved[0];
                    __no_operation();

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

                    dataWord = (dataByte1<<8 | dataByte2);
                    setFrequencyFlag =1;
                    state = 4;
                    __no_operation();

                    if(flagACW == 1)
                    {
                        P3OUT |= BIT5;
                        P3OUT &= ~BIT6;

                    }
                    else
                    {
                        P3OUT &= ~BIT5;
                        P3OUT |= BIT6;
                    }
                    __no_operation();
                    // ASK TA's HELP
                    //TB1CCR1 = dataWord;


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
            TB1CCR1 = dataWord;
            __no_operation();
        }

    }



    // global interrupt enable
    return 0;
}




#pragma vector = USCI_A0_VECTOR
__interrupt void USCI_A0_ISR(void)
{
    __no_operation();                       // For debug only
    RxByte = UCA0RXBUF; //store byte in RX buffer in a variable RxByte
    while ((UCA0IFG & UCTXIFG)==0); //Check if no transmission is taking place ie. if transmit flag is clear
            UCA0TXBUF =RxByte;

            //Add element to the buffer
    if (bufferLength <= sizeOfBuffer)
    {
        if(bufferLength == sizeOfBuffer)
        {
            sendMessageOverUART(messageBufferOverrun);
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
    if(bufferLength>=5)
        flagByteRx = 1;

    __no_operation();                       // For debug only
}




