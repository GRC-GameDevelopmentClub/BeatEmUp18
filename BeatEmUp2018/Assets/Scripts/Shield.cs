using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shield : MonoBehaviour {

    public float shieldTime;
    public float coolDown;
    public KeyCode shield;
    private CircleCollider2D circleCol;
    private SpriteRenderer sr;
    private bool isShield;

	// Use this for initialization
	void Start () {
        circleCol = GetComponent<CircleCollider2D>();
        sr = GetComponent<SpriteRenderer>();

        circleCol.enabled = false;
        sr.enabled = false;
	}

    float sTimer = 0;
    float cTimer = 0;
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(shield) && cTimer == 0)
        {
            isShield = true;
        }

        if (isShield)
        {
            circleCol.enabled = true;
            sr.enabled = true;

            sTimer += Time.deltaTime;
            if (sTimer > shieldTime)
            {
                isShield = false;
                sTimer = 0;
                cTimer = coolDown;
            }
        }
        else
        {
            circleCol.enabled = false;
            sr.enabled = false;
            cTimer -= Time.deltaTime;
            if(cTimer < 0)
            {
                cTimer = 0;
            }
        }

	}

}
