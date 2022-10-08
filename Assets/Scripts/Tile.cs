using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public enum TileType {PATH, WALL}

public class Tile 
{

    public Vector3Int position;
    public TileType type;
    public bool isOccupied = false;

    public Tile(Vector3Int _pos,TileType _type)
    {
        position = _pos;
        type = _type;
    }

    public void Initialize()
    {
        if(type == TileType.PATH)
        {
            GameObject.Instantiate(Manager.Instance.pathPrefab,position,Quaternion.identity);
            //isOccupied = true;
        }
        else if(type == TileType.WALL)
        {
            GameObject.Instantiate(Manager.Instance.wallPrefab,position,Quaternion.identity);
        }
    }

    private void OnStart()
    {
        
    }
    private void OnUpdate()
    {

    }

}