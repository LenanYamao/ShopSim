using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    // Manage shop items
    // To-Do: Add currency to buy items if there's time left
    // To-Do: Fix scroll starting in the middle instead of the top and not reseting
    [SerializeField] private List<Clothes> items;
    [SerializeField] private ShopInventory shopInventory;
    [SerializeField] private GameObject itemToBuyPrefab;

    private void Awake()
    {
        foreach (var item in items)
        {
            var itemInstance = Instantiate(itemToBuyPrefab);
            itemInstance.transform.SetParent(gameObject.transform);
            var shopItem = itemInstance.GetComponent<ShopItem>();
            if (shopItem)
            {
                shopItem.SetClothe(item);
            }
        }
    }
    private void OnEnable()
    {
        if (GameManager.Instance)
            GameManager.Instance.shopOpen += onShopOpen;
    }
    private void OnDisable()
    {
        GameManager.Instance.shopOpen -= onShopOpen;
    }

    private void onShopOpen()
    {
        shopInventory.InitializeInventory();
        return;
    }
}
