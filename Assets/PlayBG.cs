using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayBG : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AudioManager.instance.Play("Background");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
