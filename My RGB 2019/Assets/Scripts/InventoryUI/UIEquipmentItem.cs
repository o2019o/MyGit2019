using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 装备 的穿 和 卸下
/// </summary>
public class UIEquipmentItem : MonoBehaviour {
    public static UIEquipmentItem Instance;
    public int itemId;
    private UISprite sprite;
    ObjectInfo info;
    bool isHover = false;//是否在装备上
    private void Awake()
    {
        Instance = this;
        sprite = GetComponent<UISprite>();
    }
    public void SetId(int id)
    {
        itemId = id;
        info = ObjectsInfo._instance.GetObjectInfoById(id);
        SetItemInfo(info);
    }
    public void SetItemInfo(ObjectInfo info)
    {
        itemId = info.id;
        sprite.spriteName = info.icon_name;
    }
    //当鼠标移到 装备上
    public void OnHover(bool isOver)
    {
        isHover = isOver;
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (isHover)
        {//当鼠标在这个装备栏之上的时候，检测鼠标右键的点击
            if (Input.GetMouseButtonDown(1))
            {//鼠标右键的点击，表示卸下该装备
                UIEquipment.Instance.TakeOff(itemId,this.gameObject);
               // UIInventory.Instance.GetItem(itemId);//在 物品栏里生成 这个装备
               // Destroy(gameObject);
            }
        }
    }
}
