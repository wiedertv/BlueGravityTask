using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBehavior : MonoBehaviour
{

    public static UIBehavior Instance { get; private set; }

    [SerializeField]
    private GameObject MainMenu;


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
                MainMenu.SetActive(true);
                GameManager.Instance.GameMenuOpen = true;

            }
        }
    }
    
}
