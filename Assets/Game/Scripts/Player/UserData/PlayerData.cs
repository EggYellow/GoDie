using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Games.GlobeDefine;
using Games.LogicObj;
using Games.Item;

public class PlayerData
{
    private Dictionary<string, string> m_PlayerData = new Dictionary<string, string>();

    public void CleanUp()
    {
        m_PlayerData.Clear();
        m_BackPack = new ItemPack(ItemPack.SIZE_BACKPACK, ItemPack.Type.TYPE_BACKPACK);
        //玩家创建数据缓存
        m_CreateMainPlayerCache = new Obj_Init_Data();
    }
    #region 物品背包

    public delegate void BackPackItemChange();
    public static BackPackItemChange delegateBackPackItemChanged;
    public void OnUpdateItem_BackPack()
    {
        if (delegateBackPackItemChanged != null)
        {
            delegateBackPackItemChanged();
        }
    }

    private ItemPack m_BackPack;
    public ItemPack BackPack
    {
        get { return m_BackPack; }
        set { m_BackPack = value; }
    }
    #endregion

    #region 主角创建
    //记录主角缓存，这样在创建玩家之前，会先从这里读取，再将数值赋给玩家
    private Obj_Init_Data m_CreateMainPlayerCache;
    public Obj_Init_Data CreateMainPlayerCache
    {
        get { return m_CreateMainPlayerCache; }
        set { m_CreateMainPlayerCache = value; }
    }
    #endregion
}
