using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShowButtonAfterDelay : MonoBehaviour
{
    public Button startButton;  
    public Button muteButton;  
    public float delayTime = 15f;  
    public AudioSource backgroundMusic;  

    private bool isMusicPlaying = false;  

    void Start()
    {
        startButton.gameObject.SetActive(false);
        muteButton.gameObject.SetActive(false);
        Invoke("ShowButton", delayTime);

        startButton.onClick.AddListener(ChangeScene);
        if (backgroundMusic != null)
        {
            backgroundMusic.Play(); 
            isMusicPlaying = true;
        }
    }

    void ShowButton()
    {
        startButton.gameObject.SetActive(true);
        muteButton.gameObject.SetActive(true);
    }

    void ChangeScene()
    {
        
        SceneManager.LoadScene("Story");
    }
}
