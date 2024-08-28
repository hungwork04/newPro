using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory :SaiMonoBehavior
{
    [SerializeField] protected int maxSlot = 7;
    [SerializeField] protected List<ItemInventory> items;
    public List<ItemInventory> Items => items;

    protected override void Start()
    {
        base.Start();
        this.AddItem(ItemCode.Equip, 2);
        this.AddItem(ItemCode.Coin, 4);
    }

    public virtual bool AddItem(ItemCode itemCode, int addCount)
    {

        ItemProfileSO itemProfile = this.GetItemProfile(itemCode);

        int addRemain = addCount;
        int newCount;
        int itemMaxStack;
        int addMore;
        ItemInventory itemExist;
        for (int i = 0; i < this.maxSlot; i++)
        {
            itemExist = this.GetItemNotFullStack(itemCode);
            if (itemExist == null)//nếu itemExist bằng null
            {
                if (this.IsInventoryFull()) return false;//nếu Inventory full trả AddItem về false

                itemExist = this.CreateEmptyItem(itemProfile);// còn không thì tạo item rỗng 
                this.items.Add(itemExist);//đưa item rỗng vừa tạo thêm vào Inventory(danh sách items)
            }

            newCount = itemExist.itemCount + addRemain;

            itemMaxStack = this.GetMaxStack(itemExist);
            if (newCount > itemMaxStack)
            {
                addMore = itemMaxStack - itemExist.itemCount;
                newCount = itemExist.itemCount + addMore;
                addRemain -= addMore;
            }
            else
            {
                addRemain -= newCount;
            }

            itemExist.itemCount = newCount;
            if (addRemain < 1) break;
        }

        return true;
    }

    protected virtual bool IsInventoryFull()
    {
        if (this.items.Count >= this.maxSlot) return true;
        return false;
    }


    protected virtual int GetMaxStack(ItemInventory itemInventory)
    {
        if (itemInventory == null) return 0;

        return itemInventory.maxStack;
    }

    protected virtual ItemProfileSO GetItemProfile(ItemCode itemCode)
    {
        var profiles = Resources.LoadAll("Item", typeof(ItemProfileSO));
        foreach (ItemProfileSO profile in profiles)
        {
            if (profile.itemCode != itemCode) continue;
            return profile;
        }
        return null;
    }

    protected virtual ItemInventory GetItemNotFullStack(ItemCode itemCode)
    {
        foreach (ItemInventory itemInventory in this.items)// duyệt tất cả các item trong inventory
        {
            if (itemCode != itemInventory.itemProfile.itemCode) continue;//nếu không trùng itemCode thì thoát
            if (this.IsFullStack(itemInventory)) continue;//nếu item này full số lượng thì thoát
            return itemInventory;// còn không thì trả về item tìm đc
        }

        return null;//nếu thuộc trường hợp if trong foreach thì itemInventory có giá trị NULL
    }

    protected virtual bool IsFullStack(ItemInventory itemInventory)
    {
        if (itemInventory == null) return true;

        int maxStack = this.GetMaxStack(itemInventory);
        return itemInventory.itemCount >= maxStack;
    }

    protected virtual ItemInventory CreateEmptyItem(ItemProfileSO itemProfile)
    {
        ItemInventory itemInventory = new ItemInventory// tạo item trong Inventory với thông số default(item rỗng)
        {
            itemProfile = itemProfile,
            maxStack = itemProfile.defaultMaxStack
        };

        return itemInventory;
    }


    public virtual bool ItemCheck(ItemCode itemCode, int numberCheck)
    {
        int totalCount = this.ItemTotalCount(itemCode);
        return totalCount >= numberCheck;
    }

    public virtual int ItemTotalCount(ItemCode itemCode)
    {
        int totalCount = 0;
        foreach (ItemInventory itemInventory in this.items)
        {
            if (itemInventory.itemProfile.itemCode != itemCode) continue;
            totalCount += itemInventory.itemCount;
        }

        return totalCount;
    }

    public virtual void DeductItem(ItemCode itemCode, int deductCount)
    {
        ItemInventory itemInventory;
        int deduct;
        for (int i = this.items.Count - 1; i >= 0; i--)
        {
            if (deductCount <= 0) break;

            itemInventory = this.items[i];
            if (itemInventory.itemProfile.itemCode != itemCode) continue;

            if (deductCount > itemInventory.itemCount)
            {
                deduct = itemInventory.itemCount;
                deductCount -= itemInventory.itemCount;
            }
            else
            {
                deduct = deductCount;
                deductCount = 0;
            }

            itemInventory.itemCount -= deduct;
        }
        this.ClearEmtySlot();
    }
    protected virtual void ClearEmtySlot()
    {
        this.items.RemoveAll(item => item.itemCount <= 0);
        /*        ItemInventory itemInventory;
                for(int i=0; i<this.items.Count; i++)
                {
                    itemInventory = this.items[i];
                    if(itemInventory.itemCount<=0) this.items.RemoveAt(i);
                }*/
    }





    /*public virtual bool AddItem(ItemCode itemCode,int addCount)
    {
        ItemInventory itemInventory = this.GetItemByCode(itemCode);

        int newCount = itemInventory.itemCount + addCount;
        if(newCount > itemInventory.maxStack)  return false; 
        itemInventory.itemCount = newCount;
        return true;

    }
    public virtual ItemInventory GetItemByCode(ItemCode itemCode)
    {
        ItemInventory itemInventory = this.items.Find((x) => x.itemProfile.itemCode == itemCode);
        if (itemInventory == null) itemInventory = this.AddEmptyProfile(itemCode);
        return itemInventory;
    }
    public virtual ItemInventory AddEmptyProfile(ItemCode itemCode)
    {
        var profiles = Resources.LoadAll("Item", typeof(ItemProfileSO));
        foreach (ItemProfileSO profile in profiles)
        {
            if (profile.itemCode != itemCode) continue;
            ItemInventory itemInventory = new ItemInventory
            {
                itemProfile = profile,
                maxStack = profile.defaultMaxStack
            };
            this.items.Add(itemInventory);
            return itemInventory;
        }
        return null;
    }*/
}
