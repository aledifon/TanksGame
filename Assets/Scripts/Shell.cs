using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell : MonoBehaviour
{
    [SerializeField] ParticleSystem explosionShell; // Ref. to the particle system of the bullet's child
    public int damageShell;

    // GO components
    AudioSource audioSource;
    Renderer rend;
    Collider coll;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();   
        rend = GetComponent<Renderer>();
        coll = GetComponent<Collider>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        coll.enabled = false;
        rend.enabled = false;
        explosionShell.Play();
        audioSource.Play();
        Destroy(gameObject, 0.5f);
    }    
}
