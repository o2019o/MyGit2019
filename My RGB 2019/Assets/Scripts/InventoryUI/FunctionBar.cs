using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunctionBar : MonoBehaviour {
    public void OnStatusButton()
    {
        StatusManager.Instance.TransformState();
    }
    public void OnBagButtonClick()
    {
        UIInventory.Instance.ChangePos();
    }
    public void OnEquipButtonClick()
    {
        UIEquipment.Instance.TransformState();
    }
    public void OnSkillButtonClick()
    {
        SkillUI._instance.TransformState();
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
