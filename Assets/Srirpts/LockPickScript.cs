using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LockPickScript : MonoBehaviour
{

    [SerializeField]
    float speed = 40;

    [Header("Texts")]
    public TextMeshProUGUI currentAngleTxt;

    Vector3 StartMousePosition;
    Vector3 LastMousePosition;

    public RectTransform rt;

    void Start()
    {
        rt = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Mouse X") != 0)
        {
            float move = speed * Input.GetAxis("Mouse X");
            rt.Rotate(0, 0, move);

            displayText();
        }
    }

    void displayText()
    {
        float angle = rt.rotation.z * 360;
        

        currentAngleTxt.text = "Current Angle: " + (int)angle;
    }
}
