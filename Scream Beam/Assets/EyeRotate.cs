using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeRotate : MonoBehaviour {
    private Quaternion defaultRotation;
    public float rotateSpeed = 20;
	// Use this for initialization
	void Start () {
        defaultRotation = GetComponent<Transform>().localRotation;
        rotateSpeed = Random.Range(20, 100);
	}
	
	// Update is called once per frame
	void Update () {
        GetComponent<Transform>().Rotate(Vector3.forward * (Time.deltaTime * rotateSpeed), Space.World);
	}
}
