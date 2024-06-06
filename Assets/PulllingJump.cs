using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulllingJump : MonoBehaviour
{
    private Rigidbody rb;

    private Vector3 clickPosition;
    [SerializeField]
    private float jumpPower = 10;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            clickPosition = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            Vector3 dragVector = clickPosition - Input.mousePosition;
            if (dragVector.sqrMagnitude == 0) { return; }   // when click and release is the same coordinate
            rb.velocity = dragVector.normalized * jumpPower;
        }
    }
}
