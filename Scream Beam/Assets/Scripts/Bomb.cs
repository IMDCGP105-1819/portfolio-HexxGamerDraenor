using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour {
    CircleCollider2D boom;
    
    public void Start()
    {
        boom = GetComponent<CircleCollider2D>();
    }
    public void Explode()
    {
        
        StartCoroutine("boomCycle");
    }

    public IEnumerator boomCycle()
    {
        boom.enabled = true;
        yield return new WaitForSeconds(0.2f);
        boom.enabled = false;
    }
}
