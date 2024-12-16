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

    public bool bIsMovingFwd;

    // GO Components
    Rigidbody rb;
    AudioSource audioSource;

    GameManager gameManager;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = rb.GetComponent<AudioSource>();

        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }
    void Update()
    {
        InputPlayer();
        AudioEngine();

        bIsMovingFwd = vertical>0;
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

        // Rotates the Rigidbody to a specific rotation (current quaternion + calculated quaternion)
        rb.MoveRotation(transform.rotation * turnRotation);       
    }
    void AudioEngine()
    {
        if (!gameManager.gameOver && !gameManager.victory)
        {
            if (vertical != 0 || horizontal != 0)       // The tank is moving or rotating        
            {
                if (audioSource.clip != drivingClip)
                    audioSource.clip = drivingClip;
            }
            else                                        // The tank is stopped               
            {
                if (audioSource.clip != idleClip)
                    audioSource.clip = idleClip;
            }
            if (!audioSource.isPlaying)
                audioSource.Play();
        }
        else
            audioSource.Stop();
    }
}
