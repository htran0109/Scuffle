using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementInput : MonoBehaviour {

    public int damage;
    public Vector3 knockback;

    public string horizAxis, vertAxis, fire1, fire2, fire3, fire4;
    public float speed;
    public float maxSpeed;
    public float jumpForce;
    public float chargeForce;
    protected Rigidbody rb;
    private bool grounded = false;
    protected int vertMov, horizMov, vertDir, horizDir;
    public Transform attack;
    protected Transform attackTrans;
    public const float  attack_DISAPPEAR_TIME = 0.1f;
    public const float CHARGE_EXECUTION_TIME = 0.1f;
    protected float attackTimer;
    protected float chargeTimer;
    public float attackOffset;
    protected Quaternion prevRotation;
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        vertMov = -1;
        horizMov = -1;
	}
	
	// Update is called once per frame
	void Update () {
        if (attacksFinished())
        {
            readKeys();
        };
	}
    protected bool attacksFinished()
    {
        attackTimer += Time.deltaTime;
        chargeTimer += Time.deltaTime;
        if (isAttacking())
        {
            transform.Rotate(Vector3.up, 90f * (Time.deltaTime / .1f));
        }
        if (!isAttacking() && attackTrans != null)
        {
            transform.rotation = prevRotation;
            Destroy(attackTrans.gameObject);
        }
        if (!isAttacking() && !isCharging())
        {
            return true;
        }
        return false;
    }
    protected void readKeys()
    {
        float vertInput = Input.GetAxis(vertAxis);
        float horizInput = Input.GetAxis(horizAxis);

        trackMove(vertInput, horizInput);
        Vector3 noVertVel = new Vector3(rb.velocity.x, 0, rb.velocity.z);
        Vector3 clampedVel = Vector3.ClampMagnitude(noVertVel, maxSpeed);
        //only add force if we're below max speed
        if (noVertVel.magnitude <= clampedVel.magnitude )
        {
            rb.AddForce(horizInput * speed, 0, vertInput * speed);
        }
        
        noVertVel = new Vector3(rb.velocity.x, 0, rb.velocity.z);
        clampedVel = Vector3.ClampMagnitude(noVertVel, maxSpeed);
        rb.velocity = new Vector3(clampedVel.x, rb.velocity.y, clampedVel.z);
        if (Input.GetButtonDown(fire1) && grounded)
        {
            Debug.Log("Jump");
            rb.AddForce(0, jumpForce, 0);
            grounded = false;
        }
        if (Input.GetButtonDown(fire2))
        {
            Attack1(horizMov, vertMov);
        }
        if (Input.GetButtonDown(fire3))
        {
            Attack2(horizMov, vertMov, horizDir, vertDir);
        }
    }


    private void trackMove(float vertInput, float horizInput)
    {
        if (vertInput > 0)
        {
            vertMov = 1;
            vertDir = 1;
        }
        else if (vertInput < 0)
        {
            vertMov = -1;
            vertDir = -1;
        }
        else
        {
            vertMov = 0;
        }
        if (horizInput > 0)
        {
            horizMov = 1;
            horizDir = 1;
        }
        else if (horizInput < 0)
        {
            horizMov = -1;
            horizDir = -1;
        }
        else
        {
            horizMov = 0;
        }
        this.knockback = new Vector3(horizMov, 0, vertMov);
        this.transform.LookAt(new Vector3(rb.position.x + horizMov, rb.position.y, rb.position.z +vertMov));
    }

    virtual
    protected void Attack1(int horizMov, int vertMov)
    {
        if (attackTrans == null) { 
        Debug.Log("Slash");
            prevRotation = transform.rotation;
        transform.Rotate(Vector3.up, -45f);
        attackTrans = Instantiate(attack, this.transform.position + transform.forward *attackOffset, Quaternion.identity);
        attackTrans.parent = this.transform;
        attackTrans.transform.rotation = this.transform.rotation;
        attackTimer = 0f;
            }
        
    }

    virtual
    protected void Attack2(int horizMov, int vertMov, int horizDir, int vertDir)
    {
        Debug.Log("Charge");
        rb.AddForce(chargeForce * this.transform.forward);
        rb.velocity= new Vector3(rb.velocity.x, 0, rb.velocity.z);
        chargeTimer = 0;
    }

    protected void OnCollisionEnter(Collision collision)
    {
        grounded = true;
    }

    public bool isCharging()
    {
        if(chargeTimer > CHARGE_EXECUTION_TIME)
        {
            return false;
        }
        return true;
    }

    public bool isAttacking()
    {
        if(attackTimer > attack_DISAPPEAR_TIME)
        {
            return false;
        }
        return true;
    }

}
