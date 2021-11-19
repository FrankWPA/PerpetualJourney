// GENERATED AUTOMATICALLY FROM 'Assets/PerpetualJourney/Scripts/InputSystem/GameInputAction.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace PerpetualJourney
{
    public class @GameInputAction : IInputActionCollection, IDisposable
    {
        public InputActionAsset asset { get; }
        public @GameInputAction()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""GameInputAction"",
    ""maps"": [
        {
            ""name"": ""Running"",
            ""id"": ""24702c35-e376-4cf3-a3c5-4e6e307a8067"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Button"",
                    ""id"": ""b8c5e7ac-9d77-4a2c-9496-f46884c5dd53"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""ca47c239-8399-4f78-918e-92d886aa486a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Return"",
                    ""type"": ""Button"",
                    ""id"": ""3794a532-da76-4fec-ad69-60736f4ebcf8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""666e28aa-3268-49e0-9e84-df31b51b864e"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Negative"",
                    ""id"": ""c5f2421c-f57f-4809-9723-562e06f3faec"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Positive"",
                    ""id"": ""6c43b327-6a14-4c99-8f76-ea3341692023"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""29ecfbb7-7992-4579-87ad-30ce4058fe36"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""96e9283f-f7e8-4648-855e-d249191ac9b1"",
                    ""path"": ""<Keyboard>/backspace"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Return"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e651f0b2-c6c7-4b4a-93a5-078cf6be1f08"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Return"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
            // Running
            m_Running = asset.FindActionMap("Running", throwIfNotFound: true);
            m_Running_Movement = m_Running.FindAction("Movement", throwIfNotFound: true);
            m_Running_Jump = m_Running.FindAction("Jump", throwIfNotFound: true);
            m_Running_Return = m_Running.FindAction("Return", throwIfNotFound: true);
        }

        public void Dispose()
        {
            UnityEngine.Object.Destroy(asset);
        }

        public InputBinding? bindingMask
        {
            get => asset.bindingMask;
            set => asset.bindingMask = value;
        }

        public ReadOnlyArray<InputDevice>? devices
        {
            get => asset.devices;
            set => asset.devices = value;
        }

        public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

        public bool Contains(InputAction action)
        {
            return asset.Contains(action);
        }

        public IEnumerator<InputAction> GetEnumerator()
        {
            return asset.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Enable()
        {
            asset.Enable();
        }

        public void Disable()
        {
            asset.Disable();
        }

        // Running
        private readonly InputActionMap m_Running;
        private IRunningActions m_RunningActionsCallbackInterface;
        private readonly InputAction m_Running_Movement;
        private readonly InputAction m_Running_Jump;
        private readonly InputAction m_Running_Return;
        public struct RunningActions
        {
            private @GameInputAction m_Wrapper;
            public RunningActions(@GameInputAction wrapper) { m_Wrapper = wrapper; }
            public InputAction @Movement => m_Wrapper.m_Running_Movement;
            public InputAction @Jump => m_Wrapper.m_Running_Jump;
            public InputAction @Return => m_Wrapper.m_Running_Return;
            public InputActionMap Get() { return m_Wrapper.m_Running; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(RunningActions set) { return set.Get(); }
            public void SetCallbacks(IRunningActions instance)
            {
                if (m_Wrapper.m_RunningActionsCallbackInterface != null)
                {
                    @Movement.started -= m_Wrapper.m_RunningActionsCallbackInterface.OnMovement;
                    @Movement.performed -= m_Wrapper.m_RunningActionsCallbackInterface.OnMovement;
                    @Movement.canceled -= m_Wrapper.m_RunningActionsCallbackInterface.OnMovement;
                    @Jump.started -= m_Wrapper.m_RunningActionsCallbackInterface.OnJump;
                    @Jump.performed -= m_Wrapper.m_RunningActionsCallbackInterface.OnJump;
                    @Jump.canceled -= m_Wrapper.m_RunningActionsCallbackInterface.OnJump;
                    @Return.started -= m_Wrapper.m_RunningActionsCallbackInterface.OnReturn;
                    @Return.performed -= m_Wrapper.m_RunningActionsCallbackInterface.OnReturn;
                    @Return.canceled -= m_Wrapper.m_RunningActionsCallbackInterface.OnReturn;
                }
                m_Wrapper.m_RunningActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Movement.started += instance.OnMovement;
                    @Movement.performed += instance.OnMovement;
                    @Movement.canceled += instance.OnMovement;
                    @Jump.started += instance.OnJump;
                    @Jump.performed += instance.OnJump;
                    @Jump.canceled += instance.OnJump;
                    @Return.started += instance.OnReturn;
                    @Return.performed += instance.OnReturn;
                    @Return.canceled += instance.OnReturn;
                }
            }
        }
        public RunningActions @Running => new RunningActions(this);
        public interface IRunningActions
        {
            void OnMovement(InputAction.CallbackContext context);
            void OnJump(InputAction.CallbackContext context);
            void OnReturn(InputAction.CallbackContext context);
        }
    }
}
