using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PinCounter : MonoBehaviour
{
    public TextMeshProUGUI fallenPinsText;
    private int fallenPins = 0;

    public void IncreasePinCount()
    {
        string currentScene = SceneManager.GetActiveScene().name; 
        if (currentScene == "Level1")
        {
            fallenPins++;
        }
        else if (currentScene == "Level2")
        {
            fallenPins += 2;
        }
        else if (currentScene == "Level3")
        {
            fallenPins += 3;
        }

        UpdateUI();
    }

    public void ResetPinCount()
    {
        fallenPins = 0;
        UpdateUI();
    }

    private void UpdateUI()
    {
        fallenPinsText.text = "Score    " + fallenPins;
    }
}
