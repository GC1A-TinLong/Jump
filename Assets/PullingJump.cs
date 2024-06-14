using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PulllingJump : MonoBehaviour
{
    private Rigidbody rb;

    private Vector3 clickPosition;
    [SerializeField] float groundLimit = 30.0f;
    [SerializeField]
    private float jumpPower = 10;

    private bool isCanJump;

    private void OnCollisionEnter(Collision collision)
    {
        /*var obj = collision.gameObject;
        var rend = obj.GetComponent<Renderer>();
        var mat = rend.material;
        mat.color = Color.yellow;
        rend.material = mat;*/

        Vector3 normal = collision.contacts[0].normal;  // getting surface's normal
        float angle = Vector3.Angle(normal, Vector3.up);

        if (angle < 30)
        {
            isCanJump = true;
        }

        Debug.Log("Hit");
    }
    private void OnCollisionExit(Collision collision)
    {
        isCanJump = false;
        Debug.Log("Exit");
    }
    private void OnCollisionStay(Collision collision)
    {
        Vector3 normal = collision.contacts[0].normal;  // getting surface's normal
        float angle = Vector3.Angle(normal, Vector3.up);
        if (angle < groundLimit)
        {
            isCanJump = true;
        }
    }

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
        else if (isCanJump && Input.GetMouseButtonUp(0))
        {
            Vector3 dragVector = clickPosition - Input.mousePosition;
            if (dragVector.sqrMagnitude == 0) { return; }   // when click and release is the same coordinate
            rb.velocity = dragVector.normalized * jumpPower;
        }
    }
}