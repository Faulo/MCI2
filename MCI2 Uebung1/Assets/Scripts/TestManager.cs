using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TestManager : MonoBehaviour {
    public TMP_InputField nameField;
    public Button leftButton;
	public Button rightButton;
	public float timeForEachSetup;

    private CSVLogger logger;
    private TestSetup setup;
    private TestResult result;
    private SetupManager sM;

    private bool hitLeft;
    private float timeStampLastHit;

	// Start is called before the first frame update
	void Start()
    {
        ToggleButton();
		logger = gameObject.GetComponent<CSVLogger>();
		sM = gameObject.GetComponent<SetupManager>();
		//InvokeRepeating("click",1,1);
    }

	private void click()
	{
		leftButton.onClick.Invoke();
	}

    // Update is called once per frame
    void Update()
    {
		
    }

	

	public void LeftHit()
	{
        Debug.Log("LeftHit!");

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

	public void RightHit() {
        Debug.Log("RightHit!");

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

	public void BackgroundHit() {
        Debug.Log("BackgroundHit!");

        Miss();
		ToggleButton();
	}

	private void EndTest ()
	{
        if (setup != null && result != null) {
            Debug.Log("Time Average: " + result.averageTime + " | error Rate: " + result.errorRate);
            logger.LogToCSV(setup, result);
        }
		ResetTest();
	}

	private void ResetTest()
	{
        result = null;
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
	}

	private ColorBlock SetColor (ColorBlock block, Color c)
	{
		block.normalColor = c;
		block.highlightedColor = c;
		block.selectedColor = c;
		return block;
	}

	private void Hit() {
        //Debug.Log("Hit");
        Record(true);
	}
	private void Miss() {
        //Debug.Log("Miss");
        Record(false);
	}
    private void Record(bool hit) {
        if (result == null) {
            result = new TestResult(nameField.text);
            StartCoroutine(TimeLimit());
        } else {
            result.AddRecord(Time.time - timeStampLastHit, hit);
        }
        timeStampLastHit = Time.time;
    }
	
	public void SetNewSetup(TestSetup setup)
	{
		EndTest();
        StopAllCoroutines();
        this.setup = setup;
    }

	IEnumerator TimeLimit()
	{
		yield return new WaitForSeconds(timeForEachSetup);
		sM.NextSetup();
	}
}
