using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 主角的状态 类
/// </summary>
public class StatusManager : MonoBehaviour {

    public static StatusManager Instance;
    private TweenPosition tween;
    private bool isShow = false;
    private UILabel attackLabel;
    private UILabel defLabel;
    private UILabel speedLabel;
    private UILabel pointRemainLabel;
    private UILabel summaryLabel;

    private GameObject attackButton;
    private GameObject defButton;
    private GameObject speedButton;

    private PlayerStatus ps;

    private void Awake()
    {
        Instance = this;
        tween = GetComponent<TweenPosition>();
        attackLabel = transform.Find("attack_Label").GetComponent<UILabel>();
        defLabel = transform.Find("def_Label").GetComponent<UILabel>();
        speedLabel = transform.Find("speed_Label").GetComponent<UILabel>();
        pointRemainLabel = transform.Find("point_remain_Label").GetComponent<UILabel>();
        summaryLabel = transform.Find("summary_Label").GetComponent<UILabel>();

        attackButton = transform.Find("attack_plus_button").gameObject;
        defButton = transform.Find("def_plus_button").gameObject;
        speedButton = transform.Find("speed_plus_button ").gameObject;

        ps = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStatus>();
    }
    public void TransformState()
    {
        if(!isShow)
        {
            isShow = true;
            tween.PlayForward();
        }
        else
        {
            isShow = false;
            tween.PlayReverse();
        }
    }
    /// <summary>
    /// 更新显示，根据 Player 身上的PlayerStatus的属性值，去更新显示
    /// </summary>
    private void UpdateShow()
    {
        attackLabel.text = ps.attack + "+" + ps.attack_plus;
        defLabel.text = ps.def + "+" + ps.def_plus;
        speedLabel.text = ps.speed + "+" + ps.speed_plus;
        pointRemainLabel.text = ps.point_remain.ToString();//剩余的点数
        summaryLabel.text = "伤害:" + (ps.attack + ps.attack_plus) +
            "\u3000" + "防御:" + (ps.def + ps.def_plus) +
            "\u3000" + "速度:" + (ps.speed + ps.speed_plus);

        //剩余的点数多于0，就可以加各种属性值 
        if (ps.point_remain > 0)
        {
            attackButton.SetActive(true);
            defButton.SetActive(true);
            speedButton.SetActive(true);
        }
        else
        {
            attackButton.SetActive(false);
            defButton.SetActive(false);
            speedButton.SetActive(false);
        }
    }
    public void OnAttackPlusClick()
    {
        bool success = ps.GetPoint();
        if(success)
        {
            ps.attack_plus++;
            UpdateShow();
        }
    }
    public void OnDefPlusClick()
    {
        bool success = ps.GetPoint();
        if (success)
        {
            ps.def_plus++;
            UpdateShow();
        }
    }
    public void OnSpeedPlusClick()
    {
        bool success = ps.GetPoint();
        if (success)
        {
            ps.speed_plus++;
            UpdateShow();
        }
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        UpdateShow();

    }
}
