using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flip : MonoBehaviour
{
    public Rigidbody2D rb;
    bool m_FacingRight = true;
	float horizontalMove = 0f;

	public Thruster thruster;
    // Start is called before the first frame update
    void Start()
    {
        //rb = squareblue.GetComponent<Rigidbody2D>();
    }

	void Update()
	{
		horizontalMove = Input.GetAxisRaw("Horizontal");
	}

    // Update is called once per frame
    void FixedUpdate()
    {
        if (horizontalMove > 0.1 && !m_FacingRight)
		{
			// ... flip the player.
			flip();
		}
		// Otherwise if the input is moving the player left and the player is facing right...
		else if (horizontalMove < -0.1 && m_FacingRight)
		{
			// ... flip the player.
			flip();
		}
    }

    private void flip()
	{
		// Switch the way the player is labelled as facing.
		m_FacingRight = !m_FacingRight;

		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
