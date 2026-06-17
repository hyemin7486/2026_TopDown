using UnityEngine;

public class PlayerHit : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Arrow"))
        {
            Debug.Log("¸ÂÀ½!");

            GameManager.Instance.GameOver();
        }
    }
}