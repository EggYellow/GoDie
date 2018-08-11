using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Games.GlobeDefine
{
    public partial class GlobeVar
    {
        //Const 定义
        public const int INVALID_ID = -1;                   //非法ID

        //无限远
        public static Vector3 INFINITY_FAR = new Vector3(-9999.0f, -9999.0f, -9999.0f);
    }

    public enum DAMAGEBOARD_TYPE
    {
        PLAYER_TYPE_INVALID = -1,
        PLAYER_HP_UP = 0, //我方HP增加
        PLAYER_HP_DOWN, //我方HP减少
        TARGET_HPDOWN_PLAYER,//我方主角造成对方HP减少
        SKILL_NAME, //技能名
    }

    // 掉落类型
    public enum DROP_TYPE
    {
        EDROP_ITEM = 1,     // 物品
    }
}