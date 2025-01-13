
using UnityEngine;

public class PinsController : MonoBehaviour
{
    [SerializeField]private PinsFallController pinsfallcontroller;
    public void SetPinRigidBodyValues(){
        pinsfallcontroller.SetRigidBodyValues();
    }
    
}
