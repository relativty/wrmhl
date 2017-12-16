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
using System.Threading;
using System.IO.Ports;

public abstract class wrmhlThread { // wrmhlThread is the common Thread for receiving and sending data, but it's protocols depend on the derived class you use.
																		//  protocols are definined by this.ReadProtocol() and this.SendProtocol() wich are overide by the top layer of this class.
																		// with alpha 0.1 the only one top layer is wormhlThread_ReadLines.
	public SerialPort deviceSerial;

	// ===========================================================================
	// needed vars for SerialPort.
	// ===========================================================================

	private string portName;
	private int baudRate;
	private int readTimeout = 100;

	private Thread WRMHLthread;

	private Queue outputQueue; // From Unity to Arduino.
	private Queue inputQueue; // From Arduino to Unity.

	private int QueueLenght = 1;

	public wrmhlThread(string portName, int baudRate, int readTimeout, int QueueLenght) { // the constructor take the vars coming from wrmhl.cs .
			this.portName = portName;
			this.baudRate = baudRate;
			this.readTimeout = readTimeout;
			this.QueueLenght = QueueLenght;
	}

	public wrmhlThread(string portName, int baudRate) { // no readTimeout.
		this.portName = portName;
		this.baudRate = baudRate;
	}

	public void startThread() { // Creates and starts the thread
		outputQueue = Queue.Synchronized( new Queue() );
		inputQueue  = Queue.Synchronized( new Queue() );

		WRMHLthread = new Thread (ThreadLoop);
		WRMHLthread.Start ();
	}

	public void openFlow() { // Open the SerialPort with the vars given by wrmhl.
		deviceSerial = new SerialPort(this.portName, this.baudRate); // define the SerialPort.
		deviceSerial.ReadTimeout = this.readTimeout; // set the readTimeout.
		deviceSerial.Open(); // Start the data Flow.
	}

	public bool looping = true;

	public void StopThread () { // This method is used to stop the thread.
 		lock (this) // avoid thread issues.
 		{
 		looping = false; // This var is used for the thread's while loop by the threadIsLooping method.
 		}
	}

	public bool threadIsLooping () { // This method is used to return to the thread looping's var value.
 		lock (this) // avoid thread issues.
 	{
 		return looping;
 	}
	}

	public string readQueueThread(){ // return the data stocked in the Queue. Independent from the protocol.
		if (inputQueue.Count == 0)
			return null;

		return (string)inputQueue.Dequeue ();
	}


		public string readLatestThread(){ // return the data stocked in the Queue. Independent from the protocol.
			return null; // TO DO: Delete it
		}

	public void writeThread(string dataToSend){ // add the data to the write Queue. Independent from the protocol.
		outputQueue.Enqueue (dataToSend);
	}

	public void ThreadLoop() { // Main thread loop

		while (threadIsLooping ())
		{
			// read data
			object dataComingFromDevice = ReadProtocol();
			if (dataComingFromDevice != null) {
				if (inputQueue.Count < QueueLenght)
				{
						inputQueue.Enqueue(dataComingFromDevice);
				}
		}
			// Send data
			if (outputQueue.Count != 0)
			{
				object dataToSend = outputQueue.Dequeue();
				SendProtocol(dataToSend);
			}
		}

		deviceSerial.Close(); // Close th e data Flow.
}

		public abstract string ReadProtocol(); // with Alpha 0.1 Overide by the protocol wrmhlThread_ReadLines to be used as reading protocol.

		public abstract void SendProtocol(object message); // with Alpha 0.1 Overide by the protocol wormhlThread_ReadLines to be used as reading protocol.
}
