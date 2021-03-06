﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System.IO;
using System.Text;

public class ItemInfo : MonoBehaviour {
    public static ItemInfo Instance;
    private void Awake()
    {
        Instance = this;
    }
    private JsonData itemDate;
    private Dictionary<int, ObjectInfo> itemDict = new Dictionary<int, ObjectInfo>();

	void Start () {
        itemDate = JsonMapper.ToObject(File.ReadAllText(Application.streamingAssetsPath + "/ItemInfo.json", Encoding.GetEncoding("GB2312")));
        AddItemDict();
      // Debug.Log(GetObjectInfoByID(1002).Stackable);
    }
	public ObjectInfo GetObjectInfoByID(int id)
    {
        ObjectInfo info = new ObjectInfo();
        itemDict.TryGetValue(id, out info);
        return info;
    }
    // Update is called once per frame
    void Update () {
		
	}
    void AddItemDict()
    {
        for (int i = 0; i < itemDate.Count; i++)
        {
           // Debug.Log(itemDate.ToJson());
            ObjectInfo info = new ObjectInfo();
            info.Id = int.Parse(itemDate[i]["id"].ToString());
            info.Name = itemDate[i]["name"].ToString();
            info.Icon_name = itemDate[i]["icon_name"].ToString();
            info.Type = ObjectType.Drug;
            
            string type = itemDate[i]["type"].ToString();
            switch(type)
            {
                case "Drug":
                    info.Type = ObjectType.Drug;break;
                case "Equip":
                    info.Type = ObjectType.Equip; break;
                case "Mat":
                    info.Type = ObjectType.Mat; break;
            }
            if(info.Type == ObjectType.Drug)
            {
                info.Hp = int.Parse(itemDate[i]["hp"].ToString());
                info.Mp = int.Parse(itemDate[i]["mp"].ToString());
                info.Price_sell = int.Parse(itemDate[i]["price_sell"].ToString());
                info.Price_buy = int.Parse(itemDate[i]["price_buy"].ToString());
            }
            info.Stackable = bool.Parse(itemDate[i]["stackable"].ToString());
            info.StackMax = int.Parse(itemDate[i]["stackMax"].ToString());

            itemDict.Add(info.Id, info);
        }
    }
}
public enum ObjectType
{
    Drug,//药品
    Equip,//装备
    Mat,//材料
}
public class ObjectInfo
{
    public int Id;
    public string Name;
    public string Icon_name;//这个名称是存储在图集中的图片名称
    public ObjectType Type;
    public int Hp;
    public int Mp;
    public int Price_sell;
    public int Price_buy;
    public bool Stackable;
    public int StackMax;
}