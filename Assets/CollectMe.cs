using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectMe : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            AudioManager.instance.Play("Pickup");
            Popup.instance.PlayPopup("Pickup Collected!");
            GameObject.Destroy(gameObject);
            CollectionManager.instance.StarIncrement(); 
        }
        
    }
}
