using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemButton : MonoBehaviour
{

    public Image ButtonImage;
    public int ButtonValue;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Press()
    {

        if(UIBehavior.Instance.MainMenu.activeInHierarchy) { 
            if (GameManager.Instance.ItemsPositions[ButtonValue] != "")
            {
                UIBehavior.Instance.SelectItem(GameManager.Instance.GetItemByName(GameManager.Instance.ItemsPositions[ButtonValue]));
            }
        }else if (ShopBehavior.Instance.Shop.activeInHierarchy)
        {
            if(ShopBehavior.Instance.BuyPanel.activeInHierarchy)
            {
                if(ShopBehavior.Instance.itemsForSale[ButtonValue] != "" )
                    ShopBehavior.Instance.BuySelectItem(GameManager.Instance.GetItemByName(ShopBehavior.Instance.itemsForSale[ButtonValue]));
            }
            if (ShopBehavior.Instance.SellPanel.activeInHierarchy)
            {
                if (GameManager.Instance.ItemsPositions[ButtonValue] != "")
                    ShopBehavior.Instance.SellSelectItem(GameManager.Instance.GetItemByName(GameManager.Instance.ItemsPositions[ButtonValue]));
            }

        }
    }
}
