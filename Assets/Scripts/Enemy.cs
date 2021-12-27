using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	public Animator animator;

	public int maxHealth = 100;
	public int currentHealth;

	public HealthBar healthBar;

	public Transform fire_point;
	public GameObject fireball_prefab;
	private bool is_on_CD = false;
	private float CD_time = 2.0f;
	private float CD_timer = 0.0f;

	public bool stunned = false;

	// Start is called before the first frame update
	void Start()
	{
		currentHealth = maxHealth;
		healthBar.SetMaxHealth(maxHealth);
		
	}

	void Update()
	{
        if (!stunned)
        {
			Use_Spell();
		}
		
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
		}
	}


	public void Use_Spell()
	{
		if (is_on_CD)
		{
			//return false;

		}
		else
		{
			is_on_CD = true;
			CD_timer = CD_time;
			Instantiate(fireball_prefab, fire_point.position, fire_point.rotation, GameObject.FindGameObjectWithTag("Canvas").transform);
		}
	}

	public void TakeDamage(int damage)
	{
		currentHealth -= damage;

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

	public void is_stunned()
    {
		stunned = true;
		animator.SetTrigger("stunned");
	}
	public void unstun()
    {
		stunned = false;
    }


}
