using UnityEngine;
using UnityEngine.SceneManagement; 
using UnityEngine.UI; 

public class GameManager : MonoBehaviour
{
    public GameObject gameWinPanel; 
    public Button restartButton; 
    public Button nextLevelButton; 
    public Button lastLevelButton; 
    public GameObject GameOverPanel; 
    public Button GameoverRestartButton;
    private int currentLevelIndex;

    public void ShowGameOver()
    {
        if (gameWinPanel != null)
        {
            gameWinPanel.SetActive(true); 
        }
    }

    void Start()
    {
        gameWinPanel.SetActive(false);
        GameOverPanel.SetActive(false);
        restartButton.onClick.AddListener(RestartGame);
        nextLevelButton.onClick.AddListener(NextLevel);
        lastLevelButton.onClick.AddListener(LastLevel);
        GameoverRestartButton.onClick.AddListener(RestartGame);
        currentLevelIndex = SceneManager.GetActiveScene().buildIndex;
    }

    public void EndGame(bool isWin)
    {
        gameWinPanel.SetActive(true);

        if (isWin)
        {
            if (currentLevelIndex == SceneManager.sceneCountInBuildSettings - 2)
            {
                nextLevelButton.gameObject.SetActive(false); 
                lastLevelButton.gameObject.SetActive(true);
            }
            else
            {
                nextLevelButton.gameObject.SetActive(true);
                lastLevelButton.gameObject.SetActive(false);
            }
        }
        else
        {
            nextLevelButton.gameObject.SetActive(false);
            lastLevelButton.gameObject.SetActive(false);
        }
    }

    void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void NextLevel()
    {
        int nextLevelIndex = currentLevelIndex + 1;
        
        if (nextLevelIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextLevelIndex);
        }
    }

    void LastLevel()
    {
        SceneManager.LoadScene("EndScene");
    }

    public void ShowNewGameOverPanel()
    {
        if (GameOverPanel != null)
        {
            GameOverPanel.SetActive(true); 
        }
    }
}
