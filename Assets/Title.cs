using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    public void LoadScene()
    {
        Debug.Log("load scene");
        SceneManager.LoadScene("Gameplay");
    }

    void Start()
    {
        Screen.SetResolution(1600, 900, false);
    }
}
