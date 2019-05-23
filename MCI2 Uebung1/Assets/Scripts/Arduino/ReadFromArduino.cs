using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using UnityEngine.UI;

public class ReadFromArduino : MonoBehaviour
{
	public AnimationCurve deadZone;

	private SerialPort serialPort;
	

	
	
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
		serialPort.Parity = Parity.None;
		serialPort.BaudRate = 115200;
		serialPort.DataBits = 8;
		serialPort.StopBits = StopBits.One;
		//serialPort.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
		serialPort.Open();
		//StartCoroutine(Read());
		

	}

	// Update is called once per frame
	void Update()
    {
		//int.TryParse(serialPort.ReadLine(), out xValueCurrent);
		int byteSize = 4;
		double inputSum = 0;
		int inputCount = 0;
		while (serialPort.BytesToRead > byteSize)
		{
			var byteValue = serialPort.ReadLine();
			if (byteValue.Length == byteSize && int.TryParse(byteValue, out int inputValue))
			{
				inputSum += inputValue;
				inputCount++;
			}
		}
		if (inputCount > 0)
		{
			//Debug.Log(inputSum / inputCount);
			float scaledDeadInput = deadZone.Evaluate((float)inputSum / inputCount);
			//Debug.Log(scaledDeadInput);

			gameObject.GetComponent<RectTransform>().position = new Vector3(scaledDeadInput * Screen.width, Screen.height * 0.5f, 0);
		}
	}

	private void OnApplicationQuit()
	{
		serialPort.Close();
	}

	IEnumerator Read()
	{
		while (true)
		{
			yield return null;
			Debug.Log(serialPort.BytesToRead);
			//int.TryParse(serialPort.ReadLine(), out xValueCurrent);
			//Debug.Log(xValueCurrent);
		}
	}

	/*private void DataReceivedHandler(
							object sender,
							SerialDataReceivedEventArgs e)
	{
		Debug.Log(serialPort.BytesToRead);
		/*SerialPort port = (SerialPort)sender;
		byte[] data = new byte[port.BytesToRead];
		port.Read(data, 0, data.Length);
		string s = Encoding.GetEncoding("Windows-1252").GetString(data);
		Debug.Log(s);
	}*/
}
