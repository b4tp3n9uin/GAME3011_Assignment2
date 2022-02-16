using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareArrayScript : MonoBehaviour
{
    public GameObject[] squareArray;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        checkStage();
    }

    void checkStage()
    {
        int maxStage = 3;
        for (int i = 0; i < maxStage; i++)
        {
            if (i == LockPickScript.stage)
            {
                squareArray[i].transform.localScale = new Vector3(1.2f, 1.2f);
            }
            else
            {
                squareArray[i].transform.localScale = new Vector3(1.0f, 1.0f);
            }
        }
    }
}
