
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Spawner : SaiMonoBehavior // lớp abstract là để bắt người dùng kế thừa và sử dụng trong 1 lớp khác, vậy nên k thể dùng
                                                // trực tiếp lớp này mà phải kế thừa sang lớp khác rồi mới sử dụng [muốn dùng hàm nào và thay đổi thì override lại]
{
    [SerializeField] protected Transform holder;
    [SerializeField] protected List<Transform> prefabs;
    [SerializeField] protected List<Transform> poolObjs;
    [SerializeField] protected int spawnCount;

    public int SpawnCount { get => spawnCount; }

    protected override void LoadComponents()
    {
        this.loadPrefabs();
        this.loadHolder();
    }

    protected virtual void loadHolder()
    {
       if(this.holder != null)
            return;
        this.holder = transform.Find("Holder");
        Debug.Log(transform.name + ": load holder ", gameObject);
    }

    protected virtual void loadPrefabs()
    {
        if (this.prefabs.Count > 0) return;
        Transform prefabObj = transform.Find("Prefabs");
        foreach(Transform prefab in prefabObj)
        {
            this.prefabs.Add(prefab);
        }
        this.hidePrefab();

        Debug.Log(transform.name + " :loadPrefabs", gameObject);
    }

    protected virtual void hidePrefab()
    {
        foreach(Transform prefab in this.prefabs)
        {
            prefab.gameObject.SetActive(false);
        }
    }

    public virtual Transform Spawn(string prefabName,Vector3 spawnBulletPos,Quaternion rotation)
    {

        Transform prefab = this.GetPrefabName(prefabName);
        if(prefab == null)
        {
            Debug.LogWarning("Prefab not found: " + prefabName);
            return null;
        }
        Transform newprefab = this.GetObjfromPool(prefab);
        newprefab.SetPositionAndRotation(spawnBulletPos, rotation);

        newprefab.parent = this.holder;
        this.spawnCount++;
        return newprefab;
    }

    protected virtual Transform GetObjfromPool(Transform prefab)
    {
        foreach(Transform poolObj in this.poolObjs)
        {
            if (poolObj.name == prefab.name)
            {
                this.poolObjs.Remove(poolObj);
                return poolObj;
            }
        }

        Transform newPrefab = Instantiate(prefab);
        newPrefab.name = prefab.name;
        return newPrefab;
    }

    public virtual void Despawn(Transform obj)
    {
        this.poolObjs.Add(obj);
        obj.gameObject.SetActive(false);
        this.spawnCount--;
    }
    public virtual Transform GetPrefabName(string prefabName)
    {
        foreach(Transform prefab in this.prefabs)
        {
            if (prefabName == prefab.name)
            {
                return prefab;
            }
        }
        return null;
    }
}
