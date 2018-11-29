using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour {
    public GameObject explosionObj;

    public void Explode()
    {
        Instantiate(explosionObj, transform.position, transform.rotation);
    }
}
