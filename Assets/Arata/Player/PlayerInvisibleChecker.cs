using UnityEngine;

public class PlayerInvisibleChecker : MonoBehaviour
{
    [Header("Ray設定")]
    public float rayDistance = 3f;

    [Header("プレイヤーRenderer")]
    public Renderer[] renderers;

    private bool isInvisible = true;

    void Update()
    {
        CheckInvisibleFloor();
    }

    void CheckInvisibleFloor()
    {
        Ray ray = new Ray(transform.position, Vector3.down);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, rayDistance))
        {
            RandomInvisibleFloor3D area = hit.collider.GetComponent<RandomInvisibleFloor3D>();

            if (area != null)
            {
                SetPlayerVisible(area.IsInvisible);
                return;
            }
        }

        // 何も無かったら表示
        SetPlayerVisible(true);
    }

    void SetPlayerVisible(bool visible)
    {
        if (isInvisible == visible)
            return;

        isInvisible = visible;

        foreach (Renderer rend in renderers)
        {
            rend.enabled = visible;
        }
    }

    // SceneビューでRayを見えるようにする
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * rayDistance);
    }
}