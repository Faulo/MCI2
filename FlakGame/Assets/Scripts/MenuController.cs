using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour {
    private GameObject panel => transform.GetChild(0).gameObject;

    // Start is called before the first frame update
    void Start() {
        Continue();
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (panel.activeSelf) {
                Continue();
            } else {
                Pause();
            }
        }
    }

    public void Pause() {
        Time.timeScale = 0;
        panel.SetActive(true);
    }

    public void Continue() {
        Time.timeScale = 1;
        panel.SetActive(false);
    }

    public void Quit() {
        Application.Quit();
    }
}
