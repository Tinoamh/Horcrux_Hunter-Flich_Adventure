using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextSwitchEndScene : MonoBehaviour
{
    public TMP_Text text1;
    public TMP_Text text2;
    public Button button;
    public AudioSource audioSource; 

    void Start()
    {
        text1.gameObject.SetActive(true);
        text2.gameObject.SetActive(false);
        button.onClick.AddListener(OnButtonClick);
        button.GetComponentInChildren<TMP_Text>().text = "SKIP";
    }

    void OnButtonClick()
    {
        if (text1.gameObject.activeSelf)
        {
            text1.gameObject.SetActive(false);
            text2.gameObject.SetActive(true);
            button.GetComponentInChildren<TMP_Text>().text = "Leave";

            if (audioSource != null)
            {
                audioSource.PlayOneShot(audioSource.clip);

            }
        }
        else if (text2.gameObject.activeSelf)
        {
            Application.Quit();
        }
    }
}
