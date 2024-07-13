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
    private UIControllerManager uiControllerManager;
    private RockManager rockManager;
    private Animator charAnimator;
    private Rigidbody2D rb2D;
    private Vector2 moveInput;
    private bool facingRight = true;
    private bool isCharRuin = false;
    private SpriteRenderer spriteRenderer;
    private BoxCollider2D boxCollider;
    [SerializeField] private Sprite charRuinSprite;
    private Sprite charSprite;

    public float speed = 5f;
    public float jumpForce = 0.1f;
    private bool isGrounded;

    private void Awake()
    {
        playerInputActions = new PlayerActions();
        rockManager = GameObject.Find("Managers").GetComponent<RockManager>();
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
        uiControllerManager = GameObject.Find("Managers").GetComponent<UIControllerManager>();
        character = GameObject.FindGameObjectWithTag("Player");
        if (character != null)
        {
            rb2D = character.GetComponent<Rigidbody2D>();
            charAnimator = character.GetComponent<Animator>();
            spriteRenderer = character.GetComponent<SpriteRenderer>();
            boxCollider = character.GetComponent<BoxCollider2D>();
            charSprite = spriteRenderer.sprite;
        }
        findcharacter(character);
    }

    private void Update()
    {
        Move(); 
        UpdateAnimationStates();
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
        if (isGrounded && uiControllerManager.isItRuin)
        {
            Instantiate(ruinArea, new Vector3(transform.position.x, transform.position.y - 0.5f, 0), Quaternion.identity);
            StartCoroutine(HandleRuin());
            uiControllerManager.isItRuin = false;
            uiControllerManager.totalTimer = 20f;
            rockManager.RandomRockIndex();
            uiControllerManager.rockIndexCounter.text = rockManager.totalRockIndex.ToString();
        }
    }

    private void Move()
    {
        if (character != null)
        {
            Vector2 move = new Vector2(moveInput.x * speed, rb2D.velocity.y);
            rb2D.velocity = move;
            charAnimator.SetBool("isWalking", moveInput.x != 0);

            if (moveInput.x > 0 && !facingRight || moveInput.x < 0 && facingRight)
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
            spriteRenderer.sprite = charRuinSprite;
            isCharRuin = true;
            this.enabled = false;
            rb2D.velocity = Vector2.zero;
            boxCollider.isTrigger = true;
            rb2D.gravityScale = 0;

            yield return new WaitUntil(() => !ruinVoice.isPlaying);
            GetAllComponentsAfterRuin();
        }
    }

    private void GetAllComponentsAfterRuin()
    {
        if (isCharRuin)
        {
            spriteRenderer.sprite = charSprite;
            this.enabled = true;
            boxCollider.isTrigger = false;
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
    private void UpdateAnimationStates()
    {
        // This ensures that animation state changes are checked every frame
        if (Mathf.Abs(moveInput.x) > 0.01f) // Adjust threshold as needed
        {
            if (!charAnimator.GetBool("isWalking"))
                charAnimator.SetBool("isWalking", true);
        }
        else
        {
            if (charAnimator.GetBool("isWalking"))
                charAnimator.SetBool("isWalking", false);
        }
    }

    private void findcharacter(GameObject character)
    {
        if (character == null)
            Debug.Log("Character not found");
        else
            Debug.Log("Character successfully found");
    }
}
