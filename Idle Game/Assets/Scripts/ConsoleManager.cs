using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime.Misc;

public class ConsoleManager : MonoBehaviour
{
    public TextMeshProUGUI log;

    public string startText;

    public static string toLog;

    void Start()
    {
        log.text = startText;
        toLog = "";
    }

    void Update()
    {
        if (toLog.Length > 0)
        {
            // Add new log at the TOP instead of bottom
            log.text = toLog + "\n" + log.text;

            toLog = "";
        }
    }
}
