using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject shopUI;
    [SerializeField] private GameObject inventoryUI;

    private void Awake()
    {
        inventoryUI.SetActive(false);
        shopUI.SetActive(false);
    }

    public bool ToggleShop()
    {
        if (shopUI.activeSelf)
        {
            shopUI.SetActive(false);
            return false;
        }
        else
        {
            shopUI.SetActive(true);
            return true;
        }
    }
    public bool ToggleInventory()
    {
        if (inventoryUI.activeSelf)
        {
            inventoryUI.SetActive(false);
            return false;
        }
        else
        {
            inventoryUI.SetActive(true);
            return true;
        }
    }
}
