using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wrmhlThread_Lines : wrmhlThread { // wrmhlThread_ReadLines is derived from the common wrmhl Thread.

	// This constructor will call wrmhlThread.wrmhlThread(string portName, int baudRate, int readTimeout)
	public wrmhlThread_Lines(string portName, int baudRate, int readTimeout) : base(portName, baudRate, readTimeout) {
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
