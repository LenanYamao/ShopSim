using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour, IInteractable
{
    // Base for an interactable object, can be expanded if needed
    public void Interact()
    {
        Debug.Log("Khajit has wares if you have coin.");
        GameManager.Instance.ToggleShop();
    }
}
