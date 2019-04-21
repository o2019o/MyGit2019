using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 技能选框的 拖动 脚本
/// </summary>
public class SkillItemIcon : UIDragDropItem {
    private int skillId;

    protected override void OnDragDropStart()
    {
        base.OnDragDropStart();
        skillId = transform.parent.GetComponent<SkillItem>().id;//得到要拖动的物品的ID
        transform.parent = transform.root;//最高层父类
        GetComponent<UISprite>().depth = 40;//层级
    }
    protected override void OnDragDropRelease(GameObject surface)
    {
        base.OnDragDropRelease(surface);
        if(surface != null && surface.tag == "ShortCut")
        {
            surface.GetComponent<ShortCutGrid>().SetSkill(skillId);
        }
    }
}
