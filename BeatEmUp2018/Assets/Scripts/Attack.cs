using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour {

    public float damage;
    public float knockBackForce;
    public float attackTime;
    public KeyCode attack;
    private BoxCollider2D attackBox;
    Vector2 direction;
    // Use this for initialization
    void Start () {
        attackBox = GetComponent<BoxCollider2D>();
	}

    float timer = 0;
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(attack))
        {
            attackBox.enabled = true;
        }

        if (attackBox.enabled)
        {
            timer += Time.deltaTime;
            if (timer > attackTime)
            {
                attackBox.enabled = false;
                timer = 0;
            }
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Health hp = collision.GetComponent<Health>();
        if (hp == null)
            return;
        else
        {
            hp.TakeDamage(damage);
        }

        Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();
        if (rb == null)
            return;
        else
        {
            direction = (collision.transform.position - this.transform.position).normalized;
            rb.AddForce(new Vector2(direction.x * knockBackForce, direction.y * knockBackForce * 2));
        }
   
    }
}
