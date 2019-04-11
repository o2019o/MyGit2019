using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInventory : MonoBehaviour {
    public static UIInventory Instance;
    public List<UIInventoryItemGrid> itemGridList = new List<UIInventoryItemGrid>();
    public GameObject inventoryItem;
    private TweenPosition tween;
    private void Awake()
    {
        Instance = this;
        tween = GetComponent<TweenPosition>();
    }
    void Start () {
        
        foreach (UIInventoryItemGrid child in GetComponentsInChildren<UIInventoryItemGrid>())
        {
            itemGridList.Add(child);
        }

    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.S))
        {
            int itemID = Random.Range(1001, 1004);
            GetItem(itemID);
          //  Debug.Log(itemID);
        }
    }
    public void GetItem(int id)
    {
        UIInventoryItemGrid grid = null;
        foreach(UIInventoryItemGrid temp in itemGridList)
        {
            if(temp.gridID == id)
            {
                grid = temp;break;
            }
        }
        if(grid != null)
        {
            grid.PulsName();
        }
        else
        {
            foreach (UIInventoryItemGrid temp in itemGridList)
            {
                if(temp.gridID == 0)
                {
                    grid = temp;break;
                }
            }
            if (grid != null)
            {
                GameObject item = Instantiate(inventoryItem);
                item.transform.SetParent(grid.transform);
                item.transform.localPosition = Vector3.zero;
                item.transform.localScale = Vector3.one;
                grid.SetGridId(id);
            }
        }
    }
    private bool isShow = true;

    public void Show()
    {
        isShow = true;
        tween.PlayForward();
    }
    public void Hide()
    {
        isShow = false;
        tween.PlayReverse();
    }
    public void ChangePos()
    {
        if (isShow)
        {
            Hide();
        }
        else
            Show();
    }
}
