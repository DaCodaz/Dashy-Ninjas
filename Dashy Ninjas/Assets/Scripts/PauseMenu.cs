﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PauseMenu : MonoBehaviour {
    public GameObject menu;

    void Start()
    {
        menu.SetActive(false);
    }
    void FixedUpdate()
    {
        if(Input.GetKeyUp("escape"))
        {
            Pause();
        }
    }
    public void Pause()
    {
        menu.SetActive(!menu.activeSelf);
    }
    public void MainMenu()
    {
        CoinCounter.counter = 0;
        if(CoinCounter.counter > CoinCounter.highScore)
        {
            CoinCounter.highScore = CoinCounter.counter;
        }
        SceneManager.LoadScene("Menu");
    }
}
