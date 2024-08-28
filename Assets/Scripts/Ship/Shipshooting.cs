using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shipshooting : MonoBehaviour
{
    [SerializeField] protected bool isShooting = false;
    [SerializeField] protected float delayShootTime = 1f;
    [SerializeField] protected float shootTimer = 0f;
    [SerializeField] protected Transform shootingPos;


    void Update()
    {
        this.IsShooting();
    }
     private void FixedUpdate()
    {
        this.shipAttacking();
    }
    protected virtual void shipAttacking()
    {
        if (!this.isShooting) return;

        this.shootTimer += Time.deltaTime;
        if(this.shootTimer<this.delayShootTime) { return; }
        this.shootTimer = 0;

        Vector3 spawnBulletPos= shootingPos.position;
        Quaternion rotate = transform.parent.rotation;
        /*        Transform newBullet= Instantiate(bullet1,spawnBulletPos,rotate);*/
        Transform newBullet = BulletSpawner.Instance.Spawn(BulletSpawner.BulletOne,spawnBulletPos, rotate);
        if (newBullet == null) return;
        newBullet.gameObject.SetActive(true);
        BulletCtrl bulletCtrl=newBullet.GetComponent<BulletCtrl>();
        bulletCtrl.SetShooter(transform.parent);
/*        Debug.Log("spawn bullet");*/
    }
    protected virtual bool IsShooting()
    {
        this.isShooting= Inputmanager.Instance.onFiring == 1;
        return this.isShooting;
    }
}
