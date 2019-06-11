using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CursorSimulator : MonoBehaviour {

    public Button leftButton;
    public Button rightButton;
    public Button backgroundButton;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

        if (Input.GetKeyDown(KeyCode.Space) && FindObjectOfType<SetupManager>().testActive) {
            var x = GetComponent<RectTransform>().position.x;

            var leftWidth = leftButton.GetComponent<RectTransform>().rect.width;
            var leftX = leftButton.GetComponent<RectTransform>().anchoredPosition.x;

            var rightWidth = rightButton.GetComponent<RectTransform>().rect.width;
            var rightX = Screen.width + rightButton.GetComponent<RectTransform>().anchoredPosition.x - rightWidth;

            //Debug.Log("x:" + x + " lextX:" + leftX + " leftWidth:" + leftWidth + " rightX:" + rightX + " rightWidth:" + rightWidth);
            if (x > leftX && x < leftX + leftWidth) {
                leftButton.onClick.Invoke();
            } else if (x > rightX && x < rightX + rightWidth) {
                rightButton.onClick.Invoke();
            } else {
                backgroundButton.onClick.Invoke();
            }
        }
    }
}
