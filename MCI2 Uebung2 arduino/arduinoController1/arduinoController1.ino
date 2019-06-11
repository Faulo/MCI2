int xInputPin = A0;
int yInputPin = A1;
int xCalibrationZero = 512;

// the setup function runs once when you press reset or power the board
void setup() {
  // initialize digital pin LED_BUILTIN as an output.
  pinMode(LED_BUILTIN, OUTPUT);
  Serial.begin(115200);
}

// the loop function runs over and over again forever
void loop() {
  //let's print 4-byte chunks
  char buf[4];
  sprintf(buf, "%04d", analogRead(xInputPin));
  Serial.println(buf);
}
