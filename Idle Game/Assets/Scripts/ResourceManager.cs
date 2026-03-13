using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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
    private double knives;

    private double raiStones;

    void Start()
    {
        // Set the text for each currency type
        shellText.text = ("Shells: " + shells);

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
            if (shells >= upgrades[i].GetComponent<Upgrade>().paymentPrice)     // We're gonna want to modify this to work with every currency type instead of just shells
            {
                upgrades[i].SetActive(true);
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
                knives += 1;
                break;
            case CurrencyType.RaiStones:
                raiStones += 1;
                break;
        }
    }
}
