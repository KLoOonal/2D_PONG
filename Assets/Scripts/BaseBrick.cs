using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseBrick : MonoBehaviour
{
    private enum BrickType{
        normal,
        passthough,
        ball,
        item,
        invincible,

    }
    [Header("Setting")]
    [SerializeField] private BrickType type;

    public virtual void OnHit(){

    }

    
}
