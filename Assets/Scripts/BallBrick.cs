using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBrick : BaseBrick
{
  
    public override void OnHitAction()
    {
        ShowEffect();
        SpawnBall();
        Despawn();
    }

    private void SpawnBall(){
        // spawn new ball at this position;
    }

     private void ShowEffect(){
        // show Effect when hit or destroy;
    }
}
