using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace PerpetualJourney
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField]private float maxSpeed = 15;
        [SerializeField]private float acceleration = 0.2f;
        [SerializeField]private InputReader _inputReader = default;

        private Rigidbody rigidbody;
        
        private bool hasGroundContact = false;
        private bool isChangingLane = false;
        private float laneSize;
        private int currentLane = 0;

        public void Initialize()
        {
            _inputReader.jumpEvent += onJump;
            _inputReader.movementEvent += onMove;

            rigidbody = GetComponent<Rigidbody>();
            laneSize = GameSystem.current.LaneSize;
        }

        private void OnDisable()
        {
            _inputReader.jumpEvent -= onJump;
            _inputReader.movementEvent -= onMove;
        }

        private void onJump()
        {
            if (hasGroundContact)
            {
                rigidbody.AddForce(0, 200, 0);
            }
        }

        //Handle object's aceleration when in contact with the ground or changing lanes
        private void FixedUpdate() 
        {
            if (hasGroundContact || isChangingLane)
            {
                Vector3 velocity = rigidbody.velocity;

                if (Mathf.Abs(velocity.x) < maxSpeed)
                {
                    rigidbody.AddForce(Vector3.left * acceleration, ForceMode.VelocityChange);
                }
            }
        }

        private void onMove(int laneValue)
        {
            if(!isChangingLane && hasGroundContact)
            {
                int targetLane = currentLane + laneValue;
                if (targetLane <= 1 && targetLane >= -1)
                {
                    currentLane = targetLane;
                    jumpToLanePosition(45f);
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

            rigidbody.AddForce(finalVelocity * rigidbody.mass, ForceMode.Impulse);
        }

        private void jumpToLanePosition(float jumpAngle){
            Vector3 relativePosition = new Vector3(0, 0, currentLane * laneSize - transform.position.z);
            jumpToRelativePosition(relativePosition, jumpAngle);
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (!hasGroundContact)
            {
                hasGroundContact = true;
                if(isChangingLane && !gameObject.LeanIsTweening())
                {
                    LeanTween.delayedCall(gameObject, 0.25f, () => 
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
