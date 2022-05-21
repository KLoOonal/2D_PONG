using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseBrick : MonoBehaviour
{
    public enum BrickType{
        normal,
        passthough,
        ball,
        item,
        invincible,

    }
    [Header("Setting")]
    [SerializeField] private BrickType type;

    void CheckForLargeball(){
        
    }

    public virtual void OnHitAction(){}

    public virtual void OnLargeHitAction(){
        OnHitAction();
    }

    public BrickType GetBrickType(){
        return type;
    }

    protected void Despawn(){
        this.gameObject.SetActive(false);
    }

    
}
