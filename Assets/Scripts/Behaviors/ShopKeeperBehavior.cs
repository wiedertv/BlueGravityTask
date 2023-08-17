using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopKeeperBehavior : MonoBehaviour
{

    private bool canOpenStore;

    [field: SerializeField]
    public string[] itemsForSale { get; private set; } = new string[28]; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(canOpenStore && Input.GetButtonDown("Submit") && Player.Instance.CanMove)
        {
            ShopBehavior.Instance.itemsForSale = itemsForSale;
            ShopBehavior.Instance.OpenShop();
        } 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            canOpenStore = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            canOpenStore = false;
        }
    }
}
