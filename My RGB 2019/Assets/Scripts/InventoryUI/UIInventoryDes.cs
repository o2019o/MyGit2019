using System.Collections;
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
