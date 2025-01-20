using UnityEngine;

public class CameraFollowController : MonoBehaviour
{
    [SerializeField] private Transform ballTransform; 
    public GameObject closeShot; 
    private Vector3 offset;
    [SerializeField, Range(0, 3)] private float lerpValue;
    
    private Vector3 newPosition;

    private GameObject alley;
    private float alleyLength;
    private float mark;
    private Vector3 initialPosition;

    void Start()
    {
        if (ballTransform != null)
        {
            offset = transform.position - ballTransform.position;
        }
        alley = GameObject.FindGameObjectWithTag("alley");
        initialPosition = transform.position; 

        if (alley != null)
        {
            alleyLength = 300f;
            mark = alley.transform.position.z + (9.5f * alleyLength / 10f);
        }
    }

    private void SetCameraSmoothFollow()
    {
        if (ballTransform != null)
        {
            newPosition = Vector3.Lerp(transform.position, ballTransform.position + offset, lerpValue * Time.deltaTime);
            transform.position = newPosition;

            if (ballTransform.position.z >= mark)
            {
                gameObject.SetActive(false);
                closeShot.SetActive(true);
                
            }
        }
    }

    public void ResetCamera()
    {
        transform.position = initialPosition;
        gameObject.SetActive(true);
        if (closeShot != null)
        {
            closeShot.SetActive(false);
        }
    }

    void LateUpdate()
    {
        SetCameraSmoothFollow();
    }

    public void SetBallTransform(Transform newBallTransform)
    {
        ballTransform = newBallTransform; 
        if (ballTransform != null)
        {
            offset = transform.position - ballTransform.position; 
        }
    }
}
