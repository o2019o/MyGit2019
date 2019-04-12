using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 接受任务的NPC 对话框 类
/// </summary>
public class BarNPC : NPC {
    public TweenPosition questTween;
    public bool isInTask = false;//表示是否在任务中
    public int killCount = 0;//表示任务进度，已经杀死几只狼
    public UILabel desLabel;
    public GameObject acceptBtn;
    public GameObject okBtn;
    public GameObject cancelBtn;

    private PlayerStatus status;

    void Start()
    {
        status = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStatus>();
    }
    void Update()
    {

    }
    //当鼠标移到NPC上，这是点击鼠标事件，OnMouseOver是一直调用，OnMouseEnter是只调用一次
    private void OnMouseOver()
    {
        if(Input.GetMouseButtonDown(0))//点击老爷爷
        {
            GetComponent<AudioSource>().Play();
            if (isInTask)//如果在任务中
            {
                ShowTaskProgress();
            }
           else
            {
                ShowTaskDes();
            }
            ShowQuest();
        }
    }
    /// <summary>
    /// 显示和NPC的对话框
    /// </summary>
    private void ShowQuest()
    {
       // questTween.gameObject.SetActive(true);
        questTween.PlayForward();
    }
    //隐藏对话框
    private void HideQuset()
    {
        questTween.PlayReverse();
    }
    //隐藏对话框按钮
    public void OnCloseButtonClick()
    {
        HideQuset();
    }
    //接受按钮
    public void OnAcceptButtonClick()
    {
        ShowTaskProgress();
        isInTask = true;//在任务中
    }
    //提交任务完成按钮
    public void OnOKButtonClick()
    {
        if (killCount >= 10)//如果完成任务
        {
            status.GetCoint(1000);//得1000金币
            killCount = 0;//归0
            ShowTaskDes();//又可以接任务了
        }
        else
        {
            HideQuset();//隐藏对话框
        }
    }
    //取消按钮
    public void OnCancelButtonClick()
    {
        HideQuset();
    }
    //显示要完成哪些任务
    void ShowTaskDes()
    {
        desLabel.text = "任务：\n杀死10只狼\n\n奖励：\n1000金币";
        okBtn.SetActive(false);
        acceptBtn.SetActive(true);
        cancelBtn.SetActive(true);
    }
    //显示任务完成的进度
    void ShowTaskProgress()
    {
        desLabel.text = "任务：\n你已经杀死了" + killCount + "\n10只狼\n\n奖励：\n1000金币";
        okBtn.SetActive(true);
        acceptBtn.SetActive(false);
        cancelBtn.SetActive(false);
    }

}
