using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickUp : MonoBehaviour
{
    private int healAmount = 1;

    public float waitToBeCollected = .5f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (waitToBeCollected > 0)
        {
            waitToBeCollected -= Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        
        if (other.tag == "Player" && waitToBeCollected <= 0)
        {
            AudioManager.instance.SFXPlay(7);
            PlayerHealthController.instance.HealPlayer(healAmount);
            Destroy(gameObject);
        }
        
    }
}
