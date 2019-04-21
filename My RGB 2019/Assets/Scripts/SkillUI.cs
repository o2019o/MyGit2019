using UnityEngine;
using System.Collections;
/// <summary>
/// 加载技能
/// </summary>
public class SkillUI : MonoBehaviour {

    public static SkillUI _instance;
    private TweenPosition tween;
    private bool isShow = false;
    private PlayerStatus ps;

    public UIGrid grid;
    public GameObject skillItemPrefab;
    public int[] magicianSkillIdList;//魔法师的所有技能
    public int[] swordmanSkillIdList;//剑士的


    void Awake() {
        _instance = this;
        tween = this.GetComponent<TweenPosition>();
    }
    void Start() {
        ps = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStatus>();
        int[] idList = null;
        switch (ps.heroType)//主角类型
        {
            case PlayerType.Magician://如果是魔法师
                idList = magicianSkillIdList;
                break;
            case PlayerType.Swordman://剑士
                idList = swordmanSkillIdList;
                break;
        }
        foreach (int id in idList)
        {
            GameObject itemGo = NGUITools.AddChild(grid.gameObject, skillItemPrefab);
            grid.AddChild(itemGo.transform);
            itemGo.GetComponent<SkillItem>().SetId(id);//更新显示
        }

    }


    public void TransformState() {
        if (isShow) {
            tween.PlayReverse(); isShow = false;
        } else {
            tween.PlayForward(); isShow = true;
            UpdateShow();
        }
    }

    void UpdateShow() {
        SkillItem[] items = this.GetComponentsInChildren<SkillItem>();
        foreach (SkillItem item in items)
        {
            item.UpdateShow(ps.level);//根据等级显示 哪个技能已 解锁
        }
    }
}
