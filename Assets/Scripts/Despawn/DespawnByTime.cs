using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnByTime : Despawner
{
    [SerializeField] protected float timmer = 0f;
    [SerializeField] protected float timeLimit = 2f;
    protected override void OnEnable()
    {
        base.OnEnable();
        this.ResetTimmer();
    }

    protected virtual void ResetTimmer()
    {
        this.timmer = 0f;
    }

    protected override bool CanDespawn()
    {
        this.timmer += Time.fixedDeltaTime;
        if (this.timmer > timeLimit) return true; else return false;
    }
}
