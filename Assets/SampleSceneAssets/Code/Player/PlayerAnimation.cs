using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [Header("Gameobjects & Components")]
    private Rigidbody rb;
    private Animator animator;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        animator.SetFloat("Speed", rb.velocity.magnitude);
    }

    public void TriggerAnimator(string toTrigger)
    {
        animator.ResetTrigger(toTrigger);
        animator.SetTrigger(toTrigger);
    }
}
