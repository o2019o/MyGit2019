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
        info = ItemInfo.Instance.GetObjectInfoByID(id);
        UIInventoryItem item = GetComponentInChildren<UIInventoryItem>();
        item.SetSpriteName(id,info.Icon_name);
        numLabel.enabled = true;
        itemNum = num;
        numLabel.text = itemNum.ToString();
    }
    public void PulsName(int unm=1)
    {
        itemNum += unm;
        numLabel.text = itemNum.ToString();
    }
    public void CheakItem()
    {
        gridID = 0;
        itemNum = 0;
        info = null;
        numLabel.enabled = false;
    }
}
