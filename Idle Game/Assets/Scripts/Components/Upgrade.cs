using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Upgrade : MonoBehaviour, IPointerClickHandler
{
    public ResourceManager resourceManager;         // The Resource Manager script
    public float tickTime = 3f;                     // Time it takes for the upgrade to run
    private float timer;                            // Timer variable
    private int tier;                               // Number of times the upgrade has been purchased

    // UI and button elements
    public TextMeshProUGUI autoclickerText;
    public Image progressBar;

    public float multiplier;                        // How much currency the upgrade gives 
    public int paymentPrice;                        // How much the upgrade costs

    public string upgradeName;                      // Upgrade name

    public ResourceManager.CurrencyType currency;   // Currency type selection

    public int critChance;
    public int critMult;

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
                    //resourceManager.Shells += tier * multiplier * (critMult / 100);    // Will need to modify this to work with any currency type
                    resourceManager.IncrementCurrency(currency, tier, multiplier, critMult / 100);
                    Debug.Log("Crit triggered");
                }
                else
                {
                    //resourceManager.Shells += tier * multiplier;    // Will need to modify this to work with any currency type
                    resourceManager.IncrementCurrency(currency, tier, multiplier);
                }
            }
            timer += Time.deltaTime;
            progressBar.fillAmount = timer / tickTime;
        }
    }

    // Activates whenever the upgrade button is pressed
    public void OnPointerClick(PointerEventData eventData)
    {
        if (resourceManager.GetCurrencyAmount(currency) >= paymentPrice)
        {
            //resourceManager.Shells -= paymentPrice;             // Will need to modify this to work with any currency type
            resourceManager.DecrimentCurrency(currency, paymentPrice);
            tier++;
            autoclickerText.text = ("Buy " + upgradeName + " (" + paymentPrice + " " + currency + ")\n" + upgradeName + ": " + tier);   // Displays text on the button. Should probably modify this to show how many currency the upgrade actually gives
        }
    }

    public void IncreaseCrit()
    {

    }
}
