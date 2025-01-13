
using UnityEngine;

public class BallCollisionController : MonoBehaviour
{
    [SerializeField]private PinsController pinsController;
    private void OnCollisionEnter(Collision other)
{
    
    if(other.gameObject.CompareTag("ball"))
    {
        pinsController.SetPinRigidBodyValues();
    }
}

        
        

    }

