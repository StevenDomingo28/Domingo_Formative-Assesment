using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour
{
    public GameObject hitSFX;
    float _speed = 10f;
    Rigidbody _rigidbody;
    Vector3 _velocity;
    Renderer _renderer;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _renderer = GetComponent<Renderer>();
        Invoke("Launch", 0.5f);
    }

    void Launch()
    {
        _rigidbody.velocity = Vector3.down * _speed;
    }

    void FixedUpdate()
    {
       _rigidbody.velocity = _rigidbody.velocity.normalized * _speed;
       _velocity = _rigidbody.velocity;

       if (!_renderer.isVisible)
       {
           GameManager.Instance.Balls--;
           Destroy(gameObject);
       }
    }

    private void OnCollisionEnter(Collision collision)
    {
        _rigidbody.velocity = Vector3.Reflect(_velocity, collision.contacts[0].normal);
        Instantiate(hitSFX, transform.position, transform.rotation);
    }

}
