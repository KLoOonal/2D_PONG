using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalBrick : BaseBrick
{
    [SerializeField]private int life = 0;

    void Awake(){
        // set up color base on life;
    }
    public override void OnHitAction()
    {
        CheckLife();
    }

    private void CheckLife(){
        life -= 1;
        ShowEffect();
        if(life <= 0){
            Despawn();
        }
    }

    private void ShowEffect(){
        // show effect base on life , destroy or just damage.
    }
}
