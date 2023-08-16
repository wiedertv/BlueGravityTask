using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBehavior : MonoBehaviour
{

    [SerializeField]
    private string transitionName;

    // Start is called before the first frame update
    void Start()
    {
        if(transitionName == Player.Instance.areaTransitionName)
            Player.Instance.transform.position = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
