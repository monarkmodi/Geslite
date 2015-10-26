/*
---
Information
---
Program name - Arduino for Kinect gestures
Program version - 1.0
Description - Main window for the controlling arduino components.
Program credits - Created at HackUMass 2015. Open sourced and free to use.
Team - 15
---
 */

// digital pin 2 has a pushbutton attached to it. Give it a name:
int pushButton = 2;
int ledR = 13;
int ledL = 12;
int buz = 11;
// the setup routine runs once when you press reset:
void setup() {
  // initialize serial communication at 9600 bits per second:
  Serial.begin(9600);
  // make the pushbutton's pin an input:
  //pinMode(pushButton, INPUT);
  //Serial.println("Hello World");
  pinMode(ledR,OUTPUT);
  digitalWrite(ledR,LOW);
  pinMode(ledL,OUTPUT);
  digitalWrite(ledL,LOW);
  pinMode(buz,OUTPUT);
  digitalWrite(buz,LOW);
}

// the loop routine runs over and over again forever:
void loop() {
  // read the input pin:
  //int buttonState = digitalRead(pushButton);
  // print out the state of the button:
   
  if(Serial.available()>0)
  {
    int bt = Serial.read();
    //Serial.print("The char:  ");
    // right hand open = light on
    if (bt == 49)
    {
      digitalWrite(ledR,HIGH);
      analogWrite(buz,200);
    }
    else if(bt == 48) 
    {
      digitalWrite(ledR,LOW);
      analogWrite(buz,0);
    }

    if (bt == 51)
    {
      digitalWrite(ledL,LOW);
    }
    else if(bt == 52) 
    {
      digitalWrite(ledL,HIGH);
    }
    //Serial.println(bt, DEC);
  //  String s = Serial.read();
  //  Serial.println();
  }
  delay(1);        // delay in between reads for stability
}
