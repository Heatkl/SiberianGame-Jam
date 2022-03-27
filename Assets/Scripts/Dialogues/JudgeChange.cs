using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JudgeChange : MonoBehaviour
{
    [SerializeField] private Sprite sprite1;
    [SerializeField] private Sprite sprite2;
    [SerializeField] private Sprite sprite3;
    [SerializeField] private Sprite sprite4;
    [SerializeField] private Sprite sprite5;
    [SerializeField] private Sprite sprite6;

    private SpriteRenderer spriteRenderer;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void changeSprite(int num)
    {
        this.spriteRenderer.enabled = true;
        switch (num) {
            case 1:
                spriteRenderer.sprite = sprite1;
                break;
            case 5:
                spriteRenderer.sprite = sprite2;
                break;
            case 10:
                spriteRenderer.sprite = sprite3;
                break;
            case 12:
                spriteRenderer.sprite = sprite4;
                break;
            case 15:
                spriteRenderer.sprite = sprite5;
                break;
            case 16:
                spriteRenderer.sprite = sprite6;
                break;
            default:
                this.spriteRenderer.enabled = false;
                break;
        }
    }
}
