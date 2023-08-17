using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIBehavior : MonoBehaviour
{

    public static UIBehavior Instance { get; private set; }

    [SerializeField]
    private GameObject MainMenu;

    [Header("Inventory Options")]
    [SerializeField]
    private ItemButton[] ItemButtons;
    public Item ActiveItem;
    public string SelectedItem;
    [SerializeField]
    private TextMeshProUGUI ItemName, ItemDescription, EquipButtonText;

    // Start is called before the first frame update
    void Start()
    {

        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
        
        MainMenu.SetActive(false);

        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        MenuController();
        
    }

    private void MenuController()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            if (MainMenu.activeInHierarchy)
            {
                MainMenu.SetActive(false);
                GameManager.Instance.GameMenuOpen = false;
            }
            else
            {
                ShowItems();
                MainMenu.SetActive(true);
                GameManager.Instance.GameMenuOpen = true;

            }
        }
    }

    public void CloseMenuButton()
    {
        MainMenu.SetActive(false);
        GameManager.Instance.GameMenuOpen = false;
    }


    public void ShowItems()
    {
        GameManager.Instance.SortItems();

        for(int i = 0; i < ItemButtons.Length; i++)
        {
            ItemButtons[i].ButtonValue = i;


            if (GameManager.Instance.ItemsPositions[i] != "")
            {
                ItemButtons[i].ButtonImage.gameObject.SetActive(true);
                ItemButtons[i].ButtonImage.sprite = GameManager.Instance.GetItemByName(GameManager.Instance.ItemsPositions[i]).ItemSprite;
            }
            else
            {
                ItemButtons[i].ButtonImage.gameObject.SetActive(false);
            }
        }

    }

    public void SelectItem(Item newItem)
    {

        ActiveItem = newItem;

        switch (ActiveItem.PlayerPartType)
        {
            case "hood":
                if (GameManager.Instance.GetEquipedHood() == ActiveItem)
                    EquipButtonText.text = "Equiped";
                else
                    EquipButtonText.text = "Equip";
                break;
            case "torso":
                if (GameManager.Instance.GetEquipedTorso() == ActiveItem)
                    EquipButtonText.text = "Equiped";
                else
                    EquipButtonText.text = "Equip";
                break;
            case "pelvis":
                if (GameManager.Instance.GetEquipedPelvis() == ActiveItem)
                    EquipButtonText.text = "Equiped";
                else
                    EquipButtonText.text = "Equip";
                break;

        }
        ItemName.text = ActiveItem.ItemName;
        ItemDescription.text = ActiveItem.ItemDesc;


    }
    
    public void EquippingItem()
    {
        ActiveItem.Equip();
    }
}
