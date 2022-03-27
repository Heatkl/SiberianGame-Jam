using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossChange : MonoBehaviour
{
    [SerializeField] private Sprite sprite1;
    [SerializeField] private Sprite sprite2;
    [SerializeField] private Sprite sprite3;
    [SerializeField] private Sprite sprite4;
    [SerializeField] private Sprite sprite5;
    [SerializeField] private Sprite sprite6;
    [SerializeField] private Sprite sprite7;
    [SerializeField] private Sprite sprite8;
    private SpriteRenderer spriteRenderer;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    // Start is called before the first frame update
    public void changeSprite(int num)
    {
        this.spriteRenderer.enabled = true;
        this.gameObject.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().enabled = true;

        switch (num) {
            case 2:
                spriteRenderer.sprite = sprite1;
                break;
            case 3:
                spriteRenderer.sprite = sprite2;
                break;
            case 4:
                spriteRenderer.sprite = sprite3;
                break;
            case 6:
                spriteRenderer.sprite = sprite4;
                break;
            case 7:
                spriteRenderer.sprite = sprite5;
                break;
            case 8:
                spriteRenderer.sprite = sprite6;
                break;
            case 9:
                spriteRenderer.sprite = sprite7;
                break;
            case 11:
                spriteRenderer.sprite = sprite8;
                break;
            default:
                this.spriteRenderer.enabled = false;
                this.gameObject.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().enabled = false;

                break;
        }
    }
}
