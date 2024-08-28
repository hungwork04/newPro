using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundFly : SaiMonoBehavior
{
    [SerializeField] protected float backSpeed = 3f;
    [SerializeField] protected Level level;
    public Level LVUpByTime => level;
    protected void FixedUpdate()
    {
        if (this.LVUpByTime.currentLevel >= 5)
        {
            this.backSpeed -= 0.01f;
        }
        if (this.backSpeed <= 0) { this.backSpeed=0f; return; }
        transform.Translate(Vector3.down * backSpeed*Time.deltaTime);
    }
}
