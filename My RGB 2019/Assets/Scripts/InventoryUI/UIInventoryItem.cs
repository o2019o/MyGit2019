using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInventoryItem : UIDragDropItem
{
    public static UIInventoryItem Instance;
    public UISprite sprite;
    public int itemId;
	// Use this for initialization
	protected override void Awake () {
        base.Awake();
        Instance = this;
        sprite = GetComponent<UISprite>();

	}
    public void SetSpriteName(int id, string name)
    {
        itemId = id;
        sprite.spriteName = name;
    }
    // Update is called once per frame
    protected override void Update () {
        base.Update();
        if(isHover)
        {
            UIInventoryDes.Instance.ShowInfo(itemId);          
        }
	}
    /// <summary>
    /// 拖动和交换物品位置
    /// </summary>
    /// <param name="surface"></param>
    protected override void OnDragDropRelease(GameObject surface)
    {
        base.OnDragDropRelease(surface);
       // Debug.Log(surface.gameObject);
        if(surface != null)
        {
            if(surface.tag == Tags.InventoryItemGrid)
            {
                if(surface == transform.parent.gameObject)
                {
                    ResetPosition();
                }
                else
                {
                    //得到这个 要拖动的物品的父类格子，在得到要落下的 格子，在设置这个格子为物品的父类
                    //在设置要 落下的格子 里的这个物品的属性
                    UIInventoryItemGrid grid1 = transform.parent.GetComponent<UIInventoryItemGrid>();                  
                    UIInventoryItemGrid grid2 = surface.GetComponent<UIInventoryItemGrid>();
                    transform.parent = surface.transform;
                    grid2.SetGridId(grid1.gridID, grid1.itemNum);
                    grid1.CheakItem();
                }
            }
            else if(surface.tag == Tags.InventoryItem)
            {
                UIInventoryItemGrid grid1 = transform.parent.GetComponent<UIInventoryItemGrid>();
                UIInventoryItemGrid grid2 = surface.transform.parent. GetComponent<UIInventoryItemGrid>();
                int id = grid1.gridID; int num = grid1.itemNum;
                grid1.SetGridId(grid2.gridID, grid2.itemNum);
                grid2.SetGridId(id, num);
            }

        }
        ResetPosition();
    }
    void ResetPosition()
    {
        transform.localPosition = Vector3.zero;
    }
    /// <summary>
    /// 显示物品属性
    /// </summary>
    private bool isHover = false;
    public void OnHoverOver()
    {
        isHover = true;
    }
    public void OnHoverOut()
    {
        isHover = false;
    }
}
