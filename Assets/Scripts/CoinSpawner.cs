using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Coin _coinPrefab;
    [SerializeField] private Transform[] _spawnPoints;

    private void Start()
    {
        for (int i = 0; i < _spawnPoints.Length; i++)
        {
            Instantiate(_coinPrefab, _spawnPoints[i].transform.position, Quaternion.identity);
        }
    }
}
