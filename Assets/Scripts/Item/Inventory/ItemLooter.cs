using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemLooter : SaiMonoBehavior
{
    [SerializeField] protected SphereCollider _collider;
    [SerializeField] protected Rigidbody _rigidbody;
    [SerializeField] protected Inventory inventory;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCollider();
        this.LoadRigidbody();
        this.LoadInventory();
    }

    protected virtual void LoadCollider()//LoadTrigger
    {
        if (this._collider != null) return;
        this._collider=transform.GetComponent<SphereCollider>();
        _collider.isTrigger=true;
        Debug.Log(transform.name + ":LoadCollider", gameObject);
    }
    protected virtual void LoadRigidbody()
    {
        if (this._rigidbody != null) return;
        this._rigidbody = transform.GetComponent<Rigidbody>();
        _rigidbody.useGravity = false;
        _rigidbody.isKinematic = true;
        Debug.Log(transform.name + ":Loadrigidbody", gameObject);
    }
    protected virtual void LoadInventory()
    {
        if (this.inventory != null) return;
        this.inventory = transform.parent.GetComponent<Inventory>();
        Debug.Log(transform.name + ":LoadInventory", gameObject);
    }
    protected virtual void OnTriggerEnter(Collider other)
    {
        ItemPickUpAble itemPickUpAble = other.GetComponent<ItemPickUpAble>();//have to fix
        if (itemPickUpAble == null) return;
        ItemCode itemCode = itemPickUpAble.GetItemCode();
        if (this.inventory.AddItem(itemCode, 1)==true)
        {
            itemPickUpAble.Picked();
        Debug.Log(other.transform.parent.gameObject);
        Debug.Log(other.name);
        }
    }
}
