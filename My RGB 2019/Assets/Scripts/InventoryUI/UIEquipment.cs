using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 添加 装备 类
/// </summary>
public class UIEquipment : MonoBehaviour {
    public static UIEquipment Instance;

    private TweenPosition tween;
    private bool isShow = false;
    //几个装备框
    private GameObject headgear;
    private GameObject armor;
    private GameObject rightHand;
    private GameObject leftHand;
    private GameObject shoe;
    private GameObject accessory;

    private PlayerStatus ps;
    public GameObject equipmentItem;//装备物品
    //穿上装备后加的 属性
    public int attack = 0;
    public int def = 0;
    public int speed = 0;

    private void Awake()
    {
        Instance = this;
        tween = GetComponent<TweenPosition>();
        ps = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStatus>();

        headgear = transform.Find("Headgear").gameObject;
        armor = transform.Find("Armor").gameObject;
        rightHand = transform.Find("RightHand").gameObject;
        leftHand = transform.Find("LeftHand").gameObject;
        shoe = transform.Find("Shoe").gameObject;
        accessory = transform.Find("Accessory").gameObject;
    }
    public void TransformState()
    {
        if(!isShow)
        {
            isShow = true;
            tween.PlayForward();
        }else
        {
            isShow = false;
            tween.PlayReverse();
        }
    }
    //穿上装备 
    //处理装备穿戴功能
    public bool Dress(int id)
    {
        ObjectInfo info = ObjectsInfo._instance.GetObjectInfoById(id);
        if (info.type != ObjectType.Equip)
        {
            return false;//穿戴不成功
        }
        if (ps.heroType == PlayerType.Magician)
        {
            if (info.applicationType == ApplicationType.Swordman)
            {
                return false;
            }
        }
        if (ps.heroType == PlayerType.Swordman)
        {
            if (info.applicationType == ApplicationType.Magician)
            {
                return false;
            }
        }

        GameObject parent = null;
        switch (info.dressType)
        {
            case DressType.Headgear:
                parent = headgear;
                break;
            case DressType.Armor:
                parent = armor;
                break;
            case DressType.RightHand:
                parent = rightHand;
                break;
            case DressType.LeftHand:
                parent = leftHand;
                break;
            case DressType.Shoe:
                parent = shoe;
                break;
            case DressType.Accessory:
                parent = accessory;
                break;
        }
        UIEquipmentItem item = parent.GetComponentInChildren<UIEquipmentItem>();
        if (item != null)
        {//说明已经穿戴了同样类型的装备
            UIInventory.Instance.GetItem(item.itemId);//把已经穿戴的装备卸下，放回物品栏
            item.SetItemInfo(info);
        }
        else
        {//没有穿戴同样类型的装备
            GameObject itemGo = NGUITools.AddChild(parent, equipmentItem);
            itemGo.transform.localPosition = Vector3.zero;
            itemGo.GetComponent<UIEquipmentItem>().SetItemInfo(info);
        }
        UpdateProperty();
        return true;
    }
    //  卸下装备
    public void TakeOff(int id, GameObject go)
    {

        UIInventory.Instance.GetItem(id);//在 物品栏里生成 这个装备
        GameObject.Destroy(go);
        UpdateProperty();
    }
    //更新 穿上装备后 的人物 属性
    void UpdateProperty()
    {
        this.attack = 0;
        this.def = 0;
        this.speed = 0;

        UIEquipmentItem headgearItem = headgear.GetComponentInChildren<UIEquipmentItem>();
        PlusProperty(headgearItem);
        UIEquipmentItem armorItem = armor.GetComponentInChildren<UIEquipmentItem>();
        PlusProperty(armorItem);
        UIEquipmentItem leftHandItem = leftHand.GetComponentInChildren<UIEquipmentItem>();
        PlusProperty(leftHandItem);
        UIEquipmentItem rightHandItem = rightHand.GetComponentInChildren<UIEquipmentItem>();
        PlusProperty(rightHandItem);
        UIEquipmentItem shoeItem = shoe.GetComponentInChildren<UIEquipmentItem>();
        PlusProperty(shoeItem);
        UIEquipmentItem accessoryItem = accessory.GetComponentInChildren<UIEquipmentItem>();
        PlusProperty(accessoryItem);
    }

    void PlusProperty(UIEquipmentItem item)
    {
        if (item != null)
        {
            ObjectInfo equipInfo = ObjectsInfo._instance.GetObjectInfoById(item.itemId);
            this.attack += equipInfo.attack;
            this.def += equipInfo.def;
            this.speed += equipInfo.speed;
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
