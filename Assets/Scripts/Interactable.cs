using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public virtual void Interact() { return; }

    protected virtual string GetInteractMessage()
    {
        return "Press E";
    }

    public virtual void DisplayMessage(bool status)
    {
        return;
    }
    
}
