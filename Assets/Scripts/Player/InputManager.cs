using UnityEngine;
using vnc;
using vnc.Samples;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    #region InputActions for new Input System
    public InputAction Movement;
    public InputAction Swim;
    public InputAction Jumping;
    public InputAction Crouch;
    public InputAction Sprint;
    public InputAction Escape;
    public InputAction Fire;
    public InputAction InventoryNum1;
    public InputAction InventoryNum2;
    public InputAction InventoryNum3;
    public InputAction InventoryNum4;
    public InputAction InventoryNum5;
    public InputAction InventoryNum6;
    public InputAction Scroll;
    #endregion

    #region Input Variables
    [HideInInspector] public float fwd, strafe, swim;
    [HideInInspector] public bool jump, sprint, duck;
    [HideInInspector] public float mouseScrollValue;
    #endregion

    [Header("Input Game Events")]
    public GameEvent ScrollWeaponUp;
    public GameEvent ScrollWeaponDown;

    [HideInInspector]
    public RetroController retroController; //The retro controller to accept input  
    [HideInInspector]
    public MouseLook mouseLook; //Mouse look input 
    private Transform playerView; //The transform containing the player view

    [Space, Tooltip("Switch to ducking and standing by pressing once instead of holding")]
    public bool toggleDucking;
    private bool isSprinting;
    private bool isCrouching;

    [HideInInspector]
    public bool isFiring;
    [HideInInspector]
    public bool isGrounded;
    [HideInInspector]
    public bool isMoving;

    private void OnEnable()
    {
        Movement.Enable();
        Swim.Enable();
        Jumping.Enable();
        Crouch.Enable();
        Sprint.Enable();
        Escape.Enable();
        Fire.Enable();
        InventoryNum1.Enable();
        InventoryNum2.Enable();
        InventoryNum3.Enable();
        InventoryNum4.Enable();
        InventoryNum5.Enable();
        InventoryNum6.Enable();
        Scroll.Enable();
    }

    private void OnDisable()
    {
        Movement.Disable();
        Swim.Disable();
        Jumping.Disable();
        Crouch.Disable();
        Sprint.Disable();
        Fire.Disable();
        InventoryNum1.Disable();
        InventoryNum2.Disable();
        InventoryNum3.Disable();
        InventoryNum4.Disable();
        InventoryNum5.Disable();
        InventoryNum6.Disable();
        Scroll.Disable();
        Escape.Disable();
    }

    void Start()
    {
        retroController = GetComponent<RetroController>();
        playerView = GetComponent<Transform>().Find("View");

        if (mouseLook)
        {
            mouseLook.Init(retroController, playerView);
            mouseLook.SetCursorLock(true);
        }
        else
        {
            Debug.LogWarning("No MouseLook assigned.");
        }
    }

    void Update()
    {
        AssignInputs();

        // these inputs are fed into the controller
        // this is the main entry point for the controller
        retroController.SetInput(fwd, strafe, swim, jump, sprint, duck);
        isGrounded = retroController.IsGrounded;

        if (mouseLook)
        {
            //if (Escape.triggered)
            //{
            //    mouseLook.SetCursorLock(!mouseLook.lockCursor);
            //    retroController.updateController = !retroController.updateController;
            //}
            mouseLook.LookRotation();
            mouseLook.UpdateCursorLock();
        }

        if (mouseScrollValue == 120) 
        {
            ScrollWeaponUp.Raise();
        }

        if (mouseScrollValue == -120) 
        {
            ScrollWeaponDown.Raise();
        }

        //this needs changed to be separate raises
        if (InventoryNum1.triggered || InventoryNum2.triggered || InventoryNum3.triggered || InventoryNum4.triggered || InventoryNum5.triggered || InventoryNum6.triggered) 
        {
            //InventoryKeyPressed.Raise();
        }

        Time.timeScale = retroController.updateController ? 1 : 0;
    }

    void AssignInputs()
    {
        mouseScrollValue = Scroll.ReadValue<Vector2>().y;
        float swimInputs = Swim.ReadValue<float>();
        bool jumpInput = Jumping.triggered;
        bool crouchInput = Crouch.triggered;


        Vector2 wasdVectors = Movement.ReadValue<Vector2>();
        Vector3 finalVectors = new Vector3();
        finalVectors.x = wasdVectors.x;
        finalVectors.z = wasdVectors.y;

        fwd = finalVectors.z;
        strafe = finalVectors.x;
        swim = swimInputs;
        jump = jumpInput;

        if (fwd > 0 || strafe > 0 || fwd < 0 || strafe < 0) 
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }

        if (isSprinting)
        {
            sprint = true;
        }
        else { sprint = false; }

        if (toggleDucking)
        {
            // switch between modes by hitting the button once
            if (crouchInput)
            {
                duck = !duck;
            }
        }
        else
        {
            Crouch.started += context => isCrouching = true;
            Crouch.canceled += context => isCrouching = false;
            duck = isCrouching;
        }

        Sprint.started += context => isSprinting = true;
        Sprint.canceled += context => isSprinting = false;

        Fire.started += context => isFiring = true;
        Fire.canceled += context => isFiring = false;
    }
}
