using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EntranceBehavior : MonoBehaviour
{
    [SerializeField]
    private string AreaToGo;
    [SerializeField]
    private string AreaTransitionName;
    [SerializeField]
    private float TimeToLoad;

    private bool shouldLoad;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (shouldLoad)
        {
            TimeToLoad -= Time.deltaTime;

            if(TimeToLoad <= 0)
            {
                shouldLoad = false;
                SceneManager.LoadScene(AreaToGo);

            }
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            shouldLoad = true;
            FadeBehavior.Instance.FadeToBlack();
            GameManager.Instance.FadingBetweenAreas = true;
            Player.Instance.AreaTransitionName = AreaTransitionName;
        }
    }
}
