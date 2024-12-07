using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float speed;
    [SerializeField] private float turnSpeed;
    [SerializeField] private AudioClip idleClip;
    [SerializeField] private AudioClip drivingClip;

    // Movement vars.
    private float horizontal,
                vertical;

    // GO Components
    Rigidbody rb;
    AudioSource audioSource;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = rb.GetComponent<AudioSource>();
    }
    void Update()
    {
        InputPlayer();
    }

    void FixedUpdate()
    {
        Move();
        Turn();
    }

    void InputPlayer()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
    }
    void Move()
    {
        Vector3 movement = transform.forward * vertical * speed * Time.fixedDeltaTime;
        rb.MovePosition(transform.position + movement);
    }
    void Turn()
    {
        // Calcule how many grades I want to turn the tank
        float turn = horizontal * turnSpeed * Time.fixedDeltaTime;
        // Gets a Quaternion in func. of an specific amount of degrees on the X,Y and Z axis
        Quaternion turnRotation = Quaternion.Euler(0, turn, 0);

        rb.MoveRotation(transform.rotation * turnRotation);       
    }
}
