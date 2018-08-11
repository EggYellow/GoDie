using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class GameDefine_ClientConfig
{

    private static Dictionary<string, ClientConfigBoolData> m_dicBoolData = new Dictionary<string, ClientConfigBoolData>();
    public class ClientConfigBoolData
    {
        public ClientConfigBoolData(string strKey, bool bValue)
        {
            key = strKey;
            value = bValue;

            m_dicBoolData.Add(strKey, this);
        }
        public string key;
        public bool value;
    }

    private static Dictionary<string, ClientConfigFloatData> m_dicFloatData = new Dictionary<string, ClientConfigFloatData>();
    public class ClientConfigFloatData
    {
        public ClientConfigFloatData(string strKey, float fValue)
        {
            key = strKey;
            value = fValue;

            m_dicFloatData.Add(strKey, this);
        }
        public string key;
        public float value;
    }

    private static Dictionary<string, ClientConfigIntData> m_dicIntData = new Dictionary<string, ClientConfigIntData>();
    public class ClientConfigIntData
    {
        public ClientConfigIntData(string strKey, int nValue)
        {
            key = strKey;
            value = nValue;

            m_dicIntData.Add(strKey, this);
        }
        public string key;
        public int value;
    }

    public static bool MatchBool(string name)
    {
        return m_dicBoolData.ContainsKey(name);
    }

    public static void SetBool(string name, bool bValue)
    {
        if (m_dicBoolData.ContainsKey(name))
        {
            m_dicBoolData[name].value = bValue;
        }
    }

    public static bool MatchFloat(string name)
    {
        return m_dicFloatData.ContainsKey(name);
    }

    public static void SetFloat(string name, float fValue)
    {
        if (m_dicFloatData.ContainsKey(name))
        {
            m_dicFloatData[name].value = fValue;
        }
    }

    public static bool MatchInt(string name)
    {
        return m_dicIntData.ContainsKey(name);
    }

    public static void SetInt(string name, int nValue)
    {
        if (m_dicIntData.ContainsKey(name))
        {
            m_dicIntData[name].value = nValue;
        }
    }


    public static ClientConfigBoolData NotLoadHideModel = new ClientConfigBoolData("NotLoadHideModel", true);
    //public static ClientConfigBoolData UsePanelHeadInfo = new ClientConfigBoolData("UsePanelHeadInfo", true);
    public static ClientConfigBoolData UseNPCPool = new ClientConfigBoolData("UseNPCPool", true);
    public static ClientConfigBoolData DelayUnloadRes = new ClientConfigBoolData("DelayUnloadRes", true);
    public static ClientConfigBoolData NewAutoMoveLogic = new ClientConfigBoolData("NewAutoMoveLogic", true);
    public static ClientConfigBoolData EnableOrderServer = new ClientConfigBoolData("EnableOrderServer", true);
    public static ClientConfigBoolData EnableResourcesFreqPool = new ClientConfigBoolData("EnableResourcesFreqPool", true);
    public static ClientConfigBoolData EnableAssetFreqPool = new ClientConfigBoolData("EnableAssetFreqPool", true);
    public static ClientConfigBoolData CloseBatchForLowMem = new ClientConfigBoolData("CloseBatchForLowMem", true);
    public static ClientConfigBoolData CloseBuyFormAppStore = new ClientConfigBoolData("CloseBuyFormAppStore", true);
    public static ClientConfigBoolData CloseStaticCombineOptimize = new ClientConfigBoolData("CloseStaticCombineOptimize", true);

    public static ClientConfigFloatData NPCPoolRecycleDuration = new ClientConfigFloatData("NPCPoolRecycleDuration", 60.0f);
    public static ClientConfigFloatData GrassDensityLow = new ClientConfigFloatData("GrassDensityLow", 0.25f);
    public static ClientConfigFloatData GrassDensityMid = new ClientConfigFloatData("GrassDensityMid", 0.45f);
    public static ClientConfigFloatData GrassDensityHigh = new ClientConfigFloatData("GrassDensityHigh", 1.0f);


    public static void InitDefaultConfig()
    {
        if (SystemInfo.systemMemorySize < 1500)
        {
            DelayUnloadRes.value = false;
        }
    }
}
