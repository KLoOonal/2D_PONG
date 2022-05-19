using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickController : MonoBehaviour
{
    
    public void ResetBrick(){
        for(int i = 0 ; i < transform.childCount ; i++){
            transform.GetChild(i).gameObject.SetActive(true);
        }
    }
}
