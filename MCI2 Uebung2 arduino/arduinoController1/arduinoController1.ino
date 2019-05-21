int xInputPin = A0;
int yInputPin = A1;

// the setup function runs once when you press reset or power the board
void setup() {

  
  // initialize digital pin LED_BUILTIN as an output.
  pinMode(LED_BUILTIN, OUTPUT);
  Serial.begin(115200);
  //pinMode(switchPin, INPUT); 
}

// the loop function runs over and over again forever
void loop() {
  //digitalWrite(LED_BUILTIN, HIGH);   // turn the LED on (HIGH is the voltage level)
  //delay(500);                        // wait for a second
  //digitalWrite(LED_BUILTIN, LOW);    // turn the LED off by making the voltage LOW
  //delay(500);                        // wait for a second

  //Serial.print("test \n");

  //sensorValue = analogRead(sensorPin);
  delay(10);                           // 20 ist gut; 10 ist zu schnell; 
  Serial.print(analogRead(xInputPin));
  Serial.println();
  //Serial.print(analogRead(yInputPin));
  /*if (analogRead(xInputPin) > 540) {
    Serial.print(1,DEC);
  }else {
    Serial.print(2,DEC);
  }*/
}
