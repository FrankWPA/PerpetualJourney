using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PerpetualJourney{
    public class CameraPlayerFocus : MonoBehaviour
    {
        [SerializeField]private PlayerController playerController;
        [SerializeField]private float playerPositionOffset;

        private void FixedUpdate() {
            Vector3 playerPosition = playerController.transform.position;
            transform.position = new Vector3(0, playerPosition.y, playerPosition.z + playerPositionOffset);
        }
    }
}
