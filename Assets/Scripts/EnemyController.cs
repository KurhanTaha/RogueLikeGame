using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public static EnemyController instance;

    public Rigidbody2D theRB;
    public float moveSpeed;
    public float rangeToChasePlayer;
    private Vector3 moveDirection;
    public Animator anim;
    public int health = 150;
    public GameObject[] deathSplatter;
    public GameObject enemyHurtEffect;

    public bool shouldShoot;
    public GameObject bullet;
    public Transform firePoint;
    public float fireRate;
    private float fireCounter;

    public float shootRange;

    public SpriteRenderer theBody;
    
    void Start()
    {
        
    }

    private void Awake()
    {
        instance = this;
    }
    void Update()
    {
        if(theBody.isVisible && PlayerController.instance.gameObject.activeInHierarchy)
        {
            if (Vector3.Distance(transform.position,PlayerController.instance.transform.position) < rangeToChasePlayer)
            {
                moveDirection = PlayerController.instance.transform.position - transform.position;
            }else
            {
                moveDirection = Vector3.zero;
            }

            moveDirection.Normalize();
            theRB.velocity = moveDirection * moveSpeed;

            

            if (shouldShoot && Vector3.Distance(transform.position,PlayerController.instance.transform.position) < shootRange)
            {
                fireCounter -= Time.deltaTime;

                if (fireCounter <= 0)
                {
                    fireCounter = fireRate;
                    Instantiate(bullet,firePoint.transform.position,firePoint.transform.rotation);
                }
            }
        }else
        {
            theRB.velocity = Vector2.zero;
        }




        if (moveDirection != Vector3.zero)
        {
            anim.SetBool("isMoving",true);
        }else
        {
            anim.SetBool("isMoving", false);
        }
    }

    public void DamageEnemy(int damage)
    {
        health -= damage;
        Instantiate(enemyHurtEffect,transform.position,transform.rotation);
        if (health <= 0)
        {
            AudioManager.instance.SFXPlay(1);
            Destroy(gameObject);
            int selectSplatterNumbers = Random.Range(0,deathSplatter.Length);
            int rotation = Random.Range(0,4);
            Instantiate(deathSplatter[selectSplatterNumbers],transform.position,Quaternion.Euler(0f,0f,rotation*90f));
        }
    }
}
