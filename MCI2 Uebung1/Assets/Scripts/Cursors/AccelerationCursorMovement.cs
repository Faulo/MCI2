using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cursors {
    public class AccelerationCursorMovement : AbstractCursorMovement {
        private float acceleration;
        private float velocity;
        public override void AdvanceBy(float value) {
            acceleration = value;
            velocity += acceleration * Time.deltaTime;
            position += velocity * Time.deltaTime;
        }
        public override void Reset() {
            acceleration = 0;
            velocity = 0;
            position = 0.5f;
        }
    }
}