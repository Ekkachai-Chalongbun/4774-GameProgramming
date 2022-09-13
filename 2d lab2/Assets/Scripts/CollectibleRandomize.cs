using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleRandomize : MonoBehaviour
{
    [SerializeField] private Sprite[] sprites;
    [SerializeField] private int randomNumber;
    [SerializeField] private SpriteRenderer spriteRenderer;
    public CollectibleColor color;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        randomNumber = Random.Range(0, sprites.Length);

        switch (randomNumber)
        {
            case 0:
                color = CollectibleColor.Red;
                break;
            case 1:
                color = CollectibleColor.Green;
                break;
            case 2:
                color = CollectibleColor.Blue;
                break;
        }
        spriteRenderer.sprite = sprites[randomNumber];
    }
}
