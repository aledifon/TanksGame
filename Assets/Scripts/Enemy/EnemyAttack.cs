using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    //[SerializeField] GameObject shellPrefab;      // Ref. to the Prefab
    [SerializeField] Rigidbody shellEnemyPrefab;    // Ref. to the Prefab
    [SerializeField] Transform posShell;            // Ref. to the empty GO which represent the out bullet pos.
    [SerializeField] float timeBetweenAttacks;      // Weapon cadence
    [SerializeField] float launchForce;
    //[SerializeField] AudioSource audioSource;       // Ref. to the audioSource component which brings the posShell object        

    private float timer;

    //TankMovement tankMovement;
    void Start()
    {
        //tankMovement = GetComponent<TankMovement>();
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= timeBetweenAttacks)
        {
            // if (RayCast Detected)
            Launch();
            timer = 0;
        }

        // if (RayCast Detected)
        //InvokeRepeating("Launch",timeBetweenAttacks,timeBetweenAttacks);
    }
    
    void Launch()
    {
        //GameObject cloneShellPrefab = Instantiate(shellPrefab,posShell.position,posShell.rotation);
        Rigidbody cloneShellPrefab = Instantiate(shellEnemyPrefab, posShell.position, posShell.rotation);
        //audioSource.Play();
                
        cloneShellPrefab.velocity = posShell.forward * launchForce;
    }
}
