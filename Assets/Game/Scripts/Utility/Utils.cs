/********************************************************************
    purpose:	工具类，放置一些功能无关的通用工具函数
*********************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Utils
{
    #region General
    public static T TryAddComponent<T>(GameObject obj) where T : Component
    {
        if (null == obj) return null;
        T curComponent = obj.GetComponent<T>();
        if (null == curComponent)
        {
            curComponent = obj.AddComponent<T>();
        }

        return curComponent;
    }
    #endregion
}
