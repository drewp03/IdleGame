using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlusOneButton : MonoBehaviour
{
    public ShellManager shellManager;

    public void AddShell()
    {
        shellManager.Shells += 1;
    }
}
