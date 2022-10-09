using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuildingManager
{
    private List<Building> availableBuildings = new List<Building>(); // If a building from this list is build, remove it from the list and add it to placedBuildings
    private List<Building> placedBuildings = new List<Building>(); // If a building from this list is removed, add it back to the availableBuildings
    public Builder builder;

    private Building selectedBuilding;

    //Shop UI
    private GameObject shopItemPrefab;
    private Transform shopItemParent;
    private List<GameObject> currentShopItems = new List<GameObject>();
    private List<Button> currentShopItemButtons = new List<Button>();

    public void OnAwake()
    {
        InitializeBuilder();
        InitializeBuildings();
    }

    public void OnStart(Vector2Int _levelSize)
    {
        builder.levelSize = _levelSize;
    }

    public void OnUpdate()
    {
        //UpdateShopUI();
        CheckShopButtons();
        builder.OnUpdate();
    }

    #region Initialization
    private void InitializeBuilder()
    {
        builder = new Builder(this);
    }

    // Create all the different buildings here and add them to the available buildings list
    private void InitializeBuildings()
    {
        availableBuildings.Add(new Building("Test1", (Resources.Load("TestTower", typeof(GameObject)) as GameObject), (Resources.Load("Icon1", typeof(Texture)) as Texture), 500));
        availableBuildings.Add(new Building("Test2", (Resources.Load("TestTower2", typeof(GameObject)) as GameObject), (Resources.Load("Icon2", typeof(Texture)) as Texture), 750));
        availableBuildings.Add(new Building("Test3", (Resources.Load("TestTower", typeof(GameObject)) as GameObject), (Resources.Load("Icon1", typeof(Texture)) as Texture), 200));
        availableBuildings.Add(new Building("Test4", (Resources.Load("TestTower2", typeof(GameObject)) as GameObject), (Resources.Load("Icon2", typeof(Texture)) as Texture), 250));
        availableBuildings.Add(new Building("Test5", (Resources.Load("TestTower", typeof(GameObject)) as GameObject), (Resources.Load("Icon1", typeof(Texture)) as Texture), 100));
        availableBuildings.Add(new Building("Test6", (Resources.Load("TestTower2", typeof(GameObject)) as GameObject), (Resources.Load("Icon2", typeof(Texture)) as Texture), 350));

        //foreach (Building b in availableBuildings)
        //    Debug.Log($"Available building : {b.prefab.name} has size: {b.size.x},{b.size.y} and price: ${b.price}");
    }
    #endregion

    #region ShopUI

    public void InitializeShopUI()
    {
        shopItemParent = GameObject.Find("ItemParent").transform;
        shopItemPrefab = Resources.Load("Item", typeof(GameObject)) as GameObject;

        UpdateShopUI();
    }

    private void UpdateShopUI()
    {
        foreach (GameObject shopItem in currentShopItems)
            GameObject.Destroy(shopItem);

        for (int i = 0; i < availableBuildings.Count && i < 4; i++)
        {
            GameObject newShopItem = GameObject.Instantiate(shopItemPrefab, shopItemParent);
            newShopItem.transform.Find("Icon").GetComponent<RawImage>().texture = availableBuildings[i].buildingIcon;
            newShopItem.transform.Find("Name").GetComponent<TMP_Text>().text = availableBuildings[i].name;
            newShopItem.transform.Find("Price").GetComponent<TMP_Text>().text = $"€{availableBuildings[i].price},-";
            currentShopItems.Add(newShopItem);
            currentShopItemButtons.Add(newShopItem.transform.Find("Button").GetComponent<Button>());
        }
    }

    private void CheckShopButtons()
    {
        foreach (Button button in currentShopItemButtons)
        {
            button.onClick.AddListener(delegate { OnShopSelection(button.transform.parent.Find("Name").GetComponent<TMP_Text>().text); });
        }
    }

    private void OnShopSelection(string _buttonName)
    { 
        selectedBuilding = availableBuildings.Find(x => x.name == _buttonName);
    }

    #endregion

    public Building GetSelectedBuilding()
    {
        return selectedBuilding;
    }

    public void DeleteBuilding(Building _building)
    { 
        placedBuildings.Remove(_building);
        availableBuildings.Add(_building);
    }

    public void AddBuilding(Building _building)
    { 
        placedBuildings.Add(_building);
        availableBuildings.Remove(_building);
        UpdateShopUI();
    }
}
