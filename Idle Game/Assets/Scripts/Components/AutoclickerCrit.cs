using System.Collections;
using System.Collections.Generic;
using System.Resources;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class AutoclickerCrit : MonoBehaviour, IPointerClickHandler
{
    public TextMeshProUGUI upgradeText;
    public ResourceManager resourceManager;
    public Upgrade autoclicker;
    public GameObject goldBorder;

    private int level;
    public int cost = 50;
    public int maxLevel = 5;

    public int chancePerLevel = 5;
    public int multIncreasePerLevel = 50;

    // Start is called before the first frame update
    void Awake()
    {
        level = 0;
        RefreshText();
        goldBorder.SetActive(false);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (resourceManager.Shells >= cost && level < maxLevel)
        {
            autoclicker.critMult += multIncreasePerLevel;
            autoclicker.critChance += chancePerLevel;
            resourceManager.Shells -= cost;
            level++;
            
            if (level == maxLevel)
            {
                goldBorder.SetActive(true);
            }
        }
        RefreshText();
    }
    
    void RefreshText()
    {
        upgradeText.text = $"Autoclicker Upgrade: Crit Chance\n({cost} Shells, {level}/{maxLevel})\nCurrent Stats: {autoclicker.critChance}% Chance, {autoclicker.critMult}% Mult";
    }
}
