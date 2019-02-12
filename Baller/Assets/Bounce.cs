using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{

    public float bounceSpeed = 250f; 
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.gameObject.name == "Player")
        {
            collision.transform.GetComponent<Rigidbody>().AddForce(Vector3.up * bounceSpeed);
        }
    }
}
