using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankAttack : MonoBehaviour
{
    //[SerializeField] GameObject shellPrefab;    // Ref. to the Prefab
    [SerializeField] Rigidbody shellPrefab;    // Ref. to the Prefab
    [SerializeField] Transform posShell;        // Ref. to the empty GO which represent the out bullet pos.
    [SerializeField] float launchForce;
    [SerializeField] AudioSource audioSource;   // Ref. to the audioSource component which brings the posShell object        

    TankMovement tankMovement;
    void Start()
    {        
        tankMovement = GetComponent<TankMovement>();
    }
    
    void Update()
    {        
        if (Input.GetMouseButtonDown(0))
            Launch();
    }

    // Update is called once per frame
    void Launch()
    {
        //GameObject cloneShellPrefab = Instantiate(shellPrefab,posShell.position,posShell.rotation);
        Rigidbody cloneShellPrefab = Instantiate(shellPrefab, posShell.position, posShell.rotation);
        audioSource.Play();        
                    
        if (tankMovement.bIsMovingFwd)
            cloneShellPrefab.velocity = posShell.forward * launchForce*1.5f;
        else
            cloneShellPrefab.velocity = posShell.forward * launchForce;
    }
}
