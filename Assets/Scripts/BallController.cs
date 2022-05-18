using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public enum BallState{
        standby,
        playing
    }

    [Header("Setting Variable")]
    [SerializeField] private BallState state;
    [SerializeField] private float moveSpeed = 3.0f;
    private Rigidbody2D rb;
    private Vector3 currentVelocity;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
   
    void FixedUpdate()
    {
        BallMoveControl();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        BounceControl(col);
    }

    private void BallMoveControl()
    {

        currentVelocity = rb.velocity;
    }

    private void BounceControl(Collision2D col)
    {
        // feedback
        if (col.transform.tag == "Brick")
        {
            BaseBrick brick = col.gameObject.GetComponent<BaseBrick>();
            brick.OnHitAction();
            if (brick.GetBrickType() != BaseBrick.BrickType.passthough)
            {
                return;
            }   
        }

        // bounce
        Vector3 reflectDir = Vector3.Reflect(currentVelocity, col.contacts[0].normal);
        print(currentVelocity+" , "+ reflectDir);
        rb.velocity = reflectDir;
    }

    private void SetBallStartMove(){
        rb.velocity = Vector2.one.normalized * moveSpeed;
    }

    private void Despawn(){
        // handle when it gone down
    }
    //-------------
    public void SetBallState(BallState state){
        this.state = state;
        switch(state){
            case BallState.standby:
            break;

            case BallState.playing:
            break;
        }
    }

    public BallState GetBallState(){
        return state;
    }

}
