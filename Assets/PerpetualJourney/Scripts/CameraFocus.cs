using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PerpetualJourney{
    public class CameraFocus : MonoBehaviour
    {
        [SerializeField]private PlayerController playerController;
        [SerializeField]private float positionOffset;

        private void FixedUpdate() {
            Vector3 playerPosition = playerController.transform.position;
            transform.position = new Vector3(playerPosition.x - positionOffset, playerPosition.y, 0);
        }
    }
}
