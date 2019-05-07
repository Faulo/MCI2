using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct TestSetup {
    public float distance;
    public float width;

    public TestSetup(float distance, float width) {
        this.distance = distance;
        this.width = width;
    }

    internal TestSetup InPixel(float screenDPI) {
        return new TestSetup(
            distance * screenDPI / 2.54f / 10,
            width * screenDPI / 2.54f / 10
        );
    }
}
