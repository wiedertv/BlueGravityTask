using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIBehavior : MonoBehaviour
{

    public static UIBehavior Instance { get; private set; }

    
    [field: Header("Inventory Options")]
    [field: SerializeField]
    public GameObject MainMenu { get; private set; }
    [SerializeField]
    private ItemButton[] ItemButtons;
    public Item ActiveItem;
    public string SelectedItem;
    [SerializeField]
    private TextMeshProUGUI ItemName, ItemDescription, EquipButtonText;


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
            OpenCloseMenu();
        }
    }

    public void OpenCloseMenu()
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
                if (GameManager.Instance.GetEquipedHood().ItemName == ActiveItem.ItemName)
                    EquipButtonText.text = "Equiped";
                else
                    EquipButtonText.text = "Equip";
                break;
            case "torso":
                if (GameManager.Instance.GetEquipedTorso().ItemName == ActiveItem.ItemName)
                    EquipButtonText.text = "Equiped";
                else
                    EquipButtonText.text = "Equip";
                break;
            case "pelvis":
                if (GameManager.Instance.GetEquipedPelvis().ItemName == ActiveItem.ItemName)
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
        SelectItem(ActiveItem);
    }
}
