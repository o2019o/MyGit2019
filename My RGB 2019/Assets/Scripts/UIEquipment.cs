using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 添加 装备 类
/// </summary>
public class UIEquipment : MonoBehaviour {
    public static UIEquipment Instance;

    private TweenPosition tween;
    private bool isShow = false;
    //几个装备框
    private GameObject headgear;
    private GameObject armor;
    private GameObject rightHand;
    private GameObject leftHand;
    private GameObject shoe;
    private GameObject accessory;

    private void Awake()
    {
        Instance = this;
        tween = GetComponent<TweenPosition>();

        headgear = transform.Find("Headgear").gameObject;
        armor = transform.Find("Armor").gameObject;
        rightHand = transform.Find("RightHand").gameObject;
        leftHand = transform.Find("LeftHand").gameObject;
        shoe = transform.Find("Shoe").gameObject;
        accessory = transform.Find("Accessory").gameObject;
    }
    public void TransformState()
    {
        if(!isShow)
        {
            isShow = true;
            tween.PlayForward();
        }else
        {
            isShow = false;
            tween.PlayReverse();
        }
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
