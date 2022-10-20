using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatingEnemies : MonoBehaviour
{
    [SerializeField] private Enemy _template;

    private Transform[] _respawnPoints;
    private Coroutine _coroutine;
    private float _creatingInterval = 2f;
    private int _creatingCount = 30;
    void Start()
    {
        _respawnPoints = new Transform[gameObject.transform.childCount];

        for (int i = 0; i < _respawnPoints.Length; i++)
        {
            _respawnPoints[i] = transform.GetChild(i).transform;
        }

        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }
        else
        {
            _coroutine = StartCoroutine(CreateEnemy(_creatingInterval));
        }

    }

    private IEnumerator CreateEnemy(float time)
    {
        var WaitTime = new WaitForSeconds(time);

        do
        {
            for (int i = 0; i < _respawnPoints.Length; i++)
            {
                Instantiate(_template, _respawnPoints[i].position, Quaternion.identity);
                _creatingCount--;
                yield return WaitTime;
            }
        } while (_creatingCount>0);
    }
}
