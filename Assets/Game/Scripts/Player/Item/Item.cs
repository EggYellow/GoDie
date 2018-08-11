using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Games.LogicObj;
using Games.GlobeDefine;
using UnityEngine.UI;

namespace Games.Item
{
    public class Item
    {
        /// <summary>
        /// 物品ID
        /// </summary>
        private int m_nDataID;
        public void CleanUp()
        {
            m_nDataID = GlobeVar.INVALID_ID;
            m_nStackCount = 1;
            m_nCreateTime = 0;
        }
        /// <summary>
        /// IsValid
        /// </summary>
        /// <returns></returns>
        public bool IsValid()
        {
            if (m_nDataID >= 0)
            {
                /*
                Tab_CommonItem line = TableManager.GetCommonItemByID(m_nDataID, 0);
                if (line != null)
                {
                    return true;
                }
                */
            }
            return false;
        }

        public string GetIcon()
        {
            /*Tab_CommonItem line = TableManager.GetCommonItemByID(m_nDataID, 0);
            if (line != null)
            {
                return line.Icon;
            }*/
            return "";
        }

        public int DataID
        {
            get { return m_nDataID; }
            set { m_nDataID = value; }
        }

        /// <summary>
        /// 堆叠数量
        /// </summary>
        private int m_nStackCount;

        public int StackCount
        {
            get { return m_nStackCount; }
            set { m_nStackCount = value; }
        }     
        
        /// <summary>
        /// 创建时间
        /// </summary>
        private long m_nCreateTime;

        public long CreateTime
        {
            get { return m_nCreateTime; }
            set { m_nCreateTime = value; }
        }

        public static void SetIcon(Image itemIconSprite,  string iconName)
        {
            if (null == itemIconSprite)
            {
                return;
            }

           
        }

        public static void SetIcon(Image itemIconSprite, int itemDataId)
        {
            /*
            Tab_CommonItem line = TableManager.GetCommonItemByID(itemDataId, 0);
            if (line == null)
            {
                return;
            }

            SetIcon(itemIconSprite, line.Atlas, line.Icon);*/
        }

        public void SetIcon(Image itemIconSprite)
        {
            if (null == itemIconSprite)
            {
                return;
            }
            /*
            Tab_CommonItem line = TableManager.GetCommonItemByID(m_nDataID, 0);
            if (line == null)
            {
                return;
            }

            Item.SetIcon(itemIconSprite, line.Atlas, line.Icon);*/
        }

        /// <summary>
        /// 物品最大堆叠数量
        /// </summary>
        /// <returns></returns>
        public int GetMaxStackCount()
        {
            /*
            Tab_CommonItem line = TableManager.GetCommonItemByID(m_nDataID, 0);
            if (line != null)
            {
                return line.MaxStackSize;
            }*/
            return 0;
        }
        public int GetSortId()
        {
            /*Tab_CommonItem line = TableManager.GetCommonItemByID(m_nDataID, 0);
            if (line != null)
            {
                return line.SortId;
            }*/
            return -1;
        }
    }
}