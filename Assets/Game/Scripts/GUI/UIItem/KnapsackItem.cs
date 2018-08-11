using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Games.Item;
using Games.GlobeDefine;

public class KnapsackItem : MonoBehaviour
{
    public Image m_Icon;
    public Text m_Count;
    public Image m_Selected;
    public GameObject m_TuiJian;
    public Text m_ItemName;

    public delegate void Click(Item item);
    public Click m_delOnClickItem;

    private Item m_Item;

    public int m_StaticItemId = GlobeVar.INVALID_ID;
    public int m_StaticItemCount = 0;
    private enum Status
    {
        EMPTY,                  // 空格子
        FULL,                   // 有物品
    }
    private Status m_Status;

    void Start()
    {
        if (m_StaticItemId != GlobeVar.INVALID_ID)
        {
            Item item = new Item();
            item.DataID = m_StaticItemId;
            Init_Item(item, null, m_StaticItemCount > 0, m_StaticItemCount.ToString());
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="item">物品</param>
    /// <param name="click">点击回调</param>
    /// <param name="showNum">是否显示叠加</param>
    /// <param name="Num">叠加显示</param>
    /// <param name="isSetDisable">disable是否隐藏</param>
    public void Init_Item(Item item, Click click = null, bool showNum = false, string Num = "",  bool isSetDisable = false)
    {
        if (item == null)
        {
            Init_Empty(click);
            return;
        }
        m_delOnClickItem = click;
        m_Status = Status.FULL;
        m_Item = item;
        // 图标
        m_Icon.gameObject.SetActive(true);
        item.SetIcon(m_Icon);
        // 叠加
        if (showNum)
        {
            if (Num != "")
            {
                m_Count.text = Num;
            }
            else
            {
                m_Count.text = item.StackCount.ToString();
            }
            m_Count.gameObject.SetActive(true);
        }
        else
        {
            m_Count.gameObject.SetActive(false);
        }
        if (m_Selected)
        {
            m_Selected.gameObject.SetActive(false);
        }

        if (m_ItemName != null)
        {
            m_ItemName.text = "";
        }
    }

    public void Init_Empty(Click click = null)
    {
        m_delOnClickItem = click;
        m_Status = Status.EMPTY;
        m_Item = null;
        m_Icon.gameObject.SetActive(false);
        m_Count.gameObject.SetActive(false);
        if (m_Selected != null)
        {
            m_Selected.gameObject.SetActive(false);
        }
       
        if (m_TuiJian != null)
        {
            m_TuiJian.SetActive(false);
        }

        if (m_ItemName != null)
        {
            m_ItemName.text = "";
        }
    }

    public void OnItemClick()
    {
        if (m_Status == Status.EMPTY)
        {
            if (m_delOnClickItem != null)
            {
                m_delOnClickItem(null);
            }
        }
        else if (m_Status == Status.FULL)
        {
            if (m_Item != null)
            {
                if (m_delOnClickItem != null)
                {
                    m_delOnClickItem(m_Item);
                }
            }
        }
    }
    public void SetItemName(string name)
    {
        if (m_ItemName != null)
        {
            m_ItemName.text = name;
        }
    }

    public void SetItemNum(string Num)
    {
        m_Count.text = Num;
    }
}
