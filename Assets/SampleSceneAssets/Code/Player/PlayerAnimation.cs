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
        float speed = Mathf.Abs(rb.velocity.x) + Mathf.Abs(rb.velocity.z);
        animator.SetFloat("Speed", speed);
    }

    public void TriggerAnimator(string toTrigger)
    {
        animator.ResetTrigger(toTrigger);
        animator.SetTrigger(toTrigger);
    }
}
