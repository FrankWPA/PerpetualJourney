// GENERATED AUTOMATICALLY FROM 'Assets/PerpetualJourney/Scripts/GameInputAction.inputactions'

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
            ""name"": ""Runnning"",
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
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
            // Runnning
            m_Runnning = asset.FindActionMap("Runnning", throwIfNotFound: true);
            m_Runnning_Movement = m_Runnning.FindAction("Movement", throwIfNotFound: true);
            m_Runnning_Jump = m_Runnning.FindAction("Jump", throwIfNotFound: true);
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

        // Runnning
        private readonly InputActionMap m_Runnning;
        private IRunnningActions m_RunnningActionsCallbackInterface;
        private readonly InputAction m_Runnning_Movement;
        private readonly InputAction m_Runnning_Jump;
        public struct RunnningActions
        {
            private @GameInputAction m_Wrapper;
            public RunnningActions(@GameInputAction wrapper) { m_Wrapper = wrapper; }
            public InputAction @Movement => m_Wrapper.m_Runnning_Movement;
            public InputAction @Jump => m_Wrapper.m_Runnning_Jump;
            public InputActionMap Get() { return m_Wrapper.m_Runnning; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(RunnningActions set) { return set.Get(); }
            public void SetCallbacks(IRunnningActions instance)
            {
                if (m_Wrapper.m_RunnningActionsCallbackInterface != null)
                {
                    @Movement.started -= m_Wrapper.m_RunnningActionsCallbackInterface.OnMovement;
                    @Movement.performed -= m_Wrapper.m_RunnningActionsCallbackInterface.OnMovement;
                    @Movement.canceled -= m_Wrapper.m_RunnningActionsCallbackInterface.OnMovement;
                    @Jump.started -= m_Wrapper.m_RunnningActionsCallbackInterface.OnJump;
                    @Jump.performed -= m_Wrapper.m_RunnningActionsCallbackInterface.OnJump;
                    @Jump.canceled -= m_Wrapper.m_RunnningActionsCallbackInterface.OnJump;
                }
                m_Wrapper.m_RunnningActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Movement.started += instance.OnMovement;
                    @Movement.performed += instance.OnMovement;
                    @Movement.canceled += instance.OnMovement;
                    @Jump.started += instance.OnJump;
                    @Jump.performed += instance.OnJump;
                    @Jump.canceled += instance.OnJump;
                }
            }
        }
        public RunnningActions @Runnning => new RunnningActions(this);
        public interface IRunnningActions
        {
            void OnMovement(InputAction.CallbackContext context);
            void OnJump(InputAction.CallbackContext context);
        }
    }
}
