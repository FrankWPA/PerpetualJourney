using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PerpetualJourney
{
    public class Player : MonoBehaviour
    {
        [SerializeField]private PlayerController movementController;
        [SerializeField]private TransformOffset cameraFocus;
        public Vector3 CameraFocusPosition => cameraFocus.transform.position;

        public void Initialize()
        {
            movementController.Initialize();
            cameraFocus.Initialize(movementController.transform);
        }
    }
}
