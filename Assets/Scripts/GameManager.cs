using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance { get; private set; }

    public bool GameMenuOpen, DialogActive, FadingBetweenAreas, ShopActive;


    [Header("Inventory Information")]
    public Item[] ReferenceItems;
    public Item[] EquipedItems = new Item[3];
    public string[] ItemsPositions;

    [Header("Gold Information")]
    [SerializeField]
    private TextMeshProUGUI GoldText;
    public int CurrentCoinAmount = 20_000;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if(GameMenuOpen ||  DialogActive || FadingBetweenAreas || ShopActive)
        {
            Player.Instance.CanMove = false;
        } else
        {
            Player.Instance.CanMove = true;
        }

        UpdateGold();
    }

    public Item GetItemByName(string name)
    {

        for(int i = 0;i < ReferenceItems.Length;i++)
        {
            if (ReferenceItems[i].ItemName == name) return ReferenceItems[i];
        }

        return null;
    }

    public void SortItems()
    {
        int auxiliarCounter = 0;

        for(int i = 0; i <ItemsPositions.Length; i++)
        {
            if (ItemsPositions[i] != "")
            {
                string temp = ItemsPositions[auxiliarCounter];
                ItemsPositions[auxiliarCounter] = ItemsPositions[i];
                ItemsPositions[i] = temp;
                auxiliarCounter++;
            }
        }
    }

    public void AddItemToInventory(string itemToAdd)
    {
        List<int> spots = CheckEmptySlots();
        
        if (spots.Count > 0)
        {
            ItemsPositions[spots[0]] = itemToAdd;

        }

    }

    public void RemoveItemFromInventory(string itemToRemove)
    {
        for (int i = 0; i < ItemsPositions.Length; i++)
        {
            if (ItemsPositions[i] == itemToRemove)
            {
                ItemsPositions[i] = "";
                UIBehavior.Instance.ShowItems();
                break;
            }
        }
    }

    public List<int> CheckEmptySlots ()
    {
        List<int> emptySlots = new List<int>();

        for (int i = 0; i < ItemsPositions.Length; i++)
        {
            if (ItemsPositions[i] == "")
                emptySlots.Add(i);

        }
        
        return emptySlots;
    }

    public void SetEquipedItems(Item itemToEquip, string type)
    {
        switch (type)
        {
            case "hood":
                EquipedItems[0] = itemToEquip; 
                break;
            case "torso":
                EquipedItems[1] = itemToEquip;
                break;
            case "pelvis":
                EquipedItems[2] = itemToEquip;
                break;

        }
    }

    public Item GetEquipedHood()
    {
        return EquipedItems[0];
    }
    public Item GetEquipedTorso()
    {
        return EquipedItems[1];
    }
    public Item GetEquipedPelvis()
    {
        return EquipedItems[2];
    }


    public void AddMoreGold()
    {
        CurrentCoinAmount += 20_000;
    }

    private void UpdateGold()
    {
        GoldText.text = CurrentCoinAmount.ToString("N0");
    }
}
