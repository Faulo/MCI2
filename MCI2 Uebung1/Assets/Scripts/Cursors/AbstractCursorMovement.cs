using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cursors {

    public abstract class AbstractCursorMovement {
        abstract public void AdvanceBy(float position);
        public float position {
            get => positionCache;
            protected set {
                positionCache = Mathf.Clamp(value, 0, 1);
            }
        }
        private float positionCache;

        public abstract void Reset();
    }
}