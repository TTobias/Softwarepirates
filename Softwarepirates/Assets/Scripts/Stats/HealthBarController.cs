using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthBarController : MonoBehaviour
{
    public int initHealthPoints;
    private int healthPoints;
    private float initWidth;
    private RectTransform rect;

    void Start()
    {
        healthPoints = initHealthPoints;
        rect = GetComponent<RectTransform>();
        initWidth = rect.sizeDelta.x;
    }

    public void Damage(int amount)
    {
        healthPoints -= amount;
        UpdateBar();
        if (healthPoints <= 0)
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Heal(int amount)
    {
        healthPoints += amount;
        UpdateBar();
    }

    private void UpdateBar()
    {
        rect.sizeDelta = new Vector2(initWidth * healthPoints/100, rect.sizeDelta.y);
    }
}
