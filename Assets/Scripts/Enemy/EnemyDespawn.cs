using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDespawn : DespawnbyDistance
{
    public override void DespawnObj()
    {
        JunkSpawner.Instance.Despawn(transform.parent);
    }
    protected override void Reset()
    {
        base.Reset();
        this.limitDistance = 20;
    }
}
