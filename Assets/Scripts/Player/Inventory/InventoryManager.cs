using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    // Manages player inventory and equipment
    public InventoryItem carriedItem;
    public List<InventorySlot> inventory = new List<InventorySlot>();
    public List<InventorySlot> equipmentSlots = new List<InventorySlot>();
    [SerializeField] private Transform draggablesTransform;

    private int maxInventorySize = 30;

    private void Update()
    {
        if (!carriedItem) return;

        carriedItem.transform.position = Input.mousePosition;
    }

    public void SetCarriedItem(InventoryItem item)
    {
        if (carriedItem != null)
        {
            if (item.activeSlot.type != Slot.None && item.activeSlot.type != carriedItem.myItem.slot) return;
            item.activeSlot.SetItem(carriedItem);
        }

        if (item.activeSlot.type != Slot.None)
        {
            GameManager.Instance.ChangeEquipment(item.activeSlot.type);
        }

        carriedItem = item;
        carriedItem.canvasGroup.blocksRaycasts = false;
        item.transform.SetParent(draggablesTransform);
    }

    public void AddItemToInventory(InventorySlot item)
    {
        if (inventory.Count < maxInventorySize)
        {
            inventory.Add(item);
        }
        else
        {
            Debug.Log("Inventory full");
        }
    }
}
