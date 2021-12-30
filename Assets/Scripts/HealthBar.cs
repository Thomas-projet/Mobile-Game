using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthBar : MonoBehaviour
{
	public Slider slider;
	public TMP_Text test;

    private void Update()
    {
		test.text = Mathf.RoundToInt(slider.value * 100/ slider.maxValue).ToString() + " %";
    }

    public void SetMaxHealth(int health)
	{
		slider.maxValue = health;
		slider.value = health;
	}

	public void SetHealth(int health)
	{
		slider.value = health;
	}

}
