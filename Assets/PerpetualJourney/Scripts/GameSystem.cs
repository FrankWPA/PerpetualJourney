using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PerpetualJourney
{
    public class GameSystem : MonoBehaviour
    {
        [SerializeField]private GameManager gameManager;
        private GameInputAction gameInputAction;

        private void Awake()
        {
            gameInputAction = new GameInputAction();
            gameManager.OnAwake(gameInputAction);
        }

        private void FixedUpdate() {
            gameManager.onFixedUpdate();
        }
    }
}
