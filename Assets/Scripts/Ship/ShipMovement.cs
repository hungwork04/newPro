using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : SaiMonoBehavior
{
    [SerializeField] protected Vector3 worldPosition;
    [SerializeField] protected float shipSpeed=0.1f;

    void FixedUpdate()
    {
        worldPosition = Inputmanager.Instance.mouseWorldPos;
        worldPosition.z = 0;
        Vector3 newPos = Vector3.Lerp(transform.parent.position, worldPosition, this.shipSpeed);
        transform.parent.position = newPos;
    }


}
