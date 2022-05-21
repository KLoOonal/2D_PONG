using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    private InputController input;
    private Transform ballSpawnPoint;
    private float defaultSize;
    private float currentSize;
    [SerializeField]private BallController mainBall;
    [SerializeField]private GameObject ballPrefabs;
    [SerializeField]private GamePlayController gm;
    private float spawnDelay = 1;
    private float spawnTime;
    private bool isLetBallSpawn = false;
    private bool itemSizeActivate = false;

    private int ballSpawnCount;
    void Awake(){
        //cache
        input = GameObject.FindGameObjectWithTag("Input").GetComponent<InputController>();
        ballSpawnPoint = transform.GetChild(0);
    }

    void Start(){
        defaultSize = this.transform.localScale.x;
        currentSize = defaultSize;
    }

    void Update()
    {
        CheckUpdatePosition();
        BallSpawner();
    }

    private void CheckUpdatePosition(){
        if(input.GetTouchPosition() == Vector2.zero){
            return;
        }
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(input.GetTouchPosition());
        transform.position = new Vector2(worldPos.x,transform.position.y);
    }

    public Transform GetPlatformSpawnPoint(){
        return ballSpawnPoint;
    }

    public void DeployBall(){
        if(mainBall != null){
            mainBall.SetBallState(BallController.BallState.playing);
        }
    }

    public void PlatformReset(){
        if(mainBall != null)
        {
            mainBall.SetBallState(BallController.BallState.standby);
        }
        this.transform.localScale = new Vector2(defaultSize,transform.localScale.y);
    }

    public void PlatformSizeModify(bool isIncrease){
        if(this.transform.localScale.x < (this.transform.localScale.x/2f)/2f){
            return;
        }

        if(this.transform.localScale.x >= Screen.width){
            return;
        }

        currentSize = transform.localScale.x;
        this.transform.localScale = new Vector2(isIncrease ? this.transform.localScale.x*1.5f : this.transform.localScale.x/2f ,transform.localScale.y);
        
    }

    public void BallSizeModify(bool isIncrease){
        if(gm.GetGameState() != GamePlayController.gameState.playing){
            return;
        }

        if(GameObject.FindGameObjectsWithTag("Ball") != null && GameObject.FindGameObjectsWithTag("Ball").Length > 0){
            GameObject[] ballObj = GameObject.FindGameObjectsWithTag("Ball");
            foreach(GameObject ball in ballObj){
                if(isIncrease){
                    ball.GetComponent<BallController>().SetSizeIncrease();
                    gm.SetBallLargeEvent();
                    itemSizeActivate = true;
                }else{
                    ball.GetComponent<BallController>().SetSizeDecrease();            
                }   
            }
        }
    }

    public void BallReturnToNormalSize(){
        if(!itemSizeActivate){
            return;
        }
        gm.SetBallNormalEvent();
        itemSizeActivate = false;
    }

    public void BallSpeedModify(bool isIncrease){
          if(gm.GetGameState() != GamePlayController.gameState.playing){
            return;
        }

        if(GameObject.FindGameObjectsWithTag("Ball") != null && GameObject.FindGameObjectsWithTag("Ball").Length > 0){
            GameObject[] ballObj = GameObject.FindGameObjectsWithTag("Ball");
            foreach(GameObject ball in ballObj){
                if(isIncrease){
                    ball.GetComponent<BallController>().SetSpeedIncrease();
                }else{
                    ball.GetComponent<BallController>().SetSpeedDecrease();
                }   
            }
        }
    }

    public void PlatformFull(){
        if(this.transform.localScale.x == Screen.width){
            return;
        }

        currentSize = transform.localScale.x;
        this.transform.localScale = new Vector2(Screen.width,transform.localScale.y);
        StartCoroutine(PlatformSizeReset());
    }

    public void PlatformSpawnBall(){
        if(isLetBallSpawn ){
            return;
        }

        isLetBallSpawn = true;
    }

    private void BallSpawner(){
        if(!isLetBallSpawn ){
            return;
        }

        if(gm.GetGameState() != GamePlayController.gameState.playing){
            isLetBallSpawn = false;
            ballSpawnCount = 0;
            return;
        }

      spawnTime += 1f * Time.deltaTime;
        if(spawnTime > spawnDelay){
            spawnTime = 0;
            GameObject ballObj = Instantiate(ballPrefabs,ballSpawnPoint.transform.position,Quaternion.Euler(0f,0f,-35f)); 
            BallController ballCtr = ballObj.GetComponent<BallController>();
            ballCtr.SetBallState(BallController.BallState.playing);
            ballSpawnCount += 1;
            if(ballSpawnCount > 5){
                isLetBallSpawn = false;
                ballSpawnCount = 0;
            }
        }
    }

    // Ienumerator

    IEnumerator PlatformSizeReset(){
         yield return new WaitForSeconds(5.0f);
         this.transform.localScale =new Vector2(currentSize,transform.localScale.y);
    }

}
