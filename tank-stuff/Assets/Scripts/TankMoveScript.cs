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
	
	[SerializeField] private float pushForce = 0;
	
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


	// Using FixedUpdate because Physics is used by rigidbody
	private void FixedUpdate(){
		rb.velocity = transform.up * speed * GameManager.gameManager.getSpeedMult();
		
		//horizontalInput = Input.GetAxisRaw("Horizontal");
		float rotation = -horizontalInput * rotationSpeed * Time.deltaTime;
		//Debug.Log(rb.velocity);
		transform.Rotate(Vector3.forward * rotation);
		
	}
	
	void OnCollisionEnter2D(Collision2D c){
		
		if (c.gameObject.tag == "Wall"){
			Vector2 dir = (Vector2)transform.position - (Vector2)c.GetContact(0).point;
			dir.Normalize();
			
			gameObject.GetComponent<Rigidbody2D>().AddForce(dir * pushForce);
			
		}
	}
	
	public void OnMove(InputAction.CallbackContext context){
		horizontalInput = context.ReadValue<Vector2>().x;
	}

}
