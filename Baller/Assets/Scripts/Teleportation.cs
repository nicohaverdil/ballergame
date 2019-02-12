using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleportation : MonoBehaviour
{
    // Exit portal's position
    public Transform exitPortal;

    // Start is called before the first frame update
    void Start()
    {
        if (exitPortal == null)
            Debug.LogError("exitPortal is null!");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            // Reset velocity
            Rigidbody target = other.GetComponent<Rigidbody>();

            // Correct target's position by its localScale.y
            Vector3 exitPortalPos = exitPortal.position;
            exitPortalPos.y += target.transform.localScale.y / 2;
        
            // Teleport the target to exitPortal.position
            target.transform.position = exitPortalPos;

            target.velocity = Vector3.zero;
        }
    }
}
