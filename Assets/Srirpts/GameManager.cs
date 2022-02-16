using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

enum Difficulty
{
    EASY,
    MEDIUM,
    HARD
};

public class GameManager : MonoBehaviour
{
    public GameObject[] Pannels;
    public GameObject Msg;
    public GameObject DifficultyPannel;
    float timeLeft = 60;
    bool Play = false;

    Difficulty difficulty;

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
        DifficultyPannel.SetActive(false);
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
                Msg.SetActive(false);
                DifficultyPannel.SetActive(true);
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
        if (timeLeft > 0 && Play)
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


    public void Easy()
    {
        DifficultyPannel.SetActive(false);
        difficulty = Difficulty.EASY;
        LockPickScript._difficulty = (int)difficulty;
        ActivatePannels(true);
    }

    public void Medium()
    {
        DifficultyPannel.SetActive(false);
        difficulty = Difficulty.MEDIUM;
        LockPickScript._difficulty = (int)difficulty;
        ActivatePannels(true);
    }

    public void Hard()
    {
        DifficultyPannel.SetActive(false);
        difficulty = Difficulty.HARD;
        LockPickScript._difficulty = (int)difficulty;
        ActivatePannels(true);
    }
}
