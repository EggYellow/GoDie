using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Games.GlobeDefine;

namespace Games.LogicObj
{
    public partial class Obj_Player : Obj_Dynamic
    {
        public Obj_Player()
        {
            m_ObjType = OBJ_TYPE.OBJ_PLAYER;
        }

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
        public void ClearPlayerAttrCache()
        {
            if (null != GameManager.PlayerDataPool.CreateMainPlayerCache)
            {
                GameManager.PlayerDataPool.CreateMainPlayerCache.CleanUp();
            }
        }

    }
}