using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour {

    void Start()
    {
        Destroy(this.gameObject, 0.5f);
    }
	void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Enemy")
        {
            col.GetComponent<EnemyScript>().enemyCurHealth = 0;
        }
    }
}
