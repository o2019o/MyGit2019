using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour {

    public int grade = 1;
    public int hp = 100;
    public int mp = 100;
    public int coin = 200;

    public int attack = 20;//攻击力
    public int attack_plus = 0;//攻击后加的点数，用来加攻击力的
    public int def = 20;//防御力
    public int def_plus = 0;//用来加防御力的点数
    public int speed = 20;//速度
    public int speed_plus = 0;//用来加速度的

    public int point_remain = 0;//剩余的点数，用来升级的

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    //取得金币数
    public void GetCoint(int count)
    {
        coin += count;
    }
    //取得点数, 是否还有点数
    public bool GetPoint(int point=1)
    {
        if(point_remain >= point)
        {
            point_remain -= point;
            return true;
        }
        return false;
    }
}
