//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/ThirdPersonController/Input/ThirdPersonInput.inputactions
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

namespace Games.ThirdPersonController
{
    public partial class @ThirdPersonInput: IInputActionCollection2, IDisposable
    {
        public InputActionAsset asset { get; }
        public @ThirdPersonInput()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""ThirdPersonInput"",
    ""maps"": [
        {
            ""name"": ""Locomotion"",
            ""id"": ""5758a864-77e4-42f3-b336-64803acd9c72"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""119556d5-bf68-4464-a70e-a10d648684a3"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Run"",
                    ""type"": ""Button"",
                    ""id"": ""a046b7d9-f91c-47c1-9bd3-dcc84ed413f7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""475e799d-c67b-42f5-b040-7b0a0dcf2839"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Crouch"",
                    ""type"": ""Button"",
                    ""id"": ""1837bc6e-8150-4514-9ecd-1efa5b4c10af"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""031e63c8-dced-4bb0-86b8-1910a96f3288"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""839c2d0d-7b13-4c83-938e-9d1ded354b5d"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""5245d775-3219-44be-a8d1-3b7f654a2b17"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""e449ce28-dc7f-493e-b05b-e2441e2d1a27"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""20754486-28f5-449c-a4cc-15e0e1bd0b41"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""e5cce88d-af29-41b7-9b0f-1d5781ddd7fa"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Run"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6a6d92d7-7f4e-44ee-a7d1-8024de617b93"",
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
                    ""id"": ""2b872049-51d1-4834-b9f5-fbb3b21a555e"",
                    ""path"": ""<Keyboard>/c"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Crouch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""MouseMovement"",
            ""id"": ""b8e4f942-44c5-4b4a-93c2-4d8b5a663adc"",
            ""actions"": [
                {
                    ""name"": ""Mouse"",
                    ""type"": ""Value"",
                    ""id"": ""51a390c0-d70c-40fb-b87b-291258fac5b4"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""8855a8f2-d83a-4796-9b24-97760994829e"",
                    ""path"": ""<Pointer>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Mouse"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
            // Locomotion
            m_Locomotion = asset.FindActionMap("Locomotion", throwIfNotFound: true);
            m_Locomotion_Movement = m_Locomotion.FindAction("Movement", throwIfNotFound: true);
            m_Locomotion_Run = m_Locomotion.FindAction("Run", throwIfNotFound: true);
            m_Locomotion_Jump = m_Locomotion.FindAction("Jump", throwIfNotFound: true);
            m_Locomotion_Crouch = m_Locomotion.FindAction("Crouch", throwIfNotFound: true);
            // MouseMovement
            m_MouseMovement = asset.FindActionMap("MouseMovement", throwIfNotFound: true);
            m_MouseMovement_Mouse = m_MouseMovement.FindAction("Mouse", throwIfNotFound: true);
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

        // Locomotion
        private readonly InputActionMap m_Locomotion;
        private List<ILocomotionActions> m_LocomotionActionsCallbackInterfaces = new List<ILocomotionActions>();
        private readonly InputAction m_Locomotion_Movement;
        private readonly InputAction m_Locomotion_Run;
        private readonly InputAction m_Locomotion_Jump;
        private readonly InputAction m_Locomotion_Crouch;
        public struct LocomotionActions
        {
            private @ThirdPersonInput m_Wrapper;
            public LocomotionActions(@ThirdPersonInput wrapper) { m_Wrapper = wrapper; }
            public InputAction @Movement => m_Wrapper.m_Locomotion_Movement;
            public InputAction @Run => m_Wrapper.m_Locomotion_Run;
            public InputAction @Jump => m_Wrapper.m_Locomotion_Jump;
            public InputAction @Crouch => m_Wrapper.m_Locomotion_Crouch;
            public InputActionMap Get() { return m_Wrapper.m_Locomotion; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(LocomotionActions set) { return set.Get(); }
            public void AddCallbacks(ILocomotionActions instance)
            {
                if (instance == null || m_Wrapper.m_LocomotionActionsCallbackInterfaces.Contains(instance)) return;
                m_Wrapper.m_LocomotionActionsCallbackInterfaces.Add(instance);
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Run.started += instance.OnRun;
                @Run.performed += instance.OnRun;
                @Run.canceled += instance.OnRun;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Crouch.started += instance.OnCrouch;
                @Crouch.performed += instance.OnCrouch;
                @Crouch.canceled += instance.OnCrouch;
            }

            private void UnregisterCallbacks(ILocomotionActions instance)
            {
                @Movement.started -= instance.OnMovement;
                @Movement.performed -= instance.OnMovement;
                @Movement.canceled -= instance.OnMovement;
                @Run.started -= instance.OnRun;
                @Run.performed -= instance.OnRun;
                @Run.canceled -= instance.OnRun;
                @Jump.started -= instance.OnJump;
                @Jump.performed -= instance.OnJump;
                @Jump.canceled -= instance.OnJump;
                @Crouch.started -= instance.OnCrouch;
                @Crouch.performed -= instance.OnCrouch;
                @Crouch.canceled -= instance.OnCrouch;
            }

            public void RemoveCallbacks(ILocomotionActions instance)
            {
                if (m_Wrapper.m_LocomotionActionsCallbackInterfaces.Remove(instance))
                    UnregisterCallbacks(instance);
            }

            public void SetCallbacks(ILocomotionActions instance)
            {
                foreach (var item in m_Wrapper.m_LocomotionActionsCallbackInterfaces)
                    UnregisterCallbacks(item);
                m_Wrapper.m_LocomotionActionsCallbackInterfaces.Clear();
                AddCallbacks(instance);
            }
        }
        public LocomotionActions @Locomotion => new LocomotionActions(this);

        // MouseMovement
        private readonly InputActionMap m_MouseMovement;
        private List<IMouseMovementActions> m_MouseMovementActionsCallbackInterfaces = new List<IMouseMovementActions>();
        private readonly InputAction m_MouseMovement_Mouse;
        public struct MouseMovementActions
        {
            private @ThirdPersonInput m_Wrapper;
            public MouseMovementActions(@ThirdPersonInput wrapper) { m_Wrapper = wrapper; }
            public InputAction @Mouse => m_Wrapper.m_MouseMovement_Mouse;
            public InputActionMap Get() { return m_Wrapper.m_MouseMovement; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(MouseMovementActions set) { return set.Get(); }
            public void AddCallbacks(IMouseMovementActions instance)
            {
                if (instance == null || m_Wrapper.m_MouseMovementActionsCallbackInterfaces.Contains(instance)) return;
                m_Wrapper.m_MouseMovementActionsCallbackInterfaces.Add(instance);
                @Mouse.started += instance.OnMouse;
                @Mouse.performed += instance.OnMouse;
                @Mouse.canceled += instance.OnMouse;
            }

            private void UnregisterCallbacks(IMouseMovementActions instance)
            {
                @Mouse.started -= instance.OnMouse;
                @Mouse.performed -= instance.OnMouse;
                @Mouse.canceled -= instance.OnMouse;
            }

            public void RemoveCallbacks(IMouseMovementActions instance)
            {
                if (m_Wrapper.m_MouseMovementActionsCallbackInterfaces.Remove(instance))
                    UnregisterCallbacks(instance);
            }

            public void SetCallbacks(IMouseMovementActions instance)
            {
                foreach (var item in m_Wrapper.m_MouseMovementActionsCallbackInterfaces)
                    UnregisterCallbacks(item);
                m_Wrapper.m_MouseMovementActionsCallbackInterfaces.Clear();
                AddCallbacks(instance);
            }
        }
        public MouseMovementActions @MouseMovement => new MouseMovementActions(this);
        public interface ILocomotionActions
        {
            void OnMovement(InputAction.CallbackContext context);
            void OnRun(InputAction.CallbackContext context);
            void OnJump(InputAction.CallbackContext context);
            void OnCrouch(InputAction.CallbackContext context);
        }
        public interface IMouseMovementActions
        {
            void OnMouse(InputAction.CallbackContext context);
        }
    }
}
