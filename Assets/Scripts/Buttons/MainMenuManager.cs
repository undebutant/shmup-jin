using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour {

    public void StartNewGame() {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }


    public void QuitGame() {
        Application.Quit();
    }
}
