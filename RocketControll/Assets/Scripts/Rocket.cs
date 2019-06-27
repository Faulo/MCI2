using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
	private Rigidbody rb;

	private Vector3 startPos;
	private Quaternion startRot;

	
	// Start is called before the first frame update
    void Start()
    {
		startPos = transform.position;
		startRot = transform.rotation;
		rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Fire1") == 1)
		{
			ResetRocket();
		}
    }

	private void ResetRocket()
	{
		transform.position = startPos;
		transform.rotation = startRot;
		rb.velocity = new Vector3(0, 0, 0);
		rb.angularVelocity = new Vector3(0, 0, 0);
	}
}
