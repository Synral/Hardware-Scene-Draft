# Hardware UNI Final Project Repository
Hardware Assignment UNI Final Project
This is final assignment for the Hardware course and includes all Unity related files for the purpose of the live demo/interactive scene, arduino code/sketch, written report, and a link to the video. This is built off a branch of the assignment 4/5 repository as its own separate branch to prevent changing files meant for assignment 4/5.


Video: https://youtu.be/izDFr_9LF8M

Slides: https://docs.google.com/presentation/d/1dr8jbQTjJKI8Z7TVXSZ5QyRBwVR2b5MM2Oq-2xbamjs/edit?usp=sharing

TinkerCAD Simulation: https://www.tinkercad.com/things/hwjd9nnKiT1-uni-circuit-schematics/editel?sharecode=0zN-002wE_rMnMuKrH2g1HqCwWRB43PCGf1XQ0cxzPk

Interactive Scene:
This scene holds the UNI controller and a button to start the game. To play the game, hit the Start/Stop button and click on the listed buttons at the bottom of the screen in the correct order. Doing it correctly will result in a “WIN” text on the bottom right corner of the screen while being wrong will cause it to say “LOSE”. You can stop the game at any point by clicking the button again, which will hide the game UI at the bottom and result in a “LOSE” screen. Testing can be done with a physical Arduino using digital pins 2-12 and analog pins 0-5. Make sure to set the port to the corresponding USB port and Baud Rate to match in the Arduino code (Serial.begin(9600) default).

Controls:
Hold right-click and move the mouse to rotate the controller, and left click will cast a ray to show the name of the button you click at the top. The input map takes in mousePosition, mouseDelta, LeftClick, and RightClick of a mouse (required). If you are have an Arduino attached, any changes that make the digital pins go from HIGH to LOW will result in the top text box changing to the corresponding button input expected, and any analog change within analog pins A4 and A5 will result in the corresponding joystick from being shown in the top text box.
