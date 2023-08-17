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
        if (GameManager.Instance.ItemsPositions[ButtonValue] != "")
        {
            UIBehavior.Instance.SelectItem(GameManager.Instance.GetItemByName(GameManager.Instance.ItemsPositions[ButtonValue]));
        }
    }
}
