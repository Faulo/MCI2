using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using System.Text;

public class ReadFromArduino : MonoBehaviour
{
	public GameObject testObject;

	private SerialPort serialPort;
	private int xValueCurrent;
	
	
	// Start is called before the first frame update
    void Start()
    {
		string[] ports = SerialPort.GetPortNames();

		foreach (var port in ports)
		{
			Debug.Log(port);
		}

		serialPort = new SerialPort();
		serialPort.PortName = "COM7";
		/*serialPort.Parity = Parity.None;
		serialPort.BaudRate = 115200;
		serialPort.DataBits = 8;
		serialPort.StopBits = StopBits.One;*/
		//serialPort.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
		serialPort.Open();
	}

	// Update is called once per frame
	void Update()
    {

		//Debug.Log(serialPort.ReadExisting());
		
		//do
		//{
		/*string lastValue = serialPort.ReadLine();
		if (lastValue != null)
		{
			Debug.Log(lastValue);
		} else
		{
			Debug.Log("no new vaules");
		}*/
		//} while ()
		int.TryParse(serialPort.ReadLine(), out xValueCurrent);
		Debug.Log(xValueCurrent);
		testObject.transform.position = new Vector3(xValueCurrent * 0.1f, 0, 0);
    }

	private void OnApplicationQuit()
	{
		serialPort.Close();
	}

	/*private static void DataReceivedHandler(
							object sender,
							SerialDataReceivedEventArgs e)
	{
		SerialPort port = (SerialPort)sender;
		byte[] data = new byte[port.BytesToRead];
		port.Read(data, 0, data.Length);
		string s = Encoding.GetEncoding("Windows-1252").GetString(data);
		Debug.Log(s);
	}*/
}
