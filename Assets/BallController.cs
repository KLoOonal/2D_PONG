using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [Header("Setting Variable")]
    private Rigidbody2D rb;
    void Awake(){
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        rb.velocity = Vector2.one.normalized * 10f;
    }

    void FixedUpdate()
    {
        BallMoveControl();
    }

    void OnCollisionEnter2D(Collision2D col){
        BounceControl(col);
    }
    private void BallMoveControl(){
        // movement
    }

    private void BounceControl(Collision2D col){
              // bounce
        float speed = rb.velocity.magnitude;
        Vector3 direction = Vector2.Reflect(rb.velocity.normalized,col.contacts[0].normal);
        rb.velocity = direction * Mathf.Max(speed,0f);
    }
}
