using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    private InputController input;
    private Transform ballSpawnPoint;
    [SerializeField]private BallController mainBall;
    void Awake(){
        //cache
        input = GameObject.FindGameObjectWithTag("Input").GetComponent<InputController>();
        ballSpawnPoint = transform.GetChild(0);
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

}
