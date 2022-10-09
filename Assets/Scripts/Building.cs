using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building
{
    public string name;
    public int price;
    public GameObject prefab;
    public Texture buildingIcon;
    public BaseAttackBehaviour attackBehaviour;

    public Building(string _name, GameObject _prefab, Texture _buildingIcon, BaseAttackBehaviour _attackBehaviour, int _price)
    { 
        name = _name;
        prefab = _prefab;
        buildingIcon = _buildingIcon;
        attackBehaviour = _attackBehaviour;
        price = _price;
    }
}
