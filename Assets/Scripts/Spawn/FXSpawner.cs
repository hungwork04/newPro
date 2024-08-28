using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FXSpawner : Spawner
{
    private static FXSpawner instance;
    public static FXSpawner Instance { get => instance; }
    public static string FXOne = "Smoke_1";
    public static string FXtwo = "Impact";
    protected override void Awake()
    {
        base.Awake();
        if (FXSpawner.instance != null) Debug.LogError("chi dc ton tai 1 FXSpawner");
        FXSpawner.instance = this;
    }
}
