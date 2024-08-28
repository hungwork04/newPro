using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipDameRecieve : DameRecieve
{
    [SerializeField] protected ShipCtrl shipCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadShipCtrl();
    }

    protected virtual void LoadShipCtrl()
    {
        if (this.shipCtrl != null) return;
        this.shipCtrl = transform.parent.GetComponent<ShipCtrl>();
        Debug.Log(transform.name + ": LoadShipCtrl", gameObject);
    }
    protected override void OnDead()
    {
        this.shipCtrl.ShipDespawn.DespawnObj();
    }
}
