//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.2.0
//     from Assets/Scripts/Components/PlayerInput.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace Components
{
    public partial class @PlayerInput : IInputActionCollection2, IDisposable
    {
        public InputActionAsset asset { get; }
        public @PlayerInput()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInput"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""d167e08c-e8d5-45c8-8477-de86136dd01c"",
            ""actions"": [
                {
                    ""name"": ""Moving"",
                    ""type"": ""Value"",
                    ""id"": ""8f926ba2-6ce1-45c1-9ed8-58741cbfcebe"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Click"",
                    ""type"": ""Button"",
                    ""id"": ""74055ad2-fcb8-4ac1-a536-fd34ff83ca6d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""a5cedeae-9ea8-4988-9bbc-8616e67edb1c"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Moving"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""99dfd740-9bd3-4c5c-b51c-1707c672ee09"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Click"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""59787f8b-fcfb-46a2-a03e-c856fc28011a"",
                    ""path"": ""<Mouse>/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Click"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0dbe875c-e50b-4da7-b04b-4c95fa330b16"",
                    ""path"": ""<Touchscreen>/Press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Click"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Touch"",
            ""id"": ""29194ef5-bf69-4f99-b0e0-75997fbb5487"",
            ""actions"": [
                {
                    ""name"": ""isTouched"",
                    ""type"": ""PassThrough"",
                    ""id"": ""60abd2be-47f1-4e80-8933-6215f0651d94"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Position"",
                    ""type"": ""PassThrough"",
                    ""id"": ""b6288168-f488-48e5-bd6e-d64f3728bb18"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Start"",
                    ""type"": ""PassThrough"",
                    ""id"": ""ea210e30-0bbf-4abb-996c-00455ab6d297"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""92a22535-2530-40f5-bc8d-58b6abe50548"",
                    ""path"": ""<Touchscreen>/Press"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""isTouched"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8f67f6a9-0942-4a45-b85a-d01f5d8f7fe9"",
                    ""path"": ""<Touchscreen>/primaryTouch/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Position"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e2c083a2-bf96-4540-80df-7e4576bbddc7"",
                    ""path"": ""<Touchscreen>/primaryTouch/startPosition"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Start"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Player"",
            ""bindingGroup"": ""Player"",
            ""devices"": []
        }
    ]
}");
            // Player
            m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
            m_Player_Moving = m_Player.FindAction("Moving", throwIfNotFound: true);
            m_Player_Click = m_Player.FindAction("Click", throwIfNotFound: true);
            // Touch
            m_Touch = asset.FindActionMap("Touch", throwIfNotFound: true);
            m_Touch_isTouched = m_Touch.FindAction("isTouched", throwIfNotFound: true);
            m_Touch_Position = m_Touch.FindAction("Position", throwIfNotFound: true);
            m_Touch_Start = m_Touch.FindAction("Start", throwIfNotFound: true);
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
        public IEnumerable<InputBinding> bindings => asset.bindings;

        public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
        {
            return asset.FindAction(actionNameOrId, throwIfNotFound);
        }
        public int FindBinding(InputBinding bindingMask, out InputAction action)
        {
            return asset.FindBinding(bindingMask, out action);
        }

        // Player
        private readonly InputActionMap m_Player;
        private IPlayerActions m_PlayerActionsCallbackInterface;
        private readonly InputAction m_Player_Moving;
        private readonly InputAction m_Player_Click;
        public struct PlayerActions
        {
            private @PlayerInput m_Wrapper;
            public PlayerActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
            public InputAction @Moving => m_Wrapper.m_Player_Moving;
            public InputAction @Click => m_Wrapper.m_Player_Click;
            public InputActionMap Get() { return m_Wrapper.m_Player; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
            public void SetCallbacks(IPlayerActions instance)
            {
                if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
                {
                    @Moving.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMoving;
                    @Moving.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMoving;
                    @Moving.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMoving;
                    @Click.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnClick;
                    @Click.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnClick;
                    @Click.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnClick;
                }
                m_Wrapper.m_PlayerActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Moving.started += instance.OnMoving;
                    @Moving.performed += instance.OnMoving;
                    @Moving.canceled += instance.OnMoving;
                    @Click.started += instance.OnClick;
                    @Click.performed += instance.OnClick;
                    @Click.canceled += instance.OnClick;
                }
            }
        }
        public PlayerActions @Player => new PlayerActions(this);

        // Touch
        private readonly InputActionMap m_Touch;
        private ITouchActions m_TouchActionsCallbackInterface;
        private readonly InputAction m_Touch_isTouched;
        private readonly InputAction m_Touch_Position;
        private readonly InputAction m_Touch_Start;
        public struct TouchActions
        {
            private @PlayerInput m_Wrapper;
            public TouchActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
            public InputAction @isTouched => m_Wrapper.m_Touch_isTouched;
            public InputAction @Position => m_Wrapper.m_Touch_Position;
            public InputAction @Start => m_Wrapper.m_Touch_Start;
            public InputActionMap Get() { return m_Wrapper.m_Touch; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(TouchActions set) { return set.Get(); }
            public void SetCallbacks(ITouchActions instance)
            {
                if (m_Wrapper.m_TouchActionsCallbackInterface != null)
                {
                    @isTouched.started -= m_Wrapper.m_TouchActionsCallbackInterface.OnIsTouched;
                    @isTouched.performed -= m_Wrapper.m_TouchActionsCallbackInterface.OnIsTouched;
                    @isTouched.canceled -= m_Wrapper.m_TouchActionsCallbackInterface.OnIsTouched;
                    @Position.started -= m_Wrapper.m_TouchActionsCallbackInterface.OnPosition;
                    @Position.performed -= m_Wrapper.m_TouchActionsCallbackInterface.OnPosition;
                    @Position.canceled -= m_Wrapper.m_TouchActionsCallbackInterface.OnPosition;
                    @Start.started -= m_Wrapper.m_TouchActionsCallbackInterface.OnStart;
                    @Start.performed -= m_Wrapper.m_TouchActionsCallbackInterface.OnStart;
                    @Start.canceled -= m_Wrapper.m_TouchActionsCallbackInterface.OnStart;
                }
                m_Wrapper.m_TouchActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @isTouched.started += instance.OnIsTouched;
                    @isTouched.performed += instance.OnIsTouched;
                    @isTouched.canceled += instance.OnIsTouched;
                    @Position.started += instance.OnPosition;
                    @Position.performed += instance.OnPosition;
                    @Position.canceled += instance.OnPosition;
                    @Start.started += instance.OnStart;
                    @Start.performed += instance.OnStart;
                    @Start.canceled += instance.OnStart;
                }
            }
        }
        public TouchActions @Touch => new TouchActions(this);
        private int m_PlayerSchemeIndex = -1;
        public InputControlScheme PlayerScheme
        {
            get
            {
                if (m_PlayerSchemeIndex == -1) m_PlayerSchemeIndex = asset.FindControlSchemeIndex("Player");
                return asset.controlSchemes[m_PlayerSchemeIndex];
            }
        }
        public interface IPlayerActions
        {
            void OnMoving(InputAction.CallbackContext context);
            void OnClick(InputAction.CallbackContext context);
        }
        public interface ITouchActions
        {
            void OnIsTouched(InputAction.CallbackContext context);
            void OnPosition(InputAction.CallbackContext context);
            void OnStart(InputAction.CallbackContext context);
        }
    }
}
