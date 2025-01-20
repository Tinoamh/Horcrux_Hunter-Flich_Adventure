using UnityEngine;
using UnityEngine.SceneManagement; 
using UnityEngine.UI; 

public class GameManager : MonoBehaviour
{
    public GameObject gameWinPanel; 
    public Button restartButton; 
    public Button nextLevelButton; 
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
        GameoverRestartButton.onClick.AddListener(RestartGame);
        currentLevelIndex = SceneManager.GetActiveScene().buildIndex;
    }

    public void EndGame(bool isWin)
    {
        gameWinPanel.SetActive(true);

        if (isWin)
        {
            nextLevelButton.gameObject.SetActive(true);
        }
        else
        {
            nextLevelButton.gameObject.SetActive(false);
        }
    }

    void RestartGame()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void NextLevel()
    {

        SceneManager.LoadScene("Level2");
    }
     public void ShowNewGameOverPanel()
    {
        if (GameOverPanel != null)
        {
            GameOverPanel.SetActive(true); 
        }
    }
}
