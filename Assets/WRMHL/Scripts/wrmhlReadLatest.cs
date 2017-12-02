using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
This script is used to read the latest data coming from the device. For instance,
If arduino send ->
								{"1",
								"2",
								"3",}
readLatest() will return ->
								"3"

This is the perfect script for integration that need speed and low latency.
If you need to avoid data loose take a look to wrmhlRead.
*/

public class wrmhlReadLatest : MonoBehaviour {

	wrmhl myDevice = new wrmhl(); // wrmhl is the bridge beetwen your computer and hardware.

	[Tooltip("SerialPort of your device.")]
	public string portName = "COM8";

	[Tooltip("Baudrate")]
	public int baudRate = 250000;


	[Tooltip("Timeout")]
	public int ReadTimeout = 20;

	void Start () {
		myDevice.set (portName, baudRate, ReadTimeout); // This method set the communication with the following vars;
		//                              Serial Port, Baud Rates and Read Timeout.
		myDevice.connect (); // This method open the Serial communication with the vars previously given.
	}

	// Update is called once per frame
	void Update () {
		print (myDevice.readLatest () ); // myDevice.read() return the data coming from the device using thread.
	}

	void OnApplicationQuit() { // close the Thread and Serial Port
		myDevice.close();
	}
}
