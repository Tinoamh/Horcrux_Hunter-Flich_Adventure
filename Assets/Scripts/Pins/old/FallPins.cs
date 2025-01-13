using UnityEngine;

public class PinFall : MonoBehaviour
{
    private Rigidbody rb;
    private bool hasFallen = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnTriggerEnter(Collider collision)
    {
        
        if (collision.gameObject.CompareTag("ball"))
        {
            
            rb.isKinematic = false;
            rb.AddForce(Vector3.right * 5f, ForceMode.Impulse); 
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
       
        if (!hasFallen && Mathf.Abs(transform.rotation.eulerAngles.x) > 20f || Mathf.Abs(transform.rotation.eulerAngles.z) > 20f)
        {
            hasFallen = true;
   
            Destroy(gameObject, 2f);
        }
    }
}
