using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShowButtonAfterDelay : MonoBehaviour
{
    public Button startButton;  
    public Button muteButton;  
    public Button exitButton;  
    public float delayTime = 15f;  
    public AudioSource backgroundMusic;  

    public Sprite muteSprite;     // تصویر دکمه در حالت بی‌صدا
    public Sprite unmuteSprite;   // تصویر دکمه در حالت پخش صدا

    private bool isMusicPlaying = true;  
    private Image muteButtonImage; // برای دسترسی به تصویر دکمه Mute

    void Start()
    {
        startButton.gameObject.SetActive(false);
        muteButton.gameObject.SetActive(false);
        exitButton.gameObject.SetActive(false);
        Invoke("ShowButton", delayTime);

        startButton.onClick.AddListener(ChangeScene);
        muteButton.onClick.AddListener(ToggleMute);
        exitButton.onClick.AddListener(ExitGame);  

        muteButtonImage = muteButton.GetComponent<Image>(); // گرفتن کامپوننت تصویر دکمه

        if (backgroundMusic != null)
        {
            backgroundMusic.Play();
            isMusicPlaying = true;

            // تنظیم تصویر اولیه دکمه Mute
            if (muteButtonImage != null && unmuteSprite != null)
            {
                muteButtonImage.sprite = unmuteSprite;
            }
        }
    }

    void ShowButton()
    {
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

            // تغییر تصویر دکمه Mute
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
