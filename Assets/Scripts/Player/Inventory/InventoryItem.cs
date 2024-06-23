using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour, IPointerClickHandler
{
    // Followed a tutorial for the inventory system and tweaked it to fit what i needed
    public Image itemIcon;
    public Sprite emptyIcon;
    public CanvasGroup canvasGroup;
    public Clothes myItem { get; set; }
    public InventorySlot activeSlot { get; set; }
    [SerializeField] private bool isShopInventory = false;

    void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        itemIcon = GetComponent<Image>();
    }

    public void Initialize(Clothes item, InventorySlot parent, bool isShop = false)
    {
        activeSlot = parent;
        activeSlot.item = this;
        myItem = item;
        itemIcon.sprite = item.itemIcon;
        isShopInventory = isShop;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            if (myItem)
            {
                if (!isShopInventory)
                {
                    activeSlot.item = null;
                    GameManager.Instance.SetCarriedItem(this);
                }
                else
                {
                    GameManager.Instance.RemoveItemFromInventory(this);
                }
            }
        }
    }
}
