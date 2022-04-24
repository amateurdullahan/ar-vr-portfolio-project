using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{

	public int maxHealth;
	public int currentHealth;
	public int maxExperience;
	public int currentExperience;
	private int remainder;
	public HealthBar healthBar;
	public HealthBar experienceBar;
	public int level;
	public GameObject pauseMenu;
	public int damage;
	
	

	// Start is called before the first frame update
	void Start()
	{
		maxHealth = 100;
		currentHealth = maxHealth;
		healthBar.SetMaxHealth(maxHealth);
		level = 1;
		currentExperience = 0;
		maxExperience = 50;
		experienceBar.SetMaxExperience(maxExperience);
		damage = 5;
	}


	public void TakeDamage(int eDamage)
	{
		currentHealth -= eDamage;

		healthBar.SetHealth(currentHealth);
	}

	void OnCollisionEnter2D(Collision2D hitInfo)
	{

		if (hitInfo.gameObject.tag == "Enemy")
		{
			TakeDamage(1);
		}
	}


	public void GainExperience(int points)
    {
		currentExperience += points;
		experienceBar.SetExperience(currentExperience);
		if (currentExperience >= maxExperience)
        {
			remainder = currentExperience - maxExperience;
			level += 1;
			pauseMenu.Pause();
			LevelUp(level);
        }
    }

	void LevelUp(int level)
    {
		maxHealth += 50 * level;
		healthBar.SetMaxHealth(maxHealth);
		healthBar.SetHealth(maxHealth);
		currentHealth = maxHealth;
		currentExperience = 0 + remainder;
		maxExperience += 25 * level;
		experienceBar.SetMaxExperience(maxExperience);
		experienceBar.SetExperience(currentExperience);
		damage = 5 * level;
    }

}
