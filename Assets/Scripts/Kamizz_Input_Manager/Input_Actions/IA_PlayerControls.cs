//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.5.0
//     from Assets/Kamizz_Input_Manager/Input_Actions/IA_PlayerControls.inputactions
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

public partial class @IA_PlayerControls: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @IA_PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""IA_PlayerControls"",
    ""maps"": [
        {
            ""name"": ""AM_Grounded"",
            ""id"": ""0ef5830f-0c50-4925-a3f4-6192e77dabdd"",
            ""actions"": [
                {
                    ""name"": ""MoveAction"",
                    ""type"": ""PassThrough"",
                    ""id"": ""1563e819-2769-47d5-9914-089fa4861bb2"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WSAD"",
                    ""id"": ""5ed8bc7b-6ccb-4b8a-8bcc-9a7b7aefb7e3"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": ""NormalizeVector2"",
                    ""groups"": """",
                    ""action"": ""MoveAction"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""2c6bfcac-bbad-4d14-9942-779cb96efd84"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""eef7d684-28c0-472d-bb70-ac633c656727"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""5a8d5084-4fee-4825-a8bf-1ac16d7e61ef"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""aca7493c-4851-4d0f-8f52-67cfaed52f18"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // AM_Grounded
        m_AM_Grounded = asset.FindActionMap("AM_Grounded", throwIfNotFound: true);
        m_AM_Grounded_MoveAction = m_AM_Grounded.FindAction("MoveAction", throwIfNotFound: true);
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

    // AM_Grounded
    private readonly InputActionMap m_AM_Grounded;
    private List<IAM_GroundedActions> m_AM_GroundedActionsCallbackInterfaces = new List<IAM_GroundedActions>();
    private readonly InputAction m_AM_Grounded_MoveAction;
    public struct AM_GroundedActions
    {
        private @IA_PlayerControls m_Wrapper;
        public AM_GroundedActions(@IA_PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @MoveAction => m_Wrapper.m_AM_Grounded_MoveAction;
        public InputActionMap Get() { return m_Wrapper.m_AM_Grounded; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(AM_GroundedActions set) { return set.Get(); }
        public void AddCallbacks(IAM_GroundedActions instance)
        {
            if (instance == null || m_Wrapper.m_AM_GroundedActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_AM_GroundedActionsCallbackInterfaces.Add(instance);
            @MoveAction.started += instance.OnMoveAction;
            @MoveAction.performed += instance.OnMoveAction;
            @MoveAction.canceled += instance.OnMoveAction;
        }

        private void UnregisterCallbacks(IAM_GroundedActions instance)
        {
            @MoveAction.started -= instance.OnMoveAction;
            @MoveAction.performed -= instance.OnMoveAction;
            @MoveAction.canceled -= instance.OnMoveAction;
        }

        public void RemoveCallbacks(IAM_GroundedActions instance)
        {
            if (m_Wrapper.m_AM_GroundedActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IAM_GroundedActions instance)
        {
            foreach (var item in m_Wrapper.m_AM_GroundedActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_AM_GroundedActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public AM_GroundedActions @AM_Grounded => new AM_GroundedActions(this);
    public interface IAM_GroundedActions
    {
        void OnMoveAction(InputAction.CallbackContext context);
    }
}
