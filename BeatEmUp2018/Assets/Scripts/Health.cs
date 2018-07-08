using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

    public float health;
    private float MAX_HEALTH;

    public Color deathColor;
    private Color defaultColor;

    private SpriteRenderer sr;

	// Use this for initialization
	void Start () {
        MAX_HEALTH = health;
        sr = GetComponentInChildren<SpriteRenderer>();
        defaultColor = sr.color;
	}

    float timer;
	// Update is called once per frame
	void Update () {

        if (sr.color != defaultColor)
        {
            timer += Time.deltaTime;
            if (timer > 0.25f)
            {
                sr.color = defaultColor;
                timer = 0;
            }
        }

        if (health <= 0)
        {
            sr.color = deathColor;
        }

	}

    public void TakeDamage(float damage)
    {
        sr.color = deathColor;
        if (health - damage >= 0)
        {
            health -= damage;
        }
        else
        {
            health = 0;
        }
    }

    public void GiveHealth(float hp)
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
