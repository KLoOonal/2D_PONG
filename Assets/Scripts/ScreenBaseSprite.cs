using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenBaseSprite : MonoBehaviour
{
    [Header("Setting")]
    [SerializeField] private Vector2 defaultScreenSize = new Vector2(1080f, 2340f);
    private SpriteRenderer sr;
    private enum SpriteType
    {
        none,
        FullScreen,
        FillHorizontal,
        FillVertical,
        Ratio,
        Ball,
        Platform
    }

    [SerializeField] private SpriteType type;

    void Awake()
    {


    }

    void Start()
    {
        switch (type)
        {
            case SpriteType.FullScreen:
                ResizeSpriteToFullScreen();
                break;

            case SpriteType.FillHorizontal:
                ResizeSpriteFillHorizontal();
                break;

            case SpriteType.FillVertical:
                ResizeSpriteFillVertical();
                break;

            case SpriteType.Ratio:
                ResizeSpriteToRatio();
                break;

            case SpriteType.none:
                break;
        }
    }
    private Vector2 GetScreenBound()
    {
        sr = GetComponent<SpriteRenderer>();
        return new Vector2(sr.sprite.bounds.size.x, sr.sprite.bounds.size.y);
    }

    private void ResizeSpriteToFullScreen()
    {

        float width = GetScreenBound().x;
        float height = GetScreenBound().y;

        float worldScreenHeight = Camera.main.orthographicSize * 2.0f;
        float worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;

        transform.localScale = new Vector2(worldScreenWidth / width, worldScreenHeight / height);
        transform.position = new Vector3(0, 0, 2); // set to back when in edior.
    }

    private void ResizeSpriteToRatio()
    {
        if (DeviceData.GetDeviceType() == ENUM_Device_Type.Tablet)
        {
            Vector2 newScale = GetScaleByWidth();
            if (type == SpriteType.Ball)
            {
                newScale = GetScaleByHeight();
            }
            if(type == SpriteType.Platform){
                newScale = GetScaleByRatio();
            }
            Vector2 newScalePosition = GetScaleByRatio();
            transform.localScale = Vector2.Scale(transform.localScale, newScale);
            transform.position = Vector2.Scale(transform.position, newScalePosition);
        }


    }

    private void ResizeSpriteFillHorizontal()
    {
        float width = GetScreenBound().x;
        float height = GetScreenBound().y;

        float worldScreenHeight = Camera.main.orthographicSize * 2.0f;
        float worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;

        transform.localScale = new Vector2(worldScreenWidth / width, transform.localScale.y);
        
    }

    private void ResizeSpriteFillVertical()
    {

    }

    private Vector3 GetScaleByWidth()
    {
        return new Vector3(Screen.width / defaultScreenSize.x, Screen.height / defaultScreenSize.x, 1);
    }

    private Vector3 GetScaleByHeight()
    {
        return new Vector3(Screen.width / defaultScreenSize.y, Screen.height / defaultScreenSize.y, 1);
    }

    private Vector3 GetScaleByRatio()
    {
        return new Vector3(Screen.width / defaultScreenSize.x, Screen.height / defaultScreenSize.y, 1);
    }
}
