using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Enemy : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private Target _target;

    private float _lifeWay = 30.0f;
    private float _speed;

    public event Action<Enemy> EndWay;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void Init()
    {
        StartWay();
    }

    private void Update()
    {
        if (_target != null)
        {
            Vector3 direction = (_target.transform.position - transform.position).normalized;
            _rigidbody.velocity = direction * _speed;
        }
    }

    public void SetTarget(Target target, float speed)
    {
        _target = target;
        _speed = speed;
    }

    public void ResetSpeed()
    {
        _rigidbody.velocity = Vector3.zero;
    }

    private void StartWay()
    {
        Invoke(nameof(NotifyWayEnd), _lifeWay);
    }

    private void NotifyWayEnd()
    {
        EndWay?.Invoke(this);
    }
}
