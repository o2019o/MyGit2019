using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimManager : MonoBehaviour {

    private PlayerManager pm;
    private Animator anim;
    private Rigidbody ribody;
    private Vector3 targetPos;
    public float playerSpeed = 2;
    private GameObject model;
	// Use this for initialization
	void Start () {
        pm = GetComponent<PlayerManager>();
        model = transform.GetChild(0).gameObject;
        anim = GetComponentInChildren<Animator>();
        ribody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        anim.SetFloat("forward", pm.Dmag * Mathf.Lerp(anim.GetFloat("forward"), pm.isRun ? 2 : 1, 0.5f));
        if (pm.Dmag > 0.1f)
        {
            model.transform.forward = Vector3.Slerp(model.transform.forward, pm.Dvec, 0.3f);//让转向更圆滑          
        }
        targetPos = pm.Dmag * model.transform.forward * playerSpeed * (pm.isRun ? 2 : 1);
	}
    private void FixedUpdate()
    {
        ribody.velocity = new Vector3(targetPos.x, ribody.velocity.y, targetPos.z);
    }
}
