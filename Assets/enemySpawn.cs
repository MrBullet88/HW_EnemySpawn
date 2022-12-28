using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class enemySpawn : MonoBehaviour
{
    [SerializeField] private GameObject _enemy;
    [SerializeField] private Transform _transform;

    private bool _isSpawn = true;
    private int _enemySpawnTime = 2;
    private Transform[] _points;

    private void Start()
    {
        _points = new Transform[_transform.childCount];

        for(int i = 0; i < _points.Length; i++)
        {
            _points[i] = _transform.GetChild(i);           
        }

        StartCoroutine(CreateEnemy());
    }

    private IEnumerator CreateEnemy()
    {
        while (_isSpawn)
        {         
            GameObject gameObject = Instantiate(_enemy, _points[Random.Range(0,_points.Length)].position, Quaternion.identity); 
            yield return new WaitForSeconds(_enemySpawnTime);
        }      
    }
}
