using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class LifeUpdator : MonoBehaviour
{
    [SerializeField] private GamePlayController gm;
    private TMP_Text scoreText;
    void Awake(){
        scoreText = GetComponent<TMP_Text>();
    }
    public void UpdateLife()
    {
        scoreText.text = "LIFE : "+ gm.GetPlayerLife();
    }
}
