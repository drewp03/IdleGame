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
    private bool purchaseSuccess;
    public GameObject popupPrefab;
    public Transform canvasTransform;
    public string upgradeName;

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
            resourceManager.DecrimentCurrency(currency, cost);
            level++;
            purchaseSuccess = true;


            if (level == maxLevel)
            {
                goldBorder.SetActive(true);
            }
        }

        else
            purchaseSuccess = false;

        string message = purchaseSuccess ? "Successfully Purchased " + upgradeName : "Purchase Failed";

        GameObject popup = Instantiate(popupPrefab, canvasTransform);

        RectTransform rect = popup.GetComponent<RectTransform>();
        rect.anchoredPosition = new Vector2(0,0.2f);

        popup.GetComponent<PurchaseUI>().Setup(message,purchaseSuccess);
        RefreshText();
    }
    
    void RefreshText()
    {
        upgradeText.text = $"{upgrade.name} Upgrade: Crit Chance\n({cost} {currency}, {level}/{maxLevel})\nCurrent Stats: {upgrade.critChance}% Chance, {upgrade.critMult}% Mult";
    }
}
