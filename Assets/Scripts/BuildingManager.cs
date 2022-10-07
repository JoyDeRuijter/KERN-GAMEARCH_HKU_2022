using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuildingManager
{
    private List<Building> availableBuildings = new List<Building>(); // If a building from this list is build, remove it from the list and add it to placedBuildings
    private List<Building> placedBuildings = new List<Building>(); // If a building from this list is removed, add it back to the availableBuildings
    private Builder builder;

    //Shop UI
    private GameObject shopItemPrefab;
    private Transform shopItemParent;
    private GameObject[] currentShopItems;

    public void OnAwake()
    { 
        InitializeBuilder();
        InitializeBuildings();
        InitializeShopUI();
    }

    public void OnStart()
    { 
    
    }

    public void OnUpdate()
    {
        UpdateShopUI();
    }

    private void InitializeBuilder()
    {
        builder = new Builder(this);
    }

    // Create all the different buildings here and add them to the available buildings list
    private void InitializeBuildings()
    {
        availableBuildings.Add(new Building("Test1", (Resources.Load("TestTower", typeof(GameObject)) as GameObject), (Resources.Load("Icon1", typeof(Texture)) as Texture), new Vector2Int(2, 2), 500));
        availableBuildings.Add(new Building("Test2", (Resources.Load("TestTower2", typeof(GameObject)) as GameObject), (Resources.Load("Icon2", typeof(Texture)) as Texture), new Vector2Int(2, 3), 750));
        availableBuildings.Add(new Building("Test3", (Resources.Load("TestTower", typeof(GameObject)) as GameObject), (Resources.Load("Icon1", typeof(Texture)) as Texture), new Vector2Int(2, 2), 200));
        availableBuildings.Add(new Building("Test4", (Resources.Load("TestTower2", typeof(GameObject)) as GameObject), (Resources.Load("Icon2", typeof(Texture)) as Texture), new Vector2Int(2, 3), 250));
        availableBuildings.Add(new Building("Test5", (Resources.Load("TestTower", typeof(GameObject)) as GameObject), (Resources.Load("Icon1", typeof(Texture)) as Texture), new Vector2Int(2, 2), 100));
        availableBuildings.Add(new Building("Test6", (Resources.Load("TestTower2", typeof(GameObject)) as GameObject), (Resources.Load("Icon2", typeof(Texture)) as Texture), new Vector2Int(2, 3), 350));

        foreach (Building b in availableBuildings)
            Debug.Log($"Available building : {b.prefab.name} has size: {b.size.x},{b.size.y} and price: ${b.price}");
    }

    private void InitializeShopUI()
    {
        shopItemParent = GameObject.Find("ItemParent").transform;
        shopItemPrefab = Resources.Load("Item", typeof(GameObject)) as GameObject;

        for (int i = 0; i < availableBuildings.Count && i < 4; i++)
        {
            GameObject newShopItem = GameObject.Instantiate(shopItemPrefab, shopItemParent);
            newShopItem.transform.Find("Icon").GetComponent<RawImage>().texture = availableBuildings[i].buildingIcon;
            newShopItem.transform.Find("Name").GetComponent<TMP_Text>().text = availableBuildings[i].name;
            newShopItem.transform.Find("Price").GetComponent<TMP_Text>().text = $"€{availableBuildings[i].price},-";
        }
    }

    private void UpdateShopUI()
    { 
    
    }

    public void DeleteBuilding(Building _building)
    { 
        placedBuildings.Remove(_building);
    }

    public void AddBuilding(Building _building)
    { 
        placedBuildings.Add(_building);
    }
}
