using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Upgrade : MonoBehaviour, IPointerClickHandler
{
    public ResourceManager resourceManager;     // The Resource Manager script
    public float tickTime = 3f;                 // Time it takes for the upgrade to run
    private float timer;                        // Timer variable
    private int tier;                           // Number of times the upgrade has been purchased
    public enum CurrencyType
    {
        Shells,
        Knives
    }
    public CurrencyType currencyType;

    // UI and button elements
    public TextMeshProUGUI autoclickerText;
    public Image progressBar;

    public float multiplier;                    // How much currency the upgrade gives 
    public int paymentPrice;                    // How much the upgrade costs

    public string upgradeName;                  // Upgrade name

    public int critChance;
    public int critMult;

    // We probably won't need this enum
    public enum UpgradeState
    {
        Locked,
        Available,
        Purchased
    }

    void Start()
    {
        critChance = 0;
        critMult = 100;
    }

    void Update()
    {
        // Makes the upgrade automatically run
        if (tier > 0)
        {
            if (timer >= tickTime && tier > 0)
            {
                timer = 0f;

                if (Random.Range(0f, 100f) < critChance)
                {
                    AddCurrency(tier * multiplier * (critMult/100f));    // Will need to modify this to work with any currency type
                    Debug.Log("Crit triggered");
                }
                else
                {
                    AddCurrency(tier * multiplier);    // Will need to modify this to work with any currency type
                }
            }
            timer += Time.deltaTime;
            progressBar.fillAmount = timer / tickTime;
        }
    }

    // Activates whenever the upgrade button is pressed
    public void OnPointerClick(PointerEventData eventData)
    {
        if (GetCurrency() >= paymentPrice)
        {
            SpendCurrency(paymentPrice) ; // Will need to modify this to work with any currency type
            tier++;

            string currencyName = currencyType.ToString();
            autoclickerText.text = ("Buy " + upgradeName + " (" + paymentPrice + " " + currencyName + ")\n" + upgradeName + ": " + tier);   // Displays text on the button. Should probably modify this to show how many currency the upgrade actually gives
        }
    }

    double GetCurrency()
    {
        switch (currencyType)
        {
            case CurrencyType.Shells:
                return resourceManager.Shells;
            case CurrencyType.Knives:
                return resourceManager.Knives;
            default:
                return 0;
        }
    }

    void AddCurrency(float amount)
    {
        switch(currencyType)
        {
            case CurrencyType.Shells:
                resourceManager.Shells += amount;
                break;
            case CurrencyType.Knives:
                resourceManager.Knives += amount;
                break;
        }
    }

    void SpendCurrency(int amount)
    {
        switch(currencyType)
        {
            case CurrencyType.Shells:
                resourceManager.Shells -= amount;
                break;
            case CurrencyType.Knives:
                resourceManager.Knives -= amount;
                break;
        }
    }
}
