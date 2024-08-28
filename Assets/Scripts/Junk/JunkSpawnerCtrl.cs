using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkSpawnerCtrl : SaiMonoBehavior
{
    [SerializeField] protected JunkSpawner junkSpawner;
    [SerializeField] protected JunkSpawnPoint junkspawnPoint;
    public JunkSpawnPoint JunkSpawnPoint {  get { return junkspawnPoint; } }
    public JunkSpawner JunkSpawner { get => junkSpawner; }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadJunkSpawner();
        this.LoadJunkSpawnPoint();
    }
    protected virtual void LoadJunkSpawnPoint()
    {
        if (this.junkspawnPoint != null) return;
        this.junkspawnPoint = Transform.FindObjectOfType<JunkSpawnPoint>();
        Debug.Log(transform.name + ": LoadJunkSpawnPoint", gameObject);
    }

    protected virtual void LoadJunkSpawner()
    {
        if (this.junkSpawner != null) return;
        this.junkSpawner = GetComponent<JunkSpawner>();
        Debug.Log(transform.name + ": LoadJunkSpawner", gameObject);
    }

}
