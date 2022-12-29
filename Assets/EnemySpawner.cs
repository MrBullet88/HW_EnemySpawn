using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy _template;
    [SerializeField] private Transform _transform;

    private bool _isSpawn = true;
    private Transform[] _points;
    private WaitForSeconds _waitForSeconds = new WaitForSeconds(2);

    private void Start()
    {
        _points = new Transform[_transform.childCount];

        for (int i = 0; i < _points.Length; i++)
        {
            _points[i] = _transform.GetChild(i);
        }

        StartCoroutine(CreateEnemy());
    }

    private IEnumerator CreateEnemy()
    {
        while (_isSpawn)
        {
            Instantiate( _template, _points[Random.Range(0, _points.Length)].position, Quaternion.identity);
            yield return _waitForSeconds;
        }
    }
}
