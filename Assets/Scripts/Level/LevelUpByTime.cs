using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUpByTime : Level
{
    [SerializeField] protected float timmer = 0f;
    [SerializeField] protected float timeDelay = 60f;

    protected void FixedUpdate()
    {
        this.Timming();
/*        this.CheckCanLevelUp();*/
    }
    protected virtual bool Timming()
    {
        this.timmer += Time.fixedDeltaTime;
        if(this.timmer>=this.timeDelay) 
        { 
            this.timmer = 0f;
            updateLevel();
            return true;
        }
        return false;
    }
/*    protected virtual void CheckCanLevelUp()
    {
        if(this.Timming()==true) updateLevel();
    }*/
}
