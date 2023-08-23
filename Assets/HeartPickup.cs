using UnityEngine;

public class HeartPickup : MonoBehaviour
{
    PlayerMovement playerMovement;

    private void Start()
    {
        playerMovement = FindAnyObjectByType<PlayerMovement>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            AudioManager.instance.Play("Pickup");
            Popup.instance.PlayPopup("Heart Collected!");
            GameObject.Destroy(gameObject);
            if (playerMovement.playerHealth <= 2)
            {
                playerMovement.playerHealth++;
            }

        }

    }
}
