using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cursors {
    public class PositionCursorMovement : AbstractCursorMovement {
        public override void AdvanceBy(float position) {
            this.position = position + 0.5f;
        }
        public override void Reset() {
            position = 0.5f;
        }
    }
}