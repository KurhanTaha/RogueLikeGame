using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenPieces : MonoBehaviour
{
    public float moveSpeed = 3f;
    private Vector3 moveDirection;
    public float decelaration =5f;
    public float lifeTime = 3f;

    public SpriteRenderer piecesSR;
    public float fadeSpeed = 2.5f;

    void Start()
    {
        moveDirection.x = Random.Range(-moveSpeed,moveSpeed);
        moveDirection.y = Random.Range(-moveSpeed,moveSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += moveDirection * Time.deltaTime;
        moveDirection = Vector3.Lerp(moveDirection,Vector3.zero,decelaration * Time.deltaTime);
        lifeTime -= Time.deltaTime;
        
        if (lifeTime < 1)
        {
            piecesSR.color = new Color(piecesSR.color.r,piecesSR.color.g,piecesSR.color.b,Mathf.MoveTowards(piecesSR.color.a,0f,fadeSpeed*Time.deltaTime));
            if (piecesSR.color.a == 0)
            {
                Destroy(gameObject);
            }
            

        }
 
        
    }
}
