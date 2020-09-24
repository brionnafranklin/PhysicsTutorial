using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(Animator))]
public class PlayerMovementBehavoir : MonoBehaviour
{
    private CharacterController _controller = null;
    private Animator _animator = null;
    public float speed = 80.0f;
    public float pushPower = 2.0f;
    public float turnRate = 2.0f;
    public bool tankControls = true;
    // Use this for initialization
    void Start()
    {
        _controller = GetComponent<CharacterController>();
        _animator = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
        if (tankControls)
        { 
            _controller.SimpleMove(transform.forward * movement.z * speed);
        transform.Rotate(transform.up, movement.x * turnRate * Time.deltaTime);
        }
        else
        {
            //good movement
            _controller.SimpleMove(movement);
            if (movement.magnitude > 0)
                transform.forward = movement.normalized;
        }
        //animation
        _animator.SetFloat("Speed", movement.magnitude * speed);
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody otherRB = hit.collider.attachedRigidbody;
        if (otherRB == null || otherRB.isKinematic)
            return;
        if (hit.moveDirection.y < -0.3F)
            return;
        Vector3 pushDirection = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);
        //otherRB.velocity = pushDirection * pushPower;
        otherRB.AddForceAtPosition(pushDirection * pushPower, hit.point);
    }
}
