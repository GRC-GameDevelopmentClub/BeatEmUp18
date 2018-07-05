using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

    public float health;
    private float MAX_HEALTH;

    public Color deathColor;
    private Color defualtColor;

    private SpriteRenderer sr;

	// Use this for initialization
	void Start () {
        MAX_HEALTH = health;
        sr = GetComponentInChildren<SpriteRenderer>();
        defualtColor = sr.color;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void takeDamage(float damage)
    {
        if (health - damage >= 0)
        {
            health -= damage;
        }
        else
        {
            health = 0;
        }
    }

    void giveHealth(float hp)
    {
        if (health + hp <= MAX_HEALTH)
        {
            health += hp;
        }
        else
        {
            health = MAX_HEALTH;
        }
    }
}
