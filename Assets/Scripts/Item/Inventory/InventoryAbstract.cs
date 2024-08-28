using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryAbstract : SaiMonoBehavior
{
    [SerializeField] protected Inventory inventory;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadInventory();

    }
    protected virtual void LoadInventory()
    {
        if (inventory != null) return;
        this.inventory=transform.parent.GetComponent<Inventory>();
        Debug.Log(transform.name + ":LoadInventory", gameObject);
    }

}
