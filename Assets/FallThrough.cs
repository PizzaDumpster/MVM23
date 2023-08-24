using System.Collections;
using UnityEngine;

public class FallThrough : MonoBehaviour
{
    Collider2D collider;
    [SerializeField] Joystick joystick; 

    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<Collider2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (Input.GetKey(KeyCode.S) || (Input.GetAxisRaw("Vertical") > 0) || joystick.Vertical > 0)
            {
                StartCoroutine(DropThrough());
            }
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (Input.GetKey(KeyCode.S) || (Input.GetAxisRaw("Vertical") > 0) || joystick.Vertical > 0)
            {
                StartCoroutine(DropThrough());
            }
        }
    }

    IEnumerator DropThrough()
    {
        collider.enabled = false;
        yield return new WaitForSeconds(1);
        collider.enabled = true;
        yield return null; 
    }
}
