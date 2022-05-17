using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    private InputController input;
    void Awake(){
        //cache
        input = GameObject.FindGameObjectWithTag("Input").GetComponent<InputController>();
    }

    void Update()
    {
        CheckUpdatePosition();
    }

    private void CheckUpdatePosition(){
        if(input.GetTouchPosition() == Vector2.zero){
            return;
        }
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(input.GetTouchPosition());
        transform.position = new Vector2(worldPos.x,transform.position.y);
    }


}
