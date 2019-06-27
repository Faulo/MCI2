using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RCThruster : MonoBehaviour
{
	public GameObject rcThrusterAnker;
	public float maxRCThrust;

	private Rigidbody rocketRB;

	// Start is called before the first frame update
    void Start()
    {
		rocketRB = gameObject.GetComponent<Rigidbody>();
	}

    // Update is called once per frame
    void Update()
    {
		//Debug.Log(Input.GetAxis("Horizontal") + " | " + Input.GetAxis("Vertical")); // left stick
		//Debug.Log(Input.GetAxis("RightStickX") + " | " + Input.GetAxis("RightStickY")); // right stick
		//Debug.Log(Input.GetAxis("RightTrigger") + " | " + Input.GetAxis("LeftTrigger"));


		Vector3 rcDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
		//Vector3 rcResultingDirection = rcThrusterAnker.transform.rotation * rcDirection;
		//Vector3 rcResultingDirection = Vector3.ProjectOnPlane(rcDirection, rcThrusterAnker.transform.right);
		//Vector3 rcResultingDirection = rcThrusterAnker.transform.TransformVector(rcDirection);
		Vector3 rcResultingDirection = Vector3.Scale(rcThrusterAnker.transform.up, rcDirection); 
		Debug.Log(rcResultingDirection);
		//rocketRB.AddForceAtPosition(rcDirection * maxRCThrust, rcThrusterAnker.transform.position);
		rocketRB.AddForceAtPosition(rcThrusterAnker.transform.right * maxRCThrust * Input.GetAxis("Horizontal"), rcThrusterAnker.transform.position);
	}
}
