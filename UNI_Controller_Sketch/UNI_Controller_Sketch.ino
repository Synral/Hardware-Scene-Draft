int Left_Joystick = 0;

int Right_Joystick = 0;

void setup()
{
  Serial.begin(9600);
  //INPUT_PULLUP sets the internal resistors on for the digital input pins; doing this sets HIGH to be their default state while LOW is when the button is pushed
  pinMode(2, INPUT_PULLUP);
  pinMode(3, INPUT_PULLUP);
  pinMode(4, INPUT_PULLUP);
  pinMode(5, INPUT_PULLUP);
  pinMode(6, INPUT_PULLUP);
  pinMode(7, INPUT_PULLUP);
  pinMode(8, INPUT_PULLUP);
  pinMode(9, INPUT_PULLUP);
  pinMode(10, INPUT_PULLUP);
  pinMode(11, INPUT_PULLUP);
  pinMode(12, INPUT_PULLUP);
  //pin 13 is skipped because it is attached to the LED and the built-in resistors cannot handle button + LED
  pinMode(A0, INPUT_PULLUP);
  pinMode(A1, INPUT_PULLUP);
  pinMode(A2, INPUT_PULLUP);
  pinMode(A3, INPUT_PULLUP);
  pinMode(A4, INPUT);
  pinMode(A5, INPUT);
}

void loop()
{
  if (digitalRead(A3) == LOW) {
    Serial.print("Start Button");
  }
  if (digitalRead(A2) == LOW) {
    Serial.print("D-pad Up");
  }
  if (digitalRead(2) == LOW) {
    Serial.print("D-pad Right");
  }
  if (digitalRead(3) == LOW) {
    Serial.print("D-pad Down");
  }
  if (digitalRead(4) == LOW) {
    Serial.print("D-pad Left");
  }
  if (digitalRead(5) == LOW) {
    Serial.print("Button Y");
  }
  if (digitalRead(6) == LOW) {
    Serial.print("Button B");
  }
  if (digitalRead(7) == LOW) {
    Serial.print("Button A");
  }
  if (digitalRead(8) == LOW) {
    Serial.print("Button X");
  }
  if (digitalRead(9) == LOW) {
    Serial.print("Left Bumper");
  }
  if (digitalRead(10) == LOW) {
    Serial.print("Left Trigger");
  }
  if (digitalRead(11) == LOW) {
    Serial.print("Right Bumper");
  }
  if (digitalRead(12) == LOW) {
    Serial.print("Right Trigger");
  }
  if (digitalRead(A0) == LOW) {
    Serial.print("Home Button");
  }
  if (digitalRead(A1) == LOW) {
    Serial.print("Select Button");
  }
  if (Left_Joystick != analogRead(A4)) {
    Left_Joystick = analogRead(A4);
    Serial.print("Left Joystick");
  }
  if (Right_Joystick != analogRead(A5)) {
    Right_Joystick = analogRead(A5);
    Serial.print("Right Joystick");
  }
}
