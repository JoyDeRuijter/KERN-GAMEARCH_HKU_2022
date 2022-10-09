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
    private Vector3Int position;
    public BaseAttackBehaviour attackBehaviour;

    public Building(string _name, GameObject _prefab, Texture _buildingIcon, BaseAttackBehaviour _attackBehaviour, int _price)
    { 
        name = _name;
        prefab = _prefab;
        buildingIcon = _buildingIcon;
        attackBehaviour = _attackBehaviour;
        price = _price;
    }

    public void SetPosition(Vector3Int _position){ position = _position;}
    public Vector3Int GetPosition(){ return position;}
}
