using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private int count;
    public int speed = 10;
    public float sizeIncrement = 0.5f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
    }

    private void Update()
    {
        if (Input.GetKeyDown("space")) {
            Application.LoadLevel(Application.loadedLevel);
        }
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            transform.localScale += new Vector3(sizeIncrement, sizeIncrement, sizeIncrement);

            other.gameObject.SetActive(false);

            count = count + 1;

            if (count >= 4)
            {
                GameObject.Find("House").GetComponent<Collider>().isTrigger = true;
            }
        }

    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            transform.localScale = Vector3.one;
            other.gameObject.SetActive(false);
        }
    }
}
