// GENERATED AUTOMATICALLY FROM 'Assets/Input/Controls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Controls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @Controls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Controls"",
    ""maps"": [
        {
            ""name"": ""Gameplay"",
            ""id"": ""330495eb-f1e8-4b0c-8675-d20329ccc8cf"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""e2bdd140-7956-4c3f-94e3-2de063186ba5"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Look"",
                    ""type"": ""PassThrough"",
                    ""id"": ""ec4d59b3-b121-4132-90d1-98a6935ef8b9"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""32a8b6fa-c10b-4ed1-9ce7-e560712925b8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ChangeSelectionRight"",
                    ""type"": ""PassThrough"",
                    ""id"": ""4e64d7cf-5a43-4224-bf2b-2f0a8cc690dd"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Sprint"",
                    ""type"": ""Button"",
                    ""id"": ""069dc977-0391-4d0e-ba34-231dbfb3e232"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ChangeSelectionLeft"",
                    ""type"": ""PassThrough"",
                    ""id"": ""ec6f9fba-99a6-42fd-9ac4-02a1127961d0"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""9e5fe1b7-aea7-43c0-a556-c1fd9fe5104d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Escape"",
                    ""type"": ""Button"",
                    ""id"": ""7b18b6c4-5ffe-4920-8073-fb218a6cb7d5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Consume"",
                    ""type"": ""Button"",
                    ""id"": ""72c130cd-b66e-4715-9e8c-45509a4f948d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Scroll"",
                    ""type"": ""Value"",
                    ""id"": ""876b0178-064c-4d4c-87b9-c8059f12332c"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ChangeMenu"",
                    ""type"": ""Button"",
                    ""id"": ""aed3bb6e-5e59-46e6-9dc4-cd3a25e97f50"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ExitMenu"",
                    ""type"": ""Button"",
                    ""id"": ""0e51f01d-e750-4ef3-b30b-b281857356ad"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""2cd4d9f3-367a-457e-b0ce-9270d710bda1"",
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
                    ""id"": ""bbcd1b1a-febf-42ae-968c-f406b605f418"",
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
                    ""id"": ""390da51c-fb00-4472-9ebc-1a186bd08fbc"",
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
                    ""id"": ""05993712-bbfb-4d87-ad8b-43b082fc2052"",
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
                    ""id"": ""454fedba-b7db-4676-bae5-c7b4f09f7023"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""c86f7a43-f2df-46f3-a915-4d8829050385"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ed4d6607-b7df-46e6-937c-34115dc53802"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b32c3c25-778a-45e2-9192-cb50b9fec322"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": ""ScaleVector2(x=10,y=10)"",
                    ""groups"": """",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c5362810-50ce-4f78-829b-0ef1102028ae"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4ef2717b-5a23-4fe1-a2ba-a46b55ad2ad7"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4174beed-1d72-441a-a573-61fc72a56492"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ChangeSelectionRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e150fa19-16c4-4ee9-9a29-fdcb3f836300"",
                    ""path"": ""<DualShockGamepad>/dpad/right"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ChangeSelectionRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c1ce201f-44df-4718-ae91-858551eef58a"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Sprint"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9457e299-5a37-43d6-bbe3-66fbe2bf7520"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Sprint"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d7d15542-f57a-4b55-af7e-a1a41a8fc13b"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ChangeSelectionLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b57ed120-333d-4a18-bbe0-30d382b1b592"",
                    ""path"": ""<DualShockGamepad>/dpad/left"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ChangeSelectionLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b397f253-efe9-481e-8567-3a1035369711"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": ""Hold"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""30b0c349-944f-438f-888a-45ef11113054"",
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
                    ""id"": ""f80ca1e7-5ad4-41d8-bccf-c7d7907f01e9"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Escape"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fcdbe122-cd85-4ca6-a192-02dcb77df5a4"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Escape"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2f93392c-80a6-479b-9060-88d70d9d42ee"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Consume"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a6e18761-7921-47f5-9207-abea9b63a868"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Consume"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""575508ab-4da6-4990-86e2-6667ea7c5b8c"",
                    ""path"": ""<Mouse>/scroll"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Scroll"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""16572241-7c32-4c04-a33e-f88c85f47a1a"",
                    ""path"": ""<Keyboard>/tab"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ChangeMenu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""484801c9-621a-49fc-bb19-5fc8bc817439"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ChangeMenu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b7fe634f-df00-41bb-8680-e66749d91324"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ChangeMenu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ad2a76ad-c7c8-4b38-b6d7-d617ea09b24d"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ExitMenu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8c7b1107-505f-4c76-b07c-3ad0c7f82fb5"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ExitMenu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Gameplay
        m_Gameplay = asset.FindActionMap("Gameplay", throwIfNotFound: true);
        m_Gameplay_Move = m_Gameplay.FindAction("Move", throwIfNotFound: true);
        m_Gameplay_Look = m_Gameplay.FindAction("Look", throwIfNotFound: true);
        m_Gameplay_Interact = m_Gameplay.FindAction("Interact", throwIfNotFound: true);
        m_Gameplay_ChangeSelectionRight = m_Gameplay.FindAction("ChangeSelectionRight", throwIfNotFound: true);
        m_Gameplay_Sprint = m_Gameplay.FindAction("Sprint", throwIfNotFound: true);
        m_Gameplay_ChangeSelectionLeft = m_Gameplay.FindAction("ChangeSelectionLeft", throwIfNotFound: true);
        m_Gameplay_Jump = m_Gameplay.FindAction("Jump", throwIfNotFound: true);
        m_Gameplay_Escape = m_Gameplay.FindAction("Escape", throwIfNotFound: true);
        m_Gameplay_Consume = m_Gameplay.FindAction("Consume", throwIfNotFound: true);
        m_Gameplay_Scroll = m_Gameplay.FindAction("Scroll", throwIfNotFound: true);
        m_Gameplay_ChangeMenu = m_Gameplay.FindAction("ChangeMenu", throwIfNotFound: true);
        m_Gameplay_ExitMenu = m_Gameplay.FindAction("ExitMenu", throwIfNotFound: true);
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

    // Gameplay
    private readonly InputActionMap m_Gameplay;
    private IGameplayActions m_GameplayActionsCallbackInterface;
    private readonly InputAction m_Gameplay_Move;
    private readonly InputAction m_Gameplay_Look;
    private readonly InputAction m_Gameplay_Interact;
    private readonly InputAction m_Gameplay_ChangeSelectionRight;
    private readonly InputAction m_Gameplay_Sprint;
    private readonly InputAction m_Gameplay_ChangeSelectionLeft;
    private readonly InputAction m_Gameplay_Jump;
    private readonly InputAction m_Gameplay_Escape;
    private readonly InputAction m_Gameplay_Consume;
    private readonly InputAction m_Gameplay_Scroll;
    private readonly InputAction m_Gameplay_ChangeMenu;
    private readonly InputAction m_Gameplay_ExitMenu;
    public struct GameplayActions
    {
        private @Controls m_Wrapper;
        public GameplayActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Gameplay_Move;
        public InputAction @Look => m_Wrapper.m_Gameplay_Look;
        public InputAction @Interact => m_Wrapper.m_Gameplay_Interact;
        public InputAction @ChangeSelectionRight => m_Wrapper.m_Gameplay_ChangeSelectionRight;
        public InputAction @Sprint => m_Wrapper.m_Gameplay_Sprint;
        public InputAction @ChangeSelectionLeft => m_Wrapper.m_Gameplay_ChangeSelectionLeft;
        public InputAction @Jump => m_Wrapper.m_Gameplay_Jump;
        public InputAction @Escape => m_Wrapper.m_Gameplay_Escape;
        public InputAction @Consume => m_Wrapper.m_Gameplay_Consume;
        public InputAction @Scroll => m_Wrapper.m_Gameplay_Scroll;
        public InputAction @ChangeMenu => m_Wrapper.m_Gameplay_ChangeMenu;
        public InputAction @ExitMenu => m_Wrapper.m_Gameplay_ExitMenu;
        public InputActionMap Get() { return m_Wrapper.m_Gameplay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameplayActions set) { return set.Get(); }
        public void SetCallbacks(IGameplayActions instance)
        {
            if (m_Wrapper.m_GameplayActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMove;
                @Look.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnLook;
                @Look.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnLook;
                @Look.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnLook;
                @Interact.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnInteract;
                @Interact.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnInteract;
                @Interact.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnInteract;
                @ChangeSelectionRight.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnChangeSelectionRight;
                @ChangeSelectionRight.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnChangeSelectionRight;
                @ChangeSelectionRight.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnChangeSelectionRight;
                @Sprint.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSprint;
                @Sprint.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSprint;
                @Sprint.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSprint;
                @ChangeSelectionLeft.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnChangeSelectionLeft;
                @ChangeSelectionLeft.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnChangeSelectionLeft;
                @ChangeSelectionLeft.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnChangeSelectionLeft;
                @Jump.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJump;
                @Escape.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnEscape;
                @Escape.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnEscape;
                @Escape.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnEscape;
                @Consume.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnConsume;
                @Consume.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnConsume;
                @Consume.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnConsume;
                @Scroll.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnScroll;
                @Scroll.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnScroll;
                @Scroll.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnScroll;
                @ChangeMenu.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnChangeMenu;
                @ChangeMenu.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnChangeMenu;
                @ChangeMenu.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnChangeMenu;
                @ExitMenu.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnExitMenu;
                @ExitMenu.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnExitMenu;
                @ExitMenu.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnExitMenu;
            }
            m_Wrapper.m_GameplayActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Look.started += instance.OnLook;
                @Look.performed += instance.OnLook;
                @Look.canceled += instance.OnLook;
                @Interact.started += instance.OnInteract;
                @Interact.performed += instance.OnInteract;
                @Interact.canceled += instance.OnInteract;
                @ChangeSelectionRight.started += instance.OnChangeSelectionRight;
                @ChangeSelectionRight.performed += instance.OnChangeSelectionRight;
                @ChangeSelectionRight.canceled += instance.OnChangeSelectionRight;
                @Sprint.started += instance.OnSprint;
                @Sprint.performed += instance.OnSprint;
                @Sprint.canceled += instance.OnSprint;
                @ChangeSelectionLeft.started += instance.OnChangeSelectionLeft;
                @ChangeSelectionLeft.performed += instance.OnChangeSelectionLeft;
                @ChangeSelectionLeft.canceled += instance.OnChangeSelectionLeft;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Escape.started += instance.OnEscape;
                @Escape.performed += instance.OnEscape;
                @Escape.canceled += instance.OnEscape;
                @Consume.started += instance.OnConsume;
                @Consume.performed += instance.OnConsume;
                @Consume.canceled += instance.OnConsume;
                @Scroll.started += instance.OnScroll;
                @Scroll.performed += instance.OnScroll;
                @Scroll.canceled += instance.OnScroll;
                @ChangeMenu.started += instance.OnChangeMenu;
                @ChangeMenu.performed += instance.OnChangeMenu;
                @ChangeMenu.canceled += instance.OnChangeMenu;
                @ExitMenu.started += instance.OnExitMenu;
                @ExitMenu.performed += instance.OnExitMenu;
                @ExitMenu.canceled += instance.OnExitMenu;
            }
        }
    }
    public GameplayActions @Gameplay => new GameplayActions(this);
    public interface IGameplayActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnLook(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
        void OnChangeSelectionRight(InputAction.CallbackContext context);
        void OnSprint(InputAction.CallbackContext context);
        void OnChangeSelectionLeft(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnEscape(InputAction.CallbackContext context);
        void OnConsume(InputAction.CallbackContext context);
        void OnScroll(InputAction.CallbackContext context);
        void OnChangeMenu(InputAction.CallbackContext context);
        void OnExitMenu(InputAction.CallbackContext context);
    }
}
