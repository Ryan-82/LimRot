
using System;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    InputAction moveAction;
    InputSwitch jumpAction;
    InputSwitch attackAction;

    CharacterController controller;
    float moveAccel = 0;

    [SerializeField] PInfo info;

    Vector3 playerVelocity = Vector2.zero;
    void OnValidate()
    {   

        moveAccel = info.maxMoveVel / info.moveAccelT;
    }
    void Awake()
    {
        GlobalUtils.player = this.transform;
    }
    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        jumpAction = new InputSwitch("Jump");
        attackAction = new InputSwitch("Attack");

        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        float delta = Time.deltaTime;

        playerVelocity = new Vector3(playerVelocity.x, playerVelocity.y, 0);
        controller.Move(playerVelocity * delta);
    }

    void FixedUpdate()
    {
        if (info == null)
            return;
        float delta = Time.fixedDeltaTime;
        //gravity
        playerVelocity += delta * info.YAccel * Vector3.up;
        if (controller.isGrounded)
        {
            playerVelocity.y = 0;
        }

        //limit downward velocity
        playerVelocity.y = Mathf.Clamp(playerVelocity.y, info.maxYVel, 1000);

        //jump
        if (jumpAction.IsPressed())
        {
            playerVelocity.y = info.jumpForce;
        }

        //movement
        Vector2 moveInput = moveAction.ReadValue<Vector2>();

        playerVelocity.x += moveInput.x * moveAccel * delta;

        playerVelocity.x = Mathf.Clamp(playerVelocity.x, -info.maxMoveVel, info.maxMoveVel);

        //drag
        //only when x input is empty
        
        float dragDelta = info.maxMoveVel / (controller.isGrounded? info.GroundDragT : info.AirDragT);

        if (Mathf.Abs(moveInput.x) < 0.001)
        {
            float xvel = playerVelocity.x;
            float sign = Mathf.Sign(xvel);
            float drag = sign * dragDelta * delta; //in same dir as xvel rn
            drag = (Mathf.Abs(drag) < Math.Abs(xvel))? drag : xvel;

            playerVelocity.x -= drag;
        }
        
        //attack
        if (attackAction.IsPressed())
        {
            
        }
    }
}

