using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDespawn : DespawnbyDistance
{
    public override void DespawnObj()
    {
        BulletSpawner.Instance.Despawn(transform.parent);
    }
    protected override void Reset()
    {
        base.Reset();
        this.limitDistance = 15f;
    }
}
