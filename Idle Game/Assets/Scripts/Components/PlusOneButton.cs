using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlusOneButton : MonoBehaviour, IPointerClickHandler
{
    public ResourceManager resourceManager;         // Resource Manager script
    public ResourceManager.CurrencyType currency;   // Currency type enum from the Resource Manager script. Currency types can be selected manually in the Unity editor
    public bool CheatButton = false;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (!CheatButton)
        {
            // Increments the selected currency when the button is pressed
            resourceManager.IncrementCurrency(currency);
            ConsoleManager.toLog = "> +1 Shell";
        }
        else
        {
            for (int i = 0; i < 100; i++)
            {
                resourceManager.IncrementCurrency(currency);
            }

            ConsoleManager.toLog = "> Cheat Button";
        }
    }
}
