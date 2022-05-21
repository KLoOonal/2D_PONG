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

    public enum BallSizeState
    {
        small,
        normal,
        large
    }

    [Header("Setting Variable")]
    [SerializeField] private bool isMain = false;
    [SerializeField] private BallState state;
    [SerializeField] private BallSizeState sizeState;
    [SerializeField] private float moveSpeed = 3.0f;
    private float maxSpeed = 5.0f;
    private float minSpeed = 2.0f;
    private PlatformController platform;
    private Rigidbody2D rb;
    private Vector3 currentVelocity;
    private float defaultSize;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        platform = GameObject.FindGameObjectWithTag("Platform").GetComponent<PlatformController>();
        defaultSize = transform.localScale.x;
    }

    void FixedUpdate()
    {
        BallMoveControl();
        MovementControl();
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        BounceControl(col);
    }

    void OnTriggerEnter2D(Collider2D col)
    {

        if (sizeState == BallSizeState.large)
        {
            if (col.transform.tag == "PassThrough" || col.transform.tag == "Brick")
            {
                BaseBrick brick = col.gameObject.GetComponent<BaseBrick>();
                brick.OnLargeHitAction();
            }
        }
        else
        {
            if (col.transform.tag == "PassThrough")
            {
                BaseBrick brick = col.gameObject.GetComponent<BaseBrick>();
                brick.OnHitAction();
            }
        }
    }

    private void BallMoveControl()
    {
        if (state == BallState.standby)
        {
            this.transform.position = platform.GetPlatformSpawnPoint().position;
        }
        else if (state == BallState.playing)
        {
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
        if (col.transform.tag == "DeadZone")
        {
            Despawn();
        }
    }

    private void Bounce(Collision2D col)
    {
        // bounce
        Vector3 reflectDir = Vector3.Reflect(currentVelocity, col.contacts[0].normal);
        rb.velocity = reflectDir.normalized * rb.velocity.magnitude;
    }

    private void SetBallStartMove()
    {
        rb.velocity = Vector2.one.normalized * moveSpeed;
    }

    private void SetBallStandBy()
    {
        // track position
        this.gameObject.SetActive(true);
        rb.velocity = Vector2.zero;
        SetSizeReset();
    }

    private void Despawn()
    {
        if (isMain)
        {
            this.gameObject.SetActive(false);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void MovementControl()
    {
        if (rb.velocity.magnitude <= maxSpeed && rb.velocity.magnitude > minSpeed)
        {
            rb.velocity += rb.velocity.normalized * moveSpeed * Time.deltaTime;
        }
        else if (rb.velocity.magnitude < minSpeed)
        {
            rb.velocity = rb.velocity.normalized * minSpeed;
        }
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

    public bool GetBallType()
    {
        return isMain;
    }

    public void SetSizeIncrease()
    {
        if (sizeState != BallSizeState.large)
        {
            this.transform.localScale = new Vector2(defaultSize * 2, defaultSize * 2);
            sizeState = BallSizeState.large;
            StartCoroutine(SetSizeReset());
        }
    }

    public void SetSizeDecrease()
    {
        if (sizeState != BallSizeState.small)
        {
            this.transform.localScale = new Vector2(defaultSize / 2, defaultSize / 2);
            sizeState = BallSizeState.small;
            StartCoroutine(SetSizeReset());
        }
    }

    IEnumerator SetSizeReset()
    {
        yield return new WaitForSeconds(5.0f);
        platform.BallReturnToNormalSize();
        this.transform.localScale = new Vector2(defaultSize, defaultSize);
        sizeState = BallSizeState.normal;
    }

    public void SetSpeedIncrease()
    {
        rb.velocity = rb.velocity.normalized * moveSpeed * 2f;
    }

    public void SetSpeedDecrease()
    {
        rb.velocity = (rb.velocity.normalized * 1f);
    }

}
