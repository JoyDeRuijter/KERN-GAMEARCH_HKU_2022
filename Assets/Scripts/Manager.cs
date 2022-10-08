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
    public GameObject enemyPrefab;

    private EnemyController enemy = new EnemyController(new Vector3Int(2,0,0),new Vector3Int(9,0,6),3);

    [SerializeField] private string levelPath;

    public Transform mainCamera;

    //Customizable keybindings
    [SerializeField] private KeyCode buildKey = KeyCode.B;
    [SerializeField] private KeyCode upgradeKey = KeyCode.U;
    [SerializeField] private KeyCode destroyKey = KeyCode.D;
    [SerializeField] private KeyCode undoKey = KeyCode.Tab;

    //Dependencies
    private LevelGenerator generator = new LevelGenerator();
    private BuildingManager buildingManager = new BuildingManager();
    private InputHandler inputHandler = new InputHandler();
    private KeyBinder keyBinder;

    //Temporary? Money stat
    public int amountOfCoins = 500;

    private void Awake()
    {
        if(Instance != null && Instance != this) Destroy(this);
        else Instance = this;

        buildingManager.OnAwake();
        keyBinder = new KeyBinder(buildingManager, inputHandler, buildKey, upgradeKey, destroyKey, undoKey);
    }

    private void Start()
    {
        level = generator.Generate(levelPath);
        SetCameraPosition();
        Debug.Log(level.Count);

        buildingManager.OnStart(generator.levelSize);
        enemy.OnStart();
    }

    private void Update()
    {

        enemy.OnUpdate();
        buildingManager.OnUpdate();
        inputHandler.HandleInput();
    }

    private void SetCameraPosition()
    {
        mainCamera.position = new Vector3(generator.levelSize.y / 2, mainCamera.position.y, generator.levelSize.x / 2 + 1);
    }

}
