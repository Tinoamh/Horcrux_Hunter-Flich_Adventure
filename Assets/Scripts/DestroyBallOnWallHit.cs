using UnityEngine;

public class DestroyBallOnWallHit : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        // نمایش نام و تگ آبجکت برخوردی
        Debug.Log("Collided with: " + collision.gameObject.name + ", Tag: " + collision.gameObject.tag);

        // بررسی تگ آبجکت برخوردی
        if (collision.gameObject.CompareTag("LeftWall") || 
            collision.gameObject.CompareTag("RightWall") || 
            collision.gameObject.CompareTag("BackWall"))
        {
            // حذف توپ
            Debug.Log("Ball hit a wall and will be destroyed!");
            Destroy(gameObject);
        }
    }
}
