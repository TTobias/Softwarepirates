﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class HintCounterController : MonoBehaviour
{
    public int neededHints;
    private int hints = 0;
    private TextMeshProUGUI tmp;
    private GameWon gameWon;

    void Start()
    {
        gameWon = FindObjectOfType<GameWon>();
        tmp = GetComponent<TextMeshProUGUI>();
        UpdateText();
    }

    public void AddHint()
    {
        if(hints < neededHints)
        {
            hints++;
            UpdateText();
        }
        if (hints == neededHints)
            gameWon.Execute();
    }

    public void RemoveHint()
    {
        if(hints > 0)
        {
            hints--;
            UpdateText();
        }
    }

    private void UpdateText()
    {
        tmp.text = "Hints: " + hints + "/" + neededHints;
    }
}
