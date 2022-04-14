using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonajePrincipal : MonoBehaviour
{
    // References to the atributes of the GameObject
    private Rigidbody2D _rigidbody;

    private Animator _animator;

    private SpriteRenderer _spriteRenderer;

    [SerializeField] private float velocidadX;
    [SerializeField] private float velocidadY;

    // Default value for the gravity in floor and jumping
    [SerializeField] private float gravityDefaultValue;
    // Factor for which the gravity will be increased when an inversion occurs
    [SerializeField] private float gravityInvertFactor;
    private bool jumping;
    private void SetGravityScale(float gravityScale)
    {
        _rigidbody.gravityScale = gravityScale;
    }

    private void SetGravityDefault()
    {
        // Set gravity to default value while holding the sign
        if (_rigidbody.gravityScale > 0)
        {
            _rigidbody.gravityScale = gravityDefaultValue;
        }
        else
        {
            _rigidbody.gravityScale = -gravityDefaultValue;
        }
    }

    private void Move()
    {
        // Jump action
        float jumpFactor = 0;
        
        // Only jump if it is not already jumping
        if (Input.GetButtonDown("Jump") && !jumping)
        {
            // The direction of jump depends on the state of gravity
            if (_rigidbody.gravityScale > 0)
            {
                jumpFactor = 1;
            }
            else
            {
                jumpFactor = -1;
            }
        }
        // Constant movement to the right
        _rigidbody.velocity = new Vector2(velocidadX, 
                                            _rigidbody.velocity.y + jumpFactor * velocidadY);

        // Inversion of gravity (positive)
        if (Input.GetButtonDown("Fire1"))
        {
            SetGravityScale(gravityInvertFactor);
            gameObject.transform.eulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
            _spriteRenderer.flipX = false;
        }

        // Inversion of gravity (negative)
        if (Input.GetButtonDown("Fire2"))
        {
            SetGravityScale(-gravityInvertFactor);
            gameObject.transform.eulerAngles = new Vector3(0.0f, 0.0f, 180.0f);
            _spriteRenderer.flipX = true;
        }
    }

    // Detect the jumping of player
    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("Collision Called");
        jumping = false;

        // In floor returns gravity to its default value
        SetGravityDefault();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        jumping = true;
    }

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        jumping = false;
        _rigidbody.gravityScale = gravityDefaultValue;
    }

    private void Update()
    {
        Move();
    }
}
