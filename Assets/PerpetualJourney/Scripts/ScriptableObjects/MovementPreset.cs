using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;

namespace PerpetualJourney
{
    [CreateAssetMenu(fileName = "MovementPreset", menuName = "PerpetualJourney/Movement Preset")]
    public class MovementPreset : ScriptableObject
    {
        public float MaxVelocity = 14;
        public float Acceleration = 0.2f;
        public float JumpVelocity = 7;
        public float LaneInputDelay = 0.2f;
        public float LaneChangeAngle = 40;
    }
}
