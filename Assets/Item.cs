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

        //DestroySelf();
        Debug.Log(other.gameObject.name + " were Overlaped");
        //_anim.Play("Get");
        _anim.SetBool("IsGet", true);
    }
    private void OnTriggerExit(Collider other)
    {
        /*Rigidbody rb = other.GetComponent<Rigidbody>();
        rb.drag = 0;*/

        Debug.Log(other.gameObject.name + " Exit");
    }
    /// <summary>
    /// When ItemGet Animation is finished, call this function
    /// </summary>
    void OnGetAnimationFinsihed()
    {
        Debug.Log("Item Destroyed");
        Destroy(gameObject);
    }

    Animator _anim;

    // Start is called before the first frame update
    void Start()
    {
        _anim= GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V)) {
            _anim.Play("Idle");
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            _anim.Play("Get");
        }
    }
}
