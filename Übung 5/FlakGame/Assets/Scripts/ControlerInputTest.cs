using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlerInputTest : MonoBehaviour
{
	public GameObject cursor;

	
	// Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		Debug.Log("X: " + Input.GetAxis("RightStickX") + " | " + "Y: " + Input.GetAxis("RightStickY"));
		Vector2 input = new Vector2(Input.GetAxis("RightStickX"), Input.GetAxis("RightStickY"));

		Vector3 cursorPos = new Vector3(0, 0, 0);
		cursorPos.x = 1920 / 2 * input.x + 1920 / 2;
		cursorPos.y = 1080 / 2 * -input.y + 1080 / 2;

		cursor.transform.position = cursorPos;
	}
}
