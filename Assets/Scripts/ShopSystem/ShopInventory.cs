using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopInventory : MonoBehaviour
{
    public List<InventorySlot> inventory = new List<InventorySlot>();

    public List<InventoryItem> items = new List<InventoryItem>();

    public void InitializeInventory()
    {
        foreach (var item in items)
        {
            Destroy(item.gameObject);
        }
        items = new List<InventoryItem>();

        var playerInventory = GameManager.Instance.GetPlayerInventory();
        for (int i = 0; i < playerInventory.inventory.Count; i++)
        {
            if (playerInventory.inventory[i].item != null)
            {
                var item = Instantiate(GameManager.Instance.itemPrefab, inventory[i].transform);
                item.Initialize(playerInventory.inventory[i].item.myItem, inventory[i], true);

                items.Add(item);
            }
        }
    }

    public void AddItemToInventory(Clothes clothe)
    {
        var playerInventory = GameManager.Instance.GetPlayerInventory();
        for (int i = 0; i < playerInventory.inventory.Count; i++)
        {
            if (playerInventory.inventory[i].item == null)
            {
                var item = Instantiate(GameManager.Instance.itemPrefab, inventory[i].transform);
                item.Initialize(clothe, inventory[i], true);

                items.Add(item);
            }
        }
    }
}
