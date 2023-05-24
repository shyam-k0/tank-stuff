using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMoveScript : MonoBehaviour
{
	[SerializeField] private float speed;
	[SerializeField] private float rotationSpeed;
	private float horizontalInput;
	
	Rigidbody2D rb;
	
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


	// Using FixedUpdate because Physics is used by rigidbody
	private void FixedUpdate(){
		rb.velocity = transform.up * speed;
		
		horizontalInput = Input.GetAxisRaw("Horizontal");
		float rotation = -horizontalInput * rotationSpeed * Time.deltaTime;
		Debug.Log(horizontalInput);
		transform.Rotate(Vector3.forward * rotation);
		
	}

    // Update is called once per frame
    void Update()
    {
		// Forward Movement
		//Debug.Log(transform.up);
        //transform.Translate(transform.up * speed * Time.deltaTime);
		
		// Roational Movement
		//horizontalInput = Input.GetAxisRaw("Horizontal");
		//float rotation = -horizontalInput * rotationSpeed * Time.deltaTime;
		//Debug.Log(horizontalInput);
		//transform.Rotate(Vector3.forward * rotation);
		
		
    }
}
