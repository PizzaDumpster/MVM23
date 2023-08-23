using UnityEngine;

public class NoStick : MonoBehaviour
{
    PhysicsMaterial2D myMaterial;
    PlayerMovement playerMovement;
    CapsuleCollider2D myCapsule; 

    // Start is called before the first frame update
    void Start()
    {
        myMaterial = new PhysicsMaterial2D();
        playerMovement = FindAnyObjectByType<PlayerMovement>();
        myCapsule = GetComponent<CapsuleCollider2D>();
        myCapsule.sharedMaterial = myMaterial;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (playerMovement.isGrounded)
        {
            myMaterial.friction = 0.4f;
            myCapsule.enabled = false;
            myCapsule.enabled = true; 
            
        }else if (playerMovement.isInAir)
        {
            myMaterial.friction = 0.0f;
            myCapsule.enabled = false;
            myCapsule.enabled = true;
        }
    }
}
