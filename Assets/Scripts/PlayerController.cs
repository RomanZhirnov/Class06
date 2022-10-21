using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _movingSpeed = 10;

    private bool _canMove;
    private Rigidbody2D _rb2d;
    private Vector2 _targetPosition;

    public Player _collide;

    private void OnEnable()
    {
        _collide.Collide += StopMoving;
    }

    private void OnDisable()
    {
        _collide.Collide -= StopMoving;
    }

    void Start()
    {
        _canMove = true;
        _rb2d = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (_canMove)
        {
            _targetPosition.x = Input.GetAxisRaw("Horizontal");
            _targetPosition.y = Input.GetAxisRaw("Vertical");
            _targetPosition = _rb2d.position + _targetPosition;
            _rb2d.position = Vector2.MoveTowards(_rb2d.position, _targetPosition, _movingSpeed * Time.deltaTime);
        }
    }

    private void StopMoving()
    {
            _canMove = false;
    }
}
