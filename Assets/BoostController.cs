using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostController : MonoBehaviour
{
    private bool isMove = false;
    private PlatformController platform;
    private GamePlayController gm;
    void Awake(){
        gm = GameObject.Find("GamePlayManager").GetComponent<GamePlayController>();
        platform = GameObject.FindGameObjectWithTag("Platform").GetComponent<PlatformController>();
    }
    void Update(){
        MoveCheck();
    }

    void OnTriggerEnter2D(Collider2D col){
        if(col.transform.tag == "Boundary"){
            isMove = false;
            SetDefaultPosition();
        }
    }

    private void MoveCheck(){
        if(!isMove){
            SetDefaultPosition();
            return;
        }
        transform.position += -transform.up * 20f * Time.deltaTime;
    }

    public void StartMove(){
        if(gm.GetGameState() != GamePlayController.gameState.playing){
            return;
        }
        isMove = true;
    }

    private void SetDefaultPosition(){
        transform.position = new Vector3(   platform.transform.position.x,
                                                platform.transform.position.y -0.3f ,
                                                platform.transform.position.z);
    }
}
