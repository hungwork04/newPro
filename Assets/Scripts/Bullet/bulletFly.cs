using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletFly : ParentFly
{
    protected override void ResetValue()
    {
        base.ResetValue();
        this.objSpeed = 7f;
    }
}
