using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShopBehavior : MonoBehaviour
{


    public static ShopBehavior Instance { get; private set; }

    [field: Header("Game Objects of the Shop")]
    [field: SerializeField]
    public GameObject Shop { get; private set; }
    [field: SerializeField]
    public GameObject BuyPanel { get; private set; }
    [field: SerializeField]
    public GameObject SellPanel { get; private set; }

    [field: Header("Item Buttons Info")]
    [field: SerializeField]
    public ItemButton[] BuyButtons { get; private set; }
    [field: SerializeField]
    public ItemButton[] SellButtons { get; private set; }
    [field: SerializeField]
    public string[] itemsForSale;
    public Item ActiveItem;
    [SerializeField]
    private TextMeshProUGUI ItemName, ItemDescription, ItemValue; 
    [SerializeField]
    private TextMeshProUGUI SaleItemName, SaleItemDescription, SaleItemValue;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        Shop.SetActive(false);
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenShop()
    {
        Shop.SetActive(true);
        OpenBuyMenu();
        GameManager.Instance.ShopActive = true;
    }

    public void CloseShop()
    {
        Shop.SetActive(false);
        BuyPanel.SetActive(false);
        SellPanel.SetActive(false);
        GameManager.Instance.ShopActive = false;
    }

    public void OpenBuyMenu()
    {
        BuyPanel.SetActive(true);
        SellPanel.SetActive(false);

        for (int i = 0; i < BuyButtons.Length; i++)
        {
            BuyButtons[i].ButtonValue = i;


            if (itemsForSale[i] != "")
            {
                BuyButtons[i].ButtonImage.gameObject.SetActive(true);
                BuyButtons[i].ButtonImage.sprite = GameManager.Instance.GetItemByName(itemsForSale[i]).ItemSprite;
            }
            else
            {
                BuyButtons[i].ButtonImage.gameObject.SetActive(false);
            }
        }
    }

    public void OpenSellMenu()
    {
        BuyPanel.SetActive(false);
        SellPanel.SetActive(true);
        GameManager.Instance.SortItems();

        for (int i = 0; i < SellButtons.Length; i++)
        {
            SellButtons[i].ButtonValue = i;


            if (GameManager.Instance.ItemsPositions[i] != "")
            {
                SellButtons[i].ButtonImage.gameObject.SetActive(true);
                SellButtons[i].ButtonImage.sprite = GameManager.Instance.GetItemByName(GameManager.Instance.ItemsPositions[i]).ItemSprite;
            }
            else
            {
                SellButtons[i].ButtonImage.gameObject.SetActive(false);
            }
        }
    }


    public void BuySelectItem(Item newItem)
    {
        ActiveItem = newItem;
        ItemName.text = ActiveItem.ItemName;
        ItemDescription.text = ActiveItem.ItemDesc;
        ItemValue.text = "Value: " + ActiveItem.value.ToString("N0");
    }
    public void SellSelectItem(Item newItem)
    {
        ActiveItem = newItem;
        SaleItemName.text = ActiveItem.ItemName;
        SaleItemDescription.text = ActiveItem.ItemDesc;
        SaleItemValue.text = "Value: " + ((int)(ActiveItem.value * .8f)).ToString("N0");
    }

    public void BuyItem()
    {
        if (ActiveItem != null)
        {
            if (GameManager.Instance.CurrentCoinAmount >= ActiveItem.value)
            {
                GameManager.Instance.CurrentCoinAmount -= ActiveItem.value;
                GameManager.Instance.AddItemToInventory(ActiveItem.ItemName);
            }
        }
    }

    public void SellItem()
    {
        if(ActiveItem != null)
        {
            GameManager.Instance.RemoveItemFromInventory(ActiveItem.ItemName);
            GameManager.Instance.CurrentCoinAmount += (int)(ActiveItem.value * .8f);
            UIBehavior.Instance.ShowItems();
        }
    }

}
