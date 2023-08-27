using UnityEngine;

namespace PoopInMyPants
{
    public class Checkpoint : MonoBehaviour
    {
      

        private void Start()
        {
           
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                GameManager.instance.lastCheckPointPos = transform.position;
                AudioManager.instance.Play("Pickup");
                Popup.instance.PlayPopup("CheckPoint!");
            }
        }
    }
}
