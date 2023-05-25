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



    // Start is called before the first frame update
    void Start()
    {
        setMaxHealth(100);
		currentHealth = 100;
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = cam.transform.rotation;
		transform.position = target.position + offset;
		
		if (Input.GetKeyDown(KeyCode.Space)){
			damageTank(10);
		}
    }
	
	public void setHealth(int val){
		slider.value = val;
	}
	
	public void setMaxHealth(int max){
		slider.maxValue = max;
		slider.value = max;
	}
	
	public void damageTank(int val){
		currentHealth -= val;
		setHealth(currentHealth);
	}
}
