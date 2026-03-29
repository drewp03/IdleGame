using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Trading : MonoBehaviour
{
    public ResourceManager resourceManager;

    [Header("Row 1- Shells/Knives")]
    public Button shellsForKnivesButton;
    public Button knivesForShellsButton;
    public int knivesValueInShells = 100;

    // Start is called before the first frame update
    void Start()
    {
        shellsForKnivesButton.onClick.AddListener(ShellsForKnives);
        knivesForShellsButton.onClick.AddListener(KnivesForShells);
    }

    void ShellsForKnives()
    {
        if (resourceManager.Shells >= knivesValueInShells)
        {
            resourceManager.Shells -= knivesValueInShells;
            resourceManager.Knives++;
        }
    }

    void KnivesForShells()
    {
        if (resourceManager.Knives > 0)
        {
            resourceManager.Shells += knivesValueInShells;
            resourceManager.Knives--;
        }
    }
}
