using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayController : MonoBehaviour
{
    public enum gameState
    {
        initiate,
        standby,
        playing,
        over,
        end
    }

    [SerializeField] private gameState state;
    [SerializeField] GameObject brickSpawnPoint;
    [SerializeField] BrickController[] brickset;

    private BrickController currentBickSet;



    private int playerLife = 3;
    [SerializeField] private BallController defaultBall;
    [SerializeField] private PlatformController platform;
    private Transform ballSpawnPoint;
    void Awake()
    {

    }
    // Start is called before the first frame update
    void Start()
    {
        InitiateGame();
    }

    // Update is called once per frame
    void Update()
    {
        CheckGameOver();
        CheckGameComplete();
    }

    public gameState GetGameState()
    {
        return state;
    }

    private void PlayerLoseLife()
    {
        playerLife -= 1;
        if (playerLife <= 0)
        {
            SetGameOver();
        }
        else
        {
            SetStandby();
        }
    }

    private void InitiateGame()
    {
        playerLife = 3;
        SetStandby();
        int randomSet = Random.Range(0, brickset.Length);
        currentBickSet = Instantiate(brickset[randomSet], brickSpawnPoint.transform.position, Quaternion.identity, brickSpawnPoint.transform);
        currentBickSet.ResetBrick();
    }

    private void RestartGame()
    {
        playerLife = 3;
        SetStandby();
        currentBickSet.ResetBrick();
    }

    private void SetStandby()
    {
        state = gameState.standby;
        platform.PlatformReset();
    }
    private void SetPlaying()
    {
        state = gameState.playing;
        platform.DeployBall();
    }

    private void SetEnd()
    {
        state = gameState.end;
        if (GameObject.FindGameObjectsWithTag("Ball") != null || GameObject.FindGameObjectsWithTag("Ball").Length > 0)
        {
            GameObject[] ballObj = GameObject.FindGameObjectsWithTag("Ball");
            foreach (GameObject ball in ballObj)
            {
                if (!ball.GetComponent<BallController>().GetBallType())
                {
                    Destroy(ball);
                }
            }
        }

        platform.PlatformReset();
    }

    private void SetGameOver()
    {
        // game over  , show restart menu 
        state = gameState.over;
        platform.PlatformReset();
    }

    private void CheckGameOver()
    {
        if (state != gameState.playing)
        {
            return;
        }

        // check ball number
        if (GameObject.FindGameObjectsWithTag("Ball") == null || GameObject.FindGameObjectsWithTag("Ball").Length <= 0)
        {
            PlayerLoseLife();
        }

    }

    private void CheckGameComplete()
    {
        if (state != gameState.playing)
        {
            return;
        }

        if ((GameObject.FindGameObjectsWithTag("Brick") == null || GameObject.FindGameObjectsWithTag("Brick").Length <= 0) &&
           (GameObject.FindGameObjectsWithTag("PassThrough") == null || GameObject.FindGameObjectsWithTag("PassThrough").Length <= 0))
        {
            SetEnd();
        }
    }

    public void SetBallLargeEvent()
    {
        if (currentBickSet != null)
        {
            currentBickSet.HandleLargeBall(true);
        }
    }

    public void SetBallNormalEvent()
    {
        if (currentBickSet != null)
        {
            currentBickSet.HandleLargeBall(false);
        }
    }

    // input action handle from controller

    public void InputActionDoubleTap()
    {
        if (state == gameState.standby)
        {
            SetPlaying();
        }
    }

    public void InputActionOneTap()
    {
        if (state == gameState.end)
        {
        }
        else if (state == gameState.over)
        {
            RestartGame();
        }
    }
}
