﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class EnemyScript : MonoBehaviour {
    [Header("Movement Parameters")]
    public float moveAmount = 0.2f;
    [SerializeField]
    private Rigidbody2D Enemy;
    private float timer;
    [Range(0.2f, 2)]
    public float timerResetTime = 2f;
    [Header("Health Parameters")]
    public int maxHealth = 100;
    public float enemyCurHealth;
    public bool isInBeam = false;

    public Image healthBar;

    public TouchInput player;
    public GameObject beamRenderer1;
    public GameObject beamRenderer2;
    public AudioSource AudioSource;
	// Use this for initialization
	void Start () {
        timer = Time.time;
        enemyCurHealth = maxHealth;
        healthBar.fillAmount = enemyCurHealth / 10;
        player = GameObject.Find("Player").GetComponent<TouchInput>();
	}
	
	// Update is called once per frame
	void Update () {
        healthBar.fillAmount = enemyCurHealth / 100;

        //death statement - add score, stop coroutine, disable enemy
        if(enemyCurHealth <= 0)
        {
            StopCoroutine("MoveTheEnemy");
            AddScore();
            this.gameObject.SetActive(false);
        }


        //start movement timer
        if (moveAmount > 0)
        {
            if (timer + timerResetTime >= Time.time)
            {
                return;
            }
            timer = Time.time + timerResetTime;

            StartCoroutine("MoveTheEnemy");
        }

        //check for beam touching, if true do damage
        if (isInBeam && beamRenderer1.activeInHierarchy == true && player.isFiring == true || isInBeam && beamRenderer2.activeInHierarchy == true && player.isFiring == true)
        {
            enemyCurHealth -=  player.dmgMod * Time.deltaTime * 35;
        }
        else
        {
            beamRenderer1 = null;
            beamRenderer2 = null;
            isInBeam = false;
        }

    }

    void MoveEnemy()
    {
        Enemy.AddForce(Vector3.down * moveAmount, ForceMode2D.Impulse);
        if(timer + timerResetTime >= Time.time)
            return;
        timer = Time.time + timerResetTime;
    }

    IEnumerator MoveTheEnemy()
    {
        Enemy.AddForce(Vector3.down * moveAmount, ForceMode2D.Impulse);
        yield return new WaitForSeconds(timerResetTime);
    }

    //on trigger enter, toggle beam activity
    void OnTriggerEnter2D(Collider2D col)
    {
        beamRenderer1 = GameObject.Find("Beam1Sprite");
        beamRenderer2 = GameObject.Find("Beam2Sprite");
        AudioSource = col.gameObject.GetComponent<AudioSource>();
        isInBeam = true;
    }

    //on trigger stay, toggle beam activity
    void OnTriggerStay2D(Collider2D col)
    {
        if ( beamRenderer1 == null)
        {
            beamRenderer1 = GameObject.Find("Beam1Sprite");
            beamRenderer2 = GameObject.Find("Beam2Sprite");
            AudioSource = col.gameObject.GetComponent<AudioSource>();
            isInBeam = true;
        }
        if (beamRenderer2 == null)
        {
            beamRenderer1 = GameObject.Find("Beam1Sprite");
            beamRenderer2 = GameObject.Find("Beam2Sprite");
            AudioSource = col.gameObject.GetComponent<AudioSource>();
            isInBeam = true;
        }
    }

    //cease beam toggling
    void OnTriggerExit2D(Collider2D col)
    {
        beamRenderer1 = null;
        beamRenderer2 = null;
        AudioSource = null;
        isInBeam = false;
    }

    void OnEnable()
    {
        enemyCurHealth = maxHealth;
    }

    void AddScore()
    {
        player.Score++;
    }

    //death by planet incurs no score addition
    public void PlanetKill()
    {
        this.gameObject.SetActive(false);
    }
}
