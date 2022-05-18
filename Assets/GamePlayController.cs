using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayController : MonoBehaviour
{
    public enum gameState{
        initiate,
        standby,
        playing,
        over
    }

    [SerializeField] private gameState state;

    private int playerLife = 3;
    private BallController defaultBall;
    private PlatformController platform;
    private Transform ballSpawnPoint;

    void Awake(){
        defaultBall = GameObject.FindGameObjectWithTag("Ball").GetComponent<BallController>();
        platform = GameObject.FindGameObjectWithTag("Platform").GetComponent<PlatformController>();
    }
    // Start is called before the first frame update
    void Start()
    {
        SetInitiate();
    }

    // Update is called once per frame
    void Update()
    {
        CheckGameOver();
        CheckGameComplete();
    }

    public gameState GetGameState(){
        return state;
    }

    private void PlayerLoseLife(){
        // check if still has life left
        // if not get to game over state
    }

    private void SetInitiate(){
        playerLife = 3;
    }

    private void SetPlaying(){

    }

    private void SetEnd(){

    }

    private void CheckGameOver(){
        // in game state
        // check if ball and life
    }

    private void CheckGameComplete(){
        // in game state
        // check amount of brick
    }
}
