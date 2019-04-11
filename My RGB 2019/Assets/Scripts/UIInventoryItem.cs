using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInventoryItem : UIDragDropItem
{
    public UISprite sprite;
	// Use this for initialization
	void Awake () {
        sprite = GetComponent<UISprite>();
	}
	public void SetSpriteName(string name)
    {
        sprite.spriteName = name;
    }
	// Update is called once per frame
	void Update () {
		
	}
    protected override void OnDragDropRelease(GameObject surface)
    {
        base.OnDragDropRelease(surface);
    }
}
