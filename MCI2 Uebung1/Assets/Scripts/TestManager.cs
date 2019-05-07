using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TestManager : MonoBehaviour
{
	public TMP_InputField nameField;
	public Button leftButton;
	public Button rightButton;
	public float timeForEachSetup;

	private float mmToPixel;
	private List<float> times = new List<float>();
	private List<bool> hits = new List<bool>();
	private bool hitLeft;
	private float timeStampLastHit;
	private CSVLogger logger;
	private bool firstHit = true;

	private float width;
	private float distance;
	private float difficulty;

	private SetupManager sM;


	// Start is called before the first frame update
	void Start()
    {
		ToggleButton();
		logger = gameObject.GetComponent<CSVLogger>();
		sM = gameObject.GetComponent<SetupManager>();
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
		logger.LogToCSV(width, distance, difficulty, averageTime, errorRate, hits.Count, nameField.text, System.DateTime.Now);
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
			StartCoroutine(TimeLimit());
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
	
	public void SetNewSetup(float d, float w)
	{
		EndTest();
        StopAllCoroutines();

        distance = d;
		width = w;
		difficulty = Mathf.Log((2 * distance) / width, 2); //log2((2xDistance) / Width);
    }

	IEnumerator TimeLimit()
	{
		yield return new WaitForSeconds(timeForEachSetup);
		sM.NextSetup();
	}

	/*
	 * TODO: 
	 * Log one csv line per test setup: width + distance + Average Time to switch + Error rate in % +  Tester name
	 * On miss -> directly switch to next target
	 * 
	 * What is the time of the first button press
	 * */
}
