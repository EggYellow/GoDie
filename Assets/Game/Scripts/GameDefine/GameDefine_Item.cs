using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Games.GlobeDefine
{
    public partial class GlobeVar
    {

    }
    public enum ItemClass
    {
        EQUIP = 1,         //装备类
        MATERIAL = 2,         //材料类
        MEDIC = 3,         //药品类
    }

    public enum ItemSubClass_Material
    {
        MINERAL = 1,        //矿物
    }

    public enum ItemSubClass_Medic
    {
        HP = 1,             //气血药品
        HEALTH = 2,             //食物
        WATER = 3,             //水
    }
}