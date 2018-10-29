using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour {

    public FindTarget ft;
    public Status scStatus = null;
    public GameObject goTarget = null;

	// Use this for initialization
	void Start () {
        ft = GetComponentInParent<FindTarget>();
        scStatus = GetComponentInParent<Status>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision collision)
    {
        if (ft.GetTarget() != null)
            goTarget = ft.GetTarget();
    }

    void OnCollisionExit(Collision collision)
    {
        if (ft.GetTarget() != null)
            goTarget = null;
    }

    public void Damaged()
    {
        if(goTarget != null)
        {
            goTarget.GetComponent<Status>().SetCurrentHp(goTarget.GetComponent<Status>().GetCurrentHp() - scStatus.GetAtk());
            Debug.Log("타겟 공격");
        }
        else
        Debug.Log("타겟 공격못함");
    }
}
