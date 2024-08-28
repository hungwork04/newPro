using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : SaiMonoBehavior
{
    [SerializeField] protected Transform followPos;
    [SerializeField] protected float followSpeed=3f;

    void FixedUpdate()
    {

        Vector3 newCamPos = Vector3.Lerp(transform.position, this.followPos.position, this.followSpeed);
        transform.position = newCamPos;
    }
}
