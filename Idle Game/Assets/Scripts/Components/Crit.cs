using System.Collections;
using System.Collections.Generic;
using System.Resources;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class Crit : MonoBehaviour, IPointerClickHandler
{
    public TextMeshProUGUI upgradeText;
    public ResourceManager resourceManager;
    public Upgrade upgrade;
    public GameObject goldBorder;

    private int level;
    public int cost = 50;
    public int maxLevel = 5;

    public int chancePerLevel = 5;
    public int multIncreasePerLevel = 50;

    public ResourceManager.CurrencyType currency;

    // Start is called before the first frame update
    void Awake()
    {
        level = 0;
        RefreshText();
        goldBorder.SetActive(false);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (resourceManager.GetCurrencyAmount(currency) >= cost && level < maxLevel)
        {
            upgrade.critMult += multIncreasePerLevel;
            upgrade.critChance += chancePerLevel;
            //resourceManager.Shells -= cost;
            resourceManager.DecrimentCurrency(currency, cost);
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
        upgradeText.text = $"{upgrade.name} Upgrade: Crit Chance\n({cost} {currency}, {level}/{maxLevel})\nCurrent Stats: {upgrade.critChance}% Chance, {upgrade.critMult}% Mult";
    }
}
