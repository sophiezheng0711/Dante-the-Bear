using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour {

	// Used in the Menu, starts the game at level 0, the tutorial level
	public void StartGame () {
        SceneManager.LoadScene("Level0");
        Time.timeScale = 1;
	}

    public void BackToMenu () {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1;
    }

    public void ChooseLevel () {
        SceneManager.LoadScene("Levels");
        Time.timeScale = 1;
    }

    // This method requires that the current scene is a level, not a menu
    public void NextLevel () {
        string currentName = SceneManager.GetActiveScene().name;
        int nextLevel = int.Parse(currentName.Substring(5)) + 1;
        string nextName = "Level" + nextLevel;
        SceneManager.LoadScene(nextName);
        Time.timeScale = 1;
    }

    public void LoadLevel1 () {
        SceneManager.LoadScene("Level1");
        Time.timeScale = 1;
    }

    public void LoadLevel2 () {
        SceneManager.LoadScene("Level2");
        Time.timeScale = 1;
    }

    public void LoadLevel3 () {
        SceneManager.LoadScene("Level3");
        Time.timeScale = 1;
    }

    public void LoadLevel4 () {
        SceneManager.LoadScene("Level4");
        Time.timeScale = 1;
    }

}
