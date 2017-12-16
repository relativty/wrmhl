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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wrmhlThread_Lines : wrmhlThread { // wrmhlThread_ReadLines is derived from the common wrmhl Thread.

	// This constructor will call wrmhlThread.wrmhlThread(string portName, int baudRate, int readTimeout)
	public wrmhlThread_Lines(string portName, int baudRate, int readTimeout, int QueueLenght) : base(portName, baudRate, readTimeout, QueueLenght) {
	}

	// This constructor will call wrmhlThread.wrmhlThread(string portName, int baudRate)
	public wrmhlThread_Lines(string portName, int baudRate) : base(portName, baudRate){
	}

	public override string ReadProtocol() { // This is the only one reading protocol for 0.1 Alpha. This is a basique SerialPort ReadLine() method.
			return deviceSerial.ReadLine();
	}

	public override void SendProtocol(object message) { // This is the only one writing protocol for 0.1 Alpha. This is a basique SerialPort WriteLine() method.
		deviceSerial.WriteLine((string) message);
	}
}
