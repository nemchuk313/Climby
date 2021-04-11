using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;

//All enemies are going do derive from this class
public class Entity : MonoBehaviour
{

    //List of components all the enemies are going to have in common

    public FiniteStateMachine stateMachine;

    public D_Entity entityData;//Stores all the variables like ground check distance/Layermasks/.../etc

    public Rigidbody2D aliveRb { get; private set; }
    public Rigidbody2D deadRb { get; private set; }
    public Animator aliveAnim { get; private set; }
    public Animator deadAnim { get; private set; }
    public Animator dropAnim { get; private set; }
    public GameObject aliveGO { get; private set; }
    public GameObject deadGO { get; private set; }
    public GameObject dropGO { get; private set; }
    public int facingDirection { get; private set; }

    private Vector2 velocitySpace;

    [SerializeField]
    private Transform wallCkeck;

    [SerializeField]
    private Transform ledgeCheck;

    [SerializeField]
    private Transform playerCheck;



    public virtual void Start()
    {

        facingDirection = 1;

        //References to "Alive" GO/Animator/RigidBody2D

        aliveGO = transform.Find("Alive").gameObject;
        aliveRb = aliveGO.GetComponent<Rigidbody2D>();
        aliveAnim = aliveGO.GetComponent<Animator>();   

        //Every entity is going to have its own state machine which is an instance of FiniteStateMachine class
        stateMachine = new FiniteStateMachine();
    }

    public virtual void Update()
    {
        stateMachine.currentState.LogicUpdate();
    }

    public virtual void FixedUpdate()
    {
        stateMachine.currentState.PhysicsUpdate();
    }

    public virtual void SetVelocity(float _velocity)
    {
        velocitySpace.Set( facingDirection * _velocity , aliveRb.velocity.y );

        aliveRb.velocity = velocitySpace;
    }

    public virtual bool CheckWall()
    {
        return Physics2D.Raycast( wallCkeck.position  , aliveGO.transform.right , entityData.wallCheckDistance , entityData.whatIsWall );
    }


    public virtual bool CkeckLedge()
    {
        return Physics2D.Raycast( ledgeCheck.position , Vector2.down , entityData.ledgeCheckDistance , entityData.whatIsGround );
    }

    public virtual bool CheckPlayerInMinAgroRange()
    {
        return Physics2D.Raycast( playerCheck.position , aliveGO.transform.right , entityData.minAgroDistance , entityData.whatIsPlayer );
    }

    public virtual bool CheckPlayerInMaxAgroRange()
    {
        return Physics2D.Raycast(playerCheck.position, aliveGO.transform.right, entityData.maxAgroDistance, entityData.whatIsPlayer);
    }

    public virtual void Flip()
    {
        facingDirection *= -1;

        aliveGO.transform.Rotate( 0f , 180f , 0f );
    }

    public virtual void  OnDrawGizmos()
    {
        Gizmos.DrawLine(wallCkeck.position , wallCkeck.position + (Vector3)(Vector2.right * facingDirection * entityData.wallCheckDistance  ) );


        Gizmos.DrawLine(ledgeCheck.position, ledgeCheck.position + (Vector3)(Vector2.down * entityData.ledgeCheckDistance));
    }

}
