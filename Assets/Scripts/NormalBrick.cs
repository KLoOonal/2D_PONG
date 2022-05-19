using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalBrick : BaseBrick
{
    [SerializeField]private int life = 1;
    [SerializeField]private Color[] lifeColor;
    private SpriteRenderer sr;
    void Awake(){
        sr = GetComponent<SpriteRenderer>();
        sr.color = lifeColor[lifeColor.Length-1];
    }
    public override void OnHitAction()
    {
        CheckLife();
    }

    private void CheckLife(){
        life -= 1;
        sr.color = lifeColor[life > 0 ? life-1 : 0];
        if(life <= 0){
            ShowEffect();
            Despawn();
        }
    }

    private void ShowEffect(){
        ParticleController.Instance.ShowEffectBrickDestroy(this.transform.position);
    }
}
