﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(Rigidbody2D))]
public class TouchInput : MonoBehaviour {
    [Header("Shooting Parameters")]
    public SpriteRenderer Beam2Sprite;
    public GameObject BeamSprite;
    public SpriteRenderer BeamRenderer;
    public AudioSource audioSource;
    public Transform BeamOrigin;
    public float maxTimer;
    public float timer;
    public bool isFiring = false;

    public float BeamRadius;
    public float BeamDistance;
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

    private bool SFXToggled = false;
    public AudioSource[] SFXSources;

    void Start()
    {
        timer = maxTimer;

        //create prefab enemies for later use
        for (int i = 0; i < maxEnemies; i++)
        {
            enemies[i] = Instantiate(enemyPrefab, spawnPos.position, transform.rotation);
            enemies[i].SetActive(false);
        }

        //grab playerprefs values
        highScore = PlayerPrefs.GetInt("HighScore");
        playerName = GameObject.Find("GameController").GetComponent<MenuController>().playerName;
    }

    void Update() {
        //if score is beaten, apply new changes for later reference, save to PlayerPrefs
        if(Score > highScore)
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

        //pause menu check for pc
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            PauseSwitch();
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

    public void ResumeGame()
    {
        pauseMenuCanvas.gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    public void QuitGame()
    {
        Application.Quit();
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

    public void Fire()
    {
        BeamRenderer.enabled = true;
        if (SFXToggled == true)
        {
            audioSource.enabled = true;
        }
        isFiring = true;
    }

    public void ReleaseFire()
    {
        BeamRenderer.enabled = false;
        Beam2Sprite.enabled = false;
        audioSource.enabled = false;
        isFiring = false;

    }

    public void ToggleSFX()
    {
        if (SFXToggled == true)
        {
            foreach (var audio in SFXSources)
            {
                SFXToggled = false;
                audio.enabled = false;
            }
        }
        else if (SFXToggled == false)
        {
            foreach (var audio in SFXSources)
            {
                SFXToggled = true;
                audio.enabled = true;
                
            }
        }
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
}
