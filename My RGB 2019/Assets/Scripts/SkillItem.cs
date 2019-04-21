using UnityEngine;
using System.Collections;
/// <summary>
/// 技能面板
/// </summary>
public class SkillItem : MonoBehaviour {

    public int id;
    private SkillInfo info;

    private UISprite iconname_sprite;
    private UILabel name_label;
    private UILabel applytype_label;
    private UILabel des_label;
    private UILabel mp_label;

    private GameObject icon_mask;//遮罩，用来解锁技能的


    void InitProperty() {
        iconname_sprite = transform.Find("Icon_name").GetComponent<UISprite>();
        name_label = transform.Find("property/name_bg/name").GetComponent<UILabel>();
        applytype_label = transform.Find("property/applytype_bg/applytype").GetComponent<UILabel>();
        des_label = transform.Find("property/des_bg/def").GetComponent<UILabel>();
        mp_label = transform.Find("property/mp_bg/mp").GetComponent<UILabel>();
        icon_mask = transform.Find("Icon_mask").gameObject;
        icon_mask.SetActive(false);
    }

    public void UpdateShow(int level) {
        if (info.level <= level)
        {//技能可用
            icon_mask.SetActive(false);
            iconname_sprite.GetComponent<SkillItemIcon>().enabled = true;
        }
        else
        {
            icon_mask.SetActive(true);
            iconname_sprite.GetComponent<SkillItemIcon>().enabled = false;// 让技能不能拖动
        }
    }

    //通过调用这个方法，来更新显示
    public void SetId(int id) {
        InitProperty();//得到属性
        this.id = id;
        info = SkillsInfo._instance.GetSkillInfoById(id);
        iconname_sprite.spriteName = info.icon_name;
        name_label.text = info.name;
        switch (info.applyType) {
            case ApplyType.Passive:
                applytype_label.text = "增益";
                break;
            case ApplyType.Buff:
                applytype_label.text = "增强";
                break;
            case ApplyType.SingleTarget:
                applytype_label.text = "单个目标";
                break;
            case ApplyType.MultiTarget:
                applytype_label.text = "群体技能";
                break;
        }
        des_label.text = info.des;
        mp_label.text = info.mp + "MP";
    }

}
