using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public enum BallState
    {
        standby,
        playing
    }

    [Header("Setting Variable")]
    [SerializeField] private BallState state;
    [SerializeField] private float moveSpeed = 3.0f;
    private Rigidbody2D rb;
    private PlatformController platform;
    private Vector3 currentVelocity;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        platform = GameObject.FindGameObjectWithTag("Platform").GetComponent<PlatformController>();
    }

    void FixedUpdate()
    {
        BallMoveControl();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        BounceControl(col);
    }

    void OnTriggerEnter2D(Collider2D col){
        if(col.transform.tag == "PassThrough"){
            BaseBrick brick = col.gameObject.GetComponent<BaseBrick>();
            brick.OnHitAction();
        }
    }

    private void BallMoveControl()
    {
        if(state  == BallState.standby){
            this.transform.position = platform.GetPlatformSpawnPoint().position;
        }else if(state  == BallState.playing){
            currentVelocity = rb.velocity;
        }
        
    }

    private void BounceControl(Collision2D col)
    {
        // feedback
        if (col.transform.tag == "Brick")
        {
            BaseBrick brick = col.gameObject.GetComponent<BaseBrick>();
            brick.OnHitAction();
        }
        Bounce(col);

        // deadzone
        if(col.transform.tag == "DeadZone"){
            Despawn();
        }

        
    }

    private void Bounce(Collision2D col){
        // bounce
        Vector3 reflectDir = Vector3.Reflect(currentVelocity, col.contacts[0].normal );
        rb.velocity = reflectDir;
    }

    private void SetBallStartMove()
    {
        rb.velocity = Vector2.one.normalized * moveSpeed;
    }

    private void SetBallStandBy(){
        // track position
        this.gameObject.SetActive(true);
        rb.velocity = Vector2.zero;
    }

    private void Despawn()
    {
        this.gameObject.SetActive(false);
    }
    //-------------
    public void SetBallState(BallState state)
    {
        this.state = state;
        switch (state)
        {
            case BallState.standby:
                SetBallStandBy();
                break;

            case BallState.playing:
                SetBallStartMove();
                break;
        }
    }

    public BallState GetBallState()
    {
        return state;
    }

}
