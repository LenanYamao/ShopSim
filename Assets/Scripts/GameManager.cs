using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private UIManager _uiManager;
    [SerializeField] private InventoryManager _inventory;
    [SerializeField] InventoryItem itemPrefab;
    private GameObject _player;
    public event Action<bool> movementChanged;
    public event Action shopOpen;
    private bool canMove;

    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            return _instance;
        }
    }
    public void SetPlayer(GameObject player)
    {
        _player = player;
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
        shopOpen?.Invoke();
    }
    public void ChangeEquipment(Slot slot, Clothes clothe = null)
    {
        if (!_player) return;
        var playerVisual = _player.GetComponentInChildren<PlayerAnimation>();
        if (playerVisual)
        {
            playerVisual.ChangeVisual(slot, clothe);
        }
    }
    public void SetCarriedItem(InventoryItem item)
    {
        if (!_inventory) return;
        _inventory.SetCarriedItem(item);
    }
    public InventoryManager GetPlayerInventory()
    {
        if (!_player) return null;
        return _inventory;
    }
    public void AddItemToInventory(Clothes clothe)
    {
        for (int i = 0; i < _inventory.inventory.Count; i++)
        {
            // Check if the slot is empty
            if (_inventory.inventory[i].item == null)
            {
                Instantiate(itemPrefab, _inventory.inventory[i].transform).Initialize(clothe, _inventory.inventory[i]);
                break;
            }
        }
    }
}
