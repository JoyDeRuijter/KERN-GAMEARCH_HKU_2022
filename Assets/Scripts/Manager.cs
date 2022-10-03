using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{

    public static Manager Instance { get; private set;}

    private void Awake()
    {
        if(Instance != null && Instance != this) Destroy(this);
        else Instance = this;
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        
    }
}
