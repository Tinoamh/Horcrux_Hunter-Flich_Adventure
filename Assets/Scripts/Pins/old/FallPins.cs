using UnityEngine;

public class PinFall : MonoBehaviour
{
    private Rigidbody rb;
    private bool hasFallen = false;
    private PinCounter pinCounter;  

    private float initialXRotation;
    private float initialZRotation;

    public AudioSource collisionSound; 

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        pinCounter = FindObjectOfType<PinCounter>(); 
        initialXRotation = transform.rotation.eulerAngles.x;
        initialZRotation = transform.rotation.eulerAngles.z;
    }

    void OnTriggerEnter(Collider collision)
{
    Debug.Log("Trigger Entered with: " + collision.gameObject.name); 

    if (collision.gameObject.CompareTag("ball"))
    {
        rb.isKinematic = false;
        rb.useGravity = true;
        rb.AddForce(Vector3.right * 5f, ForceMode.Impulse);

        if (collisionSound != null)
        {
            collisionSound.PlayOneShot(collisionSound.clip);
            Debug.Log("Sound played on ball collision");
        }
        else
        {
            Debug.LogError("collisionSound is not assigned!");
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
        float deltaX = Mathf.DeltaAngle(initialXRotation, transform.rotation.eulerAngles.x);
        float deltaZ = Mathf.DeltaAngle(initialZRotation, transform.rotation.eulerAngles.z);

        if (!hasFallen && (Mathf.Abs(deltaX) > 20f || Mathf.Abs(deltaZ) > 20f))
        {
            hasFallen = true;
            if (pinCounter != null) 
            {
                pinCounter.IncreasePinCount();
            }
            Destroy(gameObject, 1.3f);
        }
    }
}
