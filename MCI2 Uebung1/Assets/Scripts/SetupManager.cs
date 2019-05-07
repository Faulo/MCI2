using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SetupManager : MonoBehaviour
{
	public RectTransform leftButton;
	public RectTransform rightButton;
	public RectTransform buttonParent;
	public Canvas canvas;

	public GameObject transitionScreen;
	public TextMeshProUGUI transitionText;

	public Vector2[] distanceWidthPerSetupInMM;

	public float transitionTime;
	public float screenDPI;

	private Vector2Int[] distanceWidthPerSetupInPixels;
	private int currentSetupIndex;
	private int totalWidthPixel;
	private TestManager tM;

	// Start is called before the first frame update
    void Start()
    {
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
		if (currentSetupIndex == distanceWidthPerSetupInPixels.Length)
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

		tM.SetNewSetup(distanceWidthPerSetupInMM[currentSetupIndex].x, distanceWidthPerSetupInMM[currentSetupIndex].y);

		leftButton.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, distanceWidthPerSetupInPixels[currentSetupIndex].y);
		rightButton.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, distanceWidthPerSetupInPixels[currentSetupIndex].y);
		
		int distanceAnchorToAnchor = distanceWidthPerSetupInPixels[currentSetupIndex].x + (distanceWidthPerSetupInPixels[currentSetupIndex].y);
		int offsetFromEdge = (totalWidthPixel - distanceAnchorToAnchor) / 2;
		Vector3 leftPos = leftButton.anchoredPosition3D;
		Vector3 rightPos = rightButton.anchoredPosition3D;

		leftPos.x = offsetFromEdge;
		rightPos.x = offsetFromEdge * -1;
		leftButton.anchoredPosition3D = leftPos;
		rightButton.anchoredPosition3D = rightPos;
	}

	private void ReCalcPixels()
	{
		distanceWidthPerSetupInPixels = new Vector2Int[distanceWidthPerSetupInMM.Length];
		for (int i = 0; i < distanceWidthPerSetupInMM.Length; i++)
		{
			Vector2Int tmp = new Vector2Int((int) (distanceWidthPerSetupInMM[i].x * (screenDPI / 2.54f / 10))
				, (int)(distanceWidthPerSetupInMM[i].y * (screenDPI / 2.54f / 10)));
			Debug.Log(tmp);
			distanceWidthPerSetupInPixels[i] = tmp;
		}
	}

	IEnumerator TransitionTimer()
	{
		yield return new WaitForSeconds(transitionTime);
		transitionScreen.SetActive(false);
	}
}
