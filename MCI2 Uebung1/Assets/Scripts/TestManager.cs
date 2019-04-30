using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestManager : MonoBehaviour
{

	public float distanceMM;
	public float widthMM;
	public int retrysPerSetup;
	


	private float mmToPixel;
	private List<float> time;
	private List<bool> hit;
	
	
	
	// Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public void HitLeft()
	{

	}

	public void HitRight()
	{

	}

	public void HitBackground()
	{

	}


	/*
	 * TODO: 
	 * Log one csv line per test setup: width + distance + Average Time to switch + Error rate in % +  Tester name
	 * On miss -> directly switch to next target
	 * 
	 * */
}
