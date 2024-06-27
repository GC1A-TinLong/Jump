using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    public void LoadScene()
    {
        Debug.Log("Test");
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("load scene");
        //SceneManager.LoadScene("SampleScene");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
