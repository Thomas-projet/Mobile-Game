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

    private GameManager GM;
    private GameObject target;

    private float speed = 2f;

    private bool is_attacking = false;

    // Start is called before the first frame update
    void Start()
    {
        GM = FindObjectOfType<GameManager>();
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        target = GM.target;

    }

    // Update is called once per frame
    void Update()
    {

        if (is_on_CD)
        {
            Apply_CD();
        }

        if (is_attacking)
        {
            Vector2 dir = target.transform.position - transform.position;
            transform.Translate(dir.normalized * speed * Time.deltaTime);
        }
    }


    void Apply_CD()
    {
        CD_timer -= Time.deltaTime;

        if (CD_timer < 0.0f)
        {
            GM.player_is_using_a_skill = false;
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
            GM.player_is_using_a_skill = true;
            animator.SetBool("blocking", true);
            animator.SetBool("healing", false);
            animator.SetBool("stunning", false);
            is_on_CD = true;
            CD_timer = CD_time;


        }
    }

    public void Use_Heal()
    {
        animator.SetBool("stunning", false);
        //if (!animator.GetBool("blocking"))
        //{
            animator.SetBool("healing", true);
        //}
        
    }

    public void Get_Healed()
    {
        currentHealth += 20;
        healthBar.SetHealth(currentHealth);
        animator.SetBool("healing", false);
    }

    public void Use_Stun()
    {
        animator.SetBool("healing", false);
        if (!animator.GetBool("blocking"))
        {
            animator.SetBool("stunning", true);
        }

    }


    public void Stun_Done()
    {
        Debug.Log("Stun_Done");
        animator.SetBool("stunning", false);
    }

    public void Use_Attack()
    {
        animator.SetBool("healing", false);
        animator.SetBool("stunning", false);
        is_attacking = true;

        //if (!animator.GetBool("blocking"))
        //{
        //    animator.SetBool("attack", true);
        //}

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
