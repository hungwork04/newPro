using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SpawnPoint : SaiMonoBehavior
{
    [SerializeField] protected List<Transform> points;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPoint();
    }
    protected virtual void LoadPoint()
    {
        if (this.points.Count>0) { return; }
        foreach (Transform point in transform)
        {
            this.points.Add(point);
        }
        Debug.Log(transform.name + ":LoadPoint", gameObject);
    }
    public virtual Transform GetRandom()
    {
        int rand=Random.Range(0, points.Count);
        return this.points[rand];
    }
}
