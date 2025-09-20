using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float jumpForce;
    public float speed;
    public LayerMask groundLayer;
    private Rigidbody2D _rigidbody2D;
    public float _horizontalDirection;
    private bool _isGrounded;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private SpriteRenderer _spriteRenderer;
    public float groundCheckRadius;
    public Transform groundcheckPosition;
    //sound
    //public AudioSource _audioSource;
    //public AudioClip _jumpAudioClip;
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        _horizontalDirection = Input.GetAxisRaw("Horizontal");

        //transform.position = new Vector2(transform.position.x + horizontalDirection * speed * Time.deltaTime, transform.position.y);
        _rigidbody2D.linearVelocityX = _horizontalDirection * speed;

        if (_horizontalDirection != 0)
        {
            if (_horizontalDirection == 1)
            {
                _spriteRenderer.flipX = false;
            }
            else
            {
                _spriteRenderer.flipX = true;
            }

        }


        if (Physics2D.OverlapCircle(groundcheckPosition.position, groundCheckRadius, groundLayer))
        {
            _isGrounded = true;
        }
        else
        {
            _isGrounded = false;
        }

        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow)) && _isGrounded)
        {
            _rigidbody2D.AddForceY(jumpForce, ForceMode2D.Impulse);
           // _audioSource.clip = _jumpAudioClip;
           // _audioSource.Play(); // TAMBIEN  .PlayOneShot(); para que suene una sola vez
        }
    }

    private void OnDrawGizmos()//esto es para ver el circulo colicionador
    {
        Gizmos.DrawWireSphere(groundcheckPosition.position, groundCheckRadius);
    }
}
