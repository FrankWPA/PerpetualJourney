using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace PerpetualJourney
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField]private float rollingSpeed;
        [SerializeField]private float laneChangingSpeed;
        [SerializeField]private float laneSize;
        [SerializeField]private LeanTweenType tweenType;

        private GameInputAction gameInputAction;
        private Rigidbody capsuleRigidbody;

        private bool hasGroundContact = false;

        private void Awake() {
            gameInputAction = new GameInputAction();
            capsuleRigidbody = GetComponent<Rigidbody>();
        }

        private void OnEnable() {
            gameInputAction.Runnning.Enable();
            gameInputAction.Runnning.Jump.performed += doJump;
            gameInputAction.Runnning.Movement.performed += ChangeLane;
        }

        private void OnDisable() {
            gameInputAction.Runnning.Disable();
        }

        private void doJump(InputAction.CallbackContext callback){
            Debug.Log(callback);
        }

        private void ChangeLane(InputAction.CallbackContext callback){
            float laneValue = callback.ReadValue<float>();
            float currentPositionX = transform.position.x;
            float newLanePosition = currentPositionX + laneSize*laneValue;

            LeanTween.moveX(gameObject, newLanePosition, laneChangingSpeed).setEase(tweenType);
        }

        private void FixedUpdate() {
            if (hasGroundContact){
                capsuleRigidbody.AddForce(0, 0, rollingSpeed);
            }
        }

        void OnCollisionEnter(Collision collision)
        {
            hasGroundContact = true;
        }

        private void OnCollisionStay(Collision other)
        {
            if (!hasGroundContact) hasGroundContact = true;
        }

        private void OnCollisionExit(Collision other)
        {
            hasGroundContact = false;
        }
    }
}
