//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/InputSystem/PlayerActions.inputactions
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

public partial class @PlayerActions: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerActions"",
    ""maps"": [
        {
            ""name"": ""PlayerInputs"",
            ""id"": ""8903bd95-0b90-41ae-9914-6c63311cf621"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Button"",
                    ""id"": ""137da145-d934-4a7d-8b12-0568eb01f7cd"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""8514dba4-b680-48d0-abae-17ae8b489be3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Ruin"",
                    ""type"": ""Button"",
                    ""id"": ""8c286c09-240a-4f71-bdef-8a86174b8cda"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""e341c4e4-bced-408b-ad24-2db1dd250480"",
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
                    ""id"": ""5a5a601a-ec71-43f3-8fd8-f4e755b166f0"",
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
                    ""id"": ""7752f50e-d199-4ef8-966d-b032c1a1651d"",
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
                    ""id"": ""0b0b75eb-8dc2-4799-9997-51ffedba1a68"",
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
                    ""id"": ""43d06a4b-82dc-4fc2-b890-76afd2fc4d4f"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""JumpVector"",
                    ""id"": ""e41caf11-e73d-45cd-b849-8ada737808f8"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""f9e56eb5-9ccb-48f0-a670-c3dd52e255ab"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""up"",
                    ""id"": ""6b43ff58-c2c7-491d-a486-6d6e41f4ee49"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""RuinVector"",
                    ""id"": ""d2ecc645-274b-4b6c-a58c-64da3912fecb"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Ruin"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""down"",
                    ""id"": ""82ba9a11-3f5b-4e1a-8167-c82bac8bd989"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Ruin"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        },
        {
            ""name"": ""ThrowRock"",
            ""id"": ""6fed4d88-c5dd-4217-948e-eb4887c71fd2"",
            ""actions"": [
                {
                    ""name"": ""Throw"",
                    ""type"": ""Button"",
                    ""id"": ""03e91ac1-3564-4fb2-a2ac-36b2d3c239d6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""0c5379e1-fa05-4ef1-91f8-b1440a5a93a3"",
                    ""path"": ""<Keyboard>/n"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Throw"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // PlayerInputs
        m_PlayerInputs = asset.FindActionMap("PlayerInputs", throwIfNotFound: true);
        m_PlayerInputs_Movement = m_PlayerInputs.FindAction("Movement", throwIfNotFound: true);
        m_PlayerInputs_Jump = m_PlayerInputs.FindAction("Jump", throwIfNotFound: true);
        m_PlayerInputs_Ruin = m_PlayerInputs.FindAction("Ruin", throwIfNotFound: true);
        // ThrowRock
        m_ThrowRock = asset.FindActionMap("ThrowRock", throwIfNotFound: true);
        m_ThrowRock_Throw = m_ThrowRock.FindAction("Throw", throwIfNotFound: true);
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

    // PlayerInputs
    private readonly InputActionMap m_PlayerInputs;
    private List<IPlayerInputsActions> m_PlayerInputsActionsCallbackInterfaces = new List<IPlayerInputsActions>();
    private readonly InputAction m_PlayerInputs_Movement;
    private readonly InputAction m_PlayerInputs_Jump;
    private readonly InputAction m_PlayerInputs_Ruin;
    public struct PlayerInputsActions
    {
        private @PlayerActions m_Wrapper;
        public PlayerInputsActions(@PlayerActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_PlayerInputs_Movement;
        public InputAction @Jump => m_Wrapper.m_PlayerInputs_Jump;
        public InputAction @Ruin => m_Wrapper.m_PlayerInputs_Ruin;
        public InputActionMap Get() { return m_Wrapper.m_PlayerInputs; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerInputsActions set) { return set.Get(); }
        public void AddCallbacks(IPlayerInputsActions instance)
        {
            if (instance == null || m_Wrapper.m_PlayerInputsActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_PlayerInputsActionsCallbackInterfaces.Add(instance);
            @Movement.started += instance.OnMovement;
            @Movement.performed += instance.OnMovement;
            @Movement.canceled += instance.OnMovement;
            @Jump.started += instance.OnJump;
            @Jump.performed += instance.OnJump;
            @Jump.canceled += instance.OnJump;
            @Ruin.started += instance.OnRuin;
            @Ruin.performed += instance.OnRuin;
            @Ruin.canceled += instance.OnRuin;
        }

        private void UnregisterCallbacks(IPlayerInputsActions instance)
        {
            @Movement.started -= instance.OnMovement;
            @Movement.performed -= instance.OnMovement;
            @Movement.canceled -= instance.OnMovement;
            @Jump.started -= instance.OnJump;
            @Jump.performed -= instance.OnJump;
            @Jump.canceled -= instance.OnJump;
            @Ruin.started -= instance.OnRuin;
            @Ruin.performed -= instance.OnRuin;
            @Ruin.canceled -= instance.OnRuin;
        }

        public void RemoveCallbacks(IPlayerInputsActions instance)
        {
            if (m_Wrapper.m_PlayerInputsActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IPlayerInputsActions instance)
        {
            foreach (var item in m_Wrapper.m_PlayerInputsActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_PlayerInputsActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public PlayerInputsActions @PlayerInputs => new PlayerInputsActions(this);

    // ThrowRock
    private readonly InputActionMap m_ThrowRock;
    private List<IThrowRockActions> m_ThrowRockActionsCallbackInterfaces = new List<IThrowRockActions>();
    private readonly InputAction m_ThrowRock_Throw;
    public struct ThrowRockActions
    {
        private @PlayerActions m_Wrapper;
        public ThrowRockActions(@PlayerActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Throw => m_Wrapper.m_ThrowRock_Throw;
        public InputActionMap Get() { return m_Wrapper.m_ThrowRock; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ThrowRockActions set) { return set.Get(); }
        public void AddCallbacks(IThrowRockActions instance)
        {
            if (instance == null || m_Wrapper.m_ThrowRockActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_ThrowRockActionsCallbackInterfaces.Add(instance);
            @Throw.started += instance.OnThrow;
            @Throw.performed += instance.OnThrow;
            @Throw.canceled += instance.OnThrow;
        }

        private void UnregisterCallbacks(IThrowRockActions instance)
        {
            @Throw.started -= instance.OnThrow;
            @Throw.performed -= instance.OnThrow;
            @Throw.canceled -= instance.OnThrow;
        }

        public void RemoveCallbacks(IThrowRockActions instance)
        {
            if (m_Wrapper.m_ThrowRockActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IThrowRockActions instance)
        {
            foreach (var item in m_Wrapper.m_ThrowRockActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_ThrowRockActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public ThrowRockActions @ThrowRock => new ThrowRockActions(this);
    public interface IPlayerInputsActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnRuin(InputAction.CallbackContext context);
    }
    public interface IThrowRockActions
    {
        void OnThrow(InputAction.CallbackContext context);
    }
}
