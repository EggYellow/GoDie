using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StatuPanel : BasePanel
{
    //UI
    public Text HP;
    public Text Water;
    public Text Hunger;
    //信息类
    #region 生命周期
    //初始化
    public override void Init(params object[] args)
    {
        base.Init(args);
        layer = PanelLayer.Statu;
       
    }

    public override void OnEnter()
    {
        base.OnEnter();
        
        Transform skinTrans = Panel.transform;
        /*HP = skinTrans.Find("Txt_HP").GetComponent<Text>();
        Water = skinTrans.Find("Txt_Water").GetComponent<Text> ();
        Hunger = skinTrans.Find("Txt_Hunger").GetComponent<Text>();
        info = GameObject.FindWithTag("Player").GetComponent<Player>().MainPlayerInfo;
    */
      
    }
 
    //状态面板帧更新
    public override void Update()
    {
        base.Update();
        /*HP.text = info.HP.ToString();
        Hunger.text = info.Starvation.ToString();
        Water.text = info.Thirsty.ToString();*/
    }

    #endregion



}