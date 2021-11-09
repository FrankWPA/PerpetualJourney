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
        },
        {
            ""name"": ""MenuControl"",
            ""id"": ""0a94e402-0e9c-408d-8063-f426a0b99e07"",
            ""actions"": [
                {
                    ""name"": ""Acept"",
                    ""type"": ""Button"",
                    ""id"": ""2f61cf97-204d-4f84-9b74-85946bf7a491"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Return"",
                    ""type"": ""Button"",
                    ""id"": ""66e09fdf-c571-4a95-95a9-12dca08f2219"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""1ffa104a-480e-4525-8786-ed83a5cef8e5"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Acept"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5c80aa1c-0fde-4efb-91a1-29d69a89a033"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Acept"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""52207ad5-2c79-4cd8-9d5e-1274b7431c2e"",
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
                    ""id"": ""585ba111-ef06-4587-82d5-c6916d1ecea5"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Return"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""DebugControl"",
            ""id"": ""91f5b37d-78b8-45e7-a6cb-c2d62cd774b1"",
            ""actions"": [
                {
                    ""name"": ""ResetScene"",
                    ""type"": ""Button"",
                    ""id"": ""5b4232ee-b5f2-4ca3-826d-950abb94e7ec"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""CloseGame"",
                    ""type"": ""Button"",
                    ""id"": ""c9028880-7306-4795-bd1f-958aef0d19b4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""06317c0e-4cec-4c97-8a2c-3022f2357fc0"",
                    ""path"": ""<Keyboard>/backspace"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ResetScene"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""417a35e1-500b-42b9-820f-913b9a954945"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CloseGame"",
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
            // MenuControl
            m_MenuControl = asset.FindActionMap("MenuControl", throwIfNotFound: true);
            m_MenuControl_Acept = m_MenuControl.FindAction("Acept", throwIfNotFound: true);
            m_MenuControl_Return = m_MenuControl.FindAction("Return", throwIfNotFound: true);
            // DebugControl
            m_DebugControl = asset.FindActionMap("DebugControl", throwIfNotFound: true);
            m_DebugControl_ResetScene = m_DebugControl.FindAction("ResetScene", throwIfNotFound: true);
            m_DebugControl_CloseGame = m_DebugControl.FindAction("CloseGame", throwIfNotFound: true);
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
        public struct RunningActions
        {
            private @GameInputAction m_Wrapper;
            public RunningActions(@GameInputAction wrapper) { m_Wrapper = wrapper; }
            public InputAction @Movement => m_Wrapper.m_Running_Movement;
            public InputAction @Jump => m_Wrapper.m_Running_Jump;
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
                }
            }
        }
        public RunningActions @Running => new RunningActions(this);

        // MenuControl
        private readonly InputActionMap m_MenuControl;
        private IMenuControlActions m_MenuControlActionsCallbackInterface;
        private readonly InputAction m_MenuControl_Acept;
        private readonly InputAction m_MenuControl_Return;
        public struct MenuControlActions
        {
            private @GameInputAction m_Wrapper;
            public MenuControlActions(@GameInputAction wrapper) { m_Wrapper = wrapper; }
            public InputAction @Acept => m_Wrapper.m_MenuControl_Acept;
            public InputAction @Return => m_Wrapper.m_MenuControl_Return;
            public InputActionMap Get() { return m_Wrapper.m_MenuControl; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(MenuControlActions set) { return set.Get(); }
            public void SetCallbacks(IMenuControlActions instance)
            {
                if (m_Wrapper.m_MenuControlActionsCallbackInterface != null)
                {
                    @Acept.started -= m_Wrapper.m_MenuControlActionsCallbackInterface.OnAcept;
                    @Acept.performed -= m_Wrapper.m_MenuControlActionsCallbackInterface.OnAcept;
                    @Acept.canceled -= m_Wrapper.m_MenuControlActionsCallbackInterface.OnAcept;
                    @Return.started -= m_Wrapper.m_MenuControlActionsCallbackInterface.OnReturn;
                    @Return.performed -= m_Wrapper.m_MenuControlActionsCallbackInterface.OnReturn;
                    @Return.canceled -= m_Wrapper.m_MenuControlActionsCallbackInterface.OnReturn;
                }
                m_Wrapper.m_MenuControlActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Acept.started += instance.OnAcept;
                    @Acept.performed += instance.OnAcept;
                    @Acept.canceled += instance.OnAcept;
                    @Return.started += instance.OnReturn;
                    @Return.performed += instance.OnReturn;
                    @Return.canceled += instance.OnReturn;
                }
            }
        }
        public MenuControlActions @MenuControl => new MenuControlActions(this);

        // DebugControl
        private readonly InputActionMap m_DebugControl;
        private IDebugControlActions m_DebugControlActionsCallbackInterface;
        private readonly InputAction m_DebugControl_ResetScene;
        private readonly InputAction m_DebugControl_CloseGame;
        public struct DebugControlActions
        {
            private @GameInputAction m_Wrapper;
            public DebugControlActions(@GameInputAction wrapper) { m_Wrapper = wrapper; }
            public InputAction @ResetScene => m_Wrapper.m_DebugControl_ResetScene;
            public InputAction @CloseGame => m_Wrapper.m_DebugControl_CloseGame;
            public InputActionMap Get() { return m_Wrapper.m_DebugControl; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(DebugControlActions set) { return set.Get(); }
            public void SetCallbacks(IDebugControlActions instance)
            {
                if (m_Wrapper.m_DebugControlActionsCallbackInterface != null)
                {
                    @ResetScene.started -= m_Wrapper.m_DebugControlActionsCallbackInterface.OnResetScene;
                    @ResetScene.performed -= m_Wrapper.m_DebugControlActionsCallbackInterface.OnResetScene;
                    @ResetScene.canceled -= m_Wrapper.m_DebugControlActionsCallbackInterface.OnResetScene;
                    @CloseGame.started -= m_Wrapper.m_DebugControlActionsCallbackInterface.OnCloseGame;
                    @CloseGame.performed -= m_Wrapper.m_DebugControlActionsCallbackInterface.OnCloseGame;
                    @CloseGame.canceled -= m_Wrapper.m_DebugControlActionsCallbackInterface.OnCloseGame;
                }
                m_Wrapper.m_DebugControlActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @ResetScene.started += instance.OnResetScene;
                    @ResetScene.performed += instance.OnResetScene;
                    @ResetScene.canceled += instance.OnResetScene;
                    @CloseGame.started += instance.OnCloseGame;
                    @CloseGame.performed += instance.OnCloseGame;
                    @CloseGame.canceled += instance.OnCloseGame;
                }
            }
        }
        public DebugControlActions @DebugControl => new DebugControlActions(this);
        public interface IRunningActions
        {
            void OnMovement(InputAction.CallbackContext context);
            void OnJump(InputAction.CallbackContext context);
        }
        public interface IMenuControlActions
        {
            void OnAcept(InputAction.CallbackContext context);
            void OnReturn(InputAction.CallbackContext context);
        }
        public interface IDebugControlActions
        {
            void OnResetScene(InputAction.CallbackContext context);
            void OnCloseGame(InputAction.CallbackContext context);
        }
    }
}
