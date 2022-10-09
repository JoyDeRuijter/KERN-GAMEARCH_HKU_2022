using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuildingManager
{
    public List<Building> availableBuildings = new List<Building>();
    public Builder builder;
    public Building selectedBuilding;
    public ShopUIManager shopUIManager; 
    
    private List<Building> placedBuildings = new List<Building>();
    private List<GameObject> placedObjects = new List<GameObject>();

    public void OnAwake()
    {
        Initialize();
        shopUIManager.OnAwake();
    }

    public void OnStart(Vector2Int _levelSize) => builder.levelSize = _levelSize;

    public void OnUpdate()
    {
        shopUIManager.CheckShopButtons();
        builder.OnUpdate();
    }

    // Make sure that all the placed buildings are activated and therefore will attack in the attackphase
    public void BuildingsAttack(IEnemy _target)
    {
        foreach (Building building in placedBuildings)
        { 
            building.attackBehaviour.Activate(_target);
        }
    }

    // Add a building to the map
    public void AddBuilding(Building _building)
    { 
        placedBuildings.Add(_building);
        availableBuildings.Remove(_building);
        EventHandler.RaiseEvent(EventType.SHOP_CHANGED, 0);
    }

    // Delete a building from the map
    public void DeleteBuilding(Building _building)
    { 
        placedBuildings.Remove(_building);
        availableBuildings.Add(_building);
        EventHandler.RaiseEvent(EventType.SHOP_CHANGED, 0);
    }

    public Building GetSelectedBuilding() => selectedBuilding;

    public void AddPlacedObject(GameObject _newBuilding) => placedObjects.Add(_newBuilding);

    // Destroy all the gameobjects of the buildings on the map
    public void DestroyAllPlacedObjects()
    {
        foreach (GameObject buildingObject in placedObjects)
        { 
            GameObject.Destroy(buildingObject);
        }
    }

    public void OnDestroy()
    {
        DestroyAllPlacedObjects();
        shopUIManager.OnDestroy();
    }

    #region Initialization

    private void InitializeBuilder() => builder = new Builder(this);
    private void InitializeShopUIManager() => shopUIManager = new ShopUIManager(this);

    // Create all the different buildings here and add them to the available buildings list
    private void InitializeBuildings()
    {
        availableBuildings.Add(new Building("Test1", (Resources.Load("TestTower", typeof(GameObject)) as GameObject), (Resources.Load("Icon1", typeof(Texture)) as Texture), new PapierAttackBehaviour(), 500));
        availableBuildings.Add(new Building("Test2", (Resources.Load("TestTower2", typeof(GameObject)) as GameObject), (Resources.Load("Icon2", typeof(Texture)) as Texture), new SchaarAttackBehaviour(), 320));
        availableBuildings.Add(new Building("Test3", (Resources.Load("TestTower3", typeof(GameObject)) as GameObject), (Resources.Load("Icon3", typeof(Texture)) as Texture), new SteenAttackBehaviour(), 150));
        availableBuildings.Add(new Building("Test4", (Resources.Load("TestTower2", typeof(GameObject)) as GameObject), (Resources.Load("Icon2", typeof(Texture)) as Texture), new PapierAttackBehaviour(), 250));
        availableBuildings.Add(new Building("Test5", (Resources.Load("TestTower", typeof(GameObject)) as GameObject), (Resources.Load("Icon1", typeof(Texture)) as Texture), new SchaarAttackBehaviour(), 100));
        availableBuildings.Add(new Building("Test6", (Resources.Load("TestTower3", typeof(GameObject)) as GameObject), (Resources.Load("Icon3", typeof(Texture)) as Texture), new SteenAttackBehaviour(), 350));
        availableBuildings.Add(new Building("Test7", (Resources.Load("TestTower", typeof(GameObject)) as GameObject), (Resources.Load("Icon1", typeof(Texture)) as Texture), new PapierAttackBehaviour(), 475));
        availableBuildings.Add(new Building("Test8", (Resources.Load("TestTower2", typeof(GameObject)) as GameObject), (Resources.Load("Icon2", typeof(Texture)) as Texture), new SchaarAttackBehaviour(), 750));
        availableBuildings.Add(new Building("Test9", (Resources.Load("TestTower3", typeof(GameObject)) as GameObject), (Resources.Load("Icon3", typeof(Texture)) as Texture), new SteenAttackBehaviour(), 800));
        availableBuildings.Add(new Building("Test10", (Resources.Load("TestTower2", typeof(GameObject)) as GameObject), (Resources.Load("Icon2", typeof(Texture)) as Texture), new PapierAttackBehaviour(), 950));
        availableBuildings.Add(new Building("Test11", (Resources.Load("TestTower", typeof(GameObject)) as GameObject), (Resources.Load("Icon1", typeof(Texture)) as Texture), new SchaarAttackBehaviour(), 1000));
        availableBuildings.Add(new Building("Test12", (Resources.Load("TestTower3", typeof(GameObject)) as GameObject), (Resources.Load("Icon3", typeof(Texture)) as Texture), new SteenAttackBehaviour(), 1300));
    }

    private void Initialize()
    {
        InitializeBuilder();
        InitializeShopUIManager();
        InitializeBuildings();
    }

    #endregion
}
