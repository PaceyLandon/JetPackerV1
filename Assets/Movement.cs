using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

	public float runSpeed = 40f;
	float horizontalMove = 0f;

	bool grounded;

	Rigidbody2D rb;
	
	// Update is called once per frame
	void Start ()
	{
		rb = gameObject.GetComponent<Rigidbody2D>();
	}
	void Update () 
	{
		horizontalMove = Input.GetAxisRaw("Horizontal");
		//Debug.Log(horizontalMove);
	}

	void FixedUpdate ()
	{
		// Move our character
		if (IsGrounded()) {
		rb.AddForce(transform.right * runSpeed * horizontalMove * Time.deltaTime);
		}
	}

	public LayerMask groundLayer;

	bool IsGrounded() 
	{
    	Vector2 position = transform.position;
    	Vector2 direction = Vector2.down;
    	float distance = 1.0f;
    
    	RaycastHit2D hit = Physics2D.Raycast(position, direction, distance, groundLayer);
    	if (hit.collider != null) {
        return true;
    	}
    return false;
	}
		
}