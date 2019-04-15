using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInventoryItemGrid : MonoBehaviour {
    public int gridID = 0;
    public int itemNum = 0;
    public UILabel numLabel;
    ObjectInfo info = null;
    // Use this for initialization
    void Start () {
        numLabel = GetComponentInChildren<UILabel>();
        numLabel.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void SetGridId(int id ,int num = 1)
    {
        gridID = id;
        info = ObjectsInfo._instance.GetObjectInfoById(id);
        UIInventoryItem item = GetComponentInChildren<UIInventoryItem>();
        item.SetSpriteName(id,info.icon_name);
        numLabel.enabled = true;
        itemNum = num;
        numLabel.text = itemNum.ToString();
    }
    public void PulsName(int unm=1)
    {
        itemNum += unm;
        numLabel.text = itemNum.ToString();
    }
    //用来减去数量的，可以用来装备的穿戴,返回值，表示是否减去成功
    public bool MinusNumber(int num = 1)
    {
        if (this.itemNum >= num)//当前的数量大于 要减去 的数量
        {
            this.itemNum -= num;
            numLabel.text = this.itemNum.ToString();//减了之后 ，要更新显示
            if (this.itemNum == 0)
            {
                //要清空这个物品格子
                CheakItem();//清空存储的信息 
                Destroy(this.GetComponentInChildren<UIInventoryItem>().gameObject);//销毁物品格子
            }
            return true;
        }
        return false;
    }
    public void CheakItem()
    {
        gridID = 0;
        itemNum = 0;
        info = null;
        numLabel.enabled = false;
    }
}
