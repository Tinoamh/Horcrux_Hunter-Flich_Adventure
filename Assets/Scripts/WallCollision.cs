using UnityEngine;
using System.Collections;

public class WallCollision : MonoBehaviour
{
    private BallManager ballManager;
    [SerializeField] private GameObject[] pins;

    [SerializeField] private Transform cameraStartPosition;
    [SerializeField] private Transform camera1;
    [SerializeField] private Transform camera2;

    private GameManager gameManager; 

    void Start()
    {
        ballManager = FindObjectOfType<BallManager>();
        gameManager = FindObjectOfType<GameManager>(); 

        camera2.gameObject.SetActive(false);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ball"))
        {
            Debug.Log("Ball collided with wall. Waiting for 5 seconds .");
            StartCoroutine(DestroyBallAfterDelay());
        }
    }

    IEnumerator DestroyBallAfterDelay()
    {
        yield return new WaitForSeconds(5f);

        if (ArePinsLeft())
        {
            ballManager.DestroyCurrentBall();
            ResetCameraToStart();
            ballManager.SpawnNextBall();
        }
        else
        {
            Debug.Log("you win!");
            gameManager.ShowGameOver(); 
        }
    }

    bool ArePinsLeft()
    {
        foreach (GameObject pin in pins)
        {
            if (pin != null)
            {
                return true; 
            }
        }
        return false; 
    }

    public void ResetCameraToStart()
    {
        StartCoroutine(ResetCameraCoroutine());
    }

    private IEnumerator ResetCameraCoroutine()
    {
        if (camera1 != null && cameraStartPosition != null)
        {
            camera1.position = cameraStartPosition.position;
            camera1.rotation = cameraStartPosition.rotation;

            camera1.gameObject.SetActive(false);
            camera2.gameObject.SetActive(false);

            yield return new WaitForSeconds(0.01f);

            camera1.gameObject.SetActive(true);

            Debug.Log("Camera reset to start position and activated.");
        }
    }
}
