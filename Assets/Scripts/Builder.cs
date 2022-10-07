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
        //buy and build selectedBuilding
    }

    public void UpgradeBuilding()
    { 
        //upgrade selectedBuilding
    }

    public void DestroyBuilding()
    { 
        //destroy selectedBuilding
    }
}
