using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonajePrincipal : MonoBehaviour
{
    [SerializeField] private float velocidadX;
    [SerializeField] private float velocidadY;

    private Rigidbody2D _rigidbody;

    private void Move()
    {
        // Constant movement to the right
        float jumpFactor = 0;
        if (Input.GetButtonDown("Jump"))
        {
            jumpFactor = 1;
        }
        _rigidbody.velocity = new Vector2(velocidadX, 
                                            _rigidbody.velocity.y + jumpFactor * velocidadY);
    }

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Move();
    }
}
