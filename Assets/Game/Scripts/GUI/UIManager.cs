using System;
using System.Collections.Generic;
using UnityEngine;
public class UIManager
{
    private static UIManager instance = new UIManager();
    private Dictionary<UIPanelType, GameObject> m_PanelCache = new Dictionary<UIPanelType, GameObject>();
    private Transform m_CanvasTransform;
    private Stack<BasePanel> PanelStack = new Stack<BasePanel>();

    private UIPanelTypeJson json;
    private UIManager()
    {
        m_CanvasTransform = GameObject.Find("UIRoot").transform;
        ParseUIPanelTypeJson();
    }
    public static UIManager Instance
    {
        get { return instance; }
    }

    public void PushPanel(UIPanelType panelType)
    {
        if (PanelStack.Count != 0)
            PanelStack.Peek().OnPause();
        BasePanel panel = GetPanel(panelType);
        if (panel != null)
        {
            panel.Panel = panel.gameObject;
            PanelStack.Push(panel);
            panel.OnEnter();
        }
    }

    public void PopPanel()
    {
        if (PanelStack.Count == 0)
            return;
        BasePanel panel = PanelStack.Pop();
        panel.OnExit();
        if (PanelStack.Count != 0)
            PanelStack.Peek().OnResume();
    }

    private void ParseUIPanelTypeJson()
    {
        json = AssetManager.ParseUIPanelTypeJson();
    }

    private BasePanel GetPanel(UIPanelType panelType)
    {
        GameObject instPanel;
        if((instPanel = m_PanelCache.MyTryGetValue(panelType)) == null)
        {
            string path = null;
            foreach (var item in json.PanelList)
            {
                if (item.PanelName == panelType.ToString())
                {
                    path = item.PanelPath;
                    break;
                }
            }
            if (path != null)
            {
                instPanel = AssetManager.GetPanelObject(path);
                if (instPanel == null)
                    return null;
                instPanel.transform.SetParent(m_CanvasTransform, false);
                instPanel.AddComponent<CanvasGroup>();
                m_PanelCache.Add(panelType, instPanel);
            }
        }

        return instPanel.GetComponent<BasePanel>();
    }
}

[Serializable]
public class UIPanelTypeJson
{
    public UIPanelInfo[] PanelList;
}

[Serializable]
public class UIPanelInfo
{
    public string PanelName;
    public string PanelPath;
}
public enum PanelLayer
{
    //状态面板
    Statu,
    //背包
    Package,
}