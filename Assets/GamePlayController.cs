using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayController : MonoBehaviour
{
    public enum gameState{
        initiate,
        standby,
        playing,
        over,
        end
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
        playerLife -= 1;
        if(playerLife <= 0){
            SetGameOver();
        }else{
            SetStandby();
        }
    }

    private void SetInitiate(){
        playerLife = 3;
        SetStandby();
    }

    private void SetStandby(){
        state = gameState.standby;
        platform.PlatformReset();
    }
    private void SetPlaying(){
        state = gameState.playing;
        platform.DeployBall();
    }

    private void SetEnd(){
        state = gameState.end;
        // game end show success menu + interact for next scene.
    }

     private void SetGameOver(){
         // game over  , show restart menu 
         state = gameState.over;
     }

    private void CheckGameOver(){
        if(state != gameState.playing){
           return; 
        }

        // check ball number
        if(GameObject.FindGameObjectsWithTag("Ball") == null || GameObject.FindGameObjectsWithTag("Ball").Length <= 0){
            PlayerLoseLife();
        }
        
    }

    private void CheckGameComplete(){
        // in game state
        // check amount of brick
    }

    public void InputActionStartGame(){
        if(state == gameState.standby){
            SetPlaying();
        }
    }
}
