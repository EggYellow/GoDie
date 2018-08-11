using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePanel : MonoBehaviour {

    protected CanvasGroup canvas;
    //层级
    public PanelLayer layer;
    //面板参数
    public object[] args;

    public GameObject Panel;
    // Use this for initialization
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    void Start() {

    }
    public virtual void Init(params object[] args)
    {
        this.args = args;
    }
    // Update is called once per frame
    public virtual void Update() {

    }

    public virtual void OnEnter()
    {
        if (canvas == null)
            canvas = this.GetComponent<CanvasGroup>();
        canvas.alpha = 1;
        canvas.blocksRaycasts = true;
        print("Open");
    }

    public virtual void OnPause()
    {
        print("OnPause");
    }

    public virtual void OnResume()
    {
        print("OnResume");
    }

    public virtual void OnExit()
    {
        canvas.alpha = 0;
        canvas.blocksRaycasts = false;
        print("Close");
    }

    public void Close()
    {
        UIManager.Instance.PopPanel();
    }
}
