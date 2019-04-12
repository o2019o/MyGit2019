using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 设置 什么时候 显示 什么 鼠标指针图片
/// </summary>
public class NPC : MonoBehaviour {

    //当鼠标从外面移到NPC上
    private void OnMouseEnter()
    {
        CursorManager.Instance.SetNpcTalk();// 为NPC指针图片
    }
    //当鼠标从NPC上移出去
    private void OnMouseExit()
    {
        CursorManager.Instance.SetNormal();// 为普通指针图片
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
