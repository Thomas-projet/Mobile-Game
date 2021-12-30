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


    private Vector2 initial_position;
    private float lookRadius = 1.2f;

    public Transform fire_point;

    // Start is called before the first frame update
    void Start()
    {
        
        GM = FindObjectOfType<GameManager>();
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        target = GM.target;
        initial_position = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        target = GM.target;
        if (is_on_CD)
        {
            Apply_CD();
        }

        if (is_attacking)
        {
            
            float distance = Vector2.Distance(target.transform.position, transform.position);
            
            if (distance <= lookRadius)
            {
                animator.SetBool("attacking", true);

            }
            else
            {
                Vector2 dir = target.transform.position - transform.position;
                transform.Translate(dir.normalized * speed * Time.deltaTime);
            }
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

    public void Attack_event()
    {
        is_attacking = false;
        animator.SetBool("attacking", false);
        transform.position = initial_position;
    }

    public void Attack_damage()
    {
        Enemy enemy = GM.target.GetComponent<Enemy>();
        enemy.TakeDamage(50);
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
            animator.SetTrigger("test");

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

    public void Stun_Event()
    {
        Enemy enemy1 = GM.enemy1.GetComponent<Enemy>();
        Enemy enemy2 = GM.enemy2.GetComponent<Enemy>();

        enemy1.is_stunned();
        enemy2.is_stunned();

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
        animator.SetTrigger("charging");

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


    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);

    }


}
