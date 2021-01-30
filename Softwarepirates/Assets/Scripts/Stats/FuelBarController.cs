using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FuelBarController : MonoBehaviour
{
    public int initFuel;
    public float secondsForBurn;
    private int fuel;
    private Image image;

    void Start()
    {
        fuel = initFuel;
        image = GetComponent<Image>();
        UpdateBar();
        StartCoroutine(FuelBurnTick());
    }

    public void AddFuel()
    {
        if (fuel < initFuel)
        {
            fuel++;
            StopAllCoroutines();
            StartCoroutine(FuelBurnTick());
            UpdateBar();
        }
    }

    public void RemoveFuel()
    {
        fuel--;
        UpdateBar();
        if(fuel <= 0)
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void UpdateBar()
    {
        float amount = (float)fuel / (float)initFuel;
        image.fillAmount = amount;
    }

    public IEnumerator FuelBurnTick()
    {
        yield return new WaitForSeconds(secondsForBurn);
        RemoveFuel();
        StartCoroutine(FuelBurnTick());
    }
}
