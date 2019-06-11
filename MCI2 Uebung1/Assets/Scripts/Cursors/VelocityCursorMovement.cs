using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cursors {
    public class VelocityCursorMovement : AbstractCursorMovement {
        private float velocity;
        public override void AdvanceBy(float value) {
            velocity = value;
            position += velocity * Time.deltaTime;
        }
        public override void Reset() {
            velocity = 0;
            position = 0.5f;
        }
    }
}
