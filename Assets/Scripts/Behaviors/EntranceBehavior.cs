using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EntranceBehavior : MonoBehaviour
{
    [SerializeField]
    private string areaToGo;
    [SerializeField]
    private string areaTransitionName;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            SceneManager.LoadScene(areaToGo);
            Player.Instance.areaTransitionName = areaTransitionName;
        }
    }
}
