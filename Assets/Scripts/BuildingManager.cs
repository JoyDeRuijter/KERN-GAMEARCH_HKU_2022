using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingManager
{
    private List<Building> placedBuildings;
    private Builder builder;

    public void OnAwake()
    { 
        
    }

    public void OnStart()
    { 
    
    }

    public void OnUpdate()
    { 
    
    }

    private void InitializeBuilder()
    {
        builder = new Builder(this);
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
