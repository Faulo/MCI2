using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSetup {
    public float distance;
    public float width;
    public float difficulty;

    public TestSetup(float distance = 0, float width = 0, float difficulty = 0) {
        if (distance == 0) {
            distance = width * Mathf.Pow(2, difficulty) / 2;
            //Debug.Log("distance:" + distance);
        }
        if (width == 0) {
            width = 2 * distance / Mathf.Pow(2, difficulty);
            //Debug.Log("width:" + width);
        }
        if (difficulty == 0) {
            difficulty = Mathf.Log(2 * distance / width, 2);
            //Debug.Log("difficulty:" + difficulty);
        }
        this.distance = distance;
        this.width = width;
        this.difficulty = difficulty;
    }

    internal TestSetup InPixel(float screenDPI) {
        return new TestSetup(
            distance * screenDPI / 25.4f,
            width * screenDPI / 25.4f,
            difficulty
        );
    }
}
