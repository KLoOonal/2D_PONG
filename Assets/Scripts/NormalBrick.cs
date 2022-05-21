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

    public override void OnLargeHitAction()
    {
        ShowEffect();
        Despawn();
    }

    private void CheckLife(){
        life -= 1;
        sr.color = lifeColor[life > 0 ? life-1 : 0];
        if(life <= 0){
            ShowEffect();
            Despawn();
        }else{
            ShakeEffect();
        }
    }

    private void ShowEffect(){
        ParticleController.Instance.ShowEffectBrickDestroy(this.transform.position);
    }

    private void ShakeEffect(){
      StartCoroutine(Tremble());
    }

    IEnumerator Tremble() {
           for ( int i = 0; i < 10; i++)
           {
               transform.localScale += new Vector3(0, 0.5f);
               yield return new WaitForSeconds(0.01f);
               transform.localScale -= new Vector3(0,0.5f);
               yield return new WaitForSeconds(0.01f);
           }
     }
}
