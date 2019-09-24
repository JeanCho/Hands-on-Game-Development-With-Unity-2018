using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using System;

public class MainMenu : MonoBehaviour
{

    [SerializeField] private Button startGameButton;


    private void OnEnable()
    {
        startGameButton.onClick.AddListener(StartGame);
    }

    private void OnDisable()
    {
        startGameButton.onClick.RemoveAllListeners();
    }
    private void StartGame()
    {
        GoToLevel("BossSandBox");
    }

    public void GoToLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }
}
