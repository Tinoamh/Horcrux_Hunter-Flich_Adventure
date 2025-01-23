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
    public Button restartInGameButton;
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
         restartInGameButton.onClick.AddListener(RestartGame);
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
            }
            else
            {
                nextLevelButton.gameObject.SetActive(true);
            }
        }
        else
        {
            nextLevelButton.gameObject.SetActive(false);
            ShowNewGameOverPanel();
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

    public void ShowNewGameOverPanel()
    {
        if (GameOverPanel != null)
        {
            GameOverPanel.SetActive(true);
        }
    }
}
