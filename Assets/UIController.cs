using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [Header("Element")]
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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
