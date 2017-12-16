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

// This class allow you to establish the connection between your device and Unity by setting-up Thread and manage these Thread.
public class wrmhl {

	// ========================================================================================
	// Alpha 0.1 is only using ReadLine protocol. New protocol and implementation are in coming.
	// This tool is initially an intern tool, he will be upgrade step by step to fit more need.
	// ========================================================================================

	private wrmhlThread_Lines deviceReader; // 0.1 Alpha use wrmhlThread_ReadLines class derived from wrmhlThread.

	// gives the thread the vars needed for connecting your device and Unity:
	public void set(string portName, int baudRate, int readTimeout, int QueueLenght){ // Connection requirements.
		deviceReader = new wrmhlThread_Lines(portName, baudRate, readTimeout, QueueLenght); // wrmhlThread_ReadLines will be instancied
		//                                                                            with those vars and use them to connect when wrmhl.connect() will be call.
	}

	// setting up the connection beetwen your device and Unity without readTimeout:
	public void set(string portName, int baudRate){ // Connection requirements.
		deviceReader = new wrmhlThread_Lines(portName, baudRate); // wrmhlThread_ReadLines will be instancied
		//                                                               with those vars and use them to connect when wrmhl.connect() will be call.
	}

	// connect the device and unity
	public void connect(){
		deviceReader.openFlow(); // Open the Serial Port data flow.
		deviceReader.startThread(); // Start the thread.
	}

	// Close the connection beetwen your device and Unity:
	public void close(){
		deviceReader.StopThread(); // Stop the thread and close flow.
	}

	// ========================================================================================

	// read the data from your device:
	public string readQueue(){ // Return the string coming from the device.
		return deviceReader.readQueueThread(); // call the Thread read method.
	}

	public void send(string dataToSend){
		deviceReader.writeThread(dataToSend); // call the Thread write method.
}
}
