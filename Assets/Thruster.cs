using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thruster : MonoBehaviour
{
    private Rigidbody2D rb;
    public float rotationSpeed = 3f;
    private float rotatedirection;
    public float Accelerating = 1f;
    private float timeleft = 0f;
    private float yAxis;
    private float xAxis;
    public float Maxhorizontal = 8f;
    public float MaxUp = 12f;
    public float MaxDown = -24f;

    void FixedUpdate()
    {
        Vector3 eulerAngles = transform.rotation.eulerAngles;
        Debug.Log(rb.velocity.y); 

        if(eulerAngles.z<15)
        {
        transform.rotation = Quaternion.Euler(0, 0, 15);
        }
        if(eulerAngles.z>345)
        {
        transform.rotation = Quaternion.Euler(0, 0, 345);
        }
        if(eulerAngles.z<180 && eulerAngles.z>165)
        {
        transform.rotation = Quaternion.Euler(0, 0, 165);
        }
        if(eulerAngles.z<195 && eulerAngles.z>180)
        {
        transform.rotation = Quaternion.Euler(0, 0, 195);
        }

        Rotate(transform, xAxis * rotationSpeed);
        Thrustforward(yAxis);

        if(rb.velocity.x > Maxhorizontal)
        {
            rb.velocity = new Vector2(Maxhorizontal, rb.velocity.y);
        }
        if(rb.velocity.x < -Maxhorizontal)
        {
            rb.velocity = new Vector2(-Maxhorizontal, rb.velocity.y);
        }
        if(rb.velocity.y > MaxUp)
        {
            rb.velocity = new Vector2(rb.velocity.x, MaxUp);
        }
        if(rb.velocity.y < MaxDown)
        {
            rb.velocity = new Vector2(rb.velocity.x, MaxDown);
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {   
        //print(timeleft);
        if (timeleft>0){
            timeleft -= Time.deltaTime;
        }
        if (timeleft>2){
            yAxis=1;
        } 
        else{
            yAxis=0;
        }
        if (Input.GetKey(KeyCode.J) && timeleft<=0) 
        {
            timeleft = 5f;
        }

        xAxis = Input.GetAxis("Jetmove");
    }

    private void Thrustforward(float amount)
    {
        Vector2 force = transform.up * amount * Accelerating;
        rb.AddForce(force);
    }

    private void Rotate(Transform t, float amount)
    {
        t.Rotate(0, 0, amount);
    }
}
