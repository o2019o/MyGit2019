using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInventoryItem : UIDragDropItem
{
    public static UIInventoryItem Instance;
    public UISprite sprite;

	// Use this for initialization
	protected override void Awake () {
        base.Awake();
        Instance = this;
        sprite = GetComponent<UISprite>();

	}
	public void SetSpriteName(string name)
    {
        sprite.spriteName = name;
    }
	// Update is called once per frame
	void Update () {
		
	}
    protected override void OnDragDropRelease(GameObject surface)
    {
        base.OnDragDropRelease(surface);
        Debug.Log(surface.gameObject);
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
                    UIInventoryItemGrid grid1 = transform.parent.GetComponent<UIInventoryItemGrid>();
                    transform.parent = surface.transform;
                    UIInventoryItemGrid grid2 = surface.GetComponent<UIInventoryItemGrid>();
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

}
