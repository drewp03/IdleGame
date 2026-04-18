using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
//using System.Diagnostics;
using System.IO;

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
        SetActiveUpgrades();
    }

    public void SetActiveUpgrades()
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

    public void Save()
    {
        //referencing class to save data
        GameSaveData data = new GameSaveData();

        //saves current amounts to data
        data.SavedShells = Shells;
        data.SavedKnives = Knives;

        //creates a list based on upgradeTiers
        data.UpgradeTiers = new List<int>();

        for(int i=0;i<upgrades.Count;i++)
        {
            //finding the component that holds the tier, then adding the tier to data
            Upgrade upTier = upgrades[i].GetComponent<Upgrade>();
            data.UpgradeTiers.Add(upTier.tier);
        }

        //saving data to json
        string json = JsonUtility.ToJson(data);
        string path = Application.persistentDataPath + "/save.json";

        //writing data to json
        File.WriteAllText(path,json);

        Debug.Log("Successfully Saved!");
    }

    public void Load()
    {
        //finding path referenced in save
        string path = Application.persistentDataPath + "/save.json";

        if(File.Exists(path))
        {
            string json = File.ReadAllText(path);
            GameSaveData data = JsonUtility.FromJson<GameSaveData>(json);

            if(data == null)
            {
                //EXCEPTION FOR ASSIGNMENT
                throw new System.Exception("Save file is NULL");
            }

            //taking the saved data and applying it to current data
            Shells = data.SavedShells;
            Knives = data.SavedKnives;

            //loop to reset gameobjects as active or inactive
            for(int i=0;i<upgrades.Count;i++)
            {
                if(i < data.UpgradeTiers.Count)
                {
                    upgrades[i].GetComponent<Upgrade>().SetTier(data.UpgradeTiers[i]);

                    if(data.UpgradeTiers[i] >= 1)
                    {
                        upgrades[i].SetActive(true);
                    }
                    else
                    {
                        upgrades[i].SetActive(false);
                    }
                }
            }
        }
        Debug.Log("Successfully Loaded!");
    }
}