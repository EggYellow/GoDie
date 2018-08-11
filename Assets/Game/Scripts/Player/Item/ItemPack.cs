using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Games.Item
{
    public class ItemPack
    {
        public enum Type
        {
            TYPE_INVALID = -1,
            TYPE_BACKPACK = 0,
        }

        // 背包默认负重
        public const int SIZE_BACKPACK = 85;

        private List<Item> m_Items = new List<Item>();

        public ItemPack(int nSize, Type nType)
        {
            m_ContainerSize = nSize;
            m_ContainerType = nType;
            for (int i = 0; i < m_ContainerSize; ++i)
            {
                m_Items.Add(new Item());
            }
        }

        /// <summary>
        /// 容器大小
        /// </summary>
        private int m_ContainerSize = 0;
        public int ContainerSize
        {
            get { return m_ContainerSize; }
        }

        /// <summary>
        /// 容器类型
        /// </summary>
        private Type m_ContainerType = Type.TYPE_INVALID;
        public ItemPack.Type ContainerType
        {
            get { return m_ContainerType; }
        }
        
        /// <summary>
        /// 扩充背包
        /// </summary>
        /// <param name="nAdd"></param>
        public void AddContainerSize(int nAdd)
        {
            m_ContainerSize += nAdd;
            for (int i = 0; i < nAdd; ++i)
            {
                m_Items.Add(new Item());
            }
        }

        /// <summary>
        /// 容器可用大小
        /// </summary>
        public int GetEmptySize()
        {
            int Num = 0;
            for (int i = 0; i < m_Items.Count; ++i)
            {
                if (m_Items[i] != null)
                {
                    if (m_Items[i].IsValid() == false)
                    {
                        Num++;
                    }
                }
            }
            return Num;
        }

        /// <summary>
        /// 取得物品
        /// </summary>
        public Item GetItem(int slot)
        {
            if (slot >= 0 && slot < m_Items.Count)
            {
                return m_Items[slot];
            }
            return null;
        }

        /// <summary>
        /// 增加物品
        /// </summary>
        public void AddItem(Item item)
        {
            if (item != null)
                m_Items.Add(item);
        }

        /// <summary>
        /// 更新物品
        /// </summary>
        /// <param name="slot">槽位</param>
        /// <param name="item">物品</param>
        public bool UpdateItem(int slot, Item item)
        {
            bool bRet = false;
            if (slot >= 0 && slot < m_Items.Count)
            {
                m_Items[slot] = item;
                bRet = true;
            }
            return bRet;
        }

        /// <summary>
        /// 有效物品数量
        /// </summary>
        /// <returns></returns>
        public int GetItemCount()
        {
            int count = 0;
            for (int i = 0; i < m_Items.Count; ++i)
            {
                Item item = m_Items[i];
                if (item.IsValid())
                {
                    ++count;
                }
            }
            return count;
        }

        /// <summary>
        /// 取得指定ID物品数量
        /// </summary>
        /// <returns></returns>
        public int GetItemCountByDataId(int dataid)
        {
            int count = 0;
            if (dataid >= 0)
            {
                for (int i = 0; i < m_Items.Count; ++i)
                {
                    if (m_Items[i].DataID == dataid)
                    {
                        count = count + m_Items[i].StackCount;
                    }
                }
            }
            return count;
        }

        /// <summary>
        /// 取得物品列表
        /// </summary>
        /// <returns></returns>
        public List<Item> GetList()
        {
            return m_Items;
        }


        /// <summary>
        /// 排序后列表
        /// </summary>
        /// <returns></returns>
        public List<Item> GetSortedList()
        {
            List<Item> tempItems = new List<Item>(m_Items.ToArray());
            tempItems.Sort(ItemTool.ItemSort);
            return tempItems;
        }
        class ItemTool
        {
            /// <summary>
            /// 背包排序
            /// </summary>
            /// <param name="item2"></param>
            /// <param name="item1"></param>
            /// <returns></returns>
            public static int ItemSort(Item item2, Item item1)
            {
                if (item1 == null || item2 == null)
                {
                    return 0;
                }
                if (item1.IsValid() && item2.IsValid() == false)
                {
                    return 1;
                }
                else if (item1.IsValid() == false && item2.IsValid())
                {
                    return -1;
                }
                else if (item1.IsValid() == false && item2.IsValid() == false)
                {
                    return 0;
                }
                else
                {
                    if (item1.GetSortId() > item2.GetSortId())
                    {
                        return 1;
                    }
                    else if (item1.GetSortId() < item2.GetSortId())
                    {
                        return -1;
                    }
                    else
                    {

                        if (item1.CreateTime < item2.CreateTime)
                        {
                            return 1;
                        }
                        else if (item1.CreateTime > item2.CreateTime)
                        {
                            return -1;
                        }
                    }
                }
                return 0;
            }
        };
    }
}