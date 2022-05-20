using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [Header("Element")]
    [SerializeField] private float fadeTime = 4f;
    [SerializeField] private CanvasGroup initiateGroup;
    [SerializeField] private CanvasGroup GameOverGroup;
    [SerializeField] private CanvasGroup GameCompleteGroup;
    private GamePlayController gm;
    void Awake(){
        gm = GameObject.Find("GameplayManager").GetComponent<GamePlayController>();
        initiateGroup.alpha = 0;
        GameOverGroup.alpha = 0;
        GameCompleteGroup.alpha = 0;
    }

    // Update is called once per frame
    void Update()
    {
        ShowStateUI();
    }

    void ShowStateUI(){
        if(gm.GetGameState() == GamePlayController.gameState.standby){
            initiateGroup.alpha = Mathf.Lerp(initiateGroup.alpha,1f,fadeTime*Time.deltaTime);
            GameOverGroup.alpha = Mathf.Lerp(GameOverGroup.alpha,0f,fadeTime*Time.deltaTime);
            GameCompleteGroup.alpha = Mathf.Lerp(GameCompleteGroup.alpha,0f,fadeTime*Time.deltaTime);
        }else if(gm.GetGameState() == GamePlayController.gameState.over){
            initiateGroup.alpha = Mathf.Lerp(initiateGroup.alpha,0f,fadeTime*Time.deltaTime);
            GameOverGroup.alpha = Mathf.Lerp(GameOverGroup.alpha,1f,fadeTime*Time.deltaTime);
            GameCompleteGroup.alpha = Mathf.Lerp(GameCompleteGroup.alpha,0f,fadeTime*Time.deltaTime);
        }
        else if(gm.GetGameState() == GamePlayController.gameState.end){
            initiateGroup.alpha = Mathf.Lerp(initiateGroup.alpha,0f,fadeTime*Time.deltaTime);
            GameOverGroup.alpha = Mathf.Lerp(GameOverGroup.alpha,0f,fadeTime*Time.deltaTime);
            GameCompleteGroup.alpha = Mathf.Lerp(GameCompleteGroup.alpha,1f,fadeTime*Time.deltaTime);
        }else{
            initiateGroup.alpha = Mathf.Lerp(initiateGroup.alpha,0f,fadeTime*Time.deltaTime);
            GameOverGroup.alpha = Mathf.Lerp(GameOverGroup.alpha,0f,fadeTime*Time.deltaTime);
            GameCompleteGroup.alpha = Mathf.Lerp(GameCompleteGroup.alpha,0f,fadeTime*Time.deltaTime);
        }
    }
}
