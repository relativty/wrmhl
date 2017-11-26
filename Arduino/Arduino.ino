/*
 MIT License

Copyright (c) 2017 Maxime Coutte Peroumal Corne

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
 */

 
// uncomment "NATIVE_USB" if you're using ARM CPU (Arduino DUE, Arduino M0, ..)
#define NATIVE_USB

// uncomment "SERIAL_USB" if you're using non ARM CPU (Arduino Uno, Arduino Mega, ..)
//#define SERIAL_USB


void setup() {
  #ifdef NATIVE_USB
    SerialUSB.begin(1); //Baudrate is irevelant for Native USB
  #endif

  #ifdef SERIAL_USB
    Serial.begin(250000); // You can choose any baudrate, just need to also change it in Unity.
    while (!Serial); // wait for Leonardo enumeration, others continue immediately
  #endif

  
}

void loop() {
  sendData("Hello World!");
  delay(5);
}

void sendData(String data){
   #ifdef NATIVE_USB
    SerialUSB.println(data); // need a end-line
  #endif

  #ifdef SERIAL_USB
    Serial.println(data); // need a end-line
  #endif
}

