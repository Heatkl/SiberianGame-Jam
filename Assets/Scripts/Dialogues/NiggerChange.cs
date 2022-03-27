using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NiggerChange : MonoBehaviour
{
    [SerializeField] private Sprite sprite1;
    [SerializeField] private Sprite sprite2;

    private SpriteRenderer spriteRenderer;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    public void changeSprite(int num)
    {
        this.spriteRenderer.enabled = true;
        switch (num) {
            case 13:
                spriteRenderer.sprite = sprite1;
                break;
            case 14:
                spriteRenderer.sprite = sprite2;
                break;
            default:
                this.spriteRenderer.enabled = false;
                break;
        }
    }
}
