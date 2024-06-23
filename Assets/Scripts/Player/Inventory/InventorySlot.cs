using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour, IPointerClickHandler
{
    // Followed a tutorial for the inventory system and tweaked it to fit what i needed
    public InventoryItem item;
    public Slot type;
    [SerializeField] private bool isShopInventory = false;


    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            if (!isShopInventory)
            {
                Debug.Log("Teste1");
                var playerInventory = GameManager.Instance.GetPlayerInventory();
                if (playerInventory.carriedItem == null) return;
                if (type != Slot.None && playerInventory.carriedItem.myItem.slot != type) return;
                SetItem(playerInventory.carriedItem);
            }
        }
    }

    public void SetItem(InventoryItem inventoryItem)
    {
        Debug.Log(inventoryItem);
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
