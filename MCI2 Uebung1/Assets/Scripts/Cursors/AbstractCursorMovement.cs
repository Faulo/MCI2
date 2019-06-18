using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cursors {
    public abstract class AbstractCursorMovement {
        public float position {
            get => positionCache;
            protected set {
                if (value > 1) {
                    Reset();
                    positionCache = 1;
                } else if (value < 0) {
                    Reset();
                    positionCache = 0;
                } else {
                    positionCache = value;
                }
            }
        }
        private float positionCache;

        abstract public void AdvanceBy(float position);
        abstract public void Reset();
    }
}