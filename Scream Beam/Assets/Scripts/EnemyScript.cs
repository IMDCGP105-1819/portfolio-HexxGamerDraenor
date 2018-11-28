using System.Collections;
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

    private TouchInput player;
    private GameObject beamRenderer1;
    private GameObject beamRenderer2;
    private AudioSource AudioSource;

    [SerializeField]
    private SpriteRenderer mySprite;
    [SerializeField]
    private GameObject myCanvas;

	void Start () {
        timer = Time.time;
        enemyCurHealth = maxHealth;
        healthBar.fillAmount = enemyCurHealth / 10;
        player = GameObject.Find("Player").GetComponent<TouchInput>();
	}
	
	void Update () {
        healthBar.fillAmount = enemyCurHealth / 100;

        //death statement - add score, stop coroutine, disable enemy
        if(enemyCurHealth <= 0)
        {
            StopCoroutine("MoveTheEnemy");
            AddScore();
            StartCoroutine("DeathSequence");
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
            enemyCurHealth -= player.dmgMod;
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

        int choice = Random.Range(1, 6);

        switch(choice)
        {
            case 5:
                Enemy.AddForce(Vector3.right * moveAmount * 10, ForceMode2D.Impulse);
                yield break;
            case 6:
                Enemy.AddForce(Vector3.right * moveAmount * 10, ForceMode2D.Impulse);
                yield break;
        }
    }

    IEnumerator DeathSequence()
    {
        myCanvas.SetActive(false);
        mySprite.enabled = false;
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(0.4f);
        this.gameObject.SetActive(false);
        StopCoroutine("DeathSequence");
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

    void OnColliderEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            PlanetKill();
        }
    }

    void OnEnable()
    {
        enemyCurHealth = maxHealth;
        myCanvas.SetActive(true);
        mySprite.enabled = true;
    }

    void AddScore()
    {
        player.Score++;
    }

    //death by planet incurs no score addition
    public void PlanetKill()
    {
        StartCoroutine("DeathSequence");
        this.gameObject.SetActive(false);
    }
}
