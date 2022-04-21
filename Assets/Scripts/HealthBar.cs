using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthSlider;
    public Slider experienceSlider;
    
    public void SetHealth(int health)
    {
        healthSlider.value = health;
    }

    public void SetMaxHealth(int health)
    {
        healthSlider.maxValue = health;
        healthSlider.value = health;
    }

    public void SetExperience(int experience)
    {
        experienceSlider.value = experience;
    }

    public void SetMaxExperience(int experience)
    {
        experienceSlider.maxValue = experience;
    }


}
