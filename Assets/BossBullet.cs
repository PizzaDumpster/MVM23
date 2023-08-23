using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BossBullet : MonoBehaviour
{
    public float moveSpeed;

    public Rigidbody2D thisRB;
    PlayerMovement playerMovement;
    [SerializeField]
    CircleCollider2D myCollider;
    [SerializeField] CircleCollider2D BossCollider; 


    // Start is called before the first frame update
    void Start()
    {
        BossCollider = GameObject.Find("Monster").GetComponent<CircleCollider2D>();
        playerMovement = GameObject.Find("whiteman_8").GetComponent<PlayerMovement>();
        

        Vector3 direction = transform.position - playerMovement.transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        //AudioManager.instance.PlaySFXAdjusted(2);
        Physics2D.IgnoreCollision(BossCollider, myCollider);
    }

    // Update is called once per frame
    void Update()
    {
        thisRB.velocity = -transform.right * moveSpeed;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerMovement.playerHealth--; 
        }
        Destroy(gameObject);

    }
}