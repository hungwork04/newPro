using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkSpawnerRandom : SaiMonoBehavior
{
    [SerializeField] protected JunkSpawnerCtrl junkSpawnerCtrl;
    [SerializeField] protected JunkRanDomAsteroid junkRanDomAsteroid;

    [SerializeField] protected float SpawnJunkTime = 0.3f;
    [SerializeField] protected float timeDelay = 0.5f;
    [SerializeField] protected float timmer = 0f;
    [SerializeField] protected int randomLimit=20;

    [SerializeField] protected bool canSpawn = true;

    [SerializeField] protected Level level;
    public Level LVUpByTime => level;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadJunkCtrl();
        this.LoadJunkRanDomAsteroid();

    }
    protected virtual void LoadJunkCtrl()
    {
        if (this.junkSpawnerCtrl != null) return;
        this.junkSpawnerCtrl = GetComponent<JunkSpawnerCtrl>();
        Debug.Log(transform.name+": LoadJunkCtrl",gameObject);
    }
    protected virtual void LoadJunkRanDomAsteroid()
    {
        if (this.junkRanDomAsteroid != null) return;
        this.junkRanDomAsteroid = GetComponentInChildren<JunkRanDomAsteroid>();
        Debug.Log(transform.name + ": LoadJunkRanDomAsteroid", gameObject);
    }

    protected override void Start()
    {
/*        this.JunkSpawning();*/
    }
    protected  void FixedUpdate()
    {
        this.CheckCanSpawn();
        this.JunkSpawning();
    }
    protected virtual void CheckCanSpawn()
    {
        if (this.LVUpByTime.currentLevel == 5)
        {
            this.canSpawn = false;
        }
    }
    protected virtual void JunkSpawning()
    {
        if (this.canSpawn == false) return ;
        if (RanDomReachLimit()) return;

        this.timmer += Time.deltaTime;
        if(timmer<timeDelay)  return; 
        this.timmer = 0f;
        string ranAsteroid = this.junkRanDomAsteroid.GetRandom().name;
        Transform ranPos = this.junkSpawnerCtrl.JunkSpawnPoint.GetRandom();
/*        Vector3 pos = ranPos.position;*/
/*        Quaternion rot = ranPos.rotation;*/
        Transform obj=this.junkSpawnerCtrl.JunkSpawner.Spawn(ranAsteroid,ranPos.transform.position, ranPos.transform.rotation);
        obj.gameObject.SetActive(true);
        Invoke(nameof(this.JunkSpawning),this.SpawnJunkTime);
    }
    protected virtual bool RanDomReachLimit()
    {
        int currentJunk = this.junkSpawnerCtrl.JunkSpawner.SpawnCount;
        return currentJunk >= this.randomLimit;
    }
}
