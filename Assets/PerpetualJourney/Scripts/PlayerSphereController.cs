using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace PerpetualJourney
{
    public class PlayerSphereController : MonoBehaviour
    {
        [SerializeField]private float rollingSpeed;
        [SerializeField]private float laneSize;
        [SerializeField]private LeanTweenType tweenType;

        private GameInputAction gameInputAction;
        private Rigidbody sphereRigidbody;
        
        private bool hasGroundContact = false;
        private bool isChangingLane = false;
        private int currentLane = 0;
        private float laneCorrection = 0;

        public void onAwake(GameInputAction inputAction)
        {
            gameInputAction = inputAction;
            inputAction.Running.Enable();
            inputAction.Running.Jump.performed += DoJump;
            inputAction.Running.Movement.performed += ChangeLane;
            sphereRigidbody = GetComponent<Rigidbody>();
        }
        
        //Handle Sphere's aceleration when in contact with the ground or changing lanes
        public void onFixedUpdate() 
        {
            if (hasGroundContact || isChangingLane)
            {
                sphereRigidbody.AddForce(new Vector3(-rollingSpeed, 0, laneCorrection));
            }
        }

        private void OnDisable()
        {
            gameInputAction.Running.Disable();
        }

        private void DoJump(InputAction.CallbackContext callback)
        {
            if (hasGroundContact)
            {
                sphereRigidbody.AddForce(0, 200, 0);
            }
        }

        //Adds a force in the direction of the target lane
        private void ChangeLane(InputAction.CallbackContext callback)
        {
            if(!isChangingLane && hasGroundContact)
            {
                int laneValue = (int)callback.ReadValue<float>();
                int targetLane = currentLane + laneValue;
                if (targetLane <= 1 && targetLane >= -1)
                {
                    currentLane = targetLane;
                    sphereRigidbody.velocity = new Vector3(sphereRigidbody.velocity.x * 0.85f, 0, 0);
                    sphereRigidbody.AddForce(new Vector3(0, 160, laneValue * laneSize * 75));
                    isChangingLane = true;
                    hasGroundContact = false;
                }
            }
        }

        //Tweens the position of the sphere to the correct one based on the lane value
        private void interpolatePositionToLane(){
            float currentZ = transform.position.z;
            float targetZ = currentLane * laneSize;

            LTDescr laneTween = LeanTween.value(gameObject, currentZ, targetZ, 0.5f);
            laneTween.setOnUpdate((float val) =>
            {
                laneCorrection = (val - transform.position.z) * 25;
            });
            laneTween.setOnComplete(() => 
            {
                laneCorrection = 0;
                isChangingLane = false;
            });
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (!hasGroundContact)
            {
                hasGroundContact = true;
                if(isChangingLane && !gameObject.LeanIsTweening())
                {
                    interpolatePositionToLane();
                }
            }
        }

        private void OnCollisionStay(Collision other)
        {
            if (!hasGroundContact)
            {
                hasGroundContact = true;
            }
        }

        private void OnCollisionExit(Collision other)
        {
            hasGroundContact = false;
        }
    }
}
