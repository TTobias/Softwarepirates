using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour
{
    public int initHealthPoints;
    private int healthPoints;
    private float initWidth;
    private RectTransform rect;
    private GameOver gameOver;

    void Start()
    {
        gameOver = FindObjectOfType<GameOver>();
        healthPoints = initHealthPoints;
        rect = GetComponent<RectTransform>();
        initWidth = rect.sizeDelta.x;
    }

    public void Damage(int amount)
    {
        healthPoints -= amount;
        UpdateBar();
        if (healthPoints <= 0)
            gameOver.Execute();
    }

    public void Heal(int amount)
    {
        healthPoints += amount;
        UpdateBar();
    }

    private void UpdateBar()
    {
        //rect.sizeDelta = new Vector2(initWidth * healthPoints/100, rect.sizeDelta.y);
        GetComponent<Image>().fillAmount = (float)healthPoints / (float)initHealthPoints;
    }
}
