using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.UI;

public class ArrowDraw : MonoBehaviour
{
    [SerializeField]
    private Image arrowImage;
    private Vector3 clickPosition;  // Drag starting position

    // Start is called before the first frame update
    void Start()
    {
        arrowImage.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            arrowImage.gameObject.SetActive(true);
            clickPosition = Input.mousePosition;
            arrowImage.rectTransform.sizeDelta = Vector2.zero; // reseting size
            arrowImage.rectTransform.position = clickPosition;
        }
        else if (Input.GetMouseButton(0))   //  while dragging
        {
            Vector3 dragVector = clickPosition - Input.mousePosition;

            float size = dragVector.magnitude;  // getting the length of the vector
            arrowImage.rectTransform.right = dragVector;    // set arrow to vector direction
            arrowImage.rectTransform.sizeDelta = Vector2.one * size; // set the size by drag distance
        }
        else if (Input.GetMouseButtonUp(0))
        {
            arrowImage.gameObject.SetActive(false);
        }
    }
}