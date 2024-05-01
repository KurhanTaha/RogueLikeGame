using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    public static PlayerHealthController instance;
    public int currentHealth,maxHealth;

    public float damageInvincibleLength = 1f;
    public float invincibleCount;

    // Start is called before the first frame update

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        
        currentHealth = maxHealth;
        UIController.instance.healthSlider.maxValue = maxHealth;
        UIController.instance.healthSlider.value = currentHealth;
        UIController.instance.healthText.text = currentHealth.ToString() + "/" + maxHealth.ToString();
        invincibleCount = damageInvincibleLength;
    }

    // Update is called once per frame
    void Update()
    {
        if (invincibleCount > 0 )
        {
            invincibleCount -= Time.deltaTime;
            
            if (invincibleCount <= 0)
            {
                PlayerController.instance.bodySR.color = new Color(PlayerController.instance.bodySR.color.r,PlayerController.instance.bodySR.color.g,PlayerController.instance.bodySR.color.b,1f);
                PlayerController.instance.handSR.color = new Color(PlayerController.instance.handSR.color.r,PlayerController.instance.handSR.color.g,PlayerController.instance.handSR.color.b,1f);
                PlayerController.instance.gunSR.color = new Color(PlayerController.instance.gunSR.color.r,PlayerController.instance.gunSR.color.g,PlayerController.instance.gunSR.color.b,1f);
            }
        }
    }

    public void DamagePlayer()
    {
        if (invincibleCount <= 0 )
        {
            if (currentHealth > 0)
            {
                AudioManager.instance.SFXPlay(11);
            }
            damageInvincibleLength = 1f;
            invincibleCount = damageInvincibleLength;
            currentHealth --;

            PlayerController.instance.bodySR.color = new Color(PlayerController.instance.bodySR.color.r,PlayerController.instance.bodySR.color.g,PlayerController.instance.bodySR.color.b,0.5f);
            PlayerController.instance.handSR.color = new Color(PlayerController.instance.handSR.color.r,PlayerController.instance.handSR.color.g,PlayerController.instance.handSR.color.b,0.5f);
            PlayerController.instance.gunSR.color = new Color(PlayerController.instance.gunSR.color.r,PlayerController.instance.gunSR.color.g,PlayerController.instance.gunSR.color.b,0.5f);
            if (currentHealth <= 0)
            {
                AudioManager.instance.SFXPlay(9);
                PlayerController.instance.gameObject.SetActive(false);
                UIController.instance.deathScreen.SetActive(true);
                AudioManager.instance.PlayGameOver();
            }
            
            UIController.instance.healthSlider.value = currentHealth;
            UIController.instance.healthText.text = currentHealth.ToString() + "/" + maxHealth.ToString();
        }    
    }

    public void MakeInvincible(float length)
    {
        damageInvincibleLength = length;
        invincibleCount = damageInvincibleLength;
        PlayerController.instance.bodySR.color = new Color(PlayerController.instance.bodySR.color.r,PlayerController.instance.bodySR.color.g,PlayerController.instance.bodySR.color.b,0.5f);
        PlayerController.instance.handSR.color = new Color(PlayerController.instance.handSR.color.r,PlayerController.instance.handSR.color.g,PlayerController.instance.handSR.color.b,0.5f);
        PlayerController.instance.gunSR.color = new Color(PlayerController.instance.gunSR.color.r,PlayerController.instance.gunSR.color.g,PlayerController.instance.gunSR.color.b,0.5f);

    }

    public void HealPlayer(int healAmount)
    {
        currentHealth += healAmount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        UIController.instance.healthSlider.value = currentHealth;
        UIController.instance.healthText.text = currentHealth.ToString() + "/" + maxHealth.ToString();
    }
}
