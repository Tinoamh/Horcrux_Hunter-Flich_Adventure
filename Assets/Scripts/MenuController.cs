using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public GameObject menuCanvas; // کانواس منو
    public Button menuButton; // دکمه منو
    private CanvasGroup canvasGroup; // برای کنترل Raycast

    void Start()
    {
        // ابتدا منو را غیرفعال می‌کنیم
        if (menuCanvas != null)
        {
            menuCanvas.SetActive(false);
            canvasGroup = menuCanvas.GetComponent<CanvasGroup>();

            // اگر CanvasGroup موجود نباشد، اضافه می‌کنیم
            if (canvasGroup == null)
            {
                canvasGroup = menuCanvas.AddComponent<CanvasGroup>();
            }

            // از بلاک شدن ورودی‌ها جلوگیری می‌کنیم
            canvasGroup.blocksRaycasts = false;
        }

        // اضافه کردن Event Listener برای دکمه منو
        if (menuButton != null)
        {
            menuButton.onClick.AddListener(ToggleMenu);
        }
    }

    void ToggleMenu()
    {
        if (menuCanvas != null)
        {
            // وضعیت منو را معکوس می‌کنیم
            bool isActive = !menuCanvas.activeSelf;
            menuCanvas.SetActive(isActive);

            // زمانی که منو فعال می‌شود، ورودی‌ها را بلاک نکنیم
            canvasGroup.blocksRaycasts = isActive; // منو فعال می‌شود، پس ورودی‌ها بلاک نمی‌شوند
        }
    }
}
