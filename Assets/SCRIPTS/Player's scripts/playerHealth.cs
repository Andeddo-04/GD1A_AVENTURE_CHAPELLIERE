using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerHealth : MonoBehaviour
{
    public int maxhealth = 100;
    
    public int currentHealth;

    public bool isInvicible = false;

    public SpriteRenderer graphics;

    public PlayerHealthbar healthBar;


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxhealth;
        healthBar.SetMaxHealth(maxhealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            TakeDamage(100);
        }
    }

    public void TakeDamage(int damage)
    {
        if (!isInvicible)
        {
            currentHealth -= damage;
            healthBar.SetHealth(currentHealth);

            if (currentHealth <= 0)
            {
                Die();
                return;
            }

            isInvicible = true;
            StartCoroutine(InvincibilityFlash());
            StartCoroutine(HandleInvincibilityDelay());
            
        }
    }

    public void Die()
    {
        PlayerMovement.instance.enabled = false;
        //PlayerMovement.instance.animator.SetTrigger("Die");
        PlayerMovement.instance.characterSprite.bodyType = RigidbodyType2D.Kinematic;
        PlayerMovement.instance.characterSprite.velocity = Vector3.zero;
        PlayerMovement.instance.characterBoxCollider.enabled = false;
        
        PlayerMovement.instance.characterSpriteRenderer.enabled = false;

    }

    public IEnumerator InvincibilityFlash()
    {
        while (isInvicible)
        {
            graphics.color = new Color(1f, 1f, 1f, 0f);
            yield return new WaitForSeconds(0.33f);
            graphics.color = new Color(1f, 1f, 1f, 1f);
            yield return new WaitForSeconds(0.33f);
        }
    }

    public IEnumerator HandleInvincibilityDelay()
    {
        while (isInvicible)
        {
            yield return new WaitForSeconds(3f);
            isInvicible = false;
        }
    }

}
