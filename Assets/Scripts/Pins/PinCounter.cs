using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PinCounter : MonoBehaviour
{
    public TextMeshProUGUI fallenPinsText;
    private int fallenPins = 0;

    // متد برای افزایش امتیاز
    public void IncreasePinCount()
    {
        string currentScene = SceneManager.GetActiveScene().name; // نام صحنه فعلی

        // اگر در لول 1 هستیم، یک پین اضافه کن
        if (currentScene == "Level1")
        {
            fallenPins++;
        }
        // اگر در لول 2 هستیم، دو پین اضافه کن
        else if (currentScene == "Level2")
        {
            fallenPins += 2;
        }

        UpdateUI();
    }

    // متد برای بازنشانی شمارش
    public void ResetPinCount()
    {
        fallenPins = 0;
        UpdateUI();
    }

    // متد برای به‌روزرسانی رابط کاربری
    private void UpdateUI()
    {
        fallenPinsText.text = "Score    " + fallenPins;
    }
}
