using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDespawn : DespawnByTime
{

    public override void DespawnObj()
    {
        ItemSpawner.Instance.Despawn(transform.parent);
    }
}
