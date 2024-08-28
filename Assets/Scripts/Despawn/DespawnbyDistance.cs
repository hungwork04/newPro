using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnbyDistance : Despawner
{
    [SerializeField] protected float limitDistance = 70f;
    [SerializeField] protected float currentDistance = 0f;
    [SerializeField] protected Transform mainCam;

    protected override void Reset()
    {
        this.LoadCamera();
    }
    protected virtual void LoadCamera()
    {
        if (this.mainCam != null) return;
        this.mainCam = Transform.FindObjectOfType<Camera>().transform;
        Debug.Log(transform.parent.name + " :load game", gameObject);
    }
    protected override bool CanDespawn()
    {
        this.currentDistance= Vector3.Distance(transform.position,this.mainCam.position);
        if (this.currentDistance > this.limitDistance) return true;
        return false;
    }
}
