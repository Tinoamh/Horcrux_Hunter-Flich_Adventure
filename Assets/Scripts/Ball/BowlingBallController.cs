using UnityEngine;

public class BowlingBallController : MonoBehaviour
{
    [SerializeField] private float maxThrowForce; 
    [SerializeField] private float forceMultiplier;
    [SerializeField] private Rigidbody ballRigidbody;
    [SerializeField] private AudioSource throwSound;

    private Vector2 startMousePosition;
    private bool ballThrown = false;

    void Update()
    {
        if (ballThrown) return;
        HandleMouseInput();
    }

    void HandleMouseInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startMousePosition = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            Vector2 endMousePosition = Input.mousePosition;
            ProcessThrow(endMousePosition);
        }
    }

    void ProcessThrow(Vector2 endMousePosition)
    {
        Vector2 swipeDelta = startMousePosition - endMousePosition;
        float swipeDistance = swipeDelta.magnitude;
        Vector3 throwDirection = new Vector3(swipeDelta.x, 0, swipeDelta.y).normalized;
        float throwForce = Mathf.Clamp((swipeDistance / 50f) * forceMultiplier, 10f, maxThrowForce);

        ThrowBall(throwDirection, throwForce);
    }

    void ThrowBall(Vector3 direction, float throwForce)
    {
        if (ballThrown) return;

        ballRigidbody.AddForce(direction * throwForce, ForceMode.Impulse);

        if (throwSound != null)
        {
            throwSound.Play();
        }

        ballThrown = true;
    }

    public void ResetBall()
    {
        ballRigidbody.velocity = Vector3.zero;
        ballRigidbody.angularVelocity = Vector3.zero;
        ballRigidbody.position = new Vector3(0, 0.5f, -10);
        ballThrown = false;
    }

    public bool IsBallThrown()
    {
        return ballThrown;
    }

    public float GetBallVelocity()
    {
        return ballRigidbody.velocity.sqrMagnitude;
    }
}
