using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private GameObject _picaReta;

    private bool hasPica = false;

    Audiomanager audioManager;

    [Header("Movement")]
    [SerializeField] private float speed = 10f;
    private float _horizontalInput;

    [Header("Jump")]
    [SerializeField] private float jumpPower;

    [Header("Ground Check")]
    [SerializeField] private Transform groundCheckPos;
    [SerializeField] private Vector2 groundCheckSize = new Vector2(0.33f, 0.03f);
    [SerializeField] private LayerMask groundLayer;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<Audiomanager>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _picaReta = GameObject.FindGameObjectWithTag("picaReta");
    }

    private void FixedUpdate()
    {
        //Player movement
        _rigidbody2D.velocity = new Vector2(_horizontalInput * speed, _rigidbody2D.velocity.y);
    }

    public void Move(InputAction.CallbackContext context)
    {
        _horizontalInput = context.ReadValue<Vector2>().x;
        if (context.performed)
        {
            _animator.SetBool("IsWalking", true);
        }
        else if (context.canceled)
        {
            _animator.SetBool("IsWalking", false);
        }
        if (context.ReadValue<Vector2>().x < 0)
        {
            _spriteRenderer.flipX = true;
        }
        else if (context.ReadValue<Vector2>().x > 0)
        {
            _spriteRenderer.flipX = false;
        }

    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed && IsGrounded()) //Hold down jump button = full height
        {
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, jumpPower);
            audioManager.PlaySFX(audioManager.jump);
            _animator.SetBool("IsJumping", true);
        }
        else if (context.canceled) //Light tap of jump button = half the height
        {
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, _rigidbody2D.velocity.y * 0.5f);
            _animator.SetBool("IsJumping", false);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireCube(groundCheckPos.position, groundCheckSize);
    }

    private bool IsGrounded()
    {
        if (Physics2D.OverlapBox(groundCheckPos.position, groundCheckSize, 0, groundLayer))
        {
            return true;
        }

        return false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("picaReta"))
        {
            hasPica = true;
            Destroy(_picaReta);
        }
    }
}