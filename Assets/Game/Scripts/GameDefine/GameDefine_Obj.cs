using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Games.GlobeDefine
{
    public partial class GlobeVar
    {

    }
    //Obj类型
    public enum OBJ_TYPE
    {
        OBJ,
        OBJ_STATIC,
        OBJ_DYNAMIC,
        OBJ_CHAR,
        OBJ_NPC,
        OBJ_PLAYER,
        OBJ_DROP_ITEM,
        OBJ_SNARE
    }


    //Obj动作类型
    public enum OBJ_ANIMSTATE
    {
        STATE_INVAILD = -1,
        STATE_NORMOR = 0,//待机状态
        STATE_WALK = 1,//行走状态
        STATE_HIT = 2,//受击状态
        STATE_DEATH = 3,//死亡状态
        STATE_CORPSE = 4,//尸体状态
        STATE_HIT_FROMNPC = 5,//受击来源于NPC
    }
}
