using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    private enum ItemType{
        ball_speed_increase,
        ball_speed_decrease,
        ball_size_increase,
        ball_size_decrease,
        platform_size_increase,
        platform_size_decrease,
        platform_size_full,
        platform_spawn_ball
    }

    [Header("Setting")]
    [SerializeField] private ItemType itemType;
    [SerializeField] private ParticleSystem itemParticle;
    private Rigidbody2D rb;
    private SpriteRenderer sr;

    void Awake(){
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Start(){
        rb.velocity = Vector2.down * 1.5f;
    }

    void OnTriggerEnter2D(Collider2D col){
        if(col.transform.tag == "Platform"){
            ActivatePower();
            Despawn();
        }
        if(col.transform.tag == "DeadZone"){
            Despawn();
        }
        
    }

    private void ActivatePower(){
        // handle all case
        switch(itemType){
            case ItemType.ball_speed_increase:
            break;
            case ItemType.ball_speed_decrease:
            break;
            case ItemType.ball_size_increase:
            break;
            case ItemType.ball_size_decrease:
            break;
            case ItemType.platform_size_decrease:
            break;
            case ItemType.platform_size_increase:
            break;
            case ItemType.platform_size_full:
            break;
            case ItemType.platform_spawn_ball:
            break;
        }
    }

    private void Despawn(bool isDeadZone = false){
        rb.velocity = Vector2.zero;
        rb.isKinematic = true;
        sr.color = Color.clear;
        if(isDeadZone) itemParticle.Emit(30);
        Destroy(this.gameObject,5.0f);
    }
}
