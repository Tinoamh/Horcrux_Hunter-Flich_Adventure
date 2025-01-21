using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class TextSwitchEndScene : MonoBehaviour
{
    public TMP_Text text1;
    public TMP_Text text2;
    public Button button;

    void Start()
    {
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
            button.GetComponentInChildren<TMP_Text>().text = "Exit";
        }
        else if (text2.gameObject.activeSelf)
        {
            Application.Quit();
        }
    }
}
