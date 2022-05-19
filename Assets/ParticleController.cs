using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour
{
    public static ParticleController Instance { get; private set; }

    [SerializeField] private ParticleSystem brickDestroyPar;
    [SerializeField] private ParticleSystem ItemCollectPar;
    [SerializeField] private ParticleSystem ItemBrickPar;
    
    void Awake(){
         if (Instance != null && Instance != this) 
    { 
        Destroy(this); 

    } 
    else 
    { 
        Instance = this; 
    } 
    }

    public void ShowEffectBrickDestroy(Vector2 position){
        brickDestroyPar.transform.position = position;
        brickDestroyPar.Emit(30);
    }

    public void ShowEffectItemCollect(Vector2 position){
        ItemCollectPar.transform.position = position;
        ItemCollectPar.Emit(40);
    }

    public void ShowEffectItemBrickDestroy(Vector2 position){
        ItemBrickPar.transform.position = position;
        ItemBrickPar.Emit(30);
    }
}
