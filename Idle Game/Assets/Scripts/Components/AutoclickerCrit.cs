using System.Collections;
using System.Collections.Generic;
using System.Resources;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class AutoclickerCrit : MonoBehaviour
{
    public TextMeshProUGUI upgradeText;
    public ResourceManager resourceManager;
    public Autoclicker autoclicker;

    private int level;
    public int cost = 50;
    public int maxLevel = 5;

    public int chancePerLevel = 5;
    public int multIncreasePerLevel = 50;

    // Start is called before the first frame update
    void Start()
    {
        level = 0;
        RefreshText();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (resourceManager.Shells >= 50 && level < maxLevel)
        {
            autoclicker.critMult += multIncreasePerLevel;
            autoclicker.chance += chancePerLevel;
        }
        RefreshText();
    }
    
    void RefreshText()
    {
        upgradeText.text = $"Autoclicker Upgrade: Crit Chance\n({cost} Shells, {level}/{maxLevel})\nCurrent Stats: {chance}% Chance, {mult}% Mult";
    }
}
