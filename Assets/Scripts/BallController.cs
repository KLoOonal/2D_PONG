using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [Header("Setting Variable")]
    [SerializeField] private float moveSpeed = 3.0f;
    private Rigidbody2D rb;
    private Vector3 currentVelocity;
    void Awake(){
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        rb.velocity = Vector2.one.normalized * moveSpeed;
    }

    void FixedUpdate()
    {
        BallMoveControl();
    }

    void OnCollisionEnter2D(Collision2D col){
        BounceControl(col);
        if(col.transform.tag == "Brick"){
            col.gameObject.SetActive(false);
        }

    }

    private void BallMoveControl(){
        currentVelocity = rb.velocity;
    }
 
    private void BounceControl(Collision2D col){
        // bounce
        Vector3 reflectDir = Vector3.Reflect(currentVelocity,col.contacts[0].normal);
        //reflectDir = new Vector3(Mathf.Clamp(reflectDir.x,-0.85f,0.85f),Mathf.Clamp(reflectDir.y,-0.85f,0.85f),reflectDir.z);
        rb.velocity = reflectDir;
    }

}
