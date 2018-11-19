using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class MenuController : MonoBehaviour {
    [Header("Assigned Variables")]
    public Transform BootMenu;
    public Transform NameMenu;
    public Transform InstructionsMenu;
    public InputField playerInputField;
    public GameObject goButton;
    public Text HighScoreText;

    public string playerName;
    public string SceneToLoad;
	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(this.gameObject);
        //set highscore text to saved variables
        HighScoreText.text = "Current Leader: " + PlayerPrefs.GetString("Leader") + ":" + PlayerPrefs.GetInt("Highscore").ToString();
        //set screen rotations to landscape values
        Screen.autorotateToLandscapeLeft = true;
        Screen.autorotateToLandscapeRight = true;

        Screen.orientation = ScreenOrientation.LandscapeLeft;

        //menu startup
        BootMenu.gameObject.SetActive(true);
        NameMenu.gameObject.SetActive(false);
        InstructionsMenu.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        playerName = playerInputField.text;

        if(playerInputField.text != "" && SceneManager.GetActiveScene().name != SceneToLoad)
        {
            goButton.SetActive(true);
        }

        //if in main game get name text obj and apply playername
        if(SceneManager.GetActiveScene().name == SceneToLoad)
        {
            GameObject nameText = GameObject.Find("NameText");
            nameText.GetComponent<TextMeshProUGUI>().text = playerName;
        }

        if(BootMenu == null)
        {
            return;
        }
	}

    //Functions for starting game and exitting .exe
    public void StartGame()
    {
        //switch from boot menu to naming menu
        BootMenu.gameObject.SetActive(false);
        NameMenu.gameObject.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void InstructionTransition()
    {
        //disable boot menu and name menu, reveal instructions!
        BootMenu.gameObject.SetActive(false);
        NameMenu.gameObject.SetActive(false);
        InstructionsMenu.gameObject.SetActive(true);
    }

    public void Playbutton()
    {
        SceneManager.LoadScene(SceneToLoad);
    }
}
