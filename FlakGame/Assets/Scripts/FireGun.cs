using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireGun : MonoBehaviour
{
	public GameObject bullet;
	public Transform EndPoint;
	public float speed = 5;
	public float roundsPerSecond = 5;

	private float timeSinceLastBullet;
	
	// Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (true)
		{
			if (timeSinceLastBullet > 1 / roundsPerSecond)
			{
				timeSinceLastBullet = 0;
				Fire();
			}
		}

		timeSinceLastBullet += Time.deltaTime;
    }

	private void Fire()
	{
		var temp = Instantiate(bullet);
		temp.transform.position = EndPoint.position;
		temp.GetComponent<Rigidbody>().velocity = EndPoint.up * speed;

	}
}
