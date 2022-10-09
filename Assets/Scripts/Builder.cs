using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Builder 
{
    public bool isBuilding;
    public int latestPaidPrice;
    public GameObject latestInstantiatedBuilding;
    public Building latestBuiltBuilding;
    public Vector2Int levelSize;

    private BuildingManager buildingManager;
    private Building selectedBuilding;
    private Manager manager = Manager.Instance;
    private Vector3 mousePosition;
    private GameObject selectionBlock;
    private Material validMat, invalidMat;
    private GameObject block;

    public Builder (BuildingManager _buildingManager)
    {
        buildingManager = _buildingManager;
        selectionBlock = Resources.Load("BuildingPlacementBlock", typeof(GameObject)) as GameObject;
        validMat = Resources.Load("BuildingPlacementGood", typeof(Material)) as Material;
        invalidMat = Resources.Load("BuildingPlacementBad", typeof(Material)) as Material;
    }

    public void OnUpdate()
    {
        if (isBuilding && block != null)
        { 
            GetMousePosition();
            MovePlacementSelectionBlocks(block);

            if (Input.GetMouseButtonDown(0))
            { 
                OnPlacementConfirmed();
            }
        }
    }

    // Starts the building process of a building
    public void BuildBuilding()
    {
        if (isBuilding)
        { 
            return;
        }

        selectedBuilding = buildingManager.GetSelectedBuilding();
        if (selectedBuilding != null && selectedBuilding.price <= manager.amountOfCoins)
        {
            isBuilding = true;
            PlacementSelectionBlocks();
        }
        else
        { 
            Debug.Log("CAN'T BUILD! - No building is selected, or the price is higher than the amount of coins!");
        }
    }

    public Vector3 GetMousePosition()
    {
        mousePosition = manager.mainCamera.gameObject.GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition);
        return mousePosition;
    }

    // Instantiates a selectionblock that serves as a visualaid for the player, to see what tile they are currently selecting while hovering
    private void PlacementSelectionBlocks()
    {
        if (block == null)
        { 
            block = GameObject.Instantiate(selectionBlock);
            block.transform.position = new Vector3Int((int)mousePosition.x, 0, (int)mousePosition.z);
        }
    }

    // Runs when the player has started building and clicked on a location on the map
    // Checks if the clicked-position is valid and if so, builds the building
    private void OnPlacementConfirmed()
    {
        Vector3Int selectedPosition = new Vector3Int((int)block.transform.position.x, 0, (int)block.transform.position.z);
        if (manager.level[selectedPosition].isOccupied)
        { 
            Debug.Log("This is not a valid place to build a building!");
            GameObject.Destroy(block);
            selectedBuilding = null;
        }
        else
        {
            AddBuilding();
            manager.level[selectedPosition].isOccupied = true;
            GameObject newBuilding = GameObject.Instantiate(selectedBuilding.prefab);
            newBuilding.transform.position = new Vector3(selectedPosition.x, -0.5f, selectedPosition.z);
            buildingManager.AddPlacedObject(newBuilding);
            latestInstantiatedBuilding = newBuilding;
            latestBuiltBuilding = selectedBuilding;
            latestPaidPrice = selectedBuilding.price;
            selectedBuilding.attackBehaviour.towerTransform = newBuilding.transform;
            EventHandler.RaiseEvent(EventType.COINS_CHANGED, manager.amountOfCoins -= selectedBuilding.price);
            GameObject.Destroy(block);
            selectedBuilding = null;
        }
        isBuilding = false;
    }

    // Makes sure the current selection block moves with the position of the mousepointer
    // Also changes it's material (red or green) to indicate the validity of the selected tile position
    private void MovePlacementSelectionBlocks(GameObject _block)
    {
        if ((int)mousePosition.x < levelSize.y && (int)mousePosition.x >= 0 && (int)mousePosition.z < levelSize.x && (int)mousePosition.z >= 0)
        {
            Vector3Int newPosition = new Vector3Int((int)mousePosition.x, 0, (int)mousePosition.z);
            _block.transform.position = newPosition;
            if (manager.level[newPosition].isOccupied)
            {
                _block.GetComponentInChildren<MeshRenderer>().material = invalidMat;
            }
            else
            { 
                _block.GetComponentInChildren<MeshRenderer>().material = validMat;
            }
        }
    }

    private void AddBuilding()
    {
        buildingManager.AddBuilding(selectedBuilding);
    }
}
