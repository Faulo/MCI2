using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretRotation : MonoBehaviour
{
	public Transform horizontalDrive;
	public Transform verticalDrive;

	public float maxVerticalAngle;
	
	// Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		Vector2 input = new Vector2(-Input.GetAxis("RightStickX"), Input.GetAxis("RightStickY"));
		Vector2 input2 = new Vector2(-Input.GetAxis("Horizontal"), -Input.GetAxis("Vertical"));
		if (input.magnitude < input2.magnitude)
		{
			input = input2;
		}
		//horizontalDrive.rotation;
		if (input.magnitude > 0)
		{
			horizontalDrive.forward = new Vector3(input.normalized.x, 0, input.normalized.y);
		}

		float verticalAngle = Mathf.Lerp(0, maxVerticalAngle, input.magnitude);
		verticalDrive.localRotation = Quaternion.Euler(0, 0, verticalAngle);
	}
}
