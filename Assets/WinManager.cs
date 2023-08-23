using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinManager : MonoBehaviour
{
    [SerializeField] Canvas winCanvas;
    Monster myMonster; 
    // Start is called before the first frame update
    void Start()
    {
        myMonster = FindAnyObjectByType<Monster>();
        winCanvas = GetComponent<Canvas>();
        winCanvas.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (myMonster.winning)
        {
            winCanvas.enabled = true; 
        }
    }
}
