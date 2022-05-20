using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    public enum ItemType
    {
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
    [SerializeField] private GameObject[] itemTypeImage;
    private int itemTypeIndex;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private bool isActivated = false;
    private PlatformController platform;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        rb.velocity = Vector2.down * 1.5f;
        // set Image active base on type
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (isActivated)
        {
            return;
        }
        if (col.transform.tag == "Platform")
        {
            platform = col.transform.GetComponent<PlatformController>();
            ActivatePower();
            Despawn();
            isActivated = true;
        }
        if (col.transform.tag == "DeadZone")
        {
            Despawn();
            isActivated = true;
        }
    }

    public void SetItemType(int randomType)
    {
        randomType = 2;
        SetItemTypeFromIndex(randomType);
        itemTypeImage[randomType].SetActive(true);
        itemTypeIndex = randomType;
 
    }

    private void ActivatePower()
    {
        // handle all case
        switch (itemType)
        {
            case ItemType.ball_speed_increase:
                platform.BallSpeedModify(true);
                break;
            case ItemType.ball_speed_decrease:
                platform.BallSpeedModify(false);
                break;
            case ItemType.ball_size_increase:
                platform.BallSizeModify(true);
                break;
            case ItemType.ball_size_decrease:
                platform.BallSizeModify(false);
                break;
            case ItemType.platform_size_decrease:
                platform.PlatformSizeModify(false);
                break;
            case ItemType.platform_size_increase:
                platform.PlatformSizeModify(true);
                break;
            case ItemType.platform_size_full:
                platform.PlatformFull();
                break;
            case ItemType.platform_spawn_ball:
                platform.PlatformSpawnBall();
                break;
        }
    }

    private void SetItemTypeFromIndex(int index)
    {
        switch (index)
        {
            case 0:
                itemType = ItemType.ball_speed_increase;
                break;
            case 1:
                itemType = ItemType.ball_speed_decrease;
                break;
            case 2:
                itemType = ItemType.ball_size_increase;
                break;
            case 3:
                itemType = ItemType.ball_size_decrease;
                break;
            case 4:
                itemType = ItemType.platform_size_increase;          
                break;
            case 5:
                itemType = ItemType.platform_size_decrease;    
                break;
            case 6:
                itemType = ItemType.platform_size_full;
                break;
            case 7:
                itemType = ItemType.platform_spawn_ball;
                break;
            default:
                itemType = ItemType.platform_size_increase;
                break;
        }
    }

    private void Despawn(bool isDeadZone = false)
    {
        rb.velocity = Vector2.zero;
        rb.isKinematic = true;
        sr.color = Color.clear;
        itemTypeImage[itemTypeIndex].SetActive(false);
        ParticleController.Instance.ShowEffectItemCollect(this.transform.position);
        Destroy(this.gameObject, 5.0f);
    }
}
