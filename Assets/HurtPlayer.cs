using System.Collections;
using UnityEngine;

public class HurtPlayer : MonoBehaviour
{

    PlayerMovement playerMovement;
    [SerializeField] float invincableTime;
    // Start is called before the first frame update
    void Start()
    {
        invincableTime = 1f;
        
        playerMovement = FindAnyObjectByType<PlayerMovement>();
        playerMovement.isBlinking = false; 
    }

    // Update is called once per frame
    void Update()
    {
        if (playerMovement.playerInvincable)
        {
            if(!playerMovement.isBlinking)
                StartCoroutine(PlayerBlinking());
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (!playerMovement.playerInvincable)
            {
                AudioManager.instance.Play("Hit");
                playerMovement.playerHealth--;
                StartCoroutine(PlayerInvincable());
            }

        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (!playerMovement.playerInvincable)
            {
                AudioManager.instance.Play("Hit");
                playerMovement.playerHealth--;
                StartCoroutine(PlayerInvincable());
            }
        }
    }

    public IEnumerator PlayerInvincable()
    {
        playerMovement.playerInvincable = true; 
        yield return new WaitForSeconds(invincableTime);
        playerMovement.playerInvincable = false; 
        yield return null;
    }
    public IEnumerator PlayerBlinking()
    {
        playerMovement.isBlinking = true; 
        yield return new WaitForSeconds(0.1f);
        playerMovement.GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(0.1f);
        playerMovement.GetComponent<SpriteRenderer>().color = Color.white;
        yield return new WaitForSeconds(0.1f);
        playerMovement.GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(0.1f);
        playerMovement.GetComponent<SpriteRenderer>().color = Color.white;
        yield return new WaitForSeconds(0.1f);
        playerMovement.GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(0.1f);
        playerMovement.GetComponent<SpriteRenderer>().color = Color.white;
        yield return new WaitForSeconds(0.1f);
        playerMovement.GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(0.1f);
        playerMovement.GetComponent<SpriteRenderer>().color = Color.white;
        yield return new WaitForSeconds(0.1f);
        playerMovement.GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(0.1f);
        playerMovement.GetComponent<SpriteRenderer>().color = Color.white;
        playerMovement.isBlinking = false; 
        yield return null; 


    }
}
