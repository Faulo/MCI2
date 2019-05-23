using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;
using System;

public class SetupManager : MonoBehaviour
{
	public bool testActive
	{
		get
		{
			return !transitionScreen.activeSelf;
		}
	}
	public RectTransform leftButton;
	public RectTransform rightButton;
	public RectTransform buttonParent;
	public Canvas canvas;

	public GameObject transitionScreen;
	public TextMeshProUGUI transitionText;
    public TextMeshProUGUI progressText;

    public GlobalTestSetup globalSetupInMM;

	public float transitionTime;
    private float screenDPI;

    public int screenInPixel;
    public float screenInMM;
    const float INCHES_TO_MILLIMETER = 25.4f;

    private IEnumerable<TestSetup> setupsInMM;
	private int currentSetupIndex;
	private int totalWidthPixel;
	private TestManager tM;

	// Start is called before the first frame update
    void Start()
    {
        if (screenInPixel > 0 && screenInMM > 0) {
            screenDPI = screenInPixel * INCHES_TO_MILLIMETER / screenInMM;
            Debug.Log("Calculated DPI to be " + screenDPI);
        }
		tM = gameObject.GetComponent<TestManager>();
		transitionScreen.SetActive(false);
		RestartAll();
    }

    // Update is called once per frame
    void Update()
    {
		//screenDPI = Screen.dpi;
		//Debug.Log(RectTransformUtility.PixelAdjustRect(buttonParent, canvas).width / screenDPI * 2.54f);
		//Debug.Log(Screen.width);
		//Debug.Log(Screen.width / screenDPI * 2.54f);
		//Debug.Log (Screen.)
	}


	public void NextSetup()
	{
		currentSetupIndex++;
		transitionText.text = "Beginne den nächsten Test wenn du bereit bist.";
		if (currentSetupIndex == setupsInMM.Count())
		{
            currentSetupIndex = 0;

			transitionText.text = "Das waren alle Tests.";
		}
		transitionScreen.SetActive(true);
		SetNewSetup();
		StartCoroutine(TransitionTimer());

	}

	public void RestartAll()
	{
		currentSetupIndex = 0;
		totalWidthPixel = (int) RectTransformUtility.PixelAdjustRect(buttonParent, canvas).width;
		SetNewSetup();
	}

	/// <summary>
	/// Sets the button to the width and distance for this Setup
	/// </summary>
	private void SetNewSetup()
	{
		ReCalcPixels();

        progressText.text = string.Format("This is test {0}/{1}", currentSetupIndex+1, setupsInMM.Count());

        var setupInMM = setupsInMM.ElementAt(currentSetupIndex);
        var setupInPixel = setupInMM.InPixel(screenDPI);
        
		tM.SetNewSetup(setupInMM);

		leftButton.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, setupInPixel.width);
		rightButton.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, setupInPixel.width);
		
		float distanceAnchorToAnchor = setupInPixel.distance + setupInPixel.width;
        float offsetFromEdge = (totalWidthPixel - distanceAnchorToAnchor) / 2;
		Vector3 leftPos = leftButton.anchoredPosition3D;
		Vector3 rightPos = rightButton.anchoredPosition3D;

		leftPos.x = offsetFromEdge;
		rightPos.x = offsetFromEdge * -1;
		leftButton.anchoredPosition3D = leftPos;
		rightButton.anchoredPosition3D = rightPos;
	}

	private void ReCalcPixels()
	{
        setupsInMM = globalSetupInMM.GetTestSetups();
	}

	IEnumerator TransitionTimer()
	{
		yield return new WaitForSeconds(transitionTime);
		transitionScreen.SetActive(false);
	}
}
