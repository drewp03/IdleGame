using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlusOneButton : MonoBehaviour, IPointerClickHandler
{
    public ShellManager shellManager;

    public void OnPointerClick(PointerEventData eventData)
    {
        shellManager.Shells += 1;
    }
}
