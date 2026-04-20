using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ConsoleManager : MonoBehaviour
{
    public TextMeshProUGUI log;
    public string startText;

    public static string toLog;

    [SerializeField] private int maxLines = 20;

    void Start()
    {
        log.text = startText;
        toLog = "";
    }

    void Update()
    {
        if (toLog.Length > 0)
        {
            log.text = toLog + "\n" + log.text;

            List<string> lines = new List<string>(log.text.Split('\n'));

            if (lines.Count > maxLines)
            {
                lines.RemoveRange(maxLines, lines.Count - maxLines);
            }

            log.text = string.Join("\n", lines);

            toLog = "";
        }
    }
}