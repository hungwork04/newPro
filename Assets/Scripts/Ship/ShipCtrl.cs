using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipCtrl : SaiMonoBehavior
{
    [SerializeField] protected ShipDespawn shipDespawn;
    public ShipDespawn ShipDespawn { get { return shipDespawn; } }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadShipDespawn();
    }
    protected virtual void LoadShipDespawn()
    {
        if (this.shipDespawn != null) return;
        this.shipDespawn = transform.parent.GetComponent<ShipDespawn>();
        Debug.Log(transform.name + ": LoadShipCtrl", gameObject);
    }
}
