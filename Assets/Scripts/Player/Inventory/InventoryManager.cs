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

    private void Update()
    {
        if (!carriedItem) return;

        carriedItem.transform.position = Input.mousePosition;
    }

    public void SetCarriedItem(InventoryItem item)
    {
        if (item.activeSlot.type != Slot.None)
        {
            print("Teste");
            GameManager.Instance.ChangeEquipment(item.activeSlot.type);
        }

        if (carriedItem != null)
        {
            if (item.activeSlot.type != Slot.None && item.activeSlot.type != carriedItem.myItem.slot) return;
            item.activeSlot.SetItem(carriedItem);
        }

        carriedItem = item;
        carriedItem.canvasGroup.blocksRaycasts = false;
        item.transform.SetParent(draggablesTransform);
    }

}
