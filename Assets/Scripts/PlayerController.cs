using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    public float moveSpeed;
    private Vector2 moveInput;
    public Rigidbody2D theRB;
    public Transform gunArm;
    private Camera theCam;
    public Animator anim;
    public GameObject bulletToFire;
    public GameObject fireToFire;
    public Transform firePoint;
    public float timeBetweenShots;
    private float shotCounter;
    public SpriteRenderer bodySR,handSR,gunSR;
    private float fireCounter;
    public float fireLength = 3f;
    private float activeMoveSpeed;
    public float dashSpeed = 8f,dashLength = 0.5f,dashCooldown=5f, dashInvincibility = 5f;
    [HideInInspector]
    public float dashCounter;
    private float dashCoolCounter;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        theCam = Camera.main;
        activeMoveSpeed = moveSpeed;
        
    }

    // Update is called once per frame
    void Update()
    {


        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");
        moveInput.Normalize();//çapraz ilerlerken daha hızlı ilerlemesini engeller
        //transform.position += new Vector3(moveInput.x*moveSpeed*Time.deltaTime,moveInput.y*moveSpeed*Time.deltaTime,0f);
        theRB.velocity = moveInput*activeMoveSpeed;
        //getting mouse input to screen
        Vector3 mousePos = Input.mousePosition; 
        Vector3 screenPoint = theCam.WorldToScreenPoint(transform.localPosition);
        //rotate character when mouse is left side
        if (mousePos.x < screenPoint.x)
        {
            transform.localScale = new Vector3(-1f,1f,1f);
            gunArm.localScale = new Vector3(-1f,-1f,1f);
        }else
        {
            transform.localScale = new Vector3(1f,1f,1f);
            gunArm.localScale = Vector3.one;
        }
        //rotate gun arm
        Vector2 offset = new Vector2(mousePos.x - screenPoint.x,mousePos.y - screenPoint.y);
        float angle = Mathf.Atan2(offset.y,offset.x)* Mathf.Rad2Deg;
        gunArm.rotation = Quaternion.Euler(0,0,angle);
        //making the gun fire
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(bulletToFire,firePoint.position,firePoint.rotation);
            shotCounter = timeBetweenShots;
        }

        if (Input.GetMouseButton(0))
        {
            shotCounter -= Time.deltaTime;
            if (shotCounter <= 0)
            {
                Instantiate(bulletToFire,firePoint.position,firePoint.rotation);

                shotCounter = timeBetweenShots;
            }
        }

        //making the fire attack
        if (Input.GetKeyDown(KeyCode.F))
        {
            
            if (fireCounter <= 0)
            {
                Instantiate(fireToFire,firePoint.position,firePoint.rotation);
                fireCounter = fireLength;
            }
            
        }

        if (fireCounter > 0)
        {
            fireCounter -= Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (dashCounter <= 0 && dashCoolCounter <= 0)
            {
                activeMoveSpeed = dashSpeed;
                dashCounter = dashLength;
                
                anim.SetTrigger("dash");
                PlayerHealthController.instance.MakeInvincible(dashInvincibility);
                
            }
           
        }
        if (dashCounter > 0)
        {
            
            dashCounter -= Time.deltaTime;
            if (dashCounter <= 0)
            {
                activeMoveSpeed = moveSpeed;
                dashCoolCounter = dashCooldown;
                
            }
        }        

        if (dashCoolCounter > 0)
        {
            dashCoolCounter -= Time.deltaTime;
        }

        

        





        if (moveInput != Vector2.zero)
        {
            anim.SetBool("isMovingg",true);
        }else
        {
            anim.SetBool("isMovingg",false);
        }

    }
}
