using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCtrl : SaiMonoBehavior
{
/*    [SerializeField] protected ItemSpawner itemSpawner;
    public ItemSpawner ItemSpawner { get { return itemSpawner; } }*/
    [SerializeField] protected Transform model;
    public Transform Model { get { return model; } }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadItemModel();
/*        this.LoadItemSpawner();*/
    }

/*    protected virtual void LoadItemSpawner()
    {
        if (this.itemSpawner != null) return;
        this.itemSpawner = transform.GetComponentInChildren<ItemSpawner>();
        Debug.Log(transform.name + ": LoaditemSpawner", gameObject);
    }
*/
    protected virtual void LoadItemModel()
    {
        if(this.model != null) { return; }
        this.model = transform.Find("Model");
        Debug.Log(transform.name + ":loaditemModel!", gameObject);
    }
}
