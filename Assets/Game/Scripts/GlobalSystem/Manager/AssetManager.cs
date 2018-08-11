using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssetManager
{
    public static string AssetBuildPath { get { return m_assetBuildPath; } }        //Bundle资源生成路径
    public static string ResBuildPath { get { return m_resBuildPath; } }            //资源生成根路径
    public static string AssetLocalPath { get { return m_assetLocalPath; } }        //本地资源加载路径
    public static string UserDataPath { get { return m_userDataPath; } }

    public static string m_gameBuildPath
    {
        get
        {
            string rootPath = Application.dataPath.Replace("Assets", "");
            return rootPath + "Build/Game";
        }
    }
    private static string m_assetBuildPath = Application.dataPath + "/../Build/Res/ResData";
    private static string m_resBuildPath = Application.dataPath + "/../Build/Res";
    private static string m_assetLocalPath = Application.streamingAssetsPath + "/ResData";
    private static string m_userDataPath = Application.persistentDataPath + "/UserData" + GetWinPathTail();
    private static FreqAssetPool m_prefabAssetPool = new FreqAssetPool(20);


    public static string GetWinPathTail()
    {
#if UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX
#if UNITY_EDITOR
        return "/Editor";
#elif PCBUILD 
        return "/PC";
#elif MACBUILD
        return "/MAC";
#elif PCTYBUILD || MACTYBUILD
        return "/TY";
#elif PCTESTBUILD || MACTESTBUILD
        return "/Test";
#else
        return "/PCUnknown";
#endif
#endif
        return "";
    }
    #region 加载UI资源
    public static Texture2D LoadUIImage(string filePath)
    {
        Texture2D texture = Resources.Load(filePath) as Texture2D;

        return texture;
    }

    public static GameObject GetUIRoot()
    {
        GameObject obj = Resources.Load<GameObject>("GUI/UIRoot/UIRoot");
        return obj;
    }

    private static UIPanelTypeJson json;
    public static GameObject GetPanelObject(string path)
    {
        GameObject instPanel = null;
        if (path != null)
        {
            instPanel = GameObject.Instantiate(Resources.Load(path)) as GameObject;
        }

        return instPanel;
    }

    public static UIPanelTypeJson ParseUIPanelTypeJson()
    {
        if (json == null)
        {
            TextAsset t = Resources.Load<TextAsset>("UIPanelType");
            Debug.Log(t.text);
            json = JsonUtility.FromJson<UIPanelTypeJson>(t.text);
        }
        return json;
    }
    #endregion

    #region GameObject操作
    public static Object LoadResource(string resPath, System.Type systemTypeInstance = null)
    {
        UnityEngine.Object resObject = null;
        if (null == systemTypeInstance)
        {
            resObject = Resources.Load(resPath);
        }
        else
        {
            resObject = Resources.Load(resPath, systemTypeInstance);
        }
        return resObject;
    }

    public static void DestroyObj(Object objToDestroy)
    {
        if (null != objToDestroy)
        {
            Object.Destroy(objToDestroy);
        }
    }

    public static void DestroyObjImmediate(Object objToDestroy)
    {
        if (null != objToDestroy)
        {
            Object.DestroyImmediate(objToDestroy);
        }
    }

    //加载一个Resource下的资源
    public static GameObject LoadObj(string resPath, string name = null)
    {
        GameObject resObject = Resources.Load(resPath) as GameObject;
        if (null == resObject)
        {
            Debug.LogError("Load Obj Error:" + resPath);
            return null;
        }

        GameObject newObj = GameObject.Instantiate(resObject) as GameObject;
        if (null != newObj && !string.IsNullOrEmpty(name))
        {
            newObj.name = name;
        }
        return newObj;
    }

    //加载一个Resource下的资源并绑定到父节点
    public static GameObject LoadObjAndBindToParent(string resPath, Transform parentTransform, string name = null)
    {

        GameObject resObject = null;
        if (GameDefine_ClientConfig.EnableAssetFreqPool.value)
        {
            Object resPoolObj = m_prefabAssetPool.GetObjFromFreqPool(resPath);
            if (null != resPoolObj)
            {
                resObject = resPoolObj as GameObject;
            }
            else
            {
                resObject = Resources.Load(resPath) as GameObject;
                m_prefabAssetPool.RemoveFreqPoolObj(resObject, resPath);
            }
        }
        else
        {
            resObject = Resources.Load(resPath) as GameObject;
        }

        if (null == resObject)
        {
            return null;
        }

        return InstantiateObjToParent(resObject, parentTransform, name);
    }

    public static bool SetObjParent(GameObject child, Transform parent)
    {
        if (null == child || null == parent)
        {
            return false;
        }
        child.transform.parent = parent;
        child.transform.localPosition = Vector3.zero;
        child.transform.localScale = Vector3.one;
        child.transform.localRotation = Quaternion.Euler(0, 0, 0);
        return true;
    }

    // 复制物体并绑定到父节点，将坐标置0
    public static GameObject InstantiateObjToParent(UnityEngine.Object resObject, Transform parentTransform, string name = null)
    {
        if (null == resObject || null == parentTransform)
        {
            return null;
        }

        GameObject newObj = GameObject.Instantiate(resObject) as GameObject;
        if (null == newObj)
        {
            return null;
        }

        if (!SetObjParent(newObj, parentTransform))
        {
            return null;
        }

        if (null != name)
        {
            newObj.name = name;
        }
        return newObj;
    }
    #endregion
}
