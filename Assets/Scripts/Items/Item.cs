using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [Header("Item Information")]
    public Sprite ItemSprite;
    public string ItemName;
    public string ItemDesc;

    [Header("Player Info")]
    public SpriteRenderer PlayerPart;
    public bool IsEquiped;

    private bool CanEquip = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPart.sprite == ItemSprite)
           IsEquiped = true;
        else
           IsEquiped= false;

        if (Input.GetKeyDown(KeyCode.Space) && CanEquip)
        {
            Equip();
        }
    }

    private void Equip()
    {
        if (PlayerPart.sprite == ItemSprite)
            return;

        PlayerPart.sprite = ItemSprite;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            CanEquip = true;
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            CanEquip = false;
        }
    }
}
