using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    bool a = true;
    bool b = false;
    
    // Start is called before the first frame update
    void Start()
    {
        a |= b;
        Debug.Log(a);
    }
}
