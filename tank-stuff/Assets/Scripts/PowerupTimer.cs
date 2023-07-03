using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PowerupTimer : MonoBehaviour
{

	[SerializeField] private int index;
	[SerializeField] private bool speedGained = false;
	[SerializeField] private bool dmgGained = false;
	
	[SerializeField] private float damagePowerupTime;
	[SerializeField] private float speedPowerupTime;
	
	[SerializeField] private Color speedColor;
	[SerializeField] private Color damageColor;
	[SerializeField] private Slider powerupTimer;
	[SerializeField] private Image sliderBase;
	[SerializeField] private Image sliderFill;
	[SerializeField] private Camera cam;
	private bool sliderOn = false;
	[SerializeField] private Vector3 offset;
	[SerializeField] private GameObject powerUpCanvas;
	
	
    // Start is called before the first frame update
    void Start()
    {
        index = gameObject.GetComponent<PlayerInput>().playerIndex;
		damagePowerupTime = GameManager.gameManager.getDamagePowerupTime();
		speedPowerupTime = GameManager.gameManager.getSpeedPowerupTime();
		cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (speedGained){
			StartCoroutine(startSpeedTimer(index));
			startSpeedSlider();
			speedGained = false;
		}
		if (dmgGained){
			StartCoroutine(startDamageTimer(index));
			startDamageSlider();
			dmgGained = false;
		}
		
		if (sliderOn){
			powerUpCanvas.transform.rotation = cam.transform.rotation;
			powerUpCanvas.transform.position = gameObject.transform.position + offset;
		}
    }
	
	public void setSpeedGainedTrue(){
		speedGained = true;
	}
	
	public void setDamageGainedTrue(){
		dmgGained = true;
	}
	
	IEnumerator startSpeedTimer(int index){
		yield return new WaitForSeconds(speedPowerupTime);
		endSpeedPowerup(index);
	}
	
	IEnumerator startDamageTimer(int index){
		yield return new WaitForSeconds(damagePowerupTime);
		endDamagePowerup(index);
	}
	
	public void endDamagePowerup(int index){
		GameManager.gameManager.setDamageMult(1f, index);
		GameManager.gameManager.setHasPowerup(index, false);
		Debug.Log(index + "  endDmg");
	}
	
	public void endSpeedPowerup(int index){
		GameManager.gameManager.setSpeedMult(1f, index);
		GameManager.gameManager.setHasPowerup(index, false);
		Debug.Log(index + "  endSpeed");
	}
	
	public void startSpeedSlider(){
		sliderBase.color = new Color(0, 0, 0, 1);
		sliderFill.color = speedColor;
		sliderOn = true;
		LeanTween.value(gameObject, (value) => {powerupTimer.value = value;}, 1f, 0f, speedPowerupTime).setOnComplete(() => {
			sliderBase.color = new Color(0, 0, 0, 0);
			sliderFill.color = new Color(1, 1, 1, 0);
			sliderOn = false;
		});
		
	}
	
	public void startDamageSlider(){
		sliderBase.color = new Color(0, 0, 0, 1);
		sliderFill.color = damageColor;
		sliderOn = true;
		LeanTween.value(gameObject, (value) => {powerupTimer.value = value;}, 1f, 0f, damagePowerupTime).setOnComplete(() => {
			sliderBase.color = new Color(0, 0, 0, 0);
			sliderFill.color = new Color(1, 1, 1, 0);
			sliderOn = false;
		});
	}
}
