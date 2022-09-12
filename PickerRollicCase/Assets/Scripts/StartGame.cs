using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public GameObject button, moveToPlay;
    public GameObject treAgain;
    public void startGame()
    {
        button.SetActive(false);
        moveToPlay.SetActive(false);
    }

    public void gameOver()
    {
        treAgain.gameObject.SetActive(true);
    }

    public void tryAgain()
    {
        SceneManager.LoadScene(0);
    }

}