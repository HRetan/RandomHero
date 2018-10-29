using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindTarget : MonoBehaviour {

    private GameObject goTarget = null;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider col)
    {
        if(this.gameObject.CompareTag("HUMAN"))
        {
            if (col.CompareTag("UNDEAD"))
                goTarget = col.gameObject;
        }
        else if(this.gameObject.CompareTag("UNDEAD"))
        {
            if (col.CompareTag("HUMAN"))
                goTarget = col.gameObject;
        }
    }

    void OnTriggerExit(Collider col)
    {
        goTarget = null;
    }

    public GameObject GetTarget()
    {
        return goTarget;
    }
}
