using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    [SerializeField] private float _speed = 2f;
    [SerializeField] private Transform[] _wayPoints;

    private int _currentWaypointIndex = 0;
    private float _detectionRadius = 0.1f;

    private void Update()
    {
        Transform wayPointsTransform = _wayPoints[_currentWaypointIndex];

        if (Vector3.Distance(transform.position, wayPointsTransform.position) < _detectionRadius)
        {
            _currentWaypointIndex = (_currentWaypointIndex + 1) % _wayPoints.Length;
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, wayPointsTransform.position, _speed * Time.deltaTime);
        }
    }
}
