using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
[RequireComponent(typeof(Rigidbody2D))]
public class TouchInput : MonoBehaviour {
    [Header("Shooting Parameters")]
    public SpriteRenderer Beam2Sprite;
    public GameObject BeamSprite;
    public SpriteRenderer BeamRenderer;
    public AudioSource audioSource;
    public Transform BeamOrigin;
    public Slider fuelSlider;
    public float maxTimer;
    public float timer;
    public bool isFiring = false;
    public float maxFuel = 10;
    public float curFuel;
    private bool canRegen = false;
    [Range(15, 40)]
    public float dmgMod;
    [Header("Movement Parameters")]
    public float moveSpeed = 20f;
    public Joystick joy;

    [Header("Enemy Spawn Parameters")]
    public Transform[] SpawnLocations;
    public GameObject enemyPrefab;
    public GameObject[] enemies;
    public Transform spawnPos;
    public int maxEnemies;
    public float SpawnRate;
    private bool willSpawn = true;
    private int spawnChoice;
    public int maxSpawnPos;

    [Header("Score Parameters")]
    public TextMeshProUGUI ScoreText;
    public int Score = 0;
    private int highScore;
    public string playerName;

    [Header("Pause Parameters")]
    public Transform pauseMenuCanvas;
    public bool isPaused;

    [Header("Power up Parameters")]
    public float minDist;

    public int maxCanisters = 2;
    public float maxCanisterSpawnRate;
    public float CanisterSpawnRate;
    public GameObject[] Canisters;
    public Transform CanisterSpawn;
    public GameObject CanisterPrefab;

    public GameObject depletedPU1;
    public GameObject PU1;

    void Start()
    {
        //set fuel slider base values
        curFuel = maxFuel;
        fuelSlider.maxValue = maxFuel;
        fuelSlider.value = curFuel;
        timer = maxTimer;

        //create prefab enemies for later use
        for (int i = 0; i < maxEnemies; i++)
        {
            enemies[i] = Instantiate(enemyPrefab, spawnPos.position, transform.rotation);
            enemies[i].SetActive(false);
        }

        //create canisters
        CanisterSpawnRate = maxCanisterSpawnRate;
        for (int i = 0; i < maxCanisters; i++)
        {
            Canisters[i] = Instantiate(CanisterPrefab, CanisterSpawn.position, transform.rotation);
            Canisters[i].SetActive(false);
        }

        //grab playerprefs values
        highScore = PlayerPrefs.GetInt("HighScore");

        //playername bypass
        var gamecontrol = GameObject.Find("GameController");
        string myPlayerName = "null";

        if ( gamecontrol )
            myPlayerName = gamecontrol.GetComponent<MenuController>().playerName;

        if(myPlayerName == null)
        {
            myPlayerName = "nulled exception";
            playerName = myPlayerName;
        }
        else
        {
            playerName = myPlayerName;
            return;
        }
    }
    void Update() {
        fuelSlider.value = curFuel;
        //if score is beaten, apply new changes for later reference, save to PlayerPrefs
        if (Score > highScore)
        {
            PlayerPrefs.SetInt("Highscore", Score);
            PlayerPrefs.SetString("Leader", playerName);
            PlayerPrefs.Save();
        }
        ScoreText.text = "" + Score;

        if (willSpawn == true)
        {
            StartCoroutine("SpawnEnemy");
        }
        //joystick controls
        if (joy.Horizontal != 0 || joy.Vertical != 0)
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2
                (joy.Horizontal * (moveSpeed * 100), joy.Vertical));
        }
        //pc controls
        if(Input.GetAxisRaw("Horizontal") != 0)
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2
                (Input.GetAxis("Horizontal") * (moveSpeed * 100), joy.Vertical));
        }

        //firing check
        if(isFiring == true)
        {
            curFuel -= Time.deltaTime;
            canRegen = false;
            if (timer >= maxTimer / 2 && isFiring == true)
            {
                BeamRenderer.enabled = true;
                Beam2Sprite.enabled = false;
            }
            if (timer <= maxTimer / 2)
            {
                Beam2Sprite.enabled = true;
                BeamRenderer.enabled = false;
            }
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                timer = maxTimer;
            }
        }
        if(canRegen)
        {
            curFuel += Time.deltaTime;
            if(curFuel > maxFuel)
            {
                curFuel = maxFuel;
            }
        }

        //pause menu check for pc
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            PauseSwitch();
        }
        if(curFuel <= 0)
        {
            ReleaseFire();
        }
        if(Input.GetButtonDown("Fire1"))
        {
            Fire();
        }
        if(Input.GetButtonUp("Fire1"))
        {
            ReleaseFire(); 
        }

        //canister spawning timer
        CanisterSpawnRate -= Time.deltaTime;
        if(CanisterSpawnRate <= 0)
        {
            SpawnCanister();
        }
        //fuel image control
        if (curFuel < maxFuel / 6)
        {
            depletedPU1.SetActive(true);
            PU1.SetActive(false);
        }
        else
        {
            depletedPU1.SetActive(false);
            PU1.SetActive(true);
        }
    }
    public void PauseSwitch()
    {
        if(pauseMenuCanvas.gameObject.activeInHierarchy == true)
        {
            //if canvas active, toggle pause state off
            pauseMenuCanvas.gameObject.SetActive(false);
            Time.timeScale = 1;
        }
        else
        {
            pauseMenuCanvas.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
    }
    private void SpawnChoice()
    {
        //check for a random spawn location
        spawnChoice = Random.Range(1, maxSpawnPos);
        switch (spawnChoice)
        {
            case 1:
                spawnPos = SpawnLocations[0];
                return;
            case 2:
                spawnPos = SpawnLocations[1];
                return;
            case 3:
                spawnPos = SpawnLocations[2];
                return;
            case 4:
                spawnPos = SpawnLocations[3];
                return;
            case 5:
                spawnPos = SpawnLocations[4];
                return;
            case 6:
                spawnPos = SpawnLocations[5];
                return;
        }  
    }
    private IEnumerator SpawnEnemy()
    {
        willSpawn = false;
        GameObject newEnemy = GetEnemy();

        if(newEnemy != null)
        {
            //set enemy active, grab random spawn location, set pos and rotation
            newEnemy.SetActive(true);
            SpawnChoice();
            newEnemy.transform.SetPositionAndRotation(spawnPos.position, Quaternion.identity);
        }
        yield return new WaitForSeconds(SpawnRate);
        willSpawn = true;
    }
    public void SpawnCanister()
    {
        GameObject newCanister = GetFuelCanister();
        if (newCanister != null)
        {
            //set canister to active, put in location
            newCanister.SetActive(true);
            newCanister.transform.SetPositionAndRotation(CanisterSpawn.position, Quaternion.identity);
        }
        CanisterSpawnRate = maxCanisterSpawnRate;
    }
    private IEnumerator FuelRegen()
    {
        yield return new WaitForSeconds(1);
        if (curFuel != maxFuel)
        {
            canRegen = true;
        }
        StopCoroutine("FuelRegen");
    }
    public void Fire()
    {
        StopCoroutine("FuelRegen");
        if (curFuel > 0)
        {
            BeamRenderer.enabled = true;
            isFiring = true;
        }
    }
    public void ReleaseFire()
    {
        BeamRenderer.enabled = false;
        Beam2Sprite.enabled = false;
        audioSource.enabled = false;
        isFiring = false;
        StartCoroutine("FuelRegen");
    }
    private GameObject GetEnemy()
    {
        //set enemies in for array
        for (int i = 0; i < maxEnemies; i++)
        {
            if(!enemies[i].activeSelf)
            {
                return enemies[i];
            }
        }
        return null;
    }
    void OnTriggerEnter2D(Collider2D col)      
    {
        if (col.gameObject.tag == "FuelCanister" && col.transform.position.y < minDist)
        {
            curFuel = maxFuel;
            col.gameObject.SetActive(false);
        }
    }
    private GameObject GetFuelCanister()
    {
        //setFuelCanisters
        for (int i = 0; i < maxCanisters; i++)
        {
            if(!Canisters[i].activeSelf)
            {
                return Canisters[i];
            }
        }
        return null;
    }
}
