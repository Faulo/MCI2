using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using UnityEngine.UI;
using System.Text.RegularExpressions;

public class ReadFromArduino : MonoBehaviour {
    public AnimationCurve deadZone;

    private SerialPort serialPort;

    private int packageSize = 4;
    private Regex packageFormat = new Regex("^[0-9]{4}$");


    // Start is called before the first frame update
    void Start() {
        string[] ports = SerialPort.GetPortNames();

        if (ports.Length == 0) {
            throw new System.Exception("no COM ports found?!");
        }

        serialPort = new SerialPort {
            PortName = ports[0],
            Parity = Parity.None,
            BaudRate = 115200,
            DataBits = 8,
            StopBits = StopBits.One
        };
        //serialPort.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
        serialPort.Open();
    }

    // Update is called once per frame
    void Update() {
        //int.TryParse(serialPort.ReadLine(), out xValueCurrent);
        double inputSum = 0;
        int inputCount = 0;
        while (serialPort.BytesToRead > packageSize) {
            var byteValue = serialPort.ReadLine();
            if (packageFormat.IsMatch(byteValue)) {
                inputSum += int.Parse(byteValue);
                inputCount++;
            }
        }
        if (inputCount > 0) {
            //Debug.Log(inputSum / inputCount);
            float scaledInput = deadZone.Evaluate((float)inputSum / inputCount);
            //Debug.Log(scaledDeadInput);

            transform.SetX(scaledInput * Screen.width);
        }
    }

    private void OnApplicationQuit() {
        serialPort.Close();
    }
}
