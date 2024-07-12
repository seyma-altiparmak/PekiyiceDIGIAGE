using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterControllerManager : MonoBehaviour
{
    [HideInInspector] public GameObject character;
    private PlayerActions playerInputActions;
    private Rigidbody2D rb2D;
    private Vector2 moveInput;
    private bool facingRight = true;

    public float speed = 5f;
    public float jumpForce = 15f;
    private bool isGrounded;

    private void Awake()
    {
        playerInputActions = new PlayerActions();
    }

    private void OnEnable()
    {
        playerInputActions.PlayerInputs.Enable();
        playerInputActions.PlayerInputs.Movement.performed += OnMove;
        playerInputActions.PlayerInputs.Movement.canceled += OnMove;
        playerInputActions.PlayerInputs.Jump.performed += OnJump;
    }

    private void OnDisable()
    {
        playerInputActions.PlayerInputs.Movement.performed -= OnMove;
        playerInputActions.PlayerInputs.Movement.canceled -= OnMove;
        playerInputActions.PlayerInputs.Jump.performed -= OnJump;
        playerInputActions.PlayerInputs.Disable();
    }

    private void Start()
    {
        character = GameObject.FindGameObjectWithTag("Player");
        if (character != null)
        {
            rb2D = character.GetComponent<Rigidbody2D>();
        }
        findcharacter(character);
    }

    private void Update()
    {
        Move();
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    private void OnJump(InputAction.CallbackContext context)
    {
        if (isGrounded)
        {
            rb2D.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
    }

    private void Move()
    {
        if (character != null)
        {
            Vector2 move = new Vector2(moveInput.x * speed, rb2D.velocity.y);
            rb2D.velocity = move;

            // Flip character based on movement direction
            if (moveInput.x > 0 && !facingRight)
            {
                Flip();
            }
            else if (moveInput.x < 0 && facingRight)
            {
                Flip();
            }
        }
    }

    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 scale = character.transform.localScale;
        scale.x *= -1;
        character.transform.localScale = scale;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    // Test Codes:
    private void findcharacter(GameObject character)
    {
        if (character == null)
            print("character not found");
        else
            print("success");
    }
}
