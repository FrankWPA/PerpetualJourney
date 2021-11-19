using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;

namespace PerpetualJourney
{
    [CreateAssetMenu(fileName = "InputReader", menuName = "PerpetualJourney/Input Reader")]
    public class InputReader : ScriptableObject,
        GameInputAction.IRunningActions
    {
        [SerializeField]private float _swipeRange = 200;
        [SerializeField]private float _tapRange = 90;
        [SerializeField]private double _swipeTime = 0.9;

        public event Action<int> OnMoveEvent;
        public event Action<Vector2> OnSwipeEvent;
        public event Action OnJumpEvent;
        public event Action OnCloseEvent;
        public event Action OnResetEvent;

        private GameInputAction _inputAction;
        private Vector2 _startTouchPosition;

        private bool _swipePressed = false;
        private double _startTime;

        public void Initialize()
        {
            if (_inputAction == null)
            {
                _inputAction = new GameInputAction();
                _inputAction.Running.SetCallbacks(this);
            }
            _inputAction.Enable();

            EnhancedTouchSupport.Enable();
            UnityEngine.InputSystem.EnhancedTouch.Touch.onFingerDown += OnFingerStartTouch;
            UnityEngine.InputSystem.EnhancedTouch.Touch.onFingerUp += OnFingerEndTouch;
            UnityEngine.InputSystem.EnhancedTouch.Touch.onFingerMove += OnFingerMove;
        }

        public void DisableReader()
        {
            UnityEngine.InputSystem.EnhancedTouch.Touch.onFingerDown -= OnFingerStartTouch;
            UnityEngine.InputSystem.EnhancedTouch.Touch.onFingerUp -= OnFingerEndTouch;
            UnityEngine.InputSystem.EnhancedTouch.Touch.onFingerMove -= OnFingerMove;
            EnhancedTouchSupport.Disable();
        }

        // DebugOnly
        public void ForceReset()
        {
            OnResetEvent?.Invoke();
        }

        public void OnReturn(InputAction.CallbackContext context)
        {
            if(context.performed)
            {
                OnCloseEvent?.Invoke();
            }
        }

        public void OnMovement(InputAction.CallbackContext context)
        {
            if(context.performed)
            {
                OnMoveEvent?.Invoke((int)context.ReadValue<float>());
            }
        }

        public void OnJump(InputAction.CallbackContext context)
        {
            if(context.performed)
            {
                OnJumpEvent?.Invoke();
            }
        }

        private void OnFingerStartTouch(Finger finger)
        {
            SetStartTouch(finger.screenPosition, Time.time);
        }

        private void OnFingerEndTouch(Finger finger)
        {
            _swipePressed = false;

            Vector2 endTouchPosition = finger.screenPosition;
            DetectSwipe(endTouchPosition - _startTouchPosition);
        }

        private void SetStartTouch(Vector2 position, double currentTime)
        {
            _startTouchPosition = position;
            _startTime = currentTime;
            _swipePressed = true;
        }

        public void OnFingerMove(Finger finger)
        {
            if(!_swipePressed)
            {
                return;
            }

            Vector2 currentTouchPosition = finger.screenPosition;
            double currentTime = Time.time;

            if(currentTime >= (_startTime + _swipeTime))
            {
                SetStartTouch(currentTouchPosition, currentTime);
            }

            Vector2 distance = currentTouchPosition - _startTouchPosition;

            if(Mathf.Abs(distance.x) >= _swipeRange || Mathf.Abs(distance.y) >= _swipeRange)
            {
                Vector2 swipeDir = DetectSwipe(distance);

                if(Mathf.Abs(swipeDir.x) == 1)
                {
                    _startTouchPosition.x = currentTouchPosition.x;
                }
                else
                {
                    _startTouchPosition.y = currentTouchPosition.y;
                }

                _startTime = currentTime;
            }
        }

        private Vector2 DetectSwipe(Vector2 swipeValue)
        {
            float horizontalDist = Mathf.Abs(swipeValue.x);
            float verticalDist = Mathf.Abs(swipeValue.y);
            Vector2 swipeResult = Vector2.zero;

            if (horizontalDist <= _tapRange && verticalDist <= _tapRange)
            {
                return swipeResult;
            }
            
            if (Mathf.Abs(horizontalDist) > Mathf.Abs(verticalDist))
            {
                swipeResult.x = Mathf.Sign(swipeValue.x);
            }
            else
            {
                swipeResult.y = Mathf.Sign(swipeValue.y);
            }

            OnSwipeEvent?.Invoke(swipeResult);
            return swipeResult;
        }
    }
}
