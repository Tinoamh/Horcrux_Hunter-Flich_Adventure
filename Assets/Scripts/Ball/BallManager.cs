using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> BallList = new List<GameObject>();
    [SerializeField] private GameObject BallPrefab;
    [SerializeField] private int BallCount;
    private CameraFollowController cameraController;
    private GameManager gameManager;
    private int BallIndex;

    private void Start() {
        cameraController = Camera.main.GetComponent<CameraFollowController>();
        gameManager = FindObjectOfType<GameManager>(); 
        
        CreateBall();
    }

    private void CreateBall() {
        for (int i = 0; i < BallCount; i++) {
            GameObject newBall = Instantiate(BallPrefab, transform.position, Quaternion.identity);
            newBall.SetActive(false); 
            BallList.Add(newBall);
           
            if (i == 0 && cameraController != null) {
                cameraController.SetBallTransform(newBall.transform); 
            }
            
        }
         BallList[0].SetActive(true);
        
    }

public void DestroyCurrentBall()
    {
        if (BallList.Count > 0)
        {
            GameObject currentBall = BallList[0]; 
            if (currentBall != null)
            {
                Destroy(currentBall); 
                BallList.RemoveAt(0); 
                Debug.Log("Current ball destroyed.");
                
                if (BallList.Count == 0)
                {
                    gameManager.ShowNewGameOverPanel(); 
                }
            }
        }
    }

    public void SpawnNextBall()
{
    if (BallList.Count > 0)
    {
        GameObject nextBall = BallList[0];
        nextBall.SetActive(true);

        if (cameraController != null)
        {
            cameraController.SetBallTransform(nextBall.transform); 
        }

        Debug.Log("Next ball activated: " );
    }
    else
    {
        Debug.LogWarning("fail!");
    }
}

    public GameObject GetCurrentBall()
    {
        return BallList.Count > 0 ? BallList[0] : null;
    }
}
