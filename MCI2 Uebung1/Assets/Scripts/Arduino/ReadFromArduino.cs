using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using UnityEngine.UI;
using System.Text.RegularExpressions;

public class ReadFromArduino : MonoBehaviour
{
	public AnimationCurve deadZone;

	private SerialPort serialPort;

    private int packageSize = 4;
    private Regex packageFormat = new Regex("^[0-9]{4}$");


    // Start is called before the first frame update
    void Start()
    {
		string[] ports = SerialPort.GetPortNames();

        if (ports.Length == 0) {
            throw new System.Exception("no COM ports found?!");
        }

		serialPort = new SerialPort();
		serialPort.PortName = ports[0];
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
		double inputSum = 0;
		int inputCount = 0;
		while (serialPort.BytesToRead > packageSize)
		{
			var byteValue = serialPort.ReadLine();
			if (packageFormat.IsMatch(byteValue)) {
				inputSum += int.Parse(byteValue);
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
