using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ShootableObjectCtrl : SaiMonoBehavior
{
    [SerializeField] protected Transform model;
    [SerializeField] protected Despawner despawn;
    [SerializeField] protected ShootableObjectSO shootableObjectSO;
    public Despawner Despawn { get { return despawn; } }
    public Transform Model { get { return model; } }
    public ShootableObjectSO ShootableObjectSO { get { return shootableObjectSO; } }

/*    [SerializeField] protected DameSender dameSender;
    public DameSender DameSender { get => dameSender; }*/
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadModel();
        this.LoadDespawn();
        this.LoadSO();
    }
    protected virtual void LoadSO()
    {
        if (this.shootableObjectSO != null) return;
        string resPath = "ShootableObject/"+this.getObjTypeString()+"/" + transform.name;
        this.shootableObjectSO = Resources.Load<ShootableObjectSO>(resPath);
        Debug.LogWarning(transform.name + ":loadJunkSO" + resPath, gameObject);
    }

    protected abstract string getObjTypeString();

    protected virtual void LoadModel()
    {
        if (this.model != null) return;
        this.model = transform.Find("Model");
        Debug.Log(transform.name + ":loadModel!", gameObject);
    }
    protected virtual void LoadDespawn()
    {
        if (this.despawn != null) return;
        this.despawn = transform.GetComponentInChildren<Despawner>();
        Debug.Log(transform.name + ": LoadJunkDespawn", gameObject);
    }
}
