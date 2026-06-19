using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float speed = 5f;

    private Vector2 moveDirection;

    private void Update()
    {
        transform.position +=
            (Vector3)(moveDirection * speed * Time.deltaTime);

        // 화면 밖으로 나가면 삭제
        if (Mathf.Abs(transform.position.x) > 15f ||
            Mathf.Abs(transform.position.y) > 15f)
        {
            Destroy(gameObject);
        }
    }

    public void SetDirection(Vector2 dir)
    {
        moveDirection = dir.normalized;

        float angle =
            Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        transform.rotation =
            Quaternion.Euler(0, 0, angle - 90f);
    }
}