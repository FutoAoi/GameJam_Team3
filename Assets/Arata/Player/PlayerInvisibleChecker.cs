using UnityEngine;

public class PlayerInvisibleChecker : MonoBehaviour
{
    [Header("Ray設定")]
    public float rayDistance = 3f;

    [Header("Rayの太さ")]
    public float rayRadius = 0.5f;

    [Header("プレイヤーRenderer")]
    public GameObject[] _player;

    private bool isInvisible = true;

    void Update()
    {
        CheckInvisibleFloor();
    }

    void CheckInvisibleFloor()
    {
        RaycastHit hit;

        // 太いRay
        if (Physics.SphereCast(
            transform.position,
            rayRadius,
            Vector3.down,
            out hit,
            rayDistance))
        {
            RandomInvisibleFloor3D area =
                hit.collider.GetComponent<RandomInvisibleFloor3D>();

            if (area != null)
            {
                SetPlayerVisible(area.IsInvisible);
                return;
            }
        }

        SetPlayerVisible(true);
    }

    void SetPlayerVisible(bool visible)
    {
        if (isInvisible == visible)
            return;

        isInvisible = visible;

        foreach (GameObject player in _player)
        {
            player.SetActive(visible);
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Vector3 start = transform.position;
        Vector3 end = transform.position + Vector3.down * rayDistance;

        Gizmos.DrawWireSphere(start, rayRadius);
        Gizmos.DrawWireSphere(end, rayRadius);
        Gizmos.DrawLine(start, end);
    }
}