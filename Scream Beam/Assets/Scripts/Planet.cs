using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Planet : MonoBehaviour {
    public string SceneToLoad;
    public float maxPlanetHP = 100;
    public float curPlanetHP;
    public Slider PlanetHealthSlider;

    void Start()
    {
        //set the planet healthslider to correct values
        PlanetHealthSlider.maxValue = maxPlanetHP;
        PlanetHealthSlider.value = curPlanetHP;
        curPlanetHP = maxPlanetHP;
    }

	void Update () {
        //update slider based on health value
        PlanetHealthSlider.value = curPlanetHP;

        //if hp <= 0 load game over scene
        if (curPlanetHP <= 0)
        {
            SceneManager.LoadScene(SceneToLoad);
        }
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        //enemy in collider, kill it and reduce hp accordingly#
        if (col.gameObject.tag == "Enemy")
        {
            curPlanetHP -= 10;
            col.GetComponent<EnemyScript>().PlanetKill();
        }
    }
}
