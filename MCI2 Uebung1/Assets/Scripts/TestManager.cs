using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class TestManager : MonoBehaviour
{

	public float distanceMM;
	public float widthMM;
	//public int retrysPerSetup;
	//public test definition;

	public InputField nameField;
	public Button leftButton;
	public Button rightButton;
		
	private float mmToPixel;
	private List<float> times = new List<float>();
	private List<bool> hits = new List<bool>();
	private bool hitLeft;
	private float timeStampLastHit;
	private CSVLogger logger;
	private bool firstHit = true;
	
	
	// Start is called before the first frame update
    void Start()
    {
		ToggleButton();
		logger = gameObject.GetComponent<CSVLogger>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public void LeftHit()
	{
		if (hitLeft)
		{
			Hit();		
		}
		else
		{
			Miss();
		}
		ToggleButton();
	}

	public void RightHit()
	{
		if (hitLeft)
		{
			Miss();
		}
		else
		{
			Hit();
		}
		ToggleButton();
	}

	public void BackgroundHit()
	{
		Miss();
		ToggleButton();
	}

	public void EndTest ()
	{
		if (hits.Count == 0)
		{
			ResetTest();
			return;
		}

		float averageTime = 0;
		float errorRate = 0;
		for (int i = 0; i < times.Count; i++)
		{
			averageTime += times[i];
			if (hits[i])
			{
				errorRate++;
			}
		}
		averageTime = averageTime / times.Count;
		Debug.Log(errorRate + " | " + hits.Count);
		errorRate = 1 - (errorRate / hits.Count);
		Debug.Log("Time Average: " + averageTime + " | error Rate: " + errorRate);
		logger.LogToCSV(0, 0, averageTime, errorRate, hits.Count, "testName", Time.time);
		ResetTest();
	}

	private void ResetTest()
	{
		times = new List<float>();
		hits = new List<bool>();
		firstHit = true;
	}

	private void ToggleButton()
	{
		hitLeft = !hitLeft;
		ColorBlock leftColors = leftButton.colors;
		ColorBlock rightColors = rightButton.colors;

		if (hitLeft)
		{
			leftColors = SetColor(leftColors, Color.green);
			rightColors = SetColor(rightColors, Color.red);
		}
		else
		{

			leftColors = SetColor(leftColors, Color.red);
			rightColors = SetColor(rightColors, Color.green);
		}

		leftButton.colors = leftColors;
		rightButton.colors = rightColors;
		timeStampLastHit = Time.time;
	}

	private ColorBlock SetColor (ColorBlock block, Color c)
	{
		block.normalColor = c;
		block.highlightedColor = c;
		block.selectedColor = c;
		return block;
	}

	private void Hit()
	{
		Debug.Log("Hit");
		if (firstHit)
		{
			firstHit = false;
			timeStampLastHit = Time.time;
			return;
		}
		Debug.Log(timeStampLastHit - Time.time);
		hits.Add(true);
		times.Add(Time.time - timeStampLastHit);
	}

	private void Miss()
	{
		Debug.Log("Miss");
		if (firstHit)
		{
			firstHit = false;
			timeStampLastHit = Time.time;
			return;
		}
		Debug.Log(timeStampLastHit - Time.time);
		hits.Add(false);
		times.Add(Time.time - timeStampLastHit);
	}
	


	/*
	 * TODO: 
	 * Log one csv line per test setup: width + distance + Average Time to switch + Error rate in % +  Tester name
	 * On miss -> directly switch to next target
	 * 
	 * What is the time of the first button press
	 * */
}
