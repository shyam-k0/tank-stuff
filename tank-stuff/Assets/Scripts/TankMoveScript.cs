using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TankMoveScript : MonoBehaviour
{
	[SerializeField] private float speed;
	[SerializeField] private float rotationSpeed;
	private float horizontalInput;
	
	Rigidbody2D rb;
	
	//[SerializeField] private float pushForce = 0;
	[SerializeField] private int player;
	[SerializeField] private bool continueMoving;
	[SerializeField] private bool takeInput = false;
	[SerializeField] private IdleTimeoutScript idleTimeout;
	
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
		player = gameObject.GetComponent<PlayerInput>().playerIndex;
		continueMoving = GameManager.gameManager.getGamePlaying();
		idleTimeout = GameObject.Find("/TimerManager").GetComponent<IdleTimeoutScript>();
	}


	// Using FixedUpdate because Physics is used by rigidbody
	private void FixedUpdate(){
		if (continueMoving){
			handleInput();
			//horizontalInput = Input.GetAxisRaw("Horizontal");
			takeInput = true;
		}
		
		if (!continueMoving && takeInput){
			handleInput();
			takeInput = !GameManager.gameManager.getDisplayDeathScreen();
		}
		
		continueMoving = GameManager.gameManager.getGamePlaying();
		
	}
	
	private void handleInput(){
		rb.velocity = transform.up * speed * GameManager.gameManager.getSpeedMult(player);
		float rotation = -horizontalInput * rotationSpeed * Time.deltaTime;
		transform.Rotate(Vector3.forward * rotation);
	}
	
	// Code for pushback from wall on collision. Didn't work tho. Scrapped it.
	/*
	void OnCollisionEnter2D(Collision2D c){
		
		if (c.gameObject.tag == "Wall"){
			Vector2 dir = (Vector2)transform.position - (Vector2)c.GetContact(0).point;
			dir.Normalize();
			
			gameObject.GetComponent<Rigidbody2D>().AddForce(dir * pushForce);
			
		}
	}
	*/
	
	public void OnMove(InputAction.CallbackContext context){
		horizontalInput = context.ReadValue<Vector2>().x;
		if (horizontalInput == 1 || horizontalInput == -1)
			idleTimeout.restartTimer();
	}

}
