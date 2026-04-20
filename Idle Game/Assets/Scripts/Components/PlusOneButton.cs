using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlusOneButton : MonoBehaviour, IPointerClickHandler
{
    public ResourceManager resourceManager;         // Resource Manager script
    public ResourceManager.CurrencyType currency;   // Currency type enum from the Resource Manager script. Currency types can be selected manually in the Unity editor

    public void OnPointerClick(PointerEventData eventData)
    {
        // Increments the selected currency when the button is pressed
        resourceManager.IncrementCurrency(currency);
        ConsoleManager.toLog = "> +1 Shell";
    }
}
