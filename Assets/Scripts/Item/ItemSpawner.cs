using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ItemSpawner : Spawner
{
    private static ItemSpawner instance;
    public static ItemSpawner Instance { get => instance; }


    protected override void LoadComponents()
    {
        base.LoadComponents();

    }
    protected override void Awake()
    {
        base.Awake();
        if (ItemSpawner.instance != null) Debug.LogError("chi dc ton tai 1 ItemSpawner");
        ItemSpawner.instance = this;
    }

    public virtual void Drop(List<DropRate> dropList,Vector3 pos,Quaternion rot)
    {
        ItemCode itemCode = dropList[0].itemSO.itemCode;
        Transform itemDrop=this.Spawn(itemCode.ToString(), pos, rot);
        if (itemDrop == null) { return; }
        itemDrop.gameObject.SetActive(true);
    }
}
