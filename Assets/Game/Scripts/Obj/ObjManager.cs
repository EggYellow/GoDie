using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Games.GlobeDefine;
using Games.LogicObj;
using Games.Scene;

public class ObjManager

{    //当前客户端主角色
    private static Obj_Player m_MainPlayer;
    public static Obj_Player MainPlayer
    {
        get { return m_MainPlayer; }
    }

    //创建主角
    private static bool m_bBeginAsycCreateMainPlayer = false;
    public static void CreateMainPlayer()
    {
        if (true == m_bBeginAsycCreateMainPlayer && null != m_MainPlayer || null == GameManager.CurActiveScene)
        {
            return;
        }
        //所有的玩家都创建自固定的PlayerRoot的Prefab，具体模型在PlayerRoot下建立Model节点
        GameObject mainPlayer = AssetManager.LoadObjAndBindToParent("Prefab/Model/PlayerRoot", GameManager.CurActiveScene.CharRoot, "MainPlayer") as GameObject;
        if (null == m_MainPlayer)
        {               
            //先加载逻辑
            m_MainPlayer = Utils.TryAddComponent<Obj_Player>(mainPlayer);
            //Clear the mainplayer attr cache when create finished
            m_MainPlayer.ClearPlayerAttrCache();

            //AddPoolObj(m_MainPlayer.ServerID.ToString(), m_MainPlayer);

            //ObjMainPlayer初始化完成
            m_MainPlayer.CanLogic = true;
        }
    }
}

