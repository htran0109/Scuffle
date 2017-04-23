using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementInput : MonoBehaviour {

    public string horizAxis, vertAxis, fire1, fire2, fire3, fire4;
    public float speed;
    public float maxSpeed;
    public float jumpForce;
    private Rigidbody rb;
    private bool grounded = false;
    private int vertMov, horizMov;
    public Transform sword;
    private Transform swordTrans;
    public const float  SWORD_DISAPPEAR_TIME = 0.1f;
    private float swordTimer;
    public float swordOffset;
    private Quaternion prevRotation;
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        vertMov = -1;
        horizMov = -1;
	}
	
	// Update is called once per frame
	void Update () {
        swordTimer += Time.deltaTime;
        if (swordTimer < SWORD_DISAPPEAR_TIME)
        {
            transform.Rotate(Vector3.up, 90f * (Time.deltaTime / .1f));
        }
        if(swordTimer > SWORD_DISAPPEAR_TIME && swordTrans != null)
        {
            transform.rotation = prevRotation;
            Destroy(swordTrans.gameObject);
        }
        if (swordTimer > SWORD_DISAPPEAR_TIME)
        {
            readKeys();
        }
	}

    void readKeys()
    {
        float vertInput = Input.GetAxis(vertAxis);
        float horizInput = Input.GetAxis(horizAxis);

        trackMove(vertInput, horizInput);

        rb.AddForce(horizInput * speed, 0, vertInput * speed);
        Vector3 noVertVel = new Vector3(rb.velocity.x, 0, rb.velocity.z);
        Vector3 clampedVel = Vector3.ClampMagnitude(noVertVel, maxSpeed);
        rb.velocity = new Vector3(clampedVel.x, rb.velocity.y, clampedVel.z);
        if (Input.GetButtonDown(fire1) && grounded)
        {
            Debug.Log("Jump");
            rb.AddForce(0, jumpForce, 0);
            grounded = false;
        }
        if (Input.GetButtonDown(fire2))
        {
            attack(horizMov, vertMov);
        }
    }


    private void trackMove(float vertInput, float horizInput)
    {
        if (vertInput > 0)
        {
            vertMov = 1;
        }
        else if (vertInput < 0)
        {
            vertMov = -1;
        }
        else
        {
            vertMov = 0;
        }
        if (horizInput > 0)
        {
            horizMov = 1;
        }
        else if (horizInput < 0)
        {
            horizMov = -1;
        }
        else
        {
            horizMov = 0;
        }
        this.transform.LookAt(new Vector3(rb.position.x + horizMov, rb.position.y, rb.position.z +vertMov));
    }

    private void attack(int horizMov, int vertMov)
    {
        if (swordTrans == null) { 
        Debug.Log("Slash");
            prevRotation = transform.rotation;
        transform.Rotate(Vector3.up, -45f);
        swordTrans = Instantiate(sword, this.transform.position + transform.forward *swordOffset, Quaternion.identity);
            swordTrans.parent = this.transform;
            swordTrans.transform.rotation = this.transform.rotation;
        swordTimer = 0f;
            }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        grounded = true;
    }

}
