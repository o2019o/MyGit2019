using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIEquipment : MonoBehaviour {
    public static UIEquipment Instance;
    private void Awake()
    {
        Instance = this;
        tween = GetComponent<TweenPosition>();
    }
    private TweenPosition tween;
    private bool isShow = false;
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
