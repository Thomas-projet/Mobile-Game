using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public Animator animator;

    private bool is_on_CD = false;
    private float CD_time = 2.0f;
    private float CD_timer = 0.0f;


    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);       

    }

    // Update is called once per frame
    void Update()
    {

        if (is_on_CD)
        {
            Apply_CD();
        }
    }


    void Apply_CD()
    {
        CD_timer -= Time.deltaTime;

        if (CD_timer < 0.0f)
        {
            is_on_CD = false;
            animator.SetBool("blocking", false);
        }

    }


    public void Use_Block()
    {
        if (is_on_CD)
        {

        }
        else
        {
            animator.SetBool("blocking", true);
            animator.SetBool("healing", false);
            is_on_CD = true;
            CD_timer = CD_time;


        }
    }

    public void Use_Heal()
    {
        animator.SetBool("healing", true);
    }

    public void Get_Healed()
    {
        Debug.Log("Stop_Heal");
        currentHealth += 20;
        healthBar.SetHealth(currentHealth);
        animator.SetBool("healing", false);
    }


    public void TakeDamage(int damage)
    {
        if(!is_on_CD)
        {
            currentHealth -= damage;
        }
        

        if (currentHealth <= 0)
        {
            Die();
        }

        healthBar.SetHealth(currentHealth);
    }


    void Die()
    {
        Destroy(gameObject);
    }





}
