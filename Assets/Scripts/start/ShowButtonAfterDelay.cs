using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShowButtonAfterDelay : MonoBehaviour
{
    public Button startButton;  
    public Button muteButton;  
    public Button exitButton;  
    public Slider volume;
    public float delayTime = 15f;  
    public AudioSource backgroundMusic;  

    public Sprite muteSprite;   
    public Sprite unmuteSprite;   

    private bool isMusicPlaying = true;  
    private Image muteButtonImage;

    void Start()
    {
        startButton.gameObject.SetActive(false);
        volume.gameObject.SetActive(false);
        muteButton.gameObject.SetActive(false);
        exitButton.gameObject.SetActive(false);
        Invoke("ShowButton", delayTime);

        startButton.onClick.AddListener(ChangeScene);
        muteButton.onClick.AddListener(ToggleMute);
        exitButton.onClick.AddListener(ExitGame);  

        muteButtonImage = muteButton.GetComponent<Image>(); 

        if (backgroundMusic != null)
        {
            backgroundMusic.Play();
            isMusicPlaying = true;
            if (muteButtonImage != null && unmuteSprite != null)
            {
                muteButtonImage.sprite = unmuteSprite;
            }
        }
    }

    void ShowButton()
    {
        volume.gameObject.SetActive(true);
        startButton.gameObject.SetActive(true);
        muteButton.gameObject.SetActive(true);
        exitButton.gameObject.SetActive(true);
    }

    void ChangeScene()
    {
        SceneManager.LoadScene("Story");
    }

    void ToggleMute()
    {
        if (backgroundMusic != null)
        {
            if (isMusicPlaying)
            {
                backgroundMusic.Pause();
            }
            else
            {
                backgroundMusic.Play();
            }
            isMusicPlaying = !isMusicPlaying;
            if (muteButtonImage != null)
            {
                muteButtonImage.sprite = isMusicPlaying ? unmuteSprite : muteSprite;
            }
        }
    }

    void ExitGame()
    {
        Application.Quit();
    }
}
