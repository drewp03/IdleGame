using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BeachComber : MonoBehaviour, IPointerClickHandler
{
    public ShellManager shellManager;
    public float tickTime = 10f;
    private float timer;
    private int clickers;

    public TextMeshProUGUI autoclickerText;
    public Image progressBar;

    void Update()
    {
        if (clickers > 0)
        {
            if (timer >= tickTime && clickers > 0)
            {
                shellManager.Shells += clickers * 5;
                timer = 0f;
            }
            timer += Time.deltaTime;
            progressBar.fillAmount = timer / tickTime;
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (shellManager.Shells >= 75)
        {
            shellManager.Shells -= 75;
            clickers++;
            autoclickerText.text = ("Buy Beach Comber (75 Shells)\nBeach Combers: " + clickers);
        }
    }
}
