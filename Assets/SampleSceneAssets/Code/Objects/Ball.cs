using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private float speed;
    private Vector3 startPos;
    private bool isMoving;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        startPos = transform.position;
    }

    private void Update()
    {
        if (!isMoving)
            return;

        rb.velocity = Vector3.forward * speed;
    }

    public void StartMoving()
    {
        isMoving = true;
        ResetBall();
    }

    public void ResetBall()
    {
        transform.position = startPos;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerUnit>().Death();
            ResetBall();
        }
    }
}
