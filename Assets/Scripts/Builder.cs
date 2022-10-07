using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Builder 
{
    private BuildingManager buildingManager;
    private InputHandler inputHandler;
    private Building selectedBuilding;

    public Builder (BuildingManager _buildingManager)
    {
        buildingManager = _buildingManager;
    }

    public void BuildBuilding()
    {
        selectedBuilding = buildingManager.GetSelectedBuilding();
        //Don't forget NULL check
        //buy and build selectedBuilding
        Debug.Log($"Build {selectedBuilding.name} for €{selectedBuilding.price},-");
    }

    public void UpgradeBuilding()
    {
        selectedBuilding = buildingManager.GetSelectedBuilding();
        //Don't forget NULL check
        //upgrade selectedBuilding
        Debug.Log($"Upgrade {selectedBuilding.name} to level {selectedBuilding.level + 1}");
    }

    public void DestroyBuilding()
    {
        selectedBuilding = buildingManager.GetSelectedBuilding();
        //Don't forget NULL check
        //destroy selectedBuilding
        Debug.Log($"Destroy {selectedBuilding.name}");
    }
}
