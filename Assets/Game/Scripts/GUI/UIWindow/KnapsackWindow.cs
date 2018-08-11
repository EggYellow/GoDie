using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Games.GlobeDefine;
using Games.LogicObj;
using Games.Item;

public class KnapsackWindow : MonoBehaviour
{

    public KnapsackItem m_KnapsackItem;
    public Grid m_ItemGrid;
    public Text m_PlayerName;

    private List<KnapsackItem> m_BackPackItemObjects = new List<KnapsackItem>();
    private List<Image> m_BackPackItemSprites = new List<Image>();

    private static KnapsackWindow m_Instance = null;
    public static KnapsackWindow Instance()
    {
        return m_Instance;
    }

    private KnapsackItem m_curSelectedItem = null;

    private ItemPack.Type m_CurPackType = ItemPack.Type.TYPE_BACKPACK;

    public ItemPack.Type CurPackType
    {
        get { return m_CurPackType; }
    }

    void Awake()
    {
        m_Instance = this;
        Init();
    }

    void OnEnable()
    {
        UpdateData();
        PlayerData.delegateBackPackItemChanged += UpdateData_CurPack;
    }

    void OnDisable()
    {
        PlayerData.delegateBackPackItemChanged -= UpdateData_CurPack;
    }

    void OnDestroy()
    {
        m_Instance = null;
    }

    public void Init()
    {
        Init_BackPack();

    }

    public void Init_BackPack()
    {
    }

    public void UpdateData()
    {
        UpdateData_CurPack();
    }

    public void UpdateData_CurPack()
    {

    }
}
