using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    //Manage shop items
    [SerializeField] private List<Clothes> items;
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
                shopItem.setClothe(item);
            }
        }
    }
    private void Start()
    {
        GameManager.Instance.shopOpen += onShopOpen;
    }
    private void OnDisable()
    {
        GameManager.Instance.shopOpen -= onShopOpen;
    }

    private void onShopOpen()
    {

        return;
    }
}
