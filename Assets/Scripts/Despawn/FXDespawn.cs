using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FXDespawn : DespawnByTime
{
    public override void DespawnObj()
    {
        FXSpawner.Instance.Despawn(transform.parent);

    }
}
