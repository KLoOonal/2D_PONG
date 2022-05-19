using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    private InputController input;
    private Transform ballSpawnPoint;
    private Transform defaultSize;
    [SerializeField]private BallController mainBall;
    void Awake(){
        //cache
        input = GameObject.FindGameObjectWithTag("Input").GetComponent<InputController>();
        ballSpawnPoint = transform.GetChild(0);
    }

    void Start(){
        defaultSize = this.transform;
    }

    void Update()
    {
        CheckUpdatePosition();
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
        if(mainBall != null){
            mainBall.SetBallState(BallController.BallState.standby);
        }
    }

    public void PlatformSizeModify(bool isIncrease){

    }

    public void BallSizeModify(bool isIncrease){

    }

    public void BallSpeedModify(bool isIncrease){

    }

    public void PlatformFull(){

    }

    public void PlatformSpawnBall(){

    }

}
