using UnityEngine;

public class PlayerHit : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("충돌 발생 : " + collision.name);

        if (collision.CompareTag("Arrow"))
        {
            Debug.Log("화살 맞음");

            GameManager.Instance.GameOver();
        }
    }
}