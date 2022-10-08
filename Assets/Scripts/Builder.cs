using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.ObjectChangeEventStream;

public class Builder 
{
    private BuildingManager buildingManager;
    private InputHandler inputHandler;
    private Building selectedBuilding;
    private Manager manager = Manager.Instance;
    public bool isBuilding;
    private Vector3 mousePosition;

    //Selection process
    private GameObject selectionBlock;
    private Material validMat, invalidMat;
    private GameObject block;
    public Vector2Int levelSize;

    public Builder (BuildingManager _buildingManager)
    {
        buildingManager = _buildingManager;
        selectionBlock = Resources.Load("BuildingPlacementBlock", typeof(GameObject)) as GameObject;
        validMat = Resources.Load("BuildingPlacementGood", typeof(Material)) as Material;
        invalidMat = Resources.Load("BuildingPlacementBad", typeof(Material)) as Material;
    }

    public void BuildBuilding()
    {
        selectedBuilding = buildingManager.GetSelectedBuilding();
        if (selectedBuilding != null && selectedBuilding.price <= manager.amountOfCoins)
        {
            isBuilding = true;
            // Start placement selection, should show the player if a location is valid or not
            PlacementSelectionBlocks();
            // If the player clicks on an invalid location -> give feedback and let them try again
            // If the player clicks on a valid location -> start building
            // When building is started, pay the building price from the amountOfCoins
            // Instantiate the building on the chosen position.
            // Delete the building from the available buildings and update the shop
            // Add the building to built buildings
        }
        else
            Debug.Log("CAN'T BUILD! - No building is selected, or the price is higher than the amount of coins!");

        //isBuilding = false;
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

    public void OnUpdate()
    {
        if (isBuilding)
        { 
            GetMousePosition();
            MovePlacementSelectionBlocks(block);
        }
    }

    public Vector3 GetMousePosition()
    {
        mousePosition = manager.mainCamera.gameObject.GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition);
        return mousePosition;
    }

    private void PlacementSelectionBlocks()
    {
        block = GameObject.Instantiate(selectionBlock);
        block.transform.position = new Vector3Int((int)mousePosition.x, 0, (int)mousePosition.z);
    }

    private void MovePlacementSelectionBlocks(GameObject _block)
    {
        if ((int)mousePosition.x < levelSize.y && (int)mousePosition.x >= 0 && (int)mousePosition.z < levelSize.x && (int)mousePosition.z >= 0)
        {
            Vector3Int newPosition = new Vector3Int((int)mousePosition.x, 0, (int)mousePosition.z);
            _block.transform.position = newPosition;
            if (manager.level[newPosition].isOccupied)
                _block.GetComponentInChildren<MeshRenderer>().material = invalidMat;
            else
                _block.GetComponentInChildren<MeshRenderer>().material = validMat;
        }
    }
}
