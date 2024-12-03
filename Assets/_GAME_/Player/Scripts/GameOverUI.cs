using UnityEngine;
using UnityEngine.SceneManagement;  
using UnityEngine.UI;              

public class GameOverUI : MonoBehaviour
{
    // A gombok referencia
    public Button retryButton;
    public Button backToMenuButton;

    void Start()
    {
        retryButton.onClick.AddListener(RetryGame);
        backToMenuButton.onClick.AddListener(BackToMainMenu);
    }

    // Retry gomb kattintásakor
    void RetryGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void BackToMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}