using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    [SerializeField] float velocity = 1f;
    Rigidbody rb;
    [SerializeField] Camera cam;
    [SerializeField] Vector3 cam_offset = new Vector3(4, 4, 0);
    [SerializeField] Vector3 force = new Vector3(0, 0, -4);

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        GetComponent<TrailRenderer>().enabled = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.MovePosition(transform.position + Vector3.right * velocity * Time.fixedDeltaTime);
        cam.transform.position = rb.position + cam_offset;
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.A))
        {
            rb.AddForce(force, ForceMode.Acceleration);
            GetComponent<TrailRenderer>().enabled = true;
        }
        if(Input.GetKey(KeyCode.D))
        {
            rb.AddForce(-force, ForceMode.Acceleration);
            GetComponent<TrailRenderer>().enabled = true;
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            GetComponent<TrailRenderer>().enabled = false;
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            GetComponent<TrailRenderer>().enabled = false;
        }
    }
}
