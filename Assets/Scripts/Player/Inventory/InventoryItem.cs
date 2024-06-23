using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour, IPointerClickHandler
{
    public Image itemIcon;
    public Sprite emptyIcon;
    public CanvasGroup canvasGroup;
    public Clothes myItem { get; set; }
    public InventorySlot activeSlot { get; set; }

    public void Initialize(Clothes item, InventorySlot parent)
    {
        activeSlot = parent;
        activeSlot.item = this;
        myItem = item;
        itemIcon.sprite = item.itemIcon;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            if (myItem)
                GameManager.Instance.SetCarriedItem(this);
        }
    }
}
