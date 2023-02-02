using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float _speed = 4;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask whatIsGround;
    [SerializeField] private float _jumpForce = 400;

    private Rigidbody2D _playerRigidbody;
    private bool _isGrounded = false;
    private float _groundRadius = 0.2f;
    private bool _isFacingRight = true;
    private Animator _animator;

    private void Start()
    {
        _playerRigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        _isGrounded = Physics2D.OverlapCircle(groundCheck.position, _groundRadius, whatIsGround);

        if (!_isGrounded)
        {
            return;
        }
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        float move = Input.GetAxis("Horizontal");
        _animator.SetFloat("Speed", Mathf.Abs(move));
        _playerRigidbody.velocity = new Vector2(move * _speed, _playerRigidbody.velocity.y);

        if (move > 0 && !_isFacingRight)
        {
            Flip();
        }
        else if (move < 0 && _isFacingRight)
        {
            Flip();
        }

        if (_isGrounded && Input.GetKeyDown(KeyCode.W))
        {
            _animator.SetBool("isJumped", true);
            _playerRigidbody.AddForce(new Vector2(0, _jumpForce));
        }
        else
        {
            _animator.SetBool("isJumped", false);
        }
    }

    private void Flip()
    {
        _isFacingRight = !_isFacingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
