using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ShootableObject", menuName = "SO/ShootableObject")]
public class ShootableObjectSO : ScriptableObject
{
    public string ShootableObjectName = "ShootableObject";
    public ObjectType objectType = ObjectType.Notype;
    public float hpMax = 20f;
    public List<DropRate> dropList;
}
