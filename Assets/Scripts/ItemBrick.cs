using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBrick : BaseBrick
{
    [Header("Setting")]
    [SerializeField] private GameObject itemObject;
    public override void OnHitAction()
    {
        SpawnItem();
        ShowEffect();
        Despawn();
    }

    private void SpawnItem(){
        GameObject item = Instantiate(itemObject,this.transform.position,Quaternion.identity);
        int randType = Random.Range(0,8);
        item.GetComponent<ItemController>().SetItemType(randType);
    }

    private void ShowEffect(){
        ParticleController.Instance.ShowEffectItemBrickDestroy(this.transform.position);
    }
}
