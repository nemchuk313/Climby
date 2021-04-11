using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class Combat : MonoBehaviour
{
    [Header("General")]
    [SerializeField]
    private bool canHit;
    [SerializeField]
    private float inputTimer;

    private float[] attackDetails = new float[2];

    private bool gotInput, attacking;
    private float lastInputTime = Mathf.NegativeInfinity;// to store time when player last tryied to attemp hit

    [Header("Components")]
    [SerializeField]
    private LayerMask WIDamage;
    private Animator anim;
    private PlayerController pc;
    private PlayerStats ps;


    [Header("Melee Attack")]
    [SerializeField]
    private Transform attack1HitBox;
    [SerializeField]
    private float attack1Radius , attack1Damage;


    private void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("canAttack",canHit);

        pc = GetComponent<PlayerController>();
        ps = GetComponent<PlayerStats>();
    }

    private void Update()
    {
        
        CheckAttacks();
    }

    //this function is public to be visible in UI Button OnClick event
    public void CheckCombatInput()
    {
        if(canHit)
        {
            gotInput = true;

            lastInputTime = Time.time;
        }  
    }

    private void CheckAttacks()
    {
        if(gotInput)
        {
            if(!attacking)
            {
                gotInput = false;
                attacking = true;
                anim.SetBool("attack1",true);
                anim.SetBool("attacking",attacking);
            }
        }

        if(Time.time >= lastInputTime + inputTimer)
        {
            gotInput = false;
        }
    }

    private void CheckAttackHitBox()
    {
        Collider2D[] detectedObjects = Physics2D.OverlapCircleAll( attack1HitBox.position , attack1Radius , WIDamage );

        attackDetails[0] = attack1Damage;
        attackDetails[1] = transform.position.x;

        foreach(Collider2D collider in detectedObjects)
        {
            collider.transform.parent.SendMessage("Damage" , attackDetails);
        }
    }

    private void FinishAttack1()
    {
        attacking = false;
        anim.SetBool("attacking" , false);
        anim.SetBool("attack1" , false);
    }
    
    private void Damage(float[] attackDetails)
    {
        //Player doesn t receive damage when dash through the enemies
        if( !pc.GetDashStatus() )
        {
            int direction;

            ps.DecreaseHealth(attackDetails[0]);

            if (attackDetails[1] < transform.position.x)
            {
                direction = 1;
            }
            else
            {
                direction = -1;
            }

            pc.Knockback(direction);
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(attack1HitBox.position, attack1Radius);
    }
}
