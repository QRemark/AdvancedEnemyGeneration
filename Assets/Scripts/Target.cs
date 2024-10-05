using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private List<Transform> _points;

    [SerializeField] private float _speed = 5.0f;
    [SerializeField] private float _minDistance = 0.1f;

    private int _currentPoint = 0;

    private void Update()
    {
        MoveToNextPoint();
    }

    private void MoveToNextPoint()
    {
        Transform targetPoint = _points[_currentPoint];

        Vector3 direction = (targetPoint.position - transform.position).normalized;

        transform.position += direction * _speed * Time.deltaTime;

        if (Vector3.Distance(transform.position, targetPoint.position) < _minDistance)
        {
            _currentPoint++;

            if (_currentPoint >= _points.Count)
                _currentPoint = 0;
        }
    }
}
