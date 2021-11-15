using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace PerpetualJourney
{
    public class LaneController : MonoBehaviour
    {
        [SerializeField]private float maxVelocity = 15;
        [SerializeField]private float acceleration = 0.2f;
        [SerializeField]private float jumpVelocity = 4;
        [SerializeField]private float laneInputDelay = 0.25f;
        [SerializeField]private float laneChangeAngle = 40;

        private InputReader inputReader;
        private Rigidbody pRigidbody;
        
        private bool hasGroundContact = false;
        private bool isChangingLane = false;
        private int currentLane = 0;
        private float laneSize;

        public void Initialize(InputReader _inputReader)
        {
            inputReader = _inputReader;
            inputReader.jumpEvent += onJump;
            inputReader.movementEvent += onMove;
            inputReader.swipeEvent += onSwipeMove;

            pRigidbody = GetComponent<Rigidbody>();
            laneSize = GameSystem.current.LaneSize;
        }

        private void OnDisable()
        {
            inputReader.jumpEvent -= onJump;
            inputReader.movementEvent -= onMove;
            inputReader.swipeEvent -= onSwipeMove;
        }

        private void onJump()
        {
            if (hasGroundContact)
            {
                pRigidbody.AddForce(Vector3.up * jumpVelocity, ForceMode.VelocityChange);
            }
        }

        private void FixedUpdate() 
        {
            if (hasGroundContact || isChangingLane)
            {
                Vector3 velocity = pRigidbody.velocity;

                if (Mathf.Abs(velocity.x) < maxVelocity)
                {
                    pRigidbody.AddForce(Vector3.left * acceleration, ForceMode.VelocityChange);
                }
            }
        }

        private void onSwipeMove(Vector2 swipeDir){
            if (swipeDir.y > 0)
            {
                onJump();
                return;
            }

            onMove((int)swipeDir.x);
        }

        private void onMove(int laneValue)
        {
            if(!isChangingLane && hasGroundContact)
            {
                int targetLane = currentLane + laneValue;
                if (targetLane <= 1 && targetLane >= -1)
                {
                    currentLane = targetLane;
                    jumpToLanePosition(laneChangeAngle);
                    isChangingLane = true;
                }
            }
        }

        private void jumpToRelativePosition(Vector3 relativePosition, float jumpAngle)
        {
            float gravity = Physics.gravity.magnitude;
            float angle = jumpAngle * Mathf.Deg2Rad;
            float yOffset = relativePosition.y;

            Vector3 origin = new Vector3();
            float distance = Vector3.Distance(origin, relativePosition);

            float initialVelocity = (1 / Mathf.Cos(angle)) * Mathf.Sqrt((0.5f * gravity * Mathf.Pow(distance, 2)) / (distance * Mathf.Tan(angle) + yOffset));
            Vector3 velocity = new Vector3(0, initialVelocity * Mathf.Sin(angle), initialVelocity * Mathf.Cos(angle));
            float angleBetweenObjects = Vector3.Angle(Vector3.forward, relativePosition) * Mathf.Sign(relativePosition.x);
            Vector3 finalVelocity = Quaternion.AngleAxis(angleBetweenObjects, Vector3.up) * velocity;

            pRigidbody.AddForce(finalVelocity * pRigidbody.mass, ForceMode.Impulse);
        }

        private void jumpToLanePosition(float jumpAngle){
            Vector3 relativePosition = Vector3.zero;
            relativePosition.z = currentLane * laneSize - transform.position.z;
            
            jumpToRelativePosition(relativePosition, jumpAngle);
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (!hasGroundContact)
            {
                hasGroundContact = true;
                if(isChangingLane && !gameObject.LeanIsTweening())
                {
                    LeanTween.delayedCall(gameObject, laneInputDelay, () => 
                    {
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
