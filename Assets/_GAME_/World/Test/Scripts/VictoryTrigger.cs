using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class VictoryTrigger : MonoBehaviour
{
    public GameObject victoryCanvas;
    public TextMeshProUGUI victoryText; 
    public string menuSceneName = "Menu"; 

    private void Start()
    {
        if (victoryCanvas != null)
            victoryCanvas.SetActive(false); 
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag("Player"))
        {
            if (victoryCanvas != null)
            {
                victoryCanvas.SetActive(true); 
                victoryText.text = "You Escaped!"; 
            }
        }
    }

   
    public void LoadMenuScene()
    {
        SceneManager.LoadScene(menuSceneName);
    }
}
