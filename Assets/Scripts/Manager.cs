using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public static Manager Instance { get; private set;}
    private FiniteStateMachine fsm;

    public Dictionary<Vector3Int, Tile> level = new Dictionary<Vector3Int, Tile>();

    [Header ("Prefabs")]
    public GameObject pathPrefab;
    public GameObject wallPrefab;
    public GameObject enemyPrefab;

    [Header("UI Menu's")]
    public GameObject startMenu;
    public GameObject buildingMenu;
    public GameObject gameOverMenu;

    public EnemyManager enemyManager = new EnemyManager(3);

    [Header("Level Settings")]
    [SerializeField] private string levelPath;
    [SerializeField] public float buildTime;
    public int amountOfCoins = 500;
    public float health;

    public Transform mainCamera;


    [Header("Key Bindings")]
    //Customizable keybindings
    [SerializeField] private KeyCode buildKey = KeyCode.B;
    [SerializeField] private KeyCode upgradeKey = KeyCode.U;
    [SerializeField] private KeyCode destroyKey = KeyCode.D;
    [SerializeField] private KeyCode undoKey = KeyCode.Tab;

    //Dependencies
    private LevelGenerator generator = new LevelGenerator();
    public BuildingManager buildingManager = new BuildingManager();
    private InputHandler inputHandler = new InputHandler();
    private KeyBinder keyBinder;

    //States
    private BaseState[] states = new BaseState[] { new StartState(), new BuildingState(), new AttackState(), new GameOverState()} ;

    private void Awake()
    {
        if(Instance != null && Instance != this) Destroy(this);
        else Instance = this;

        buildingManager.OnAwake();
        keyBinder = new KeyBinder(buildingManager, inputHandler, buildKey, upgradeKey, destroyKey, undoKey);

    }

    private void Start()
    {
        fsm = new FiniteStateMachine(typeof(StartState),states);

        level = generator.Generate(levelPath);
        SetCameraPosition();

        buildingManager.OnStart(generator.levelSize);
        enemyManager.OnStart();
    }

    private void Update()
    {
        fsm.OnUpdate();
        buildingManager.OnUpdate();
        inputHandler.HandleInput();
        enemyManager.OnUpdate();
    }

    private void SetCameraPosition()
    {
        mainCamera.position = new Vector3(generator.levelSize.y / 2, mainCamera.position.y, generator.levelSize.x / 2 + 1);
    }

    public void StartButton()
    {
        fsm.SwitchState(typeof(BuildingState));
    }

    public void StartOverButton()
    {
        fsm.SwitchState(typeof(StartState));
    }
}
