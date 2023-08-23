using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blinking : MonoBehaviour
{
    
    HurtPlayer[] hurtPlayer;
    PlayerMovement playeMovement; 

    // Start is called before the first frame update
    void Start()
    {
        hurtPlayer = FindObjectsOfType<HurtPlayer>();
        playeMovement = FindObjectOfType<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
