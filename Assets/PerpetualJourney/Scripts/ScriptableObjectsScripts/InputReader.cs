using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace PerpetualJourney
{
    [CreateAssetMenu(fileName = "InputReader", menuName = "Input Reader")]
    public class InputReader : ScriptableObject,
        GameInputAction.IRunningActions,
        GameInputAction.IDebugControlActions,
        GameInputAction.ITouchSwipeActions
    {
        [SerializeField]private float _swipeRange = 300;
        [SerializeField]private float _tapRange = 100;
        [SerializeField]private double _swipeTime = 1;

        public event Action<int> OnMoveEvent;
        public event Action<Vector2> OnSwipeEvent;
        public event Action OnJumpEvent;
        public event Action OnCloseEvent;
        public event Action OnResetEvent;

        private GameInputAction _inputAction;
        private Vector2 _startTouchPosition;

        private bool _swipePressed = false;
        private double _startTime;

        private void OnEnable()
        {
            if (_inputAction == null)
            {
                _inputAction = new GameInputAction();
                _inputAction.Running.SetCallbacks(this);
                _inputAction.DebugControl.SetCallbacks(this);
                _inputAction.TouchSwipe.SetCallbacks(this);
            }
            _inputAction.Enable();
        }

        private void OnDisable()
        {
            _inputAction.Disable();
        }

        public void OnResetScene(InputAction.CallbackContext context)
        {
            if(context.performed)
            {
                OnResetEvent?.Invoke();
            }
        }

        public void OnCloseGame(InputAction.CallbackContext context)
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

        public void OnContact(InputAction.CallbackContext context)
        {
            if(context.ReadValue<float>() == 1)
            {
                StartTouch(context);
            }
            else
            {
                EndTouch(context);
            }
        }

        public void OnPosition(InputAction.CallbackContext context)
        {
            if(!_swipePressed)
            {
                return;
            }

            Vector2 currentTouchPosition = _inputAction.TouchSwipe.Position.ReadValue<Vector2>();
            double currentTime = context.time;

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

                _startTime = context.startTime;
            }
        }

        private void StartTouch(InputAction.CallbackContext context)
        {
            Vector2 position = _inputAction.TouchSwipe.Position.ReadValue<Vector2>();
            SetStartTouch(position, context.startTime);
        }

        private void SetStartTouch(Vector2 position, double currentTime)
        {
            _startTouchPosition = position;
            _startTime = currentTime;
            _swipePressed = true;
        }

        private void EndTouch(InputAction.CallbackContext context)
        {
            _swipePressed = false;

            Vector2 endTouchPosition = _inputAction.TouchSwipe.Position.ReadValue<Vector2>();
            DetectSwipe(endTouchPosition - _startTouchPosition);
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
