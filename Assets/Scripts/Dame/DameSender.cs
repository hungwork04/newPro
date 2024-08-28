using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DameSender : SaiMonoBehavior
{
    [SerializeField] protected float damage = 4f;
 
    public virtual void Send(Transform obj)
    {
        DameRecieve dameRecieve = obj.GetComponentInChildren<DameRecieve>();
        if (dameRecieve == null) return;
        /*        dameRecieve.Deduct(this.damage);*/
        this.Send(dameRecieve);
    }

    public virtual void Send(DameRecieve dameRecieve)
    {
        dameRecieve.Deduct(this.damage);
    }


}
