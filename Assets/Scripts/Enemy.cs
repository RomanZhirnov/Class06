using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _enemySpeed = 1;

    private Animator _animator;
    private Transform _target;
    private Rigidbody2D _rg2D;

    private void Start()
    {
        _rg2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _target = GameObject.FindObjectOfType<Player>().transform;
    }

    private void FixedUpdate()
    {
        _rg2D.position = Vector2.MoveTowards(_rg2D.position, _target.position, _enemySpeed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out Player player))
        {
            StartCoroutine(DestroyEnemy());
        }
    }

    private IEnumerator DestroyEnemy()
    {
        _animator.SetTrigger("IsCollision");
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
