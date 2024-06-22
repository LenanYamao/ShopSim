using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private UIManager _uiManager;
    public event Action<bool> movementChanged;
    private bool canMove;

    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            return _instance;
        }
    }
    private void Awake()
    {
        _instance = this;
        canMove = true;
    }

    public void ToggleInventory()
    {
        canMove = !_uiManager.ToggleInventory();
        movementChanged?.Invoke(canMove);
    }
    public void ToggleShop()
    {
        canMove = !_uiManager.ToggleShop();
        movementChanged?.Invoke(canMove);
    }
}
