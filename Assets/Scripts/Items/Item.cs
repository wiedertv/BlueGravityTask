using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [field: Header("Item Information")]
    [field: SerializeField]
    public Sprite ItemSprite { get; private set; }
    [field: SerializeField]
    public string ItemName { get; private set; }
    [field: SerializeField]
    public string ItemDesc { get; private set; }
    [field: SerializeField]
    public int value { get; private set; }

    [field: Header("Player Info")]
    [field: SerializeField]
    public string PlayerPartType { get; private set; }

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
