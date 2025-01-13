using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Transform ballStartPosition;
    [SerializeField] private Transform cameraStartPosition; // موقعیت اولیه دوربین
    [SerializeField] private Transform camera1; // دوربین اول
    [SerializeField] private Transform camera2; // دوربین دوم
    [SerializeField] private GameObject[] pins; // لیست پین‌ها

    private bool isCheckingPins = false; // جلوگیری از اجرای هم‌زمان بررسی

    void Start()
    {
        // دوربین 2 به طور پیش‌فرض غیرفعال است
        camera2.gameObject.SetActive(false);
    }

    void OnCollisionEnter(Collision collision)
    {
        // بررسی ID دیوار برخورد شده
        string wallID = collision.gameObject.name; // نام آبجکت برخورد شده

        if (wallID == "LeftWall" || wallID == "RightWall" || wallID == "BackWall")
        {
            // وقتی برخورد با دیوار مشخصی رخ داد، بررسی پین‌ها را شروع کن
            StartCoroutine(CheckPinsAfterDelay());
        }
    }

    IEnumerator CheckPinsAfterDelay()
    {
        if (isCheckingPins) yield break; // اگر بررسی در حال انجام است، خروج

        isCheckingPins = true;

        // 5 ثانیه صبر کن
        yield return new WaitForSeconds(5);

        // بررسی وضعیت پین‌ها
        bool pinsLeft = ArePinsLeft();

        if (pinsLeft)
        {
            // اگر پین‌ها هنوز باقی مانده‌اند، توپ را به موقعیت اولیه باز گردان
            ResetBallPosition();

            // تغییر جای دوربین‌ها
            SwitchCameras();
        }

        isCheckingPins = false; // آماده برای بررسی بعدی
    }

    bool ArePinsLeft()
    {
        foreach (GameObject pin in pins)
        {
            // بررسی اینکه آیا پین هنوز موجود است (آبجکت پین از صحنه حذف نشده باشد)
            if (pin != null)
            {
                return true; // حداقل یک پین باقی مانده است
            }
        }

        return false; // هیچ پینی باقی نمانده
    }

    void ResetBallPosition()
    {
        // بازگرداندن توپ به موقعیت اولیه
        transform.position = ballStartPosition.position;

        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = Vector3.zero; // توقف حرکت توپ
            rb.angularVelocity = Vector3.zero; // توقف چرخش توپ
        }

        // بازگرداندن دوربین اول به موقعیت اولیه
        ResetCameraToStart();
    }

    void ResetCameraToStart()
    {
        if (camera1 != null && cameraStartPosition != null)
        {
            camera1.position = cameraStartPosition.position;
            camera1.rotation = cameraStartPosition.rotation;
        }
    }

    void SwitchCameras()
    {
        // غیرفعال کردن دوربین ۲ و فعال کردن دوربین ۱
        if (camera1 != null && camera2 != null)
        {
            camera2.gameObject.SetActive(false); // غیرفعال کردن دوربین ۲
            camera1.gameObject.SetActive(true);  // فعال کردن دوربین ۱
        }
    }
}
