using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="ItemProfileSO",menuName ="SO/ItemProfile")]
public class ItemProfileSO : ScriptableObject
{
    public Itemtype itemType = Itemtype.Notype;
    public ItemCode itemCode = ItemCode.NoItem;
    public string itemName = "NoName";
    public int defaultMaxStack = 7;
    public List<ItemRecipe> upgradeLevels;
}
