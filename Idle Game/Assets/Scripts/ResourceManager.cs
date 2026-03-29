using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Diagnostics;

public class ResourceManager : MonoBehaviour
{
    // List of upgrades
    public List<GameObject> upgrades = new List<GameObject>();
    
    // Enum for different currency types
    public enum CurrencyType
    {
        Shells,
        Knives,
        RaiStones
    }

    // Will want to set this up for the other currency types
    public TextMeshProUGUI shellText;
    private double shells;

    public TextMeshProUGUI knivesText;
    private double knives;

    public double Shells
    {
        get
        {
            return shells;
        }
        set
        {
            shells = value;
            shellText.text = ("Shells: " + shells);
        }
    }

    //The other currency types. Do what was done above for these
    public double Knives
    {
        get
        {
            return knives;
        }
        set
        {
            knives = value;
            knivesText.text = ("Knives: " + knives);
        }
    }

    private double raiStones;

    void Start()
    {
        // Set the text for each currency type
        shellText.text = ("Shells: " + shells);
        knivesText.text = ("Knives: " + knives);

        // Sets all upgrade buttons to inactive
        for (int i = 0; i < upgrades.Count; i++)
        {
            upgrades[i].SetActive(false);
        }
    }

    void Update()
    {
        // Makes the upgrade button active once the player can afford the upgrade
        for (int i = 0; i < upgrades.Count; i++)
        {
            if (upgrades[i].GetComponent<Upgrade>().currency == CurrencyType.Shells)
            {
                if (shells >= upgrades[i].GetComponent<Upgrade>().paymentPrice)
                {
                    upgrades[i].SetActive(true);
                }
            }
            else if (upgrades[i].GetComponent<Upgrade>().currency == CurrencyType.Knives)
            {
                if (knives >= upgrades[i].GetComponent<Upgrade>().paymentPrice)
                {
                    upgrades[i].SetActive(true);
                }
            }
        }
    }

    public void IncrementCurrency(CurrencyType currency)
    {
        // Increments the currency type when the plus one button is pressed
        switch(currency)
        {
            case CurrencyType.Shells:
                Shells += 1;            // These numbers can be different for each if we so choose
                break;
            case CurrencyType.Knives:
                Knives += 1;
                break;
            case CurrencyType.RaiStones:
                raiStones += 1;
                break;
        }
    }

    public void IncrementCurrency(CurrencyType currency, int tier, float multiplier)
    {
        // Overload for incrementing currency with upgrades
        switch (currency)
        {
            case CurrencyType.Shells:
                Shells += tier * multiplier;
                break;
            case CurrencyType.Knives:
                Knives += tier * multiplier;
                break;
            case CurrencyType.RaiStones:
                raiStones += tier * multiplier;
                break;
        }
    }

    public void IncrementCurrency(CurrencyType currency, int tier, float multiplier, int crit)
    {
        // Overload for incrementing currency with upgrades when the crit goes off
        switch (currency)
        {
            case CurrencyType.Shells:
                Shells += tier * multiplier * crit;
                break;
            case CurrencyType.Knives:
                Knives += tier * multiplier * crit;
                break;
            case CurrencyType.RaiStones:
                raiStones += tier * multiplier * crit;
                break;
        }
    }

    public void DecrimentCurrency(CurrencyType currency, int price)
    {
        // Decriments the currency type when a purchase is made with them
        switch (currency)
        {
            case CurrencyType.Shells:
                Shells -= price;
                break;
            case CurrencyType.Knives:
                Knives -= price;
                break;
            case CurrencyType.RaiStones:
                raiStones -= price;
                break;
        }
    }

    public double GetCurrencyAmount(CurrencyType currency)
    {
        // Get the amount of a specific currency when required in other scripts
        switch(currency)
        {
            case CurrencyType.Shells:
                return Shells;
            case CurrencyType.Knives:
                return Knives;
            case CurrencyType.RaiStones:
                return raiStones;
            default:
                return 0;
        }
    }
}
