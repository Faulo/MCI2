using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	public float lifeTime = 5f;
	public bool permanent = false;

    // Start is called before the first frame update
    void Awake()
    {
		if (!permanent)
		{
			Destroy(gameObject, lifeTime);
		}
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.GetComponent<Target>())
		{
			collision.gameObject.GetComponent<Target>().Hit();
		}

		if (!permanent)
		{
			Destroy(gameObject);
		}
	}
}
