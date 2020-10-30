// GENERATED AUTOMATICALLY FROM 'Assets/Inputs.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Inputs : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @Inputs()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Inputs"",
    ""maps"": [
        {
            ""name"": ""InputBufferActions"",
            ""id"": ""89e9d724-1897-49f2-bd77-37af34eec265"",
            ""actions"": [
                {
                    ""name"": ""Horizontal"",
                    ""type"": ""Value"",
                    ""id"": ""ccae170c-2ef3-442f-8315-dc44c12586ae"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Vertical"",
                    ""type"": ""Button"",
                    ""id"": ""6640442f-eec5-4954-8104-edb9e1cf5544"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""70e0f5f7-210b-4f10-903b-e7bbc9791984"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LightAttack"",
                    ""type"": ""Button"",
                    ""id"": ""8370664a-2306-4a28-a41c-9a9ce431153a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MediumAttack"",
                    ""type"": ""Button"",
                    ""id"": ""f56e7849-8deb-4cf1-a8c4-9cf18f8e1a89"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""HeavyAttack"",
                    ""type"": ""Button"",
                    ""id"": ""f1c9e265-0b46-4771-9c61-190d46b9a3dd"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Dash"",
                    ""type"": ""Button"",
                    ""id"": ""ca7d036e-5c94-4856-acfa-7ecf0ea4d15d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Keyboard"",
                    ""id"": ""f9d8af37-5344-4e50-b5a0-307070fca686"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Horizontal"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""739238e7-7bbb-4e04-a68a-ce4910e2dec8"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Horizontal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""a23c80ca-c4bd-4707-a77a-68cb2c5874e2"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Horizontal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Controller"",
                    ""id"": ""d59956af-6ed2-416b-a987-5bccfb188c6a"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Horizontal"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""dc98eb8e-82f8-4b44-8b78-2806a6b7279a"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Horizontal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""c8464647-146f-46a9-b1bf-d112980e5248"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Horizontal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Keyboard"",
                    ""id"": ""8b29b612-8bae-4103-8a91-3871b39df0ce"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Vertical"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""70371b88-ef1a-4d0c-b71e-eee33c85f294"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Vertical"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""30bf91e1-ec85-46ba-b01c-d93efa90926f"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Vertical"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Controller"",
                    ""id"": ""d684a56c-4016-46c8-9115-8717d14430f9"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Vertical"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""d797ee68-ca8f-469a-aa83-18c6c7959a6f"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Vertical"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""e256a6ea-9d10-40be-b796-a8fb30c9014b"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Vertical"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""61a68413-efa3-4b8e-95f8-63d48d461945"",
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
                    ""id"": ""ca8c7741-358a-450d-bd6b-546c6f10f246"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""07374155-77b2-4025-84c7-e5f89fe242b4"",
                    ""path"": ""<Keyboard>/i"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LightAttack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7fa27c58-7024-483d-b436-0e7b2248a3a7"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LightAttack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""260ef627-cb81-456c-ba56-33a54b662bb7"",
                    ""path"": ""<Keyboard>/o"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MediumAttack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""253aa792-86ea-421a-a04b-f5858719fda5"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MediumAttack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3823c5c2-f6e9-46cf-b108-6efea42a8030"",
                    ""path"": ""<Keyboard>/p"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""HeavyAttack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c11db632-3fec-41e6-8136-965a040231a4"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""HeavyAttack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8e8eb685-290a-404b-9cb3-3a43482c6f9c"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b4bb2888-dbe4-4636-8045-75fd4feb6bf9"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // InputBufferActions
        m_InputBufferActions = asset.FindActionMap("InputBufferActions", throwIfNotFound: true);
        m_InputBufferActions_Horizontal = m_InputBufferActions.FindAction("Horizontal", throwIfNotFound: true);
        m_InputBufferActions_Vertical = m_InputBufferActions.FindAction("Vertical", throwIfNotFound: true);
        m_InputBufferActions_Jump = m_InputBufferActions.FindAction("Jump", throwIfNotFound: true);
        m_InputBufferActions_LightAttack = m_InputBufferActions.FindAction("LightAttack", throwIfNotFound: true);
        m_InputBufferActions_MediumAttack = m_InputBufferActions.FindAction("MediumAttack", throwIfNotFound: true);
        m_InputBufferActions_HeavyAttack = m_InputBufferActions.FindAction("HeavyAttack", throwIfNotFound: true);
        m_InputBufferActions_Dash = m_InputBufferActions.FindAction("Dash", throwIfNotFound: true);
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

    // InputBufferActions
    private readonly InputActionMap m_InputBufferActions;
    private IInputBufferActionsActions m_InputBufferActionsActionsCallbackInterface;
    private readonly InputAction m_InputBufferActions_Horizontal;
    private readonly InputAction m_InputBufferActions_Vertical;
    private readonly InputAction m_InputBufferActions_Jump;
    private readonly InputAction m_InputBufferActions_LightAttack;
    private readonly InputAction m_InputBufferActions_MediumAttack;
    private readonly InputAction m_InputBufferActions_HeavyAttack;
    private readonly InputAction m_InputBufferActions_Dash;
    public struct InputBufferActionsActions
    {
        private @Inputs m_Wrapper;
        public InputBufferActionsActions(@Inputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @Horizontal => m_Wrapper.m_InputBufferActions_Horizontal;
        public InputAction @Vertical => m_Wrapper.m_InputBufferActions_Vertical;
        public InputAction @Jump => m_Wrapper.m_InputBufferActions_Jump;
        public InputAction @LightAttack => m_Wrapper.m_InputBufferActions_LightAttack;
        public InputAction @MediumAttack => m_Wrapper.m_InputBufferActions_MediumAttack;
        public InputAction @HeavyAttack => m_Wrapper.m_InputBufferActions_HeavyAttack;
        public InputAction @Dash => m_Wrapper.m_InputBufferActions_Dash;
        public InputActionMap Get() { return m_Wrapper.m_InputBufferActions; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(InputBufferActionsActions set) { return set.Get(); }
        public void SetCallbacks(IInputBufferActionsActions instance)
        {
            if (m_Wrapper.m_InputBufferActionsActionsCallbackInterface != null)
            {
                @Horizontal.started -= m_Wrapper.m_InputBufferActionsActionsCallbackInterface.OnHorizontal;
                @Horizontal.performed -= m_Wrapper.m_InputBufferActionsActionsCallbackInterface.OnHorizontal;
                @Horizontal.canceled -= m_Wrapper.m_InputBufferActionsActionsCallbackInterface.OnHorizontal;
                @Vertical.started -= m_Wrapper.m_InputBufferActionsActionsCallbackInterface.OnVertical;
                @Vertical.performed -= m_Wrapper.m_InputBufferActionsActionsCallbackInterface.OnVertical;
                @Vertical.canceled -= m_Wrapper.m_InputBufferActionsActionsCallbackInterface.OnVertical;
                @Jump.started -= m_Wrapper.m_InputBufferActionsActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_InputBufferActionsActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_InputBufferActionsActionsCallbackInterface.OnJump;
                @LightAttack.started -= m_Wrapper.m_InputBufferActionsActionsCallbackInterface.OnLightAttack;
                @LightAttack.performed -= m_Wrapper.m_InputBufferActionsActionsCallbackInterface.OnLightAttack;
                @LightAttack.canceled -= m_Wrapper.m_InputBufferActionsActionsCallbackInterface.OnLightAttack;
                @MediumAttack.started -= m_Wrapper.m_InputBufferActionsActionsCallbackInterface.OnMediumAttack;
                @MediumAttack.performed -= m_Wrapper.m_InputBufferActionsActionsCallbackInterface.OnMediumAttack;
                @MediumAttack.canceled -= m_Wrapper.m_InputBufferActionsActionsCallbackInterface.OnMediumAttack;
                @HeavyAttack.started -= m_Wrapper.m_InputBufferActionsActionsCallbackInterface.OnHeavyAttack;
                @HeavyAttack.performed -= m_Wrapper.m_InputBufferActionsActionsCallbackInterface.OnHeavyAttack;
                @HeavyAttack.canceled -= m_Wrapper.m_InputBufferActionsActionsCallbackInterface.OnHeavyAttack;
                @Dash.started -= m_Wrapper.m_InputBufferActionsActionsCallbackInterface.OnDash;
                @Dash.performed -= m_Wrapper.m_InputBufferActionsActionsCallbackInterface.OnDash;
                @Dash.canceled -= m_Wrapper.m_InputBufferActionsActionsCallbackInterface.OnDash;
            }
            m_Wrapper.m_InputBufferActionsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Horizontal.started += instance.OnHorizontal;
                @Horizontal.performed += instance.OnHorizontal;
                @Horizontal.canceled += instance.OnHorizontal;
                @Vertical.started += instance.OnVertical;
                @Vertical.performed += instance.OnVertical;
                @Vertical.canceled += instance.OnVertical;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @LightAttack.started += instance.OnLightAttack;
                @LightAttack.performed += instance.OnLightAttack;
                @LightAttack.canceled += instance.OnLightAttack;
                @MediumAttack.started += instance.OnMediumAttack;
                @MediumAttack.performed += instance.OnMediumAttack;
                @MediumAttack.canceled += instance.OnMediumAttack;
                @HeavyAttack.started += instance.OnHeavyAttack;
                @HeavyAttack.performed += instance.OnHeavyAttack;
                @HeavyAttack.canceled += instance.OnHeavyAttack;
                @Dash.started += instance.OnDash;
                @Dash.performed += instance.OnDash;
                @Dash.canceled += instance.OnDash;
            }
        }
    }
    public InputBufferActionsActions @InputBufferActions => new InputBufferActionsActions(this);
    public interface IInputBufferActionsActions
    {
        void OnHorizontal(InputAction.CallbackContext context);
        void OnVertical(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnLightAttack(InputAction.CallbackContext context);
        void OnMediumAttack(InputAction.CallbackContext context);
        void OnHeavyAttack(InputAction.CallbackContext context);
        void OnDash(InputAction.CallbackContext context);
    }
}
