
using UnityEngine;

public class PinsFallController : MonoBehaviour
{
    private Rigidbody rb;
    private void Start(){
        rb= GetComponent<Rigidbody>();

    }
    public void SetRigidBodyValues(){
        rb.isKinematic = false;
            rb.AddForce(Vector3.right * 5f, ForceMode.Impulse); 
        
    }
}
