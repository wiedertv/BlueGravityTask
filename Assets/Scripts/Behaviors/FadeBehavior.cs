using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeBehavior : MonoBehaviour
{
    [Header("Fading Variables")]
    [SerializeField]
    private Image FadeImage;
    [SerializeField]
    private float FadeSpeed;

    private bool ShouldFadeToBlack;
    private bool ShouldFadeFromBlack;

    public static FadeBehavior Instance { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        if(Instance == null)
            Instance = this;
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);

    }

    // Update is called once per frame
    void Update()
    {
        if (ShouldFadeToBlack)
        {
            FadeImage.color = new Color(FadeImage.color.r, FadeImage.color.b, FadeImage.color.g, Mathf.MoveTowards(FadeImage.color.a, 1f, FadeSpeed * Time.deltaTime));
            if(FadeImage.color.a == 1f )
            {
                ShouldFadeToBlack = false;
            }
        }

        if (ShouldFadeFromBlack)
        {
            FadeImage.color = new Color(FadeImage.color.r, FadeImage.color.b, FadeImage.color.g, Mathf.MoveTowards(FadeImage.color.a, 0, FadeSpeed * Time.deltaTime));
            if (FadeImage.color.a == 0)
            {
                ShouldFadeFromBlack = false;
            }
        }
    }

    public void FadeToBlack()
    {
        ShouldFadeToBlack = true;
        ShouldFadeFromBlack = false;
    }

    public void FadeFromBlack() 
    {
        ShouldFadeToBlack = false;
        ShouldFadeFromBlack = true;
    }

}

