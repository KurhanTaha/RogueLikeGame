using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakables : MonoBehaviour
{
    public GameObject[] brokenPieces;
    public int maxPiece = 5;

    public bool shouldDropItems;
    public GameObject[] itemsToDrop;
    public float itemDropPercent;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (PlayerController.instance.dashCounter > 0)
        {
            if (other.gameObject.tag == "Player")
                {
                    Destroy(gameObject);
                    AudioManager.instance.SFXPlay(0);

                    
                    //show broken pieces
                    int piecesToDrop = Random.Range(1,maxPiece);
                    for (int i = 0; i < piecesToDrop; i++)
                    {
                        int randomPiece = Random.Range(0,brokenPieces.Length);
                        Instantiate(brokenPieces[randomPiece],transform.position,transform.rotation);
                    }

                    //drop items
                    if (shouldDropItems)
                    {
                        float dropChange = Random.Range(0f,100f);
                        if (dropChange < itemDropPercent)
                        {
                            int randomItem = Random.Range(0,itemsToDrop.Length);
                            Instantiate(itemsToDrop[randomItem],transform.position,transform.rotation);
                        }
                    }
        
                }

            
            
        }

        
    }

    private void OnCollisionStay2D(Collision2D other)
    {
       if (PlayerController.instance.dashCounter > 0)
        {
            if (other.gameObject.tag == "Player")
                {
                    Destroy(gameObject);
                    int piecesToDrop = Random.Range(1,maxPiece);
                    for (int i = 0; i < piecesToDrop; i++)
                    {
                        int randomPiece = Random.Range(0,brokenPieces.Length);
                        Instantiate(brokenPieces[randomPiece],transform.position,transform.rotation);
                    }
                }

                //drop items
                    if (shouldDropItems)
                    {
                        float dropChange = Random.Range(0f,100f);
                        if (dropChange < itemDropPercent)
                        {
                            int randomItem = Random.Range(0,itemsToDrop.Length);
                            Instantiate(itemsToDrop[randomItem],transform.position,transform.rotation);
                        }
                    }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "PlayerBullet")
        {
            
                    Destroy(gameObject);
                    int piecesToDrop = Random.Range(1,maxPiece);
                    for (int i = 0; i < piecesToDrop; i++)
                    {
                        int randomPiece = Random.Range(0,brokenPieces.Length);
                        Instantiate(brokenPieces[randomPiece],transform.position,transform.rotation);
                    }
                

                //drop items
                    if (shouldDropItems)
                    {
                        float dropChange = Random.Range(0f,100f);
                        if (dropChange < itemDropPercent)
                        {
                            int randomItem = Random.Range(0,itemsToDrop.Length);
                            Instantiate(itemsToDrop[randomItem],transform.position,transform.rotation);
                        }
                    }
        }
    }
}   

