using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCtrl : ShootableObjectCtrl
{
    [SerializeField] protected EnemyDespawn enemyDespawn;
    public EnemyDespawn EnemyDespawn { get { return enemyDespawn; } }
    protected override string getObjTypeString()
    {
        return ObjectType.Enemy.ToString();
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEnemyDespawn();
    }

    protected virtual void LoadEnemyDespawn()
    {
        if (this.enemyDespawn != null) return;
        this.enemyDespawn = transform.GetComponentInChildren<EnemyDespawn>();
        Debug.Log(transform.name + ": LoadEnemyDespawn", gameObject);
    }
}
