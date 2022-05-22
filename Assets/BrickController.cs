using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickController : MonoBehaviour
{
    
    public void HandleLargeBall(bool isLarge){
        for(int i = 0 ; i < transform.childCount ; i++){
           BaseBrick brick = transform.GetChild(i).GetComponent<BaseBrick>();
           if(brick.GetBrickType() != BaseBrick.BrickType.invincible && brick.GetBrickType() != BaseBrick.BrickType.passthough){
               brick.GetComponent<BoxCollider2D>().isTrigger = isLarge;
           }
        }
    }

    public void ResetBrick(){
        for(int i = 0 ; i < transform.childCount ; i++){
            transform.GetChild(i).gameObject.SetActive(true);
        }
    }
}
