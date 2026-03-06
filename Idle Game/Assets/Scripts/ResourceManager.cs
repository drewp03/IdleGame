using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    // Resource dictionary
    Dictionary<string, double> clickResources = new Dictionary<string, double>()
    {
        {"Cowrie shells", 0 },
        {"Knives", 0 },
        {"Rai stones", 0 }
    };

    // Upgrade list
    List<Upgrade> upgrades = new List<Upgrade>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
