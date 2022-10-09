using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuildingManager
{
    public List<Building> availableBuildings = new List<Building>(); // If a building from this list is build, remove it from the list and add it to placedBuildings
    public Builder builder;
    public Building selectedBuilding;
    public ShopUIManager shopUIManager; 
    
    private List<Building> placedBuildings = new List<Building>(); // If a building from this list is removed, add it back to the availableBuildings
    private List<GameObject> placedObjects = new List<GameObject>();

    #region Initialization

    private void InitializeBuilder() => builder = new Builder(this);
    private void InitializeShopUIManager() => shopUIManager = new ShopUIManager(this);

    // Create all the different buildings here and add them to the available buildings list
    private void InitializeBuildings()
    {
        availableBuildings.Add(new Building("Test1", (Resources.Load("TestTower", typeof(GameObject)) as GameObject), (Resources.Load("Icon1", typeof(Texture)) as Texture), new PapierAttackBehaviour(), 500));
        availableBuildings.Add(new Building("Test2", (Resources.Load("TestTower2", typeof(GameObject)) as GameObject), (Resources.Load("Icon2", typeof(Texture)) as Texture), new SchaarAttackBehaviour(), 750));
        availableBuildings.Add(new Building("Test3", (Resources.Load("TestTower3", typeof(GameObject)) as GameObject), (Resources.Load("Icon3", typeof(Texture)) as Texture), new SteenAttackBehaviour(), 200));
        availableBuildings.Add(new Building("Test4", (Resources.Load("TestTower2", typeof(GameObject)) as GameObject), (Resources.Load("Icon2", typeof(Texture)) as Texture), new PapierAttackBehaviour(), 250));
        availableBuildings.Add(new Building("Test5", (Resources.Load("TestTower", typeof(GameObject)) as GameObject), (Resources.Load("Icon1", typeof(Texture)) as Texture), new SchaarAttackBehaviour(), 100));
        availableBuildings.Add(new Building("Test6", (Resources.Load("TestTower3", typeof(GameObject)) as GameObject), (Resources.Load("Icon3", typeof(Texture)) as Texture), new SteenAttackBehaviour(), 350));
    }

    private void Initialize()
    {
        InitializeBuilder();
        InitializeShopUIManager();
        InitializeBuildings();
    }

    #endregion

    public void OnAwake()
    {
        Initialize();
    }

    public void OnStart(Vector2Int _levelSize) => builder.levelSize = _levelSize;

    public void OnUpdate()
    {
        shopUIManager.CheckShopButtons();
        builder.OnUpdate();
    }

    public void BuildingsAttack(IEnemy _target)
    {
        foreach (Building building in placedBuildings)
        { 
            building.attackBehaviour.Activate(_target);
        }
    }

    public Building GetSelectedBuilding() => selectedBuilding;

    public void AddBuilding(Building _building)
    { 
        placedBuildings.Add(_building);
        availableBuildings.Remove(_building);
        shopUIManager.UpdateShopUI();
    }

    public void DeleteBuilding(Building _building)
    { 
        placedBuildings.Remove(_building);
        availableBuildings.Add(_building);
        shopUIManager.UpdateShopUI();
    }

    public void AddPlacedObject(GameObject _newBuilding)
    { 
        placedObjects.Add(_newBuilding);
    }

    public void DestroyAllPlacedObjects()
    {
        foreach (GameObject buildingObject in placedObjects)
        { 
            GameObject.Destroy(buildingObject);
        }
    }
}
