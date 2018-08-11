using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Games.LogicObj
{
    public partial class Obj : MonoBehaviour {
        //位置
        public Vector3 Position
        {
            get { return ObjTransform.localPosition; }
            set { ObjTransform.localPosition = value; }
        }

        //旋转
        public Quaternion Rotation
        {
            get { return ObjTransform.localRotation; }
            set { ObjTransform.localRotation = value; }
        }

        //缩放
        public Vector3 Scale
        {
            get { return ObjTransform.localScale; }
            set { ObjTransform.localScale = value; }
        }
        public void SetScale(float fScale)
        {
            if (null != gameObject)
            {
                ObjTransform.localScale = Vector3.one * fScale;
            }
        }

        private CapsuleCollider m_ObjCollider = null;      //Obj的包围盒
        public CapsuleCollider ObjCollider
        {
            get
            {
                if (null == m_ObjCollider)
                {
                    m_ObjCollider = gameObject.GetComponent<CapsuleCollider>();
                }
                return m_ObjCollider;
            }
        }

        //模型节点
        private GameObject m_ModelNode = null;
        public UnityEngine.GameObject ModelNode
        {
            get { return m_ModelNode; }
            set { m_ModelNode = value; }
        }

        //逻辑相关数据，包括是否可以运行、服务器ID、模型ID等
        protected bool m_bCanLogic = false;
        public bool CanLogic
        {
            get { return m_bCanLogic; }
            set { m_bCanLogic = value; }
        }

        protected int m_ServerID;
        public int ServerID
        {
            get { return m_ServerID; }
            set { m_ServerID = value; }
        }

        protected int m_ModelID;
        public int ModelID
        {
            get { return m_ModelID; }
            set { m_ModelID = value; }
        }

    }

}