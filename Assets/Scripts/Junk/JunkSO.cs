using System.Collections.Generic;
using UnityEngine;

[ CreateAssetMenu(fileName ="Junk",menuName = "SO/Junk")]
public class JunkSO : ScriptableObject
{
    public string junkName = "Junk";
    public float hpMax = 100f;
    public List<DropRate> dropList;
}
