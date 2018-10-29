using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KinghtCtrl : MonoBehaviour {

    private Transform tr;
    private Animator animator;
    private Status scStatus;
    private Damage scDamage;

    public GameObject goTarget = null;

    private float fSpeed = 50f;
    private Vector3 vecRot;
    private Vector3 vecVelocity;

    private int iAtkPattern;

    // Use this for initialization
    void Start () {
        tr = GetComponent<Transform>();
        animator = GetComponent<Animator>();
        scStatus = GetComponent<Status>();
        scDamage = gameObject.GetComponentInChildren<Damage>();

        scStatus.SetCurrentHp(100);
        scStatus.SetMaxHp(100);
        scStatus.SetAtk(10);
    }

    // Update is called once per frame
    void Update () {
        if (!animator.GetBool("IsAtk"))
        {
            if (Input.GetMouseButtonDown(0))
            {
                iAtkPattern = Random.Range(0, 2);
                animator.SetBool("IsAtk", true);
                animator.SetInteger("IsAtkPattern", iAtkPattern);
            }
            else if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                tr.Translate(Vector3.forward * fSpeed * Time.deltaTime);
                animator.SetBool("IsRun", true);
            }
            else
                animator.SetBool("IsRun", false);
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            tr.Rotate(0, Time.deltaTime * -120f, 0);
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            tr.Rotate(0, Time.deltaTime * 120f, 0);



        if (animator.GetBool("IsAtk"))
        {
            float animState = animator.GetCurrentAnimatorStateInfo(0).normalizedTime;
            if (Input.GetMouseButtonDown(0) && animState >= 0.8f && animState < 1f)
            {
                if (iAtkPattern == 0)
                {
                    ++iAtkPattern;
                    animator.SetInteger("IsAtkPattern", iAtkPattern);

                    animator.Play("Attack2", -1, 0f);
                }
                else
                {
                    --iAtkPattern;
                    animator.SetInteger("IsAtkPattern", iAtkPattern);

                    animator.Play("Attack2", -1, 0f);
                }
            }
            else if (animState >= 1f)
                animator.SetBool("IsAtk", false);
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.CompareTag("UNDEAD"))
         goTarget = col.gameObject;
    }
    void OnTriggerExit(Collider col)
    {
        goTarget = null;
    }
    
    void Damaged()
    {
        scDamage.Damaged();
    }
}

