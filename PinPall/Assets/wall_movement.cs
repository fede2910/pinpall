using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wall_movement : MonoBehaviour
{
    int velocita = 40;
    Rigidbody rb;
    bool sinistra;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (transform.position.z >= -10.95f)
        {
            sinistra = true;
        }
        if (transform.position.z <= 10.92f)
        {
            sinistra = false;
        }
        if (sinistra == true)
        {
            rb.MovePosition(transform.position + Vector3.back * velocita * Time.fixedDeltaTime);
        }
        if (sinistra == false)
        {
            rb.MovePosition(transform.position + Vector3.forward * velocita * Time.fixedDeltaTime);
        }
    }
}