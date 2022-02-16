using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject[] Pannels;
    public GameObject Msg;
    float timeLeft = 60;
    bool Play = false;

    int level;

    [Header("End Game Pannels")]
    public GameObject WinPannel;
    public GameObject LosePannel;

    public TextMeshProUGUI timeTxt;

    // Start is called before the first frame update
    void Start()
    {
        // activate = false
        ActivatePannels(false);

        WinPannel.SetActive(false);
        LosePannel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        PlayGame();
        StartTimer();

        if (LockPickScript.stage > 2)
        {
            DeactivateAll();
            WinPannel.SetActive(true);
        }
    }

    void PlayGame()
    {
        if (!Play)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                // activate = true
                ActivatePannels(true);
            }
        }
        
    }

    void ActivatePannels(bool activate)
    {
        Msg.SetActive(!activate);

        Play = activate;
        for (int i = 0; i < 3; i++)
        {
            Pannels[i].SetActive(activate);
        }
    }

    void StartTimer()
    {
        if (Play && timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            timeTxt.text = "Time Left: " + (int)timeLeft;
        }
        else if (timeLeft <= 0)
        {
            DeactivateAll();
            LosePannel.SetActive(true);
        }

    }

    void DeactivateAll()
    {
        Play = false;
        timeTxt.text = " ";
        Msg.SetActive(false);

        for (int i = 0; i < 3; i++)
        {
            Pannels[i].SetActive(false);
        }
    }
}
