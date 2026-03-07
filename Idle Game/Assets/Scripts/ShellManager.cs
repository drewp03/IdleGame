using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShellManager : MonoBehaviour
{
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
    }
}
