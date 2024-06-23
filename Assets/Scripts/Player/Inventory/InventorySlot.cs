using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour, IPointerClickHandler
{
    public InventoryItem item;
    public Slot type;


    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            var playerInventory = GameManager.Instance.GetPlayerInventory();
            if (playerInventory.carriedItem == null) return;
            if (type != Slot.None && playerInventory.carriedItem.myItem.slot != type) return;
            SetItem(playerInventory.carriedItem);
        }
    }

    public void SetItem(InventoryItem inventoryItem)
    {
        var inventory = GameManager.Instance.GetPlayerInventory();

        inventory.carriedItem = null;

        inventoryItem.activeSlot.item = null;

        // Set current slot
        item = inventoryItem;
        item.activeSlot = this;
        item.transform.SetParent(transform);
        item.canvasGroup.blocksRaycasts = true;

        if (type != Slot.None)
        {
            GameManager.Instance.ChangeEquipment(type, inventoryItem.myItem);
        }
    }
}
