using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour, IPointerClickHandler
{
    // Followed a tutorial for the inventory system and tweaked it to fit what i needed
    public InventoryItem item;
    //Make items stack if there's enough time. (Did not have enough time)
    public int amount;
    public Slot type;
    [SerializeField] private bool isShopInventory = false;


    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            if (!isShopInventory)
            {
                var playerInventory = GameManager.Instance.GetPlayerInventory();
                if (playerInventory.carriedItem == null) return;
                if (type != Slot.None && playerInventory.carriedItem.myItem.slot != type) return;
                SetItem(playerInventory.carriedItem);
            }
        }
    }

    public void SetItem(InventoryItem inventoryItem)
    {
        var inventory = GameManager.Instance.GetPlayerInventory();

        inventory.carriedItem = null;

        // Set current slot
        item = inventoryItem;
        item.activeSlot = this;
        item.transform.SetParent(transform);
        item.transform.position = transform.position;
        item.canvasGroup.blocksRaycasts = true;

        if (type != Slot.None)
        {
            GameManager.Instance.ChangeEquipment(type, inventoryItem.myItem);
        }
    }
}
