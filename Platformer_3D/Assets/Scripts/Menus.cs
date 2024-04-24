using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menus : MonoBehaviour
{
    public void PlayButton() //Renvoie à la scene du Jeu
    {
        SceneManager.LoadScene("GameScene");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitButton() //Quitte le jeu
    {
#if UNITY_EDITOR //Pour quitter sur Unity

        UnityEditor.EditorApplication.isPlaying = false;
#endif

#if UNITY_STANDALONE //Quitter en standalone

        Application.Quit();
#endif

    }
}