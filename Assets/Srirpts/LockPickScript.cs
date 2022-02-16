using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LockPickScript : MonoBehaviour
{

    [SerializeField]
    float speed = 40;

    float goalPoint;
    public static int stage;
    bool inRange = false;

    [Header("Texts")]
    public TextMeshProUGUI currentAngleTxt;
    public TextMeshProUGUI goalAngleTxt;
    public TextMeshProUGUI progressTxt;

    Vector3 StartMousePosition;
    Vector3 LastMousePosition;

    public RectTransform rt;

    void Start()
    {
        rt = GetComponent<RectTransform>();
        goalPoint = generateRandomAngle();
        stage = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (inRange)
            {
                Debug.Log("Progress");
                stage++;
                goalPoint = generateRandomAngle();
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
        float angle = rt.rotation.z * 180;
        CheckAngle(angle);

        currentAngleTxt.text = "Current Angle: " + (int)angle;
        goalAngleTxt.text = "Goal Angle: " + (int)goalPoint;
    }

    float generateRandomAngle()
    {
        float goal = Random.Range(-180.0f, 180.0f);
        return goal;
    }

    void CheckAngle(float _angle)
    {
        float maxRange = goalPoint + 5,
            minRange = goalPoint - 5;


        if (_angle > minRange && _angle < maxRange)
        {
            progressTxt.text = "In Target Range";
            inRange = true;
        }
        else
        {
            inRange = false;
            progressTxt.text = "Not in Range!";
        }
    }
}
