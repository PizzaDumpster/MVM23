using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Monster : MonoBehaviour
{
    [SerializeField] GameObject enemyBullet;
    [SerializeField] Transform firePointLeft;
    [SerializeField] Transform firePointRight;
    [SerializeField] Transform playerTarget;
    [SerializeField] float fireRateCoolDown;
    [SerializeField] public bool winning;

    [SerializeField] Image monsterHeart1;
    [SerializeField] Image monsterHeart2;
    [SerializeField] Image monsterHeart3;

    [SerializeField] Sprite fullHeart;
    [SerializeField] Sprite emptyHeart;

    [SerializeField] bool gettingHit;

    [SerializeField] SpriteRenderer myMonster;
    [SerializeField] bool isBlinking;




    public int health = 3;


    // Start is called before the first frame update
    void Start()
    {
        winning = false;
        fireRateCoolDown = 2f;
        health = 3;
        gettingHit = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(playerTarget.transform.position, this.transform.position) < 25)
        {
            if (fireRateCoolDown > 0)
            {
                fireRateCoolDown -= Time.deltaTime;
                AudioManager.instance.Play("Laugh");
                StartCoroutine(FireBossBullet());
            }
        }

        switch (health)
        {
            case 0:
                winning = true;
                Destroy(gameObject);
                monsterHeart1.sprite = emptyHeart;
                monsterHeart2.sprite = emptyHeart;
                monsterHeart3.sprite = emptyHeart;
                break;
            case 1:
                monsterHeart1.sprite = fullHeart;
                monsterHeart2.sprite = emptyHeart;
                monsterHeart3.sprite = emptyHeart;
                break;
            case 2:
                monsterHeart1.sprite = fullHeart;
                monsterHeart2.sprite = fullHeart;
                monsterHeart3.sprite = emptyHeart;
                break;
            case 3:
                monsterHeart1.sprite = fullHeart;
                monsterHeart2.sprite = fullHeart;
                monsterHeart3.sprite = fullHeart;
                break;
        }




    }

    IEnumerator FireBossBullet()
    {
        if (fireRateCoolDown < 0)
        {
            Instantiate(enemyBullet, firePointLeft.position, firePointLeft.rotation);
            AudioManager.instance.Play("FireBall");
            yield return new WaitForSeconds(1f);
            Instantiate(enemyBullet, firePointRight.position, firePointLeft.rotation);
            AudioManager.instance.Play("FireBall");
            yield return null;
            fireRateCoolDown = 1f;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (!gettingHit)
                StartCoroutine(HitMonster());
        }
    }

    IEnumerator HitMonster()
    {
        gettingHit = true;
        if (!isBlinking)
        {
            StartCoroutine(MonsterBlinking());
        }

        health--;
        yield return new WaitForSeconds(1f);
        gettingHit = false;
        yield return null;
    }

    public IEnumerator MonsterBlinking()
    {
        isBlinking = true;
        yield return new WaitForSeconds(0.1f);
        myMonster.color = Color.blue;
        yield return new WaitForSeconds(0.1f);
        myMonster.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        myMonster.color = Color.yellow;
        yield return new WaitForSeconds(0.1f);
        myMonster.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        myMonster.color = Color.blue;
        yield return new WaitForSeconds(0.1f);
        myMonster.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        myMonster.color = Color.yellow;
        yield return new WaitForSeconds(0.1f);
        myMonster.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        myMonster.color = Color.blue;
        yield return new WaitForSeconds(0.1f);
        myMonster.color = Color.red;
        isBlinking = false;
        yield return null;


    }
}
