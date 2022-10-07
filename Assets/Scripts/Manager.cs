using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Manager : MonoBehaviour
{

    public static Manager Instance { get; private set;}

    public Dictionary<Vector3Int, Tile> level = new Dictionary<Vector3Int, Tile>();

    public GameObject pathPrefab;
    public GameObject wallPrefab;

    [SerializeField]
    private string levelPath;

    [SerializeField]
    private Transform mainCamera;

    private LevelGenerator generator = new LevelGenerator();

    private void Awake()
    {
        if(Instance != null && Instance != this) Destroy(this);
        else Instance = this;
    }

    private void Start()
    {
        level = generator.Generate(levelPath);
        SetCameraPosition();
        Debug.Log(level.Count);
    }

    private void Update()
    {
        
    }

    private void SetCameraPosition()
    {
        mainCamera.position = new Vector3(generator.levelSize.y / 2, mainCamera.position.y, generator.levelSize.x / 2 + 1);
    }

}
