using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BagPackagePanel : BasePanel
{


    //UI
    public Button Btn_Exit;
    

    #region 生命周期
    //初始化
    public override void Init(params object[] args)
    {
        base.Init(args);
        //skinPath = "UISkin/Bag_Skin";
        layer = PanelLayer.Package;
    
    }

    public override void OnEnter()
    {
      
        base.OnEnter();
        Transform skinTrans = Panel.transform;
        Btn_Exit = skinTrans.Find("Exit").GetComponent<Button>();
      
        Btn_Exit.onClick.AddListener(Close);
        //HP = skinTrans.Find("Txt_HP").GetComponent<Text>();
        //Water = skinTrans.Find("Txt_Water").GetComponent<Text>();
        //Hunger = skinTrans.Find("Txt_Hunger").GetComponent<Text>();
    }
    #endregion
    


}
