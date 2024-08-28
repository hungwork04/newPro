using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentFly : SaiMonoBehavior
{
    [SerializeField] protected float objSpeed = 1f;
    [SerializeField] protected Vector3 direction = Vector3.up;


    void Update()
    {
        transform.parent.Translate(this.direction * this.objSpeed * Time.deltaTime); // hàm làm viên đạn di chuyển theo vector trong ngoặc 
    }
}
