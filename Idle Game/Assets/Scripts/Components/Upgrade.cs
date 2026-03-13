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

    // UI and button elements
    public TextMeshProUGUI autoclickerText;
    public Image progressBar;

    public float multiplier;                    // How much currency the upgrade gives 
    public int paymentPrice;                    // How much the upgrade costs

    public string upgradeName;                  // Upgrade name

    // We probably won't need this enum
    public enum UpgradeState
    {
        Locked,
        Available,
        Purchased
    }

    void Update()
    {
        // Makes the upgrade automatically run
        if (tier > 0)
        {
            if (timer >= tickTime && tier > 0)
            {
                resourceManager.Shells += tier * multiplier;    // Will need to modify this to work with any currency type
                timer = 0f;
            }
            timer += Time.deltaTime;
            progressBar.fillAmount = timer / tickTime;
        }
    }

    // Activates whenever the upgrade button is pressed
    public void OnPointerClick(PointerEventData eventData)
    {
        if (resourceManager.Shells >= paymentPrice)
        {
            resourceManager.Shells -= paymentPrice;             // Will need to modify this to work with any currency type
            tier++;
            autoclickerText.text = ("Buy "+upgradeName+" ("+paymentPrice+" Shells)\n" +upgradeName+ ": " + tier);   // Displays text on the button. Should probably modify this to show how many currency the upgrade actually gives
        }
    }
}
