using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Games.GlobeDefine;

namespace Games.LogicObj
{ 
    public partial class Obj_Npc : Obj_Dynamic
    {
        public Obj_Npc() { m_ObjType = OBJ_TYPE.OBJ_NPC; }
        //是否可以移动
        private bool m_CanMove;
        public bool CanMove
        {
            get { return m_CanMove; }
        }
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}