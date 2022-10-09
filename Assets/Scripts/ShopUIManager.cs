using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopUIManager
{
    private GameObject shopItemPrefab;
    private Transform shopItemParent;
    private List<GameObject> currentShopItems = new List<GameObject>();
    private List<Button> currentShopItemButtons = new List<Button>();
    private BuildingManager buildingManager;

    public ShopUIManager(BuildingManager _buildingManager)
    {
        buildingManager = _buildingManager;
    }

    public void InitializeShopUI()
    {
        shopItemParent = GameObject.Find("ItemParent").transform;
        shopItemPrefab = Resources.Load("Item", typeof(GameObject)) as GameObject;

        UpdateShopUI();
    }

    public void UpdateShopUI()
    {
        foreach (GameObject shopItem in currentShopItems)
        {
            GameObject.Destroy(shopItem);
        }

        for (int i = 0; i < buildingManager.availableBuildings.Count && i < 4; i++)
        {
            GameObject newShopItem = GameObject.Instantiate(shopItemPrefab, shopItemParent);
            newShopItem.transform.Find("Icon").GetComponent<RawImage>().texture = buildingManager.availableBuildings[i].buildingIcon;
            newShopItem.transform.Find("Name").GetComponent<TMP_Text>().text = buildingManager.availableBuildings[i].name;
            newShopItem.transform.Find("Price").GetComponent<TMP_Text>().text = $"€{buildingManager.availableBuildings[i].price},-";
            currentShopItems.Add(newShopItem);
            currentShopItemButtons.Add(newShopItem.transform.Find("Button").GetComponent<Button>());
        }
    }

    public void CheckShopButtons()
    {
        foreach (Button button in currentShopItemButtons)
        {
            button.onClick.AddListener(delegate { OnShopSelection(button.transform.parent.Find("Name").GetComponent<TMP_Text>().text); });
        }
    }

    private void OnShopSelection(string _buttonName)
    {
        buildingManager.selectedBuilding = buildingManager.availableBuildings.Find(x => x.name == _buttonName);
    }
}
