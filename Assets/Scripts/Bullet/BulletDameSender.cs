using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDameSender : DameSender
{
    [SerializeField] protected BulletCtrl bulletCtrl;
    
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadBulletCtrl();
    }

    protected virtual void LoadBulletCtrl()
    {
        if (this.bulletCtrl != null) return;
        this.bulletCtrl = transform.parent.GetComponent<BulletCtrl>();
        Debug.Log(transform.name + ":LoadBulletCtrl!", gameObject);
    }
    public override void Send(DameRecieve dameRecieve)
    {
        base.Send(dameRecieve);
        this.DestroyBullet();//vi day la vien dan, ban trung la destroy
    }

    protected virtual void DestroyBullet()
    {
        this.bulletCtrl.BulletDespawn.DespawnObj();
    }
}
