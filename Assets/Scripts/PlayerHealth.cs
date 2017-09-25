using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

    public int maxHealth = 100;
    public int currHealth = 100;
    /* for the health UI*/
    public float initHealthPos;
    public Image damageImage;
    public RectTransform damageBar;
    public RectTransform damageBox;


    Animator anim;
    bool isDead;
    bool damaged;


	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

        Color barColor = Color.Lerp(Color.red, Color.green, currHealth / (float)maxHealth);
        barColor.a = 1;
        damageBar.sizeDelta = new Vector2((currHealth) / (float)maxHealth * damageBox.rect.width, 10);
        damageBar.position = new Vector3(initHealthPos - (1-(currHealth) / (float)maxHealth) * (damageBox.rect.width/2),
                                                damageBar.position.y, 0);
        damageImage.color = barColor;
        damaged = false;
	}

    public void Damage(int dmg, Vector3 knockback)
    {
        damaged = true;
        currHealth -= dmg;

        if(currHealth < 0)
        {
            Debug.Log("DED");
        }
        gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        this.gameObject.GetComponent<Rigidbody>().AddForce(600 * (knockback + new Vector3(0, .5f, 0)));

    }
}
