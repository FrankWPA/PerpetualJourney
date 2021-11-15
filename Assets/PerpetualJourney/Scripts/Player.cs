using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PerpetualJourney
{
    public class Player : MonoBehaviour
    {
        [SerializeField]private LaneController laneController;
        [SerializeField]private TransformOffset cameraFocus;
        [SerializeField]private InputReader _inputReader;

        public Vector3 CameraFocusPosition => cameraFocus.transform.position;

        public void Initialize()
        {
            laneController.Initialize(_inputReader);
            cameraFocus.Initialize(laneController.transform);
        }
    }
}
