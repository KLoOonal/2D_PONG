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
        ParticleController.Instance.ShowEffectBrickDestroy(this.transform.position);
    }
}
