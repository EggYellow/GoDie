/********************************************************************************
 *	文件名：	GameManager.cs
 *	全路径：	\Script\GlobalSystem\Manager\GameManager.cs
 *	创建人：	Aemsa
 *	创建时间：2018-08-12
 *
 *	功能说明：游戏全局管理器，在第一次进入游戏后加载
 *	修改记录：
*********************************************************************************/
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Games.GlobeDefine;
using Games.LogicObj;
using Games.Scene;

public class GameManager
{
    public static PlayerData m_PlayerDataPool = new PlayerData();
    public static PlayerData PlayerDataPool
    {
        get { return m_PlayerDataPool; }
        set { m_PlayerDataPool = value; }
    }
    //当前激活场景
    private static ActiveSceneLogic m_CurActiveScene = null;
    public static ActiveSceneLogic CurActiveScene
    {
        get { return m_CurActiveScene; }
        set { m_CurActiveScene = value; }
    }

    private static int m_RunningScene = 0;
    public static int RunningScene
    { // 这个值是和sceneclass的id对应的
        get { return m_RunningScene; }
        set { m_RunningScene = value; }
    }


    public static void InitGame()
    {
        ObjManager.CreateMainPlayer();
    }

    public static void ChangeScene(int id)
    {

    }
}
