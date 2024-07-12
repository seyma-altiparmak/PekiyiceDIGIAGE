using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterControllerManager : MonoBehaviour
{
    public GameObject ruinArea;
    [HideInInspector] public GameObject character;
    [SerializeField] private AudioSource ruinVoice;
    private PlayerActions playerInputActions;
    private Rigidbody2D rb2D;
    private Vector2 moveInput;
    private bool facingRight = true;
    private bool isCharRuin = false;
    private Sprite charSprite;
    [SerializeField] private Sprite charRuinSprite;

    public float speed = 5f;
    public float jumpForce = 0.1f;
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
        playerInputActions.PlayerInputs.Ruin.performed += OnRuin;
    }

    private void OnDisable()
    {
        playerInputActions.PlayerInputs.Movement.performed -= OnMove;
        playerInputActions.PlayerInputs.Movement.canceled -= OnMove;
        playerInputActions.PlayerInputs.Jump.performed -= OnJump;
        playerInputActions.PlayerInputs.Ruin.performed -= OnRuin;
        playerInputActions.PlayerInputs.Disable();
    }

    private void Start()
    {
        character = GameObject.FindGameObjectWithTag("Player");
        if (character != null)
        {
            rb2D = character.GetComponent<Rigidbody2D>();
            charSprite = character.GetComponent<SpriteRenderer>().sprite;
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

    private void OnRuin(InputAction.CallbackContext context)
    {
        if (isGrounded)
        {
            Instantiate(ruinArea, new Vector3(transform.position.x, transform.position.y - 0.5f, 0), Quaternion.identity);
            StartCoroutine(HandleRuin());
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

    private IEnumerator HandleRuin()
    {
        if (ruinVoice != null)
        {
            ruinVoice.Play();
            var spriteRenderer = character.GetComponent<SpriteRenderer>();
            if (spriteRenderer != null)
            {
                spriteRenderer.sprite = charRuinSprite;
                isCharRuin = true;
                // Disable character controller and make collider a trigger
                this.enabled = false;
                var boxCollider = character.GetComponent<BoxCollider2D>();
                if (boxCollider != null)
                {
                    boxCollider.isTrigger = true;
                }
                // Disable gravity
                rb2D.gravityScale = 0;
            }
            yield return new WaitUntil(() => !ruinVoice.isPlaying);
            GetAllComponentsAfterRuin();
        }
    }

    private void GetAllComponentsAfterRuin()
    {
        if (isCharRuin)
        {
            var spriteRenderer = character.GetComponent<SpriteRenderer>();
            if (spriteRenderer != null)
            {
                spriteRenderer.sprite = charSprite;
            }
            var characterController = character.GetComponent<CharacterControllerManager>();
            if (characterController != null)
            {
                characterController.enabled = true;
            }
            var boxCollider = character.GetComponent<BoxCollider2D>();
            if (boxCollider != null)
            {
                boxCollider.isTrigger = false;
            }
            // Re-enable gravity
            rb2D.gravityScale = 1;
            isCharRuin = false;
        }
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
