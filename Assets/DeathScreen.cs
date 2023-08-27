using PoopInMyPants;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class DeathScreen : MonoBehaviour
{

    [SerializeField] Canvas myCanvas;
    [SerializeField] TMP_Text deathText;
    DisplayCount myDisplay; 
    // Start is called before the first frame update
    void Start()
    {
        myDisplay = FindObjectOfType<DisplayCount>();
        myCanvas = GetComponent<Canvas>();
        myCanvas.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (myDisplay.playerIsDead)
        {
            myCanvas.enabled = true;
            PlayerMovement.instance.enabled = false;
        }
        else
        {
            myCanvas.enabled = false; 
        }
    }

    public void ResetScene()
    {
        PlayerMovement.instance.enabled = true; 
        PlayerMovement.instance.transform.position = GameManager.instance.lastCheckPointPos; 
        PlayerMovement.instance.playerHealth = 3;
        myDisplay.playerIsDead = false;
        SceneManager.LoadScene(0);
    }
}
