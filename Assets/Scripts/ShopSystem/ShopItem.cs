using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShopItem : MonoBehaviour, IPointerDownHandler, IPointerExitHandler, IPointerEnterHandler
{
    [SerializeField] private GameObject focus;
    [SerializeField] private TextMeshProUGUI itemName;
    [SerializeField] private TextMeshProUGUI itemPrice;
    [SerializeField] private Image itemIcon;
    private Clothes _clothe;
    // Handle shop item mouse events
    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            GameManager.Instance.AddItemToInventory(_clothe);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        focus.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        focus.SetActive(false);
    }

    public void SetClothe(Clothes clothe)
    {
        _clothe = clothe;
        itemName.text = _clothe.clotheName;
        itemPrice.text = _clothe.clothePrice.ToString();
        itemIcon.sprite = _clothe.itemIcon;
    }
}
