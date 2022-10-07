using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public enum TileType {PATH, WALL}

public class Manager : MonoBehaviour
{

    public static Manager Instance { get; private set;}

    public Dictionary<Vector3Int, Tile> level = new Dictionary<Vector3Int, Tile>();

    public GameObject pathPrefab;
    public GameObject wallPrefab;

    [SerializeField]
    private string levelPath;

    private LevelGenerator generator = new LevelGenerator();

    private void Awake()
    {
        if(Instance != null && Instance != this) Destroy(this);
        else Instance = this;
    }

    private void Start()
    {
        level = generator.Generate(levelPath);
        Debug.Log(level.Count);
    }

    private void Update()
    {
        
    }

}
    private void GenerateLevel()
    {

        try
        {
            using(StreamReader sr = new StreamReader("Assets/Scripts/TestMap.tsv"))
            {
                string line;
                while((line = sr.ReadLine()) != null)
                {
                    Debug.Log(line);
                }
            }
        }
        catch(Exception e)
        {
            Debug.Log("The file could not be read: ");
            Debug.Log(e.Message);
        }

    }

}
