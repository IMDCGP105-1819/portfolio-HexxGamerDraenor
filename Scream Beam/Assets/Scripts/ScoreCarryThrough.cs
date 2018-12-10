using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class ScoreCarryThrough : MonoBehaviour {
    public TouchInput scoreHolder;
    public int myScore;
	
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }
	// Update is called once per frame
	void Update () {
        myScore = scoreHolder.Score;

        if(SceneManager.GetActiveScene().name == "GameOver")
        {
            GameObject.Find("GOScore").GetComponent<TextMeshProUGUI>().text = "Score: " + myScore;
        }
	}
}
