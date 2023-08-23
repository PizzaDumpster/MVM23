using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DisplayCount : MonoBehaviour
{
    [SerializeField] TMP_Text starCounterDisplay;
    [SerializeField] TMP_Text dashAvailable;
    [SerializeField] Image heartOne;
    [SerializeField] Image heartTwo;
    [SerializeField] Image heartThree;
    [SerializeField] Sprite heartFull;
    [SerializeField] Sprite heartEmpty;
    [SerializeField] Transform spawnPoint;
    [SerializeField] public bool playerIsDead; 




    PlayerMovement playerMovement;

    // Start is called before the first frame update
    void Start()
    {
        playerIsDead = false; 
        playerMovement = FindAnyObjectByType<PlayerMovement>();
        starCounterDisplay.text = "Stars: " + CollectionManager.instance.starCounter.ToString();
        if (playerMovement.unlockedDash)
        {
            dashAvailable.text = "Dash Available";
        }
        else
        {
            dashAvailable.text = "No Dash Available";
        }

    }

    // Update is called once per frame
    void Update()
    {
        if(playerMovement.playerHealth < 0)
        {
            playerMovement.playerHealth = 0; 
        }

        if (starCounterDisplay.text != CollectionManager.instance.starCounter.ToString())
        {
            starCounterDisplay.text = "Stars: " + CollectionManager.instance.starCounter.ToString();
        }

        if (playerMovement.unlockedDash)
        {
            if (playerMovement.canDash)
            {
                dashAvailable.text = "Dash Available";
            }
            else
            {
                dashAvailable.text = "Dash Charging";
            }
        }
        else
        {
            dashAvailable.text = "No Dash Available";
        }


        switch (playerMovement.playerHealth)
        {
            case 0:
                //player dead
                playerIsDead = true; 
                heartOne.sprite = heartEmpty;
                heartTwo.sprite = heartEmpty;
                heartThree.sprite = heartEmpty;
                playerMovement.gameObject.transform.position = spawnPoint.position;
                break;
            case 1:
                heartOne.sprite = heartFull;
                heartTwo.sprite = heartEmpty;
                heartThree.sprite = heartEmpty;
                break;
            case 2:
                heartOne.sprite = heartFull;
                heartTwo.sprite = heartFull;
                heartThree.sprite = heartEmpty;
                break;
            case 3:
                heartOne.sprite = heartFull;
                heartTwo.sprite = heartFull;
                heartThree.sprite = heartFull;
                break;
        }
    }
}
