using Cursors;
using Extensions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

[Serializable]
public struct GlobalTestSetup {
    public CursorMovementType startCursor;
    public float[] distances;
    public float[] difficulties;

    internal IEnumerable<TestSetup> GetTestSetups() {
        var self = this;
        return distances
            .SelectMany(distance => self.difficulties
                .Select(difficulty => new TestSetup(distance:distance, difficulty:difficulty))
            )
            .Shuffle();
    }
}
