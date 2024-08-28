using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : SaiMonoBehavior
{
    [SerializeField] public int currentLevel = 0;
    [SerializeField] protected int maxlevel = 99;
    [SerializeField] protected Level level;
    public Level LVUpByTime => level;
    public virtual void setLevel(int currentLevel)
    {
        this.currentLevel = currentLevel;
        if (currentLevel > maxlevel) this.currentLevel = this.maxlevel;
        if(currentLevel<0) this.currentLevel = 0;
    }
    protected virtual void updateLevel()
    {
        this.currentLevel++;
    }
}
