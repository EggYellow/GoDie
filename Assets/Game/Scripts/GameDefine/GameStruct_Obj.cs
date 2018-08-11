/********************************************************************************
 *	文件名：	GameStruct_Obj.cs
 *	全路径：	\Script\GameDefine\GameStruct_Obj.cs
 *	创建人：	Aesma
 *	创建时间：2018-8-12
 *
 *	功能说明：所有跟Obj相关的结构体
 *	修改记录：
*********************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Games.GlobeDefine;
using Games.LogicObj;

public class Obj_Init_Data
{

    public int m_SceneID;                       // 场景ID
    public int m_RoleBaseID;                    // 在RoleBase表中的ID
    public float m_fX;                          // 坐标X
    public float m_fY;                          // 坐标Y
    public float m_fZ;                          // 坐标Z
    public int m_Force;                         // 势力
    public string m_StrName;                    // Obj的名字
    public float m_fDir;                        // 朝向
    public bool m_IsDie;                        // 是否死亡
    public float m_fMoveSpeed;                   // 移动速度
    public int m_nCurLevel;                     // 等级
    public int m_nCurHp;                        // 当前气血
    public int m_nCurHealth;                    // 当前食物
    public int m_nCurWater;                     // 当前水分
    public int m_nMaxHp;                        // 气血上限
    public int m_nMaxHealth;                    // 食物上限
    public int m_nMaxWater;                     // 水分上限
    public int m_BindParent;                    // 绑定父节点
    public List<int> m_BindChildren;            // 绑定子节点
    public bool m_bIsInCombat;                  // 是否在战斗状态
    public bool m_bNpcBornCreate;               // 是否是刚刚刷出来的NPC
    public Obj_Init_Data()
    {
        m_BindChildren = new List<int>();
        CleanUp();
    }

    public void CleanUp()
    {
        m_SceneID = GlobeVar.INVALID_ID; // 场景ID
        m_RoleBaseID = GlobeVar.INVALID_ID; // 在RoleBase表中的ID
        m_fX = 0.0f; // 坐标X
        m_fY = 0.0f; // 坐标Y
        m_fZ = 0.0f; // 坐标Z
        //m_Force = (int)FORCETYPE.TYPE_INVAILD; // 势力
        m_StrName = ""; // Obj的名字
        m_fDir = 0.0f; // 朝向
        m_IsDie = false; // 是否死亡
        m_fMoveSpeed = 0.0f; // 移动速度
        m_nCurLevel = 0; // 等级
        m_nCurHp = 0; // 当前气血
        m_nCurHealth = 0; // 当前食物
        m_nCurWater = 0; // 当前水分
        m_nMaxHp = 1; // 气血上限
        m_nMaxHealth = 1; // 食物上限
        m_nMaxWater = 1; // 水分上限
        m_BindParent = -1; // 绑定父节点
        m_bIsInCombat = false; //是否在战斗状态
    }

    //初始化一个DropItemObj所需数据
    public class Obj_DropItemData
    {
        public int m_nObjID;         // 运行时ID
        public float m_fX;           // 坐标X
        public float m_fZ;           // 坐标Z
        public int m_nType;          // 掉落类型
        public int m_nItemId;        // 物品Id
        public int m_nItemCount;     // 物品数量
        public float m_NpcPosX;      // 怪物死亡时的坐标，用于做炸开的动画
        public float m_NpcPosZ;      // 怪物死亡时的坐标，用于做炸开的动画
        public void CleanUp()
        {
            m_fX = 0.0f;
            m_fZ = 0.0f;
            m_nItemId = GlobeVar.INVALID_ID;
            m_nItemCount = 0;
            m_nObjID = GlobeVar.INVALID_ID;
            m_nType = 0;
            m_NpcPosX = 0.0f;
            m_NpcPosZ = 0.0f;
        }
    }

    // 初始化一个采集物所需的数据
    public class Obj_CollectData
    {
        public int m_nObjId;        // 运行时Id
        public int m_nCollectId;    // 采集物Id
        public float m_fX;          // 坐标X
        public float m_fZ;          // 坐标Z
        public int m_Type;          // 采集物类型
        public void CleanUp()
        {
            m_nObjId = GlobeVar.INVALID_ID;
            m_nCollectId = GlobeVar.INVALID_ID;
            m_fX = 0.0f;
            m_fZ = 0.0f;
            m_Type = (int)ECollectType.ECOLLECT_NONE;
        }
    }
    //初始化 陷阱
    public class ObjSnare_Init_Data
    {
        public float m_fX;           //坐标X
        public float m_fY;           //坐标Y
        public float m_fZ;           //坐标Z
        public int m_SnareID;       //在RoleBase表中的ID
        public int m_OwnerObjId;   //主人objid
        public int m_nState;//陷阱的状态
        public float m_fDir;//陷阱的朝向
        public void CleanUp()
        {
            m_fX = 0.0f;
            m_fY = 0.0f;
            m_fZ = 0.0f;
            m_SnareID = GlobeVar.INVALID_ID;
            m_OwnerObjId = -1;
            m_nState = -1;
            m_fDir = 0.0f;
        }
    }
}
