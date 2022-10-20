using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(RigidbodyConstraints2D))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private float _enemySpeed = 1;
    
    private Transform _target;

    private Rigidbody2D _rg2D;

    private void Start()
    {
        _rg2D = GetComponent<Rigidbody2D>();
        _target = GameObject.FindObjectOfType<Player>().transform;
    }

    void Update()
    {
        _rg2D.position = Vector2.MoveTowards(_rg2D.position, _target.position, _enemySpeed*Time.deltaTime);
    }
}
