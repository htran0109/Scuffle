using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput2 : MovementInput {

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

    override
    protected void Attack1(int horizMov, int vertMov)
    {
        if (attackTrans == null)
        {
            Debug.Log("Bow1");
            attackTrans = Instantiate(attack, this.transform.position + transform.forward * attackOffset, Quaternion.identity);
            attackTrans.transform.rotation = this.transform.rotation;
            prevRotation = this.transform.rotation;
            attackTrans.transform.Rotate(90, 0, 0);
            attackTimer = 0f;
            //prevRotation = transform.rotation;
            //transform.Rotate(Vector3.up, -45f);
            //attackTrans = Instantiate(attack, this.transform.position + transform.forward * attackOffset, Quaternion.identity);
            //attackTrans.parent = this.transform;
            //attackTrans.transform.rotation = this.transform.rotation;
            //attackTimer = 0f;
        }

    }

    override
    protected void Attack2(int horizMov, int vertMov, int horizDir, int vertDir)
    {
        Debug.Log("Bow2");
        attackTrans = Instantiate(attack, this.transform.position + transform.forward * attackOffset, Quaternion.identity);
        attackTrans.transform.rotation = this.transform.rotation;
        prevRotation = this.transform.rotation;
        attackTrans.transform.Rotate(90, 0, 0);

        attackTrans = Instantiate(attack, this.transform.position + transform.forward * attackOffset, Quaternion.identity);
        attackTrans.transform.rotation = this.transform.rotation;
        prevRotation = this.transform.rotation;
        attackTrans.transform.Rotate(90, 30, 0);

        attackTrans = Instantiate(attack, this.transform.position + transform.forward * attackOffset, Quaternion.identity);
        attackTrans.transform.rotation = this.transform.rotation;
        prevRotation = this.transform.rotation;
        attackTrans.transform.Rotate(90, -30, 0);

        rb.AddForce(-chargeForce * this.transform.forward);
        rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);

        chargeTimer = 0;
    }
}
