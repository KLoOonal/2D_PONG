using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBrick : BaseBrick
{

    public override void OnHitAction()
    {
        SpawnItem();
        Despawn();
    }

    private void SpawnItem(){
        // spawn item when hit
    }

    private void ShowEffect(){
        // show Effect when hit or destroy;
    }
}
