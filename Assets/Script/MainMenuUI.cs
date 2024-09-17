using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    public Button playButton;
    public Button exitButton;
    public Button creditButton;

    private void Start()
    {
        playButton.onClick.AddListener(playGame);
        exitButton.onClick.AddListener(ExitGame);
        creditButton.onClick.AddListener(Credit);
    }

    public void playGame()
    {
        SceneManager.LoadScene("PinBall_Game_Marsha");
    }

    private void ExitGame()
    {
        Application.Quit();
    }

    public void Credit()
    {
        SceneManager.LoadScene("Credit");
    }
}
