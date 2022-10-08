using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building
{
    public string name;
    public int level = 1;
    public int price;
    public GameObject prefab;
    public Vector2Int size;
    public Texture buildingIcon;

    // IAttackBehavior

    public Building(string _name, GameObject _prefab, Texture _buildingIcon, Vector2Int _size, int _price)
    { 
        name = _name;
        prefab = _prefab;
        buildingIcon = _buildingIcon;
        size = _size;
        price = _price;
    }

    public void Attack()
    { 
    
    }

    public void GetDestroyed()
    { 
    
    }
}
