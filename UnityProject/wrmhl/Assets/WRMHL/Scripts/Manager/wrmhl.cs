using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This class allow you to establish the connection between your device and Unity by setting-up Thread.
public class wrmhl {

	// ========================================================================================
	// Alpha 0.1 is only using ReadLine protocol. New protocol and implementation are in coming.
	// This tool is initially an intern tool, he will be upgrade step by step to fit more need.
	// ========================================================================================

	private wrmhlThread_Lines deviceReader; // 0.1 Alpha use wrmhlThread_ReadLines class derived from wrmhlThread.

	// gives the thread the vars needed for connecting your device and Unity:
	public void set(string portName, int baudRate, int readTimeout){ // Connection requirements.
		deviceReader = new wrmhlThread_Lines(portName, baudRate, readTimeout); // wrmhlThread_ReadLines will be instancied
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

	public string readLatest(){ // Return the string coming from the device.
		return deviceReader.readLatestThread(); // call the Thread read method.
	}

	public void send(string dataToSend){
		deviceReader.writeThread(dataToSend); // call the Thread write method.
}
}
