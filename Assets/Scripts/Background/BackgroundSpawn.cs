using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundSpawn : MonoBehaviour
{
    [SerializeField] protected Transform player;
    [SerializeField] protected float limitDis=20f;
    [SerializeField] protected float currentDis;
    [SerializeField] protected float respawnDis=40.4f;
    void FixedUpdate()
    {
        GetCurrentDis();
        SpawnBack();
    }
    protected virtual void SpawnBack()
    {
        if (this.currentDis < limitDis) return;
/*        Debug.Log("spawn background!");*/
        Vector3 newPos= transform.position;
        newPos.y += respawnDis;
        transform.position = newPos;
    }
    protected virtual void GetCurrentDis()
    {
        this.currentDis=player.position.y- transform.position.y  ;
    }
}
