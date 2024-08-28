using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropManager : SaiMonoBehavior
{
    private static DropManager instance;
    public static DropManager Instance { get => instance; }

    protected override void Awake()
    {
        base.Awake();
        if (DropManager.instance != null) Debug.LogError("chi dc ton tai 1 DropManager");
        DropManager.instance = this;
    }
/*    public virtual void Drop(List<DropRate> dropList)
    {
        Debug.Log(dropList[0].itemSO.itemName);
    }*/
}
