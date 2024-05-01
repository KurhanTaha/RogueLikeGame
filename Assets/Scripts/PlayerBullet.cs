using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public float speed;
    public Rigidbody2D theRB;
    public GameObject impactEffect;


    void Start()
    {
        AudioManager.instance.SFXPlay(12);
    }

    // Update is called once per frame
    void Update()
    {
        theRB.velocity = transform.right*speed;
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Instantiate(impactEffect,transform.position,transform.rotation);
        Destroy(gameObject);

        if (other.tag == "Enemy")
        {
           AudioManager.instance.SFXPlay(2);
            other.GetComponent<EnemyController>().DamageEnemy(Random.Range(30,55));
        }
        
    }
    

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
