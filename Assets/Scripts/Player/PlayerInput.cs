//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.6.3
//     from Assets/Input/PlayerInput.inputactions
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

public partial class @PlayerInput: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInput"",
    ""maps"": [
        {
            ""name"": ""LevelSelector"",
            ""id"": ""de6fd7e2-4498-4bf1-9ac5-de3023a009ff"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""a1a726af-92db-48a6-9604-7c28e397f9c9"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""ba72c2b9-fdd7-4348-9727-68bb3e0a0665"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""7161a6f1-8e7e-4713-a229-ed88f63514a6"",
                    ""path"": ""<Keyboard>/#(A)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""360eb133-e48c-4a4e-b624-b97cae8b4691"",
                    ""path"": ""<Keyboard>/#(D)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        },
        {
            ""name"": ""TopDown"",
            ""id"": ""87de0947-597f-44d5-a28f-6616c3a6dbc1"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""ba238bc3-0008-42d4-b7b3-227542e6b5b8"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""8937d78f-1fcd-45be-953b-4e353ef09e5c"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""8ec4cbac-8c5b-4c57-9e3e-f7d064e7341b"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""bd2e0c86-7a81-43af-a42e-791efa890aa8"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""6505ba6e-a3cf-4cc4-9113-a505f1a272f1"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""52740354-9573-455b-a1b7-a68ec7e7fb84"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""New control scheme"",
            ""bindingGroup"": ""New control scheme"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // LevelSelector
        m_LevelSelector = asset.FindActionMap("LevelSelector", throwIfNotFound: true);
        m_LevelSelector_Move = m_LevelSelector.FindAction("Move", throwIfNotFound: true);
        // TopDown
        m_TopDown = asset.FindActionMap("TopDown", throwIfNotFound: true);
        m_TopDown_Move = m_TopDown.FindAction("Move", throwIfNotFound: true);
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

    // LevelSelector
    private readonly InputActionMap m_LevelSelector;
    private List<ILevelSelectorActions> m_LevelSelectorActionsCallbackInterfaces = new List<ILevelSelectorActions>();
    private readonly InputAction m_LevelSelector_Move;
    public struct LevelSelectorActions
    {
        private @PlayerInput m_Wrapper;
        public LevelSelectorActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_LevelSelector_Move;
        public InputActionMap Get() { return m_Wrapper.m_LevelSelector; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(LevelSelectorActions set) { return set.Get(); }
        public void AddCallbacks(ILevelSelectorActions instance)
        {
            if (instance == null || m_Wrapper.m_LevelSelectorActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_LevelSelectorActionsCallbackInterfaces.Add(instance);
            @Move.started += instance.OnMove;
            @Move.performed += instance.OnMove;
            @Move.canceled += instance.OnMove;
        }

        private void UnregisterCallbacks(ILevelSelectorActions instance)
        {
            @Move.started -= instance.OnMove;
            @Move.performed -= instance.OnMove;
            @Move.canceled -= instance.OnMove;
        }

        public void RemoveCallbacks(ILevelSelectorActions instance)
        {
            if (m_Wrapper.m_LevelSelectorActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(ILevelSelectorActions instance)
        {
            foreach (var item in m_Wrapper.m_LevelSelectorActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_LevelSelectorActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public LevelSelectorActions @LevelSelector => new LevelSelectorActions(this);

    // TopDown
    private readonly InputActionMap m_TopDown;
    private List<ITopDownActions> m_TopDownActionsCallbackInterfaces = new List<ITopDownActions>();
    private readonly InputAction m_TopDown_Move;
    public struct TopDownActions
    {
        private @PlayerInput m_Wrapper;
        public TopDownActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_TopDown_Move;
        public InputActionMap Get() { return m_Wrapper.m_TopDown; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(TopDownActions set) { return set.Get(); }
        public void AddCallbacks(ITopDownActions instance)
        {
            if (instance == null || m_Wrapper.m_TopDownActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_TopDownActionsCallbackInterfaces.Add(instance);
            @Move.started += instance.OnMove;
            @Move.performed += instance.OnMove;
            @Move.canceled += instance.OnMove;
        }

        private void UnregisterCallbacks(ITopDownActions instance)
        {
            @Move.started -= instance.OnMove;
            @Move.performed -= instance.OnMove;
            @Move.canceled -= instance.OnMove;
        }

        public void RemoveCallbacks(ITopDownActions instance)
        {
            if (m_Wrapper.m_TopDownActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(ITopDownActions instance)
        {
            foreach (var item in m_Wrapper.m_TopDownActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_TopDownActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public TopDownActions @TopDown => new TopDownActions(this);
    private int m_NewcontrolschemeSchemeIndex = -1;
    public InputControlScheme NewcontrolschemeScheme
    {
        get
        {
            if (m_NewcontrolschemeSchemeIndex == -1) m_NewcontrolschemeSchemeIndex = asset.FindControlSchemeIndex("New control scheme");
            return asset.controlSchemes[m_NewcontrolschemeSchemeIndex];
        }
    }
    public interface ILevelSelectorActions
    {
        void OnMove(InputAction.CallbackContext context);
    }
    public interface ITopDownActions
    {
        void OnMove(InputAction.CallbackContext context);
    }
}