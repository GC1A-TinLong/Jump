using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    private void DestroySelf()
    {
        Destroy(gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        /*Rigidbody rb = other.GetComponent<Rigidbody>();
        rb.drag = 20;*/

        DestroySelf();
        Debug.Log(other.gameObject.name + " were Overlaped");
    }
    private void OnTriggerExit(Collider other)
    {
        /*Rigidbody rb = other.GetComponent<Rigidbody>();
        rb.drag = 0;*/

        Debug.Log(other.gameObject.name + " Exit");
    }

    // Start is called before the first frame update
    //void Start()
    //{

    //}

    // Update is called once per frame
    //void Update()
    //{

    //}
}
