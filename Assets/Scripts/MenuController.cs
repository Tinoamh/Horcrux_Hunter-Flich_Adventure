using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public GameObject menuCanvas; 
    public Button menuButton; 
    private CanvasGroup canvasGroup; 

    void Start()
    {
       
        if (menuCanvas != null)
        {
            menuCanvas.SetActive(false);
            canvasGroup = menuCanvas.GetComponent<CanvasGroup>();

          
            if (canvasGroup == null)
            {
                canvasGroup = menuCanvas.AddComponent<CanvasGroup>();
            }

         
            canvasGroup.blocksRaycasts = false;
        }

     
        if (menuButton != null)
        {
            menuButton.onClick.AddListener(ToggleMenu);
        }
    }

    void ToggleMenu()
    {
        if (menuCanvas != null)
        {
           
            bool isActive = !menuCanvas.activeSelf;
            menuCanvas.SetActive(isActive);
            canvasGroup.blocksRaycasts = isActive; 
        }
    }
}
