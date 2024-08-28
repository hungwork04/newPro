using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : Spawner
{
    private static BulletSpawner instance;
    public static BulletSpawner Instance { get => instance; }
    public static string BulletOne = "Bullet_1";
    protected override void Awake()
    {
        base.Awake();
        if (BulletSpawner.instance != null) Debug.LogError("chi dc ton tai 1 BulletSpawner");
        BulletSpawner.instance = this;
    }
}
