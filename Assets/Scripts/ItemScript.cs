using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript : MonoBehaviour
{
    SpriteRenderer itemRenderer;
    public ShopScript shop;
    public GameObject totem;
    private Sprite[] sprites;
    private string spriteNames = "Items";
    // Start is called before the first frame update
    void Start()
    {
        itemRenderer = GetComponent<SpriteRenderer>();
        shop = totem.GetComponent<ShopScript>();
        sprites = Resources.LoadAll<Sprite>(spriteNames);

        switch(shop.totemType)
        {
            case "Health":
                itemRenderer.sprite = sprites[1];
                break;
            case "Speed":
                itemRenderer.sprite = sprites[5];
                break;
            case "Attack":
                itemRenderer.sprite = sprites[2];
                break;
            case "Experience":
                itemRenderer.sprite = sprites[4];
                break;
            case "Range":
                itemRenderer.sprite = sprites[0];
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
