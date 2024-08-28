using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDameRecieve : DameRecieve
{
    [SerializeField] protected EnemyCtrl enemyCtrl;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEnemyCtrl();
    }

    protected virtual void LoadEnemyCtrl()
    {
        if (enemyCtrl != null) return;
        this.enemyCtrl=transform.GetComponentInParent<EnemyCtrl>();
        Debug.Log(transform.name + ": LoadEnemyCtrl", gameObject);
    }
    protected override void OnDead()
    {
        this.OnFXDead();
/*        this.OnDeadDrop();*/
        this.enemyCtrl.EnemyDespawn.DespawnObj();

    }
    protected virtual void OnFXDead()
    {
        string FXname = this.GetFXName();
        Transform FXOndead = FXSpawner.Instance.Spawn(FXname, transform.position, transform.rotation);
        FXOndead.gameObject.SetActive(true);
    }
/*    protected virtual void OnDeadDrop()
    {
        Vector3 pos = transform.position;
        Quaternion rot = transform.rotation;
        rot.z = 0;
        ItemSpawner.Instance.Drop(this.enemyCtrl.ShootableObjectSO.dropList, pos, rot);
    }*/
    protected virtual string GetFXName()
    {
        return FXSpawner.FXOne;
    }
    public override void Reborn()
    {
        this.maxHP = this.enemyCtrl.ShootableObjectSO.hpMax;
        base.Reborn();
    }
}
