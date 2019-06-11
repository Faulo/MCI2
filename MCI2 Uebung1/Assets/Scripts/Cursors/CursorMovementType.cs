using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cursors {
    public enum CursorMovementType {
        PositionControl,
        VelocityControl,
        AccelerationControl
    }

    public static class CursorMovementTypeExtensions {
        public static AbstractCursorMovement Movement(this CursorMovementType type) {
            switch (type) {
                case CursorMovementType.PositionControl:
                    return new PositionCursorMovement();
                case CursorMovementType.VelocityControl:
                    return new VelocityCursorMovement();
                case CursorMovementType.AccelerationControl:
                    return new AccelerationCursorMovement();
            }
            throw new System.Exception(type.ToString());
        }
    }
}