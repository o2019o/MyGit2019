using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 所有鼠标指针图片的设置
/// </summary>
public class CursorManager : MonoBehaviour {
    public static CursorManager Instance;
    private void Awake()
    {
        Instance = this;
    }
    public Texture2D cursor_normal;//默认指针
    public Texture2D cursor_npc;
    public Texture2D cursor_attack;
    public Texture2D cursor_lockTarget;
    public Texture2D cursor_pick;
    private Vector2 hotspot = Vector2.zero;//指针位置
    private CursorMode mode = CursorMode.Auto;//指针类型
    //默认指针
    public void SetNormal()
    {
        Cursor.SetCursor(cursor_normal, hotspot, mode);
    }
    //点在NPC上
    public void SetNpcTalk()
    {
        Cursor.SetCursor(cursor_npc, hotspot, mode);
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
