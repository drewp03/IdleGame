using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using TMPro;

public class Prestige : MonoBehaviour
{
    public static int raiStones = 0;
    private int potentialRaiStones;
    public int prestigePrice = 1000;

    public TextMeshProUGUI raiStonesText;
    public TextMeshProUGUI buttonText;
    public ResourceManager resourceManager;

    public void OnPress()
    {
        if (resourceManager.Shells >= prestigePrice)
        {
            ResetScene();
        }
        else
        {
            ConsoleManager.toLog = "<color=red>Prestige Purchase Failed</color>";
        }
    }

    public void Update()
    {
        potentialRaiStones = (int)(resourceManager.Shells / prestigePrice);
        buttonText.text = "Prestige (" + prestigePrice + " Shells)\nPotential Rai Stones: " + potentialRaiStones;
    }

    public void Start()
    {
        raiStonesText.text = "Rai Stones: " + raiStones;
    }

    public void ResetScene()
    {
        raiStones += potentialRaiStones;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
