using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassBrick : BaseBrick
{

    public override void OnHitAction()
    {
        ShowEffect();   
        Despawn(); 
    }

    private void ShowEffect(){
        // show effect when hit or destroy;
    }
}
