using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarControllerScript : MonoBehaviour
{
	
	[SerializeField] private Camera cam;
	[SerializeField] private Transform target;
	[SerializeField] private Vector3 offset;
	
	[SerializeField] private Slider slider;
	
	public int currentHealth;
	
	[SerializeField] private Gradient grad;
	[SerializeField] private Image fill;



    // Start is called before the first frame update
    void Start()
    {
        setMaxHealth(gameObject.GetComponentInParent<PlayerProperties>().getMaxHealth());
		currentHealth = (int)slider.maxValue;
		cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = cam.transform.rotation;
		transform.position = target.position + offset;
	}
	
	public void setHealth(int val){
		currentHealth = val;
		slider.value = val;
		fill.color = grad.Evaluate(slider.normalizedValue);
	}
	
	public void setMaxHealth(int max){
		slider.maxValue = max;
		slider.value = max;
		
		fill.color = grad.Evaluate(1f);
	}
	
}
