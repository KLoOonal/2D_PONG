using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenBaseSprite : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ResizeSpriteToScreen();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ResizeSpriteToScreen() {
     SpriteRenderer sr = GetComponent<SpriteRenderer>();
     if (sr == null) return;
     
     float width = sr.sprite.bounds.size.x;
     float height = sr.sprite.bounds.size.y;
     
     float worldScreenHeight = Camera.main.orthographicSize * 2.0f;
     float worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;
     
     transform.localScale = new Vector2(worldScreenWidth / width , worldScreenHeight / height);
     transform.position = new Vector3(0,0,2);
 }
}
