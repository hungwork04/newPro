using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCtrl : SaiMonoBehavior
{
    [SerializeField] protected DameSender dameSender;
    public DameSender DameSender { get => dameSender; }
    [SerializeField] protected BulletDespawn bulletDespawn;
    public BulletDespawn BulletDespawn { get => bulletDespawn; }
    [SerializeField] protected Transform shooter;
    public Transform Shooter =>shooter;
    public void SetShooter(Transform shooter)
    {
        this.shooter = shooter;
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadDameSender();
        this.LoadBulletDespawn();
    }

    protected virtual void LoadBulletDespawn()
    {
        if (this.bulletDespawn != null) return;
        this.bulletDespawn = transform.GetComponentInChildren<BulletDespawn>();
        Debug.Log(transform.name + ":LoadBulletDespawn!", gameObject);
    }

    protected virtual void LoadDameSender()
    {
        if (this.dameSender != null) return;
        this.dameSender=transform.GetComponentInChildren<DameSender>();
        Debug.Log(transform.name + ":LoadDameSender!", gameObject);
    }
}
