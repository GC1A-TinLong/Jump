using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PulllingJump : MonoBehaviour
{
    private Rigidbody rb;

    private Vector3 clickPosition;
    [SerializeField] float groundLimit = 30.0f;
    [SerializeField] private float jumpPower = 40.0f;
    [SerializeField] private const float vectorLength = 20000.0f;

    private bool isCanJump;
    private bool isJumped = false;
    private bool isContacted = false;
    private int endCounter = 0;

    private void OnCollisionEnter(Collision collision)
    {
        Vector3 normal = collision.contacts[0].normal;  // getting surface's normal
        float angle = Vector3.Angle(normal, Vector3.up);

        if (angle < groundLimit)
        {
            isCanJump = true;
        }
        isContacted = true;
    }
    private void OnCollisionExit(Collision collision)
    {
        isCanJump = false;
        //Debug.Log("Exit");
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
            isJumped = true;
            isContacted = false;

            Vector3 dragVector = clickPosition - Input.mousePosition;
            if (dragVector.sqrMagnitude == 0) { return; }   // when click and release is the same coordinate
            else if (dragVector.sqrMagnitude <= vectorLength)
            {
                rb.velocity = dragVector.normalized * (jumpPower * 0.1f);
            }
            else if (dragVector.sqrMagnitude > vectorLength && dragVector.sqrMagnitude <= vectorLength * 2)
            {
                rb.velocity = dragVector.normalized * (jumpPower * 0.2f);
            }
            else if (dragVector.sqrMagnitude > vectorLength * 2 && dragVector.sqrMagnitude <= vectorLength * 3)
            {
                rb.velocity = dragVector.normalized * (jumpPower * 0.3f);
            }
            else if (dragVector.sqrMagnitude > vectorLength * 3 && dragVector.sqrMagnitude <= vectorLength * 4)
            {
                rb.velocity = dragVector.normalized * (jumpPower * 0.4f);
            }
            else if (dragVector.sqrMagnitude > vectorLength * 4 && dragVector.sqrMagnitude <= vectorLength * 5)
            {
                rb.velocity = dragVector.normalized * (jumpPower * 0.5f);
            }
            else if (dragVector.sqrMagnitude > vectorLength * 5 && dragVector.sqrMagnitude <= vectorLength * 6)
            {
                rb.velocity = dragVector.normalized * (jumpPower * 0.6f);
            }
            else if (dragVector.sqrMagnitude > vectorLength * 6 && dragVector.sqrMagnitude <= vectorLength * 7)
            {
                rb.velocity = dragVector.normalized * (jumpPower * 0.7f);
            }
            else if (dragVector.sqrMagnitude > vectorLength * 7 && dragVector.sqrMagnitude <= vectorLength * 8)
            {
                rb.velocity = dragVector.normalized * (jumpPower * 0.8f);
            }
            else if (dragVector.sqrMagnitude > vectorLength * 8 && dragVector.sqrMagnitude <= vectorLength * 9)
            {
                rb.velocity = dragVector.normalized * (jumpPower * 0.9f);
            }
            else { rb.velocity = dragVector.normalized * jumpPower; }
            Debug.Log("size" + dragVector.sqrMagnitude);
        }

        if (isJumped && isContacted)
        {
            endCounter++;
            if (endCounter >= 1500)
            {
                SceneManager.LoadScene("Gameplay");
            }
        }
    }
}