using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace PerpetualJourney
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField]private float rollingSpeed;
        [SerializeField]private float laneSize;
        [SerializeField]private float laneChangeDuration;
        [SerializeField]private LeanTweenType tweenType;

        private GameInputAction gameInputAction;
        private Rigidbody capsuleRigidbody;

        private bool hasGroundContact = false;
        private bool isChangingLane = false;
        private float laneChaseRelativePosition;
        private int currentLane = 0;

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
            if (hasGroundContact){
                capsuleRigidbody.AddForce(0, 300, 0);
            }
        }

        private void ChangeLane(InputAction.CallbackContext callback){
            if(!isChangingLane){
                float laneValue = callback.ReadValue<float>();
                if (currentLane + laneValue <= 1 && currentLane + laneValue >= -1){
                    currentLane += (int)laneValue;
                    float newLanePosition = laneSize * currentLane;
                    isChangingLane = true;

                    capsuleRigidbody.AddForce(0, 180, 0);
                    LeanTween.moveX(gameObject, newLanePosition, laneChangeDuration).setEase(tweenType)
                                .setOnComplete(() => isChangingLane = false);
                }
            }
        }

        //Handle Sphere's aceleration when in contact with the ground
        private void FixedUpdate() {
            if (hasGroundContact || isChangingLane){
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
