using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;
using System;

public class CSVLogger : MonoBehaviour
{
	public string delimiter = ";";

	private StreamWriter tsw;

	
	// Start is called before the first frame update
    void Start()
    {
		Setup();
    }

	private void Setup()
	{
		string filePath = Application.dataPath + "/Resources/" + "TestSession.csv"; // + DateTime.Now.ToShortTimeString() + ".csv"
		//File.CreateText(filePath );
		tsw = new StreamWriter(filePath);
		string[] headRow = { "Width", "Distance" , "Difficulty", "Average Time", "Error Rate", "Clicks", "Tester", "Time Stamp"};
		WriteLineToCSV(headRow);
	}

	public void LogToCSV (TestSetup setup, TestResult result)
	{
		string[] lineData = {
            setup.width.ToString(),
            setup.distance.ToString(),
            setup.difficulty.ToString(),
            result.averageTime.ToString(),
            result.errorRate.ToString(),
            result.testSize.ToString(),
            result.name,
            result.date.ToLongTimeString()
        };
		WriteLineToCSV(lineData);
	}

	private void WriteLineToCSV(string[] lineData)
	{
		string line = string.Join(delimiter, lineData);
		tsw.WriteLine(line);
		tsw.Flush();
	}
}
