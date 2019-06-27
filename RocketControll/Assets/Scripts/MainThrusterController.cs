using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainThrusterController : MonoBehaviour
{
	public GameObject mainThrusterGimbel;
	public GameObject mainThrusterEnd;
	public float maxThrust;
	public float maxAngle;

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

		Vector3 gimbelAngle = new Vector3(maxAngle * Input.GetAxis("RightStickY"), 0, maxAngle * Input.GetAxis("RightStickX"));
		mainThrusterGimbel.transform.localRotation = Quaternion.Euler(gimbelAngle);
		float thrust = maxThrust * Input.GetAxis("RightTrigger");
		rocketRB.AddForceAtPosition(mainThrusterEnd.transform.up * thrust, mainThrusterEnd.transform.position);

    }
}
