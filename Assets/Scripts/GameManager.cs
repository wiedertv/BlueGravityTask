using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance { get; private set; }

    public bool GameMenuOpen, DialogActive, FadingBetweenAreas;

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
    }
}
