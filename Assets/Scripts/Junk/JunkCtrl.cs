
using UnityEngine;

public class JunkCtrl : SaiMonoBehavior
{
    [SerializeField] protected Transform model;
    [SerializeField] protected JunkDespawn junkDespawn;
    [SerializeField] protected ShootableObjectSO shootableObjectSO;
    public JunkDespawn JunkDespawn {  get { return junkDespawn; } }
    public Transform Model {  get { return model; } }
    public ShootableObjectSO ShootableObjectSO { get { return shootableObjectSO; } }

    [SerializeField] protected DameSender dameSender;
    public DameSender DameSender { get => dameSender; }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadModel();
        this.LoadJunkDespawn();
        this.LoadShootableObjectSO();
        this.LoadDameSender();

    }
    protected virtual void LoadDameSender()
    {
        if (this.dameSender != null) return;
        this.dameSender = transform.GetComponentInChildren<DameSender>();
        Debug.Log(transform.name + ":LoadDameSender!", gameObject);
    }
    protected virtual void LoadShootableObjectSO()
    {
        if (this.shootableObjectSO != null) return;
        string resPath= "ShootableObject/Junk/" + transform.name;
        this.shootableObjectSO = Resources.Load<ShootableObjectSO>(resPath);
        Debug.LogWarning(transform.name + ":loadJunkSO"+resPath, gameObject);
    }

    protected virtual void LoadModel()
    {
        if (this.model != null) return;
        this.model = transform.Find("Model");
        Debug.Log(transform.name + ":loadModel!", gameObject);
    }
    protected virtual void LoadJunkDespawn()
    {
        if (this.junkDespawn != null) return;
        this.junkDespawn = transform.GetComponentInChildren<JunkDespawn>();
        Debug.Log(transform.name + ": LoadJunkDespawn", gameObject);
    }
}
