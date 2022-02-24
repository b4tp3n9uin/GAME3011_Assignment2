using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LockPickScript : MonoBehaviour
{

    [SerializeField]
    float speed = 40;

    float goalPoint;
    public static int stage;
    public static int _difficulty;
    bool inRange = false;

    [Header("Texts")]
    public TextMeshProUGUI currentAngleTxt;
    public TextMeshProUGUI goalAngleTxt;
    public TextMeshProUGUI progressTxt;

    Vector3 StartMousePosition;
    Vector3 LastMousePosition;

    [Header("ProgressBox")]
    public Image[] boxArray;

    public RectTransform rt;

    void Start()
    {
        rt = GetComponent<RectTransform>();
        goalPoint = generateRandomAngle();
        stage = 0;
        displayText();
    }

    // Update is called once per frame
    void Update()
    {
        CheckAngle(rt.rotation.z * 180 + 180);
        

        if (Input.GetMouseButtonDown(0))
        {
            if (inRange)
            {
                boxArray[stage].color = Color.green;
                Debug.Log("Progress");
                stage++;
                goalPoint = generateRandomAngle();
                displayText();
            }
            
        }

        if (Input.GetAxis("Mouse X") != 0)
        {
            float move = speed * Input.GetAxis("Mouse X");
            rt.Rotate(0, 0, move);
            displayText();
        }
    }

    void displayText()
    {
        float angle = rt.rotation.z * 180 + 180;

        currentAngleTxt.text = "Current Angle: " + (int)angle;
        goalAngleTxt.text = "Goal Angle: " + (int)goalPoint;
    }

    float generateRandomAngle()
    {
        float goal = Random.Range(0.0f, 360.0f);
        return goal;
    }

    void CheckAngle(float _angle)
    {
        // Easy
        float maxRange = goalPoint + 15,
            minRange = goalPoint - 15;

        //Medium
        if (_difficulty == 1)
        {
            maxRange = goalPoint + 9;
            minRange = goalPoint - 9;
        }

        //Hard
        if (_difficulty == 2)
        {
            maxRange = goalPoint + 3;
            minRange = goalPoint - 3;
        }



        if (_angle > minRange && _angle < maxRange)
        {
            progressTxt.text = "In Target Range";
            inRange = true;
            boxArray[stage].color = Color.blue;
        }
        else
        {
            inRange = false;
            progressTxt.text = "Not in Range!";
            boxArray[stage].color = Color.grey;
        }
    }
}
