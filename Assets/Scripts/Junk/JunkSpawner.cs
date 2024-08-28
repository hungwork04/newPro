using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class JunkSpawner : Spawner
{
    private static JunkSpawner instance;
    public static JunkSpawner Instance { get => instance; }
    public static string Asteroid = "Asteroid_1";
    public Vector2 sizeRange = new Vector2(0.5f, 3.0f);
    [SerializeField] protected List<Transform> Asteroids;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadAsteroids();
    }
    protected override void Awake()
    {
        base.Awake();
        if (JunkSpawner.instance != null) Debug.LogError("chi dc ton tai 1 JunkSpawner");
        JunkSpawner.instance = this;
    }
    protected override Transform GetObjfromPool(Transform prefab)
    {
        foreach (Transform poolObj in this.poolObjs)
        {
            if (poolObj.name == prefab.name)
            {
                this.poolObjs.Remove(poolObj);
                return poolObj;
            }
        }

        Transform newPrefab = Instantiate(prefab);
        float randomSize = Random.Range(sizeRange.x, sizeRange.y);
        newPrefab.localScale = new Vector3(randomSize, randomSize, randomSize);
        newPrefab.name = prefab.name;
        return newPrefab;
    }

    protected virtual void LoadAsteroids()
    {
        if (this.Asteroids.Count > 0) { return; }
        foreach (Transform point in transform)
        {
            this.Asteroids.Add(point);
        }
        Debug.Log(transform.name + ":LoadAsteroid", gameObject);
    }
    public virtual string GetRandomAsteroid()
    {
        int rand = Random.Range(0, Asteroids.Count);
        return this.Asteroids[rand].name;
    }
}
