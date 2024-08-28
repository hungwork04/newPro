using UnityEngine;

public class JunkDameReceive : DameRecieve
{
    [SerializeField] protected JunkCtrl junkCtrl;


    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadJunkCtrl();
    }

    protected virtual void LoadJunkCtrl()
    {
        if (this.junkCtrl != null) return;
        this.junkCtrl = transform.parent.GetComponent<JunkCtrl>();
        Debug.Log(transform.name + ": LoadJunkCtrl", gameObject);
    }

    protected override void OnDead()
    {
        this.OnFXDead();
        this.OnDeadDrop();
        this.junkCtrl.JunkDespawn.DespawnObj();

    }
    protected virtual void OnFXDead()
    {
        string FXname=this.GetFXName();
        Transform FXOndead=FXSpawner.Instance.Spawn(FXname,transform.position,transform.rotation);
        FXOndead.gameObject.SetActive(true);
    }
    protected virtual void OnDeadDrop()
    {
        Vector3 pos=transform.position;
        Quaternion rot=transform.rotation;
        rot.z = 0;
        ItemSpawner.Instance.Drop(this.junkCtrl.ShootableObjectSO.dropList, pos, rot);
    }
    protected virtual string GetFXName()
    {
        return FXSpawner.FXOne;
    }
    public override void Reborn()
    {
        this.maxHP = this.junkCtrl.ShootableObjectSO.hpMax;
        base.Reborn();
    }
}
