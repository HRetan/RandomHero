using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status : MonoBehaviour {

    private int iCurrentHp;
    private int iMaxHp;
    private int iAttack;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetCurrentHp(int iHp)
    {
        iCurrentHp = iHp;
    }
    public void SetMaxHp(int iHp)
    {
        iMaxHp = iHp;
    }
    public void SetAtk(int iAtk)
    {
        iAttack = iAtk;
    }

    public int GetCurrentHp()
    {
        return iCurrentHp;
    }

    public int GetMaxHp()
    {
        return iMaxHp;
    }

    public int GetAtk()
    {
        return iAttack;
    }
}
