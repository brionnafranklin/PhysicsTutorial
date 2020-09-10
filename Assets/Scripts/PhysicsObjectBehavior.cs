using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PhysicsObjectBehavior : MonoBehaviour
{
    public Material awakeMaterial = null;
    public Material asleepMaterial = null;
    private Rigidbody _rigidbody = null;
    bool wasAsleep = false;
    // Use this for initialization
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {
    }
    private void FixedUpdate()
    {
        if (_rigidbody.IsSleeping() && !wasAsleep && asleepMaterial != null)
        {
            wasAsleep = true;
            GetComponent<MeshRenderer>().material = asleepMaterial;
        }
        if (!_rigidbody.IsSleeping() && wasAsleep && awakeMaterial != null)
        {
            wasAsleep = false;
            GetComponent<MeshRenderer>().material = awakeMaterial;
        }
    }
}

