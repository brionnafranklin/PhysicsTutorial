using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CannonBallBehavior : MonoBehaviour
{
    public float forceOnFire = 300;
    private bool _canFire = true;
    Rigidbody _rigidbody = null;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.isKinematic = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown && _canFire)
        {
            _rigidbody.isKinematic = false;
            _rigidbody.AddForce(transform.forward * forceOnFire);
            _canFire = false;
        }
    }
}
