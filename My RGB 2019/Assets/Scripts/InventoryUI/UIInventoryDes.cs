﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInventoryDes : MonoBehaviour {
    private  static UIInventoryDes instance;
    public static UIInventoryDes Instance
    {
        get
        {
            if(instance == null)
            {
                instance = new UIInventoryDes();
            }
            return instance;
        }
    }
    private UILabel infoLabel;
    private float timer;
    private void Awake()
    {
        instance = this;
    }
    void Start () {
        infoLabel = GetComponentInChildren<UILabel>();
        gameObject.SetActive(false);
	}
	
    public void ShowInfo(int id)
    {
        transform.position = UICamera.currentCamera.ScreenToWorldPoint(Input.mousePosition);
        gameObject.SetActive(true);
        timer = 0.1f;

        ObjectInfo info = ObjectsInfo._instance.GetObjectInfoById(id);
        string des = "";
        switch (info.type)
        {
            case ObjectType.Drug:
                des = GetFoodDes(info);
                break;
            case ObjectType.Equip:
                des = GetEquipDes(info);
                break;
        }
        infoLabel.text = des;
    }
    private string GetFoodDes(ObjectInfo info)
    {
        string str = "";
        str += "名称：" + info.name + "\n";
        str += "+HP：" + info.hp + "\n";
        str += "+MP：" + info.mp + "\n";
        str += "出售价：" + info.price_sell + "\n";
        str += "购买价：" + info.price_buy + "\n";
        return str;
    }
    string GetEquipDes(ObjectInfo info)
    {
        string str = "";
        str += "名称：" + info.name + "\n";
        switch (info.dressType)
        {
            case DressType.Headgear:
                str += "穿戴类型：头盔\n";
                break;
            case DressType.Armor:
                str += "穿戴类型：盔甲\n";
                break;
            case DressType.LeftHand:
                str += "穿戴类型：左手\n";
                break;
            case DressType.RightHand:
                str += "穿戴类型：右手\n";
                break;
            case DressType.Shoe:
                str += "穿戴类型：鞋\n";
                break;
            case DressType.Accessory:
                str += "穿戴类型：饰品\n";
                break;
        }
        switch (info.applicationType)
        {
            case ApplicationType.Swordman:
                str += "适用类型：剑士\n";
                break;
            case ApplicationType.Magician:
                str += "适用类型：魔法师\n";
                break;
            case ApplicationType.Common:
                str += "适用类型：通用\n";
                break;
        }

        str += "伤害值：" + info.attack + "\n";
        str += "防御值：" + info.def + "\n";
        str += "速度值：" + info.speed + "\n";

        str += "出售价：" + info.price_sell + "\n";
        str += "购买价：" + info.price_buy;

        return str;
    }
    void Update () {
		if(gameObject.activeInHierarchy)
        {
            timer -= Time.deltaTime;
            if(timer <= 0)
            {
                gameObject.SetActive(false);
            }
        }
	}
}
