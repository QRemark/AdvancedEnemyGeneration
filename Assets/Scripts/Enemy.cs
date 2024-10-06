using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Enemy : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private Target _target;

    private float _lifeWay = 15.0f;
    private float _speed;

    public event Action<Enemy> Reached;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (_target != null)
        {
            Vector3 direction = (_target.transform.position - transform.position).normalized;
            _rigidbody.velocity = direction * _speed;
        }
    }

    public void Init()
    {
        StartWay();
    }

    public void BeginPursuit(Target target, float speed)
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
        StartCoroutine(Countdown());
    }

    private IEnumerator Countdown()
    {
        yield return new WaitForSeconds(_lifeWay);
        NotifyReached();
    }

    private void NotifyReached()
    {
        Reached?.Invoke(this);
    }
}
