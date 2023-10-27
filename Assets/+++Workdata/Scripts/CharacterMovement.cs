using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class CharacterMovement : MonoBehaviour
{
    private Player_InputActions inputActions;

    private InputAction moveAction;
    private InputAction rollAction;
    private InputAction attackAction;

    public Vector2 moveInput;
    public float speed = 5.0f;

    public Rigidbody2D rb;
    public Animator anim;
    public SpriteRenderer spriteRenderer;

    private void Awake()
    {
        inputActions = new Player_InputActions();
        moveAction = inputActions.Player.Move;
        rollAction = inputActions.Player.Roll;
        attackAction = inputActions.Player.Attack;
    }

    private void OnEnable()
    {
        inputActions.Enable();

        moveAction.performed += Move;
        moveAction.canceled += Move;

        attackAction.performed += Attack;
        rollAction.performed += Roll;
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveInput.x * speed, rb.velocity.y);
    }

    private void OnDisable()
    {
        inputActions.Disable();

        moveAction.performed -= Move;
        moveAction.canceled -= Move;

        attackAction.performed -= Attack;
        rollAction.performed -= Roll;
    }

    void Move(CallbackContext ctx)
    {
        if(ctx.performed)
        {
            print("WASD wurde gedrückt");
        }
        else
        {
            print("WASD wurde losgelassen");
        }


        moveInput = moveAction.ReadValue<Vector2>();
        if (moveInput.x < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (moveInput.x > 0)
        {
            spriteRenderer.flipX = false;
        }

        if (moveInput.x != 0)
        {
            anim.SetFloat("MovementValue", 5);
        }
        else
        {
            anim.SetFloat("MovementValue", 0);
        }
    }

    void Attack(CallbackContext ctx)
    {
        CallAction(10);
    }

    void Roll(CallbackContext ctx)
    {
        CallAction(1);
    }

    void CallAction(int id)
    {
        anim.SetTrigger("ActionTrigger");
        anim.SetInteger("ActionId", id);
    }

}