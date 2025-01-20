using UnityEngine;

public class PinFall : MonoBehaviour
{
    private Rigidbody rb;
    private bool hasFallen = false;
    private PinCounter pinCounter;  

    private float initialXRotation;
    private float initialZRotation;

    public AudioSource collisionSound;  // برای صدای برخورد

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        pinCounter = FindObjectOfType<PinCounter>(); 

        // ذخیره مقدار اولیه‌ی چرخش
        initialXRotation = transform.rotation.eulerAngles.x;
        initialZRotation = transform.rotation.eulerAngles.z;
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("ball"))
        {
            rb.isKinematic = false;
            rb.useGravity = true;
            rb.AddForce(Vector3.right * 5f, ForceMode.Impulse); 

            if (collisionSound != null)
            {
                collisionSound.Play();
            }
        }

        if (collision.gameObject.CompareTag("pin"))
        {
            Rigidbody otherRb = collision.gameObject.GetComponent<Rigidbody>();
            if (otherRb != null && otherRb.isKinematic)
            {
                otherRb.isKinematic = false;
                otherRb.AddForce(Vector3.right * 5f, ForceMode.Impulse); 
            }
        }
    }

    void Update()
    {
        // محاسبه تغییرات زاویه نسبت به مقدار اولیه
        float deltaX = Mathf.DeltaAngle(initialXRotation, transform.rotation.eulerAngles.x);
        float deltaZ = Mathf.DeltaAngle(initialZRotation, transform.rotation.eulerAngles.z);

        if (!hasFallen && (Mathf.Abs(deltaX) > 20f || Mathf.Abs(deltaZ) > 20f))
        {
            hasFallen = true;
            if (pinCounter != null) 
            {
                pinCounter.IncreasePinCount();
            }
            Destroy(gameObject, 2f);
        }
    }
}
