using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class goalTrigger : MonoBehaviour
{
    private bool isClear = false;
    private int counter = 0;

    private void OnCollisionEnter(Collision collision)
    {
        isClear = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (isClear)
        {
            counter++;
            if (counter >= 120)
            {
                SceneManager.LoadScene("Clear");
            }
        }
    }
}
