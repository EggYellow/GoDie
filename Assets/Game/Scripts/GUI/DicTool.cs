using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DicTool {
    public static TValue MyTryGetValue<TKey, TValue>(this Dictionary<TKey, TValue> dic, TKey type)
    {
        TValue v;
        dic.TryGetValue(type, out v);
        return v;
    }
}
