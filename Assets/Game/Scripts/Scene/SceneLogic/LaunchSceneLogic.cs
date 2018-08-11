using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchSceneLogic : MonoBehaviour
{
    private GameObject m_UIRoot;

    private void Awake()
    {
        GameObject obj = AssetManager.GetUIRoot();
        if (obj != null)
        {
            m_UIRoot = GameObject.Instantiate(obj);
            m_UIRoot.name = "UIRoot";
            DontDestroyOnLoad(m_UIRoot);
        }
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
