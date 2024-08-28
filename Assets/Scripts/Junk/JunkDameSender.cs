using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkDameSender : DameSender
{
    [SerializeField] protected JunkCtrl junkCtrl;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadJunkCtrl();
    }
    protected override void Reset()
    {
        base.Reset();
        this.damage = 6f;
    }
    protected virtual void LoadJunkCtrl()
    {
        if (this.junkCtrl != null) return;
        this.junkCtrl = transform.parent.GetComponent<JunkCtrl>();
        Debug.Log(transform.name + ":LoadBulletCtrl!", gameObject);
    }
    public override void Send(DameRecieve dameRecieve)
    {
        base.Send(dameRecieve);
        this.DestroyJunk();//vi day la vien dan, ban trung la destroy
    }

    protected virtual void DestroyJunk()
    {
        this.junkCtrl.JunkDespawn.DespawnObj();
    }
}
