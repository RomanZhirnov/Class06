using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _movingSpeed = 10;

    private Rigidbody2D _rb2d;
    private Vector2 _targetPosition;

    void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        _targetPosition.x = Input.GetAxisRaw("Horizontal");
        _targetPosition.y = Input.GetAxisRaw("Vertical");

        _targetPosition = _rb2d.position + _targetPosition;

        _rb2d.position =  Vector2.MoveTowards(_rb2d.position, _targetPosition, _movingSpeed*Time.deltaTime);
    }

}
