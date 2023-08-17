using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Item : MonoBehaviour
{
    [Header("Item Information")]
    public Sprite ItemSprite;
    public string ItemName;
    public string ItemDesc;

    [Header("Player Info")]
    public string PlayerPartType;

    private SpriteRenderer PlayerPart;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Equip()
    {
        PlayerPart = GameObject.Find(PlayerPartType).GetComponent<SpriteRenderer>();

        if (PlayerPart.sprite == ItemSprite)    
            return;

        PlayerPart.sprite = ItemSprite;
        GameManager.Instance.SetEquipedItems(this, PlayerPartType);
    }
}
