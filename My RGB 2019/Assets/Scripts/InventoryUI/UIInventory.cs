using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInventory : MonoBehaviour {
    public static UIInventory Instance;
    public List<UIInventoryItemGrid> itemGridList = new List<UIInventoryItemGrid>();
    public GameObject inventoryItem;
    private TweenPosition tween;

    public int coinCount = 1000;
    public UILabel coinLabel;

    private void Awake()
    {
        Instance = this;
        tween = GetComponent<TweenPosition>();
        coinLabel = GameObject.Find("CoinLabel").GetComponent<UILabel>();
    }
    void Start () {
        
        foreach (UIInventoryItemGrid child in GetComponentsInChildren<UIInventoryItemGrid>())
        {
            itemGridList.Add(child);
        }

    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.F))
        {
            int itemID = Random.Range(2001,2023);
            GetItem(itemID,1);
          //  Debug.Log(itemID);
        }
    }
    public void GetItem(int id,int count=1)//count 购买的数量
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
            grid.PulsName(count);
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
                grid.SetGridId(id,count);
            }
        }
    }
    /// <summary>
    /// 显示 和隐藏背包
    /// </summary>
    private bool isShow = false;
    private void Show()
    {
        isShow = true;
        tween.PlayForward();
    }
    private void Hide()
    {
        isShow = false;
        tween.PlayReverse();
    }
    //移动位置
    public void ChangePos()
    {
        if (!isShow)
        {
            Show();
        }
        else
            Hide();
    }
    //这个是取款方法，购买物品时调用，来减少金币
    public bool GetCoin(int count)
    {
        if(coinCount >= count)
        {
            coinCount -= count;
            coinLabel.text = coinCount.ToString();//更新金币 显示
            return true;
        }
        return false;
    }
}
