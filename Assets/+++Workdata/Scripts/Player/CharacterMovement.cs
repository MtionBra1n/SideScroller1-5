using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class CharacterMovement : MonoBehaviour
{
    #region PlayerInput Variables
    private Player_InputActions inputActions;

    private InputAction moveAction;
    private InputAction rollAction;
    private InputAction attackAction;
    private InputAction jumpAction;

    #endregion
    #region public Variables

    public Vector2 moveInput;
    public float speed = 5.0f;
    public float jumpPower = 7;
    public float rollPower = 7;

    public float radialOverlapCircle;
    public bool isGrounded;
    public bool isRolling;
    public Vector2 cubeSize;
    public Vector3 cubePos;

    public LayerMask groundLayer;
    #endregion
    #region private Variables

    Rigidbody2D rb;
    Animator anim;
    SpriteRenderer spriteRenderer;

    #endregion
    #region Unity Event Functions
    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    private void Awake()
    {
        inputActions = new Player_InputActions();
        moveAction = inputActions.Player.Move;
        rollAction = inputActions.Player.Roll;
        attackAction = inputActions.Player.Attack;
        jumpAction = inputActions.Player.Jump;
    }

    private void OnEnable()
    {
        inputActions.Enable();

        moveAction.performed += Move;
        moveAction.canceled += Move;

        attackAction.performed += Attack;
        rollAction.performed += Roll;

        jumpAction.performed += Jump;
    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapBox(transform.position + cubePos, cubeSize, 0, groundLayer);

        if (isRolling == false)
        {
            rb.velocity = new Vector2(moveInput.x * speed, rb.velocity.y);
        }


        SetGroundAnimator();
    }

    private void OnDisable()
    {
        inputActions.Disable();

        moveAction.performed -= Move;
        moveAction.canceled -= Move;

        attackAction.performed -= Attack;
        rollAction.performed -= Roll;

        jumpAction.performed -= Jump;
    }
    #endregion
    #region InputEvents
    #region Movement
    void Move(CallbackContext ctx)
    {
        moveInput = moveAction.ReadValue<Vector2>();
        if (moveInput.x < 0)
        {
            gameObject.transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (moveInput.x > 0)
        {
            gameObject.transform.localScale = new Vector3(1, 1, 1);
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

    void Roll(CallbackContext ctx)
    {
        if (!isRolling && isGrounded)
        {
            isRolling = true;

            if (gameObject.transform.localScale.x == -1)
            {
                rb.AddForce(new Vector2(-1 * rollPower, 0), ForceMode2D.Impulse);
            }
            else
            {
                rb.AddForce(Vector2.right * rollPower, ForceMode2D.Impulse);
            }

            CallAction(1);

            //Invoke("EndRoll", .5f);
        }
    }

    void EndRoll()
    {
        isRolling = false;
    }

    void Jump(CallbackContext ctx)
    {
        if (isGrounded)
        {
            rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
        }
        CallAction(2);
        isGrounded = false;
    }

    #endregion

    #region Attack
    void Attack(CallbackContext ctx)
    {
        if (isGrounded) // Ground Attacks
        {
            if (isRolling)
            {
                CallAction(11);
            }
            else
            {
                CallAction(10);
            }
        }
        else // in der Luft
        {

        }

    }

    #endregion
    #endregion
    #region Animation Events
    void CallAction(int id)
    {
        anim.SetTrigger("ActionTrigger");
        anim.SetInteger("ActionId", id);
    }

    void SetGroundAnimator()
    {
        anim.SetBool("isGrounded", isGrounded);
    }
    #endregion

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position + cubePos, cubeSize);
    }
}