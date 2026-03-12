using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Upgrade : MonoBehaviour, IPointerClickHandler
{
    public ShellManager shellManager;
    public float tickTime = 3f;
    private float timer;
    private int clickers;

    public TextMeshProUGUI autoclickerText;
    public Image progressBar;

    public float multiplier;
    public float paymentPrice;

    public string upgradeName;

    public int numOfUnlockedUpgrades;

    public enum UpgradeState
    {
        Locked,
        Available,
        Purchased
    }

    void Update()
    {
        if (clickers > 0)
        {
            if (timer >= tickTime && clickers > 0)
            {
                shellManager.Shells += clickers * multiplier;
                timer = 0f;
            }
            timer += Time.deltaTime;
            progressBar.fillAmount = timer / tickTime;
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (shellManager.Shells >= paymentPrice)
        {
            shellManager.Shells -= paymentPrice;
            clickers++;
            autoclickerText.text = ("Buy "+upgradeName+" ("+paymentPrice+" Shells)\n" +upgradeName+ ": " + clickers);
        }
    }
}
