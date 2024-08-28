using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUpAble : SaiMonoBehavior
{
    [SerializeField] protected SphereCollider _collider;
    [SerializeField] protected ItemDespawn itemDespawn;
    public ItemDespawn Itemdespawn { get { return itemDespawn; } }
    public static ItemCode String2ItemCode(string itemName)
    {
        return (ItemCode)System.Enum.Parse(typeof(ItemCode), itemName);//
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadTrigger();
    }

    protected virtual void LoadTrigger()
    {
        if (this._collider != null) return;
        this._collider = transform.GetComponent<SphereCollider>();
        this._collider.isTrigger = true;
        Debug.LogWarning(transform.name + " LoadTrigger", gameObject);
    }
    public virtual ItemCode GetItemCode()
    {
        return ItemPickUpAble.String2ItemCode(transform.parent.name);
    }
    public virtual void Picked()
    {
        this.Itemdespawn.DespawnObj();
    }
}
