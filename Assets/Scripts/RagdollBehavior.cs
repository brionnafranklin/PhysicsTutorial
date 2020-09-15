using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class RagdollBehavior : MonoBehaviour
{
    private Animator animator = null;
    private CharacterController controller = null;
    public List<Rigidbody> rigidbodies = new List<Rigidbody>();
    public bool ragdollEnabled
    {
        get { return !animator.enabled; }
        set
        {
            animator.enabled = !value;
            controller.enabled = !value;
            foreach (Rigidbody r in rigidbodies)
                r.isKinematic = !value;
        }
    }
    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
            ragdollEnabled = false;
    }
}
