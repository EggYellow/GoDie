using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Games.GlobeDefine;
using Games.LogicObj;

namespace Games.Scene
{
    public class ActiveSceneLogic : MonoBehaviour
    {
        //传送点节点
        private Transform m_TeleportRoot;
        public Transform TeleportRoot
        {
            get { return m_TeleportRoot; }
            set { m_TeleportRoot = value; }
        }

        //Player节点
        public Transform CharRoot { get { return m_charRoot; } }
        private Transform m_charRoot;

        //当前场景UI根节点
        private GameObject m_UIRoot;
        public GameObject UIRoot
        {
            get { return m_UIRoot; }
            set { m_UIRoot = value; }
        }

        //当前场景节点
        private GameObject m_SceneRoot;
        public GameObject SceneRoot
        {
            get { return m_SceneRoot; }
            set { m_SceneRoot = value; }
        }

        private void Awake()
        {
            GameManager.InitGame();
            //将当前场景ActiveSceneLogic放入GameManager暂存
            GameManager.CurActiveScene = this;
            InitCurSceneLogic();
        }
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
        //由于每个场景都绑定一个ActiveSceneLogic，所以当前场景的成员变量都可以在这里进行初始化。
        //初始化当前场景变量
        private void InitCurSceneLogic()
        {
            m_UIRoot = GameObject.Find("UI Root");
            if (null == m_UIRoot)
            {
                Debug.LogWarning("can not find uiroot in curscene");
                return;
            }


            //创建角色根节点
            GameObject objCharRoot = GameObject.Find("CharRoot");

            if (objCharRoot == null)
            {
                objCharRoot = new GameObject("CharRoot");
                objCharRoot.transform.parent = transform;
            }

            m_charRoot = objCharRoot.transform;

            //创建传送点根节点
            GameObject objTeleRoot = GameObject.Find("TeleportRoot");

            if (objTeleRoot == null)
            {
                objTeleRoot = new GameObject("TeleportRoot");
                objTeleRoot.transform.parent = transform;
            }
            m_TeleportRoot = objTeleRoot.transform;
            //LoadSceneTeleport(GameManager.RunningScene);

            /*

            // 客户端采集点根节点
            GameObject objPickItemsRoot = GameObject.Find("PickItemsRoot");
            if (objPickItemsRoot == null)
            {
                objPickItemsRoot = new GameObject("PickItemsRoot");
                objPickItemsRoot.transform.parent = transform;
            }
            m_PickItemsRoot = objPickItemsRoot.transform;
            */

            GameManager.CurActiveScene = this;

            if (null == ObjManager.MainPlayer)
            {
                GameManager.PlayerDataPool.CreateMainPlayerCache.m_RoleBaseID = 0;
                GameManager.PlayerDataPool.CreateMainPlayerCache.m_fMoveSpeed = 6.0f;
                ObjManager.CreateMainPlayer();
            }
        }

        #region 传送点
        /*
        //根据当前RunningScene创建传送点
        public void LoadSceneTeleport(int nRunningScene)
        {
            //如果有数据，清空
            RemoveAllTeleport();

            //创建传送点
            foreach (KeyValuePair<int, List<Tab_Teleport>> kvp in TableManager.GetTeleport())
            {
                foreach (Tab_Teleport teleport in kvp.Value)
                {
                    CreateTeleport(teleport);
                }
            }
        }

        //创建单个传送点
        private void CreateTeleport(Tab_Teleport tel)
        {
            if (null == tel)
                return;

            if (tel.SrcSceneID != GameManager.RunningScene)
                return;

            GameObject objTeleport = AssetManager.LoadObjAndBindToParent("Prefab/Model/Teleport", m_TeleportRoot, tel.Id.ToString());
            if (null != objTeleport)
            {
                Vector3 pos = new Vector3(tel.SrcPosX, 0, tel.SrcPosZ);
                pos = ActiveSceneLogic.GetTerrainPosition(pos);

                objTeleport.transform.position = pos;

                TeleportPoint teleScript = objTeleport.GetComponent<TeleportPoint>();
                if (null != teleScript)
                {
                    teleScript.TeleportID = tel.Id;
                }
            }
        }

        //删除所有传送点
        private void RemoveAllTeleport()
        {
            if (null == m_TeleportRoot || m_TeleportRoot.childCount <= 0)
                return;

            int nTeleportCount = m_TeleportRoot.childCount;
            GameObject[] childObj = new GameObject[nTeleportCount];
            for (int i = 0; i < nTeleportCount; ++i)
            {
                childObj[i] = m_TeleportRoot.GetChild(i).gameObject;
            }

            for (int i = 0; i < childObj.Length; ++i)
            {
                if (null != childObj[i])
                {
                    GameObject.Destroy(childObj[i]);
                }
            }
        }
        */
        #endregion
    }
}