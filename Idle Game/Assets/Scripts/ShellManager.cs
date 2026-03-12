using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShellManager : MonoBehaviour
{
    public GameObject Autoclicker;
    public GameObject BeachComber;

    public TextMeshProUGUI shellText;
    private double shells;

    public double Shells
    {
        get
        {
            return shells;
        }
        set
        {
            shells = value;
            shellText.text = ("Shells: " + shells);
        }
    }

    void Start()
    {
        shellText.text = ("Shells: " + shells);

        Autoclicker.SetActive(false);
        BeachComber.SetActive(false);
    }

    void Update()
    {
        if(shells >= 15)
            Autoclicker.SetActive(true);

        if(shells >= 75)
            BeachComber.SetActive(true);
    }
}
