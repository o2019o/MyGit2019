using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 购买物品的NPC
/// </summary>
public class ShopDrugNPC : NPC {
    public TweenPosition shopDrugTween;
    private GameObject NumberDiglog;//购买数量确定小面板，在ShopDrugPanle里面
    private UIInput NumberInput;
    private int buy_Id = 0;//购买的是哪一个，找对应的ID
    //private UILabel label;
    public void OnMouseOver()
    {
        if(Input.GetMouseButtonDown(0))
        {
            GetComponent<AudioSource>().Play();
            TransformState();
        }
    }
    void Start()
    {
        NumberDiglog = GameObject.Find("NumberDiglog");
        NumberInput = NumberDiglog.GetComponentInChildren<UIInput>();
        NumberDiglog.SetActive(false);
       // label = NumberDiglog.transform.GetChild(0).GetComponentInChildren<UILabel>();
    }
    /// <summary>
    /// 显示 和 隐藏 购买框
    /// </summary>
    bool isShow = false;
    public void TransformState()
    {
        if(!isShow)
        {
            isShow = true;
            shopDrugTween.PlayForward();
        }
        else
        {
            isShow = false;
            shopDrugTween.PlayReverse();
        }
    }
    //取消按钮，也可以 隐藏购买框 
    public void OnCloseButtonClick()
    {
        TransformState();
    }
    //购买物品的按钮
    public void OnBuyId1001()
    {
        Buy(1001);
    }
    public void OnBuyId1002()
    {
        Buy(1002);
    }
    public void OnBuyId1003()
    {
        Buy(1003);
    }
    void Buy(int id)
    {
        ShowNumberDiglog();
        buy_Id = id;
    }
    void ShowNumberDiglog()
    {
        NumberDiglog.SetActive(true);
        NumberInput.value = "0";//每显示一次的时候让它 归0
    }
    //购买数确定按钮
    public void OnOKButtonClick()
    {
        int count = int.Parse(NumberInput.value);//得到输入数量
        ObjectInfo info = ItemInfo.Instance.GetObjectInfoByID(buy_Id);
        int price = info.Price_buy;//得到购买价格
        int price_total = price * count;//得到总价
        bool success = UIInventory.Instance.GetCoin(price_total);//判断总价是否买的起
        if(success)
        {
            if(count > 0)
            {
                UIInventory.Instance.GetItem(buy_Id, count);//就更新UIInventory里的物品数量
            }
        }
        NumberDiglog.SetActive(false);
    }
    // Use this for initialization

	
	// Update is called once per frame
	void Update () {
		
	}
}
