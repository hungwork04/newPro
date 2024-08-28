using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DameRecieve : SaiMonoBehavior
{
    [SerializeField] protected float currentHP = 1;
    [SerializeField] protected float maxHP = 10;
    [SerializeField] protected bool isDead = false;
    [SerializeField] protected SphereCollider sphereCollider;

    protected override void OnEnable()
    {
        this.Reborn();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCollider();
    }

    protected virtual void LoadCollider()
    {
        if (this.sphereCollider != null) return;
        this.sphereCollider = transform.GetComponent<SphereCollider>();
        this.sphereCollider.isTrigger = true;
        Debug.Log(transform.name + ":LoadCollider!", gameObject);
    }
    public virtual void Reborn()
    {
        this.currentHP = this.maxHP;
        this.isDead = false;
    }

    public virtual void Add(float add)
    {
        this.currentHP += add;
        if(this.currentHP > maxHP) { this.currentHP = maxHP; }
    }
    public virtual void Deduct(float deduct)
    {
        if (this.isDead) {
            return; }

        this.currentHP -= deduct;
        if (this.currentHP < 0) {
            this.currentHP = 0;
        }
        this.CheckIsDead();
    }


    protected virtual void CheckIsDead()
    {
        if (this.currentHP>0) return;
        else
        {
            //animator.SetBool("IsDead", true);
            this.isDead = true;
            this.OnDead();
        }

    }

    protected virtual void OnDead()
    {
        
    }

}
