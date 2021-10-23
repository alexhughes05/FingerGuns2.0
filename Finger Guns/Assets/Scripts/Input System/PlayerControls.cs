// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Input System/PlayerControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""FingerGunMan"",
            ""id"": ""6ba6440c-a28e-4722-bd36-911727f2c3e1"",
            ""actions"": [
                {
                    ""name"": ""MoveHorizontal"",
                    ""type"": ""Value"",
                    ""id"": ""67b2377c-cd24-4f1e-b4e7-0ba208fe9624"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""3035f2f2-3f87-49e6-91ce-a4bcb20275b6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Crouch"",
                    ""type"": ""Button"",
                    ""id"": ""55b2b18b-91ee-4a5c-bc0f-dbfc730a3ee3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SlideLeft"",
                    ""type"": ""Button"",
                    ""id"": ""8934c5f5-305c-47b2-9ba8-91676cef744e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SlideRight"",
                    ""type"": ""Button"",
                    ""id"": ""72dce245-f617-447b-b23a-0dee34b1c806"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""FlipLeft"",
                    ""type"": ""Button"",
                    ""id"": ""e50597a2-c0ff-400b-936b-c616d49cbfaf"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""FlipRight"",
                    ""type"": ""Button"",
                    ""id"": ""85985629-0625-48d4-944a-5cc0c3bdab6f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Shoot"",
                    ""type"": ""PassThrough"",
                    ""id"": ""fa8cd00d-25b0-405b-a9b8-bb6328df0930"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Aim"",
                    ""type"": ""PassThrough"",
                    ""id"": ""0823240c-c9fb-487b-99cc-849abebbc21c"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Sideways"",
                    ""id"": ""2b77d362-6b41-4490-b4a7-f157d98070c7"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveHorizontal"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""ccec09b4-874d-49b9-b029-3e8e784cf50b"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""MoveHorizontal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""28902369-e7c4-4a72-868d-ce95847c3a31"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""MoveHorizontal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""79859a36-80c4-4efb-8f0d-51c78764c707"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Crouch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Button With One Modifier"",
                    ""id"": ""d183a821-1679-42bf-a951-889d13d476a5"",
                    ""path"": ""ButtonWithOneModifier"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SlideRight"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""modifier"",
                    ""id"": ""4b8a8973-ea85-4d82-b9e5-98f1f5f11ae4"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""SlideRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""button"",
                    ""id"": ""3de89198-2c54-4b23-b13d-975a32a4f3f3"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""SlideRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Button With One Modifier"",
                    ""id"": ""bd4ec3d8-6a77-47fa-b6c1-1ae2d96799be"",
                    ""path"": ""ButtonWithOneModifier"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SlideLeft"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""modifier"",
                    ""id"": ""c5288b43-8c0c-442c-bbd0-b51bea568013"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""SlideLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""button"",
                    ""id"": ""7eb83c40-83ed-4c9c-b7c5-1f346b084ec1"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""SlideLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""6c871efe-2812-44bb-868d-4df4bdc1cdf3"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Button With One Modifier"",
                    ""id"": ""d9c175d0-c013-477f-8029-b02f04b6a28c"",
                    ""path"": ""ButtonWithOneModifier"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""FlipLeft"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""modifier"",
                    ""id"": ""1f15c934-7a05-4e5e-9314-27e1d75932c4"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""FlipLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""button"",
                    ""id"": ""78e2a797-10f7-4c8e-a0e2-b07cd83bebaf"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""FlipLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Button With One Modifier"",
                    ""id"": ""4e690c5a-295d-4574-867a-eed90df31e27"",
                    ""path"": ""ButtonWithOneModifier"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""FlipRight"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""modifier"",
                    ""id"": ""264ba6ec-e3f0-46d4-b917-09fafdf8f788"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""FlipRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""button"",
                    ""id"": ""81d4660b-41f8-4bfb-965c-198375294035"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""FlipRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""f9f2a8dc-fef8-470f-94c6-9e83d28ef11a"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3a35164f-cec0-42d5-b9c0-9555281ee348"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Aim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard and Mouse"",
            ""bindingGroup"": ""Keyboard and Mouse"",
            ""devices"": []
        },
        {
            ""name"": ""Gamepad"",
            ""bindingGroup"": ""Gamepad"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // FingerGunMan
        m_FingerGunMan = asset.FindActionMap("FingerGunMan", throwIfNotFound: true);
        m_FingerGunMan_MoveHorizontal = m_FingerGunMan.FindAction("MoveHorizontal", throwIfNotFound: true);
        m_FingerGunMan_Jump = m_FingerGunMan.FindAction("Jump", throwIfNotFound: true);
        m_FingerGunMan_Crouch = m_FingerGunMan.FindAction("Crouch", throwIfNotFound: true);
        m_FingerGunMan_SlideLeft = m_FingerGunMan.FindAction("SlideLeft", throwIfNotFound: true);
        m_FingerGunMan_SlideRight = m_FingerGunMan.FindAction("SlideRight", throwIfNotFound: true);
        m_FingerGunMan_FlipLeft = m_FingerGunMan.FindAction("FlipLeft", throwIfNotFound: true);
        m_FingerGunMan_FlipRight = m_FingerGunMan.FindAction("FlipRight", throwIfNotFound: true);
        m_FingerGunMan_Shoot = m_FingerGunMan.FindAction("Shoot", throwIfNotFound: true);
        m_FingerGunMan_Aim = m_FingerGunMan.FindAction("Aim", throwIfNotFound: true);
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

    // FingerGunMan
    private readonly InputActionMap m_FingerGunMan;
    private IFingerGunManActions m_FingerGunManActionsCallbackInterface;
    private readonly InputAction m_FingerGunMan_MoveHorizontal;
    private readonly InputAction m_FingerGunMan_Jump;
    private readonly InputAction m_FingerGunMan_Crouch;
    private readonly InputAction m_FingerGunMan_SlideLeft;
    private readonly InputAction m_FingerGunMan_SlideRight;
    private readonly InputAction m_FingerGunMan_FlipLeft;
    private readonly InputAction m_FingerGunMan_FlipRight;
    private readonly InputAction m_FingerGunMan_Shoot;
    private readonly InputAction m_FingerGunMan_Aim;
    public struct FingerGunManActions
    {
        private @PlayerControls m_Wrapper;
        public FingerGunManActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @MoveHorizontal => m_Wrapper.m_FingerGunMan_MoveHorizontal;
        public InputAction @Jump => m_Wrapper.m_FingerGunMan_Jump;
        public InputAction @Crouch => m_Wrapper.m_FingerGunMan_Crouch;
        public InputAction @SlideLeft => m_Wrapper.m_FingerGunMan_SlideLeft;
        public InputAction @SlideRight => m_Wrapper.m_FingerGunMan_SlideRight;
        public InputAction @FlipLeft => m_Wrapper.m_FingerGunMan_FlipLeft;
        public InputAction @FlipRight => m_Wrapper.m_FingerGunMan_FlipRight;
        public InputAction @Shoot => m_Wrapper.m_FingerGunMan_Shoot;
        public InputAction @Aim => m_Wrapper.m_FingerGunMan_Aim;
        public InputActionMap Get() { return m_Wrapper.m_FingerGunMan; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(FingerGunManActions set) { return set.Get(); }
        public void SetCallbacks(IFingerGunManActions instance)
        {
            if (m_Wrapper.m_FingerGunManActionsCallbackInterface != null)
            {
                @MoveHorizontal.started -= m_Wrapper.m_FingerGunManActionsCallbackInterface.OnMoveHorizontal;
                @MoveHorizontal.performed -= m_Wrapper.m_FingerGunManActionsCallbackInterface.OnMoveHorizontal;
                @MoveHorizontal.canceled -= m_Wrapper.m_FingerGunManActionsCallbackInterface.OnMoveHorizontal;
                @Jump.started -= m_Wrapper.m_FingerGunManActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_FingerGunManActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_FingerGunManActionsCallbackInterface.OnJump;
                @Crouch.started -= m_Wrapper.m_FingerGunManActionsCallbackInterface.OnCrouch;
                @Crouch.performed -= m_Wrapper.m_FingerGunManActionsCallbackInterface.OnCrouch;
                @Crouch.canceled -= m_Wrapper.m_FingerGunManActionsCallbackInterface.OnCrouch;
                @SlideLeft.started -= m_Wrapper.m_FingerGunManActionsCallbackInterface.OnSlideLeft;
                @SlideLeft.performed -= m_Wrapper.m_FingerGunManActionsCallbackInterface.OnSlideLeft;
                @SlideLeft.canceled -= m_Wrapper.m_FingerGunManActionsCallbackInterface.OnSlideLeft;
                @SlideRight.started -= m_Wrapper.m_FingerGunManActionsCallbackInterface.OnSlideRight;
                @SlideRight.performed -= m_Wrapper.m_FingerGunManActionsCallbackInterface.OnSlideRight;
                @SlideRight.canceled -= m_Wrapper.m_FingerGunManActionsCallbackInterface.OnSlideRight;
                @FlipLeft.started -= m_Wrapper.m_FingerGunManActionsCallbackInterface.OnFlipLeft;
                @FlipLeft.performed -= m_Wrapper.m_FingerGunManActionsCallbackInterface.OnFlipLeft;
                @FlipLeft.canceled -= m_Wrapper.m_FingerGunManActionsCallbackInterface.OnFlipLeft;
                @FlipRight.started -= m_Wrapper.m_FingerGunManActionsCallbackInterface.OnFlipRight;
                @FlipRight.performed -= m_Wrapper.m_FingerGunManActionsCallbackInterface.OnFlipRight;
                @FlipRight.canceled -= m_Wrapper.m_FingerGunManActionsCallbackInterface.OnFlipRight;
                @Shoot.started -= m_Wrapper.m_FingerGunManActionsCallbackInterface.OnShoot;
                @Shoot.performed -= m_Wrapper.m_FingerGunManActionsCallbackInterface.OnShoot;
                @Shoot.canceled -= m_Wrapper.m_FingerGunManActionsCallbackInterface.OnShoot;
                @Aim.started -= m_Wrapper.m_FingerGunManActionsCallbackInterface.OnAim;
                @Aim.performed -= m_Wrapper.m_FingerGunManActionsCallbackInterface.OnAim;
                @Aim.canceled -= m_Wrapper.m_FingerGunManActionsCallbackInterface.OnAim;
            }
            m_Wrapper.m_FingerGunManActionsCallbackInterface = instance;
            if (instance != null)
            {
                @MoveHorizontal.started += instance.OnMoveHorizontal;
                @MoveHorizontal.performed += instance.OnMoveHorizontal;
                @MoveHorizontal.canceled += instance.OnMoveHorizontal;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Crouch.started += instance.OnCrouch;
                @Crouch.performed += instance.OnCrouch;
                @Crouch.canceled += instance.OnCrouch;
                @SlideLeft.started += instance.OnSlideLeft;
                @SlideLeft.performed += instance.OnSlideLeft;
                @SlideLeft.canceled += instance.OnSlideLeft;
                @SlideRight.started += instance.OnSlideRight;
                @SlideRight.performed += instance.OnSlideRight;
                @SlideRight.canceled += instance.OnSlideRight;
                @FlipLeft.started += instance.OnFlipLeft;
                @FlipLeft.performed += instance.OnFlipLeft;
                @FlipLeft.canceled += instance.OnFlipLeft;
                @FlipRight.started += instance.OnFlipRight;
                @FlipRight.performed += instance.OnFlipRight;
                @FlipRight.canceled += instance.OnFlipRight;
                @Shoot.started += instance.OnShoot;
                @Shoot.performed += instance.OnShoot;
                @Shoot.canceled += instance.OnShoot;
                @Aim.started += instance.OnAim;
                @Aim.performed += instance.OnAim;
                @Aim.canceled += instance.OnAim;
            }
        }
    }
    public FingerGunManActions @FingerGunMan => new FingerGunManActions(this);
    private int m_KeyboardandMouseSchemeIndex = -1;
    public InputControlScheme KeyboardandMouseScheme
    {
        get
        {
            if (m_KeyboardandMouseSchemeIndex == -1) m_KeyboardandMouseSchemeIndex = asset.FindControlSchemeIndex("Keyboard and Mouse");
            return asset.controlSchemes[m_KeyboardandMouseSchemeIndex];
        }
    }
    private int m_GamepadSchemeIndex = -1;
    public InputControlScheme GamepadScheme
    {
        get
        {
            if (m_GamepadSchemeIndex == -1) m_GamepadSchemeIndex = asset.FindControlSchemeIndex("Gamepad");
            return asset.controlSchemes[m_GamepadSchemeIndex];
        }
    }
    public interface IFingerGunManActions
    {
        void OnMoveHorizontal(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnCrouch(InputAction.CallbackContext context);
        void OnSlideLeft(InputAction.CallbackContext context);
        void OnSlideRight(InputAction.CallbackContext context);
        void OnFlipLeft(InputAction.CallbackContext context);
        void OnFlipRight(InputAction.CallbackContext context);
        void OnShoot(InputAction.CallbackContext context);
        void OnAim(InputAction.CallbackContext context);
    }
}
