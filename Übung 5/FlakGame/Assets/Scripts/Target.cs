using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
	public int pointsForKill = 100;
	public float lifeTime = 10f;

	// Start is called before the first frame update
	void Awake()
	{
		Destroy(gameObject, lifeTime);
	}

	// Update is called once per frame
	void Update()
    {
        
    }

	public void Hit()
	{
		GameManager.instance.AddScore(pointsForKill);
		Destroy(gameObject); 
	}
}
