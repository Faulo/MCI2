using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetupManager : MonoBehaviour
{
	public RectTransform leftButton;
	public RectTransform rightButton;
	public RectTransform buttonParent;
	public Canvas canvas;

	public Vector2[] distanceWidthPerSetupInCentimeters;


	public float screenDPI;

	// Start is called before the first frame update
    void Start()
    {
		
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
}
