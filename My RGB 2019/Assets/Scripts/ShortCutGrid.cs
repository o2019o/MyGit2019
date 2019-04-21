using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 6个 快捷框
/// </summary>
public enum ShortCutType{// 快捷框类型
    Skill,//技能
    Drug,//药品
    None
}
public class ShortCutGrid : MonoBehaviour {
    private UISprite icon;
    private int shortID;
    public ShortCutType type = ShortCutType.None;
    private SkillInfo info;
    private void Awake()
    {
        icon = transform.Find("icon (1)").GetComponent<UISprite>();
        icon.gameObject.SetActive(false);
    }
    public void SetSkill(int id)
    {
        shortID = id;
        info = SkillsInfo._instance.GetSkillInfoById(id);
        icon.gameObject.SetActive(true);
        icon.spriteName = info.icon_name;
        type = ShortCutType.Skill;
    }
    public void SetInventory(int id)
    {

    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
