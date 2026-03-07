using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Autoclicker : MonoBehaviour
{
    public ShellManager shellManager;
    public float tickTime = 3f;
    private float timer;
    private int clickers;

    public TextMeshProUGUI autoclickerText;
    public Image progressBar;

    void Update()
    {
        if (clickers > 0)
        {
            if (timer >= tickTime && clickers > 0)
            {
                shellManager.Shells += clickers;
                timer = 0f;
            }
            timer += Time.deltaTime;
            progressBar.fillAmount = timer / tickTime;
        }
    }

    public void AddClicker()
    {
        if (shellManager.Shells >= 15)
        {
            shellManager.Shells -= 15;
            clickers++;
            autoclickerText.text = ("Buy Autoclicker (15 Shells)\nAutoclickers: " + clickers);
        }
    }
}
