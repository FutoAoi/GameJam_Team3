using UnityEngine;

public class MovingFloor3D : MonoBehaviour
{
    [Header("移動設定")]
    public Vector3 moveDistance = new Vector3(5f, 0f, 0f);
    public float moveSpeed = 2f;

    private Vector3 startPos;
    private Vector3 targetPos;

    void Start()
    {
        startPos = transform.position;
        targetPos = startPos + moveDistance;
    }

    void Update()
    {
        transform.position = Vector3.Lerp(
            startPos,
            targetPos,
            Mathf.PingPong(Time.time * moveSpeed, 1f)
        );
    }

    // プレイヤーが乗った時
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(transform);
        }
    }

    // プレイヤーが降りた時
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(null);
        }
    }
}