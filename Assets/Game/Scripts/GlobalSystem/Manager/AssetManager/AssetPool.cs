/********************************************************************
	created:	201//8/12
	created:	12:8:2018   02:59
	author:		Aesma
	
	purpose:	一些通用的资源池，避免频繁加载卸载资源。
*********************************************************************/
using UnityEngine;
using System.Collections.Generic;

//频率池，针对不重复obj使用，每次调用GetObjFromFreqPool都会更新当前路径物体使用频率
//Remove时如果频率大于池子中物体使用频率，或者有空间，则加入池子
//加载时，如果池子中有Obj则直接返回
public class FreqAssetPool
{
    public FreqAssetPool(int maxSize, float autoIncPercent = 0, int minRecordFreq = 0)
    {
        m_maxSize = maxSize;
        m_autoIncPercent = Mathf.Clamp01(autoIncPercent);
        m_minRecordFreq = minRecordFreq;
    }

    private float m_autoIncPercent = 0;        //自动增长比例，如果大于0，则开启自动增长模式
    private int m_maxSize = 5;
    private int m_minRecordFreq = 0;           //引用数低于某个数则不缓存
    private Dictionary<string, int> m_dicObjFreq = new Dictionary<string, int>();
    private Dictionary<string, Object> m_dicFreqObjsCache = new Dictionary<string, Object>();

    public Dictionary<string, Object> FreqObjDic { get { return m_dicFreqObjsCache; } }

    private int m_curMinFreq = -1;
    private string m_curMinFreqPath = "";

    // 清空字典，注意此防范不负责卸载数据
    public void Clean()
    {
        m_dicObjFreq.Clear();
        m_dicFreqObjsCache.Clear();
        m_curMinFreq = -1;
        m_curMinFreqPath = "";
    }

    public Object GetObjFromFreqPool(string path)
    {
        int curObjFreq = 0;
        if (m_dicObjFreq.ContainsKey(path))
        {
            curObjFreq = m_dicObjFreq[path]++;
        }
        else
        {
            m_dicObjFreq.Add(path, 1);
            curObjFreq = 1;
        }

        if (m_curMinFreq < 0)
        {
            m_curMinFreq = curObjFreq;
            m_curMinFreqPath = path;
        }
        else if (path == m_curMinFreqPath)
        {
            //重新找到最小频率资源
            ReCalMinFreqInfo();
        }

        if (m_dicFreqObjsCache.ContainsKey(path))
        {
            return m_dicFreqObjsCache[path];
        }
        return null;
    }

    //添加新的obj时调用，返回的是需要移除的obj
    public Object RemoveFreqPoolObj(Object newAddObj, string path)
    {
        //新加入的OBJ已经在缓存中，直接返回不移除
        if (m_dicFreqObjsCache.ContainsKey(path))
        {
            return null;
        }

        if (!m_dicObjFreq.ContainsKey(path))
        {
            // 不应该出现这种情况，没有配合成对使用
            return newAddObj;
        }

        int curObjFreq = m_dicObjFreq[path];

        if (curObjFreq < m_minRecordFreq)
        {
            return newAddObj;
        }

        // 如果缓存数量小于总量的某个比例，可以继续加
        if (m_dicFreqObjsCache.Count >= m_maxSize)
        {
            if (m_dicFreqObjsCache.Count < m_dicObjFreq.Count * m_autoIncPercent)
            {
                m_maxSize++;
            }
        }

        if (m_dicFreqObjsCache.Count < m_maxSize)
        {
            m_dicFreqObjsCache.Add(path, newAddObj);
            return null;
        }

        //这个时候已经满了，考虑换掉一个最小频率资源

        //如果当前资源使用频率小于最小频率，直接舍弃
        if (curObjFreq <= m_curMinFreq)
        {
            return newAddObj;
        }

        //如果找不到最小频率资源（异常情况）重新计算最小资源
        if (!m_dicFreqObjsCache.ContainsKey(m_curMinFreqPath))
        {
            ReCalMinFreqInfo();
            return newAddObj;
        }

        Object cachingObj = m_dicFreqObjsCache[m_curMinFreqPath];
        m_dicFreqObjsCache.Remove(m_curMinFreqPath);
        m_dicFreqObjsCache.Add(path, newAddObj);

        m_curMinFreqPath = path;
        m_curMinFreq = curObjFreq;

        return cachingObj;
    }

    //重新计算最小频率资源
    void ReCalMinFreqInfo()
    {
        m_curMinFreq = int.MaxValue;
        foreach (string cachingObjPath in m_dicFreqObjsCache.Keys)
        {
            if (m_dicObjFreq.ContainsKey(cachingObjPath))
            {
                if (m_dicObjFreq[cachingObjPath] < m_curMinFreq)
                {
                    m_curMinFreq = m_dicObjFreq[cachingObjPath];
                    m_curMinFreqPath = cachingObjPath;
                }
            }
        }
    }

    public string StatusLog()
    {
        string strLog = "pool max size:" + m_maxSize.ToString() + "\n";
        strLog += "object freq:\n";
        foreach (var pair in m_dicObjFreq)
        {
            strLog += "  name:" + pair.Key + " value:" + pair.Value + "\n";
        }

        strLog += "object caching:\n";
        foreach (var pair in m_dicFreqObjsCache)
        {
            strLog += "  name:" + pair.Key;
        }

        strLog += "\n";
        return strLog;
    }

}

