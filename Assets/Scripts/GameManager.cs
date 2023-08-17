using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance { get; private set; }

    public bool GameMenuOpen, DialogActive, FadingBetweenAreas;


    [Header("Inventory Information")]
    public Item[] referenceItems;
    public Item[] equipedItems = new Item[3];
    public string[] ItemsPositions;


    // Start is called before the first frame update
    void Start()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if(GameMenuOpen ||  DialogActive || FadingBetweenAreas)
        {
            Player.Instance.CanMove = false;
        } else
        {
            Player.Instance.CanMove = true;
        }

        AddItemToInventory("");
    }

    public Item GetItemByName(string name)
    {

        for(int i = 0;i < referenceItems.Length;i++)
        {
            if (referenceItems[i].ItemName == name) return referenceItems[i];
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
                equipedItems[0] = itemToEquip; 
                break;
            case "torso":
                equipedItems[1] = itemToEquip;
                break;
            case "pelvis":
                equipedItems[2] = itemToEquip;
                break;

        }
    }

    public Item GetEquipedHood()
    {
        return equipedItems[0];
    }
    public Item GetEquipedTorso()
    {
        return equipedItems[1];
    }
    public Item GetEquipedPelvis()
    {
        return equipedItems[2];
    }
}
