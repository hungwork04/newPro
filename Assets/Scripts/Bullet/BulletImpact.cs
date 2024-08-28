using UnityEngine;

public class BulletImpact : BulletAbstract
{
    [SerializeField] protected CapsuleCollider sphereCollider;
    [SerializeField] protected Rigidbody _rigidbody;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCollider();
        this.LoadRigidbody();
    }

    protected virtual void LoadRigidbody()
    {
        if (this._rigidbody != null) return;
        this._rigidbody = transform.GetComponent<Rigidbody>();
        this._rigidbody.isKinematic=true;
        Debug.Log(transform.name + ":LoadRigidbody!", gameObject);
    }
    protected virtual void LoadCollider()
    {
        if (this.sphereCollider != null) return;
        this.sphereCollider = transform.GetComponent<CapsuleCollider>();
        this.sphereCollider.isTrigger = true;
        Debug.Log(transform.name + ":LoadCollider!", gameObject);
    }
    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Junk")
        {
            return;
        }
        this.bulletCtrl.DameSender.Send(other.transform);
        this.SpawnFXImpact(other);

    }
    protected virtual void SpawnFXImpact(Collider other)
    {
        string FXimpactname = this.GetFXImpactName();
        Transform FxImpact = FXSpawner.Instance.Spawn(FXimpactname, transform.position,transform.rotation);
        FxImpact.gameObject.SetActive(true);
    }
    protected virtual string GetFXImpactName()
    {
        return FXSpawner.FXtwo;
    }
}
