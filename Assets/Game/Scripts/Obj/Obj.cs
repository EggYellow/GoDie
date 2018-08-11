using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Games.GlobeDefine;


namespace Games.LogicObj
{
    public partial class Obj : MonoBehaviour
    {
        public Obj()
        {
            m_ObjType = OBJ_TYPE.OBJ;
        }
        //Obj类型
        protected OBJ_TYPE m_ObjType;
        public OBJ_TYPE ObjType
        {
            get { return m_ObjType; }
        }

        private Transform m_ObjTransform = null;
        public Transform ObjTransform
        {
            get
            {
                if (null == m_ObjTransform)
                {
                    m_ObjTransform = transform;
                }
                return m_ObjTransform;
            }
        }
        // Use this for initialization
        #region 类型判断

        public bool IsNpc()
        {
            return (ObjType == OBJ_TYPE.OBJ_NPC);
        }
        public bool IsPlayer ()
        {
            return ObjType == OBJ_TYPE.OBJ_PLAYER;
        }
        #endregion
    }
}