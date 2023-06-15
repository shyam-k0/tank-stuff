using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Unity.Netcode;

public class mTankMoveScript : NetworkBehaviour
{
	[SerializeField] private float speed;
	[SerializeField] private float rotationSpeed;
	private float horizontalInput;
	
	Rigidbody2D rb;
	
	//[SerializeField] private float pushForce = 0;
	[SerializeField] private int player;
	
	
    // Start is called before the first frame update
    void Start()
    {
		// Workaround to make the InputSystem work on Netcode
		InputSystem.settings.defaultDeadzoneMax = 0.924f;
		
        rb = GetComponent<Rigidbody2D>();
		player = gameObject.GetComponent<PlayerInput>().playerIndex;
	}


	// Using FixedUpdate because Physics is used by rigidbody
	private void FixedUpdate(){
		if (!IsOwner) return;
		
		//rb.velocity = transform.up * speed * GameManager.gameManager.getSpeedMult(player);
		rb.velocity = transform.up * speed;
		//horizontalInput = Input.GetAxisRaw("Horizontal");
		float rotation = -horizontalInput * rotationSpeed * Time.deltaTime;
		//Debug.Log(rb.velocity);
		transform.Rotate(Vector3.forward * rotation);
		
	}
	
	void OnCollisionEnter2D(Collision2D c){
		
		if (c.gameObject.tag == "Wall"){
			Vector2 dir = (Vector2)transform.position - (Vector2)c.GetContact(0).point;
			dir.Normalize();
			
			//gameObject.GetComponent<Rigidbody2D>().AddForce(dir * pushForce);
			
		}
	}
	
	public void OnMove(InputAction.CallbackContext context){
		horizontalInput = context.ReadValue<Vector2>().x;
	}

}
