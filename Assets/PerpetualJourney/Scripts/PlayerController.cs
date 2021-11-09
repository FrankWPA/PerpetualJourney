using System;
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
        [SerializeField]private LeanTweenType tweenType;

        private GameInputAction gameInputAction;
        private Rigidbody capsuleRigidbody;

        private bool hasGroundContact = false;
        private bool isChangingLane = false;
        private int currentLane = 0;
        private float laneCorrection = 0;

        private void Awake()
        {
            gameInputAction = new GameInputAction();
            capsuleRigidbody = GetComponent<Rigidbody>();
        }

        private void OnEnable()
        {
            gameInputAction.Running.Enable();
            gameInputAction.Running.Jump.performed += DoJump;
            gameInputAction.Running.Movement.performed += ChangeLane;
        }

        private void OnDisable()
        {
            gameInputAction.Running.Disable();
        }

        private void DoJump(InputAction.CallbackContext callback)
        {
            // if (hasGroundContact)
            // {
            //     capsuleRigidbody.AddForce(0, 200, 0);
            // }
            transform.position = new Vector3(-10, 10, transform.position.z);
        }

        private void ChangeLane(InputAction.CallbackContext callback)
        {
            if(!isChangingLane && hasGroundContact)
            {
                int laneValue = (int)callback.ReadValue<float>();
                int targetLane = currentLane + laneValue;
                if (targetLane <= 1 && targetLane >= -1)
                {
                    currentLane = targetLane;
                    capsuleRigidbody.velocity = new Vector3(capsuleRigidbody.velocity.x * 0.85f, 0, 0);
                    capsuleRigidbody.AddForce(new Vector3(0, 160, laneValue * laneSize * 75));
                    isChangingLane = true;
                    hasGroundContact = false;
                }
            }
        }

        //Handle Sphere's aceleration when in contact with the ground
        private void FixedUpdate() 
        {
            if (hasGroundContact || isChangingLane)
            {
                capsuleRigidbody.AddForce(new Vector3(-rollingSpeed, 0, laneCorrection));
            }
            else
            {
                capsuleRigidbody.AddTorque(Vector3.forward);
            }
        }

        void OnCollisionEnter(Collision collision)
        {
            if (!hasGroundContact)
            {
                hasGroundContact = true;
                if(isChangingLane && !gameObject.LeanIsTweening())
                {
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
