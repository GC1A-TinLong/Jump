using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    Animator _anim;
    AudioSource _audioSource;

    private void DestroySelf()
    {
        Destroy(gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        /*Rigidbody rb = other.GetComponent<Rigidbody>();
        rb.drag = 20;*/

        Debug.Log(other.gameObject.name + " were Overlaped");
        //_anim.Play("Get");
        _anim.SetBool("IsGet", true);
        _audioSource.Play();
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

    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponent<Animator>();
        _audioSource = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            _anim.Play("Idle");
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            _anim.Play("Get");
        }
    }
}
