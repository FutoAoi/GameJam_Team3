using UnityEngine;

public class CameraFollowZ : MonoBehaviour
{
    [Header("追従対象")]
    public Transform player;

    [Header("X追従範囲")]
    public float minX = -5f;
    public float maxX = 5f;

    [Header("Zオフセット")]
    public float zOffset = -10f;

    [Header("追従速度")]
    [Range(0.01f, 1f)]
    public float smoothSpeed = 0.1f;

    void LateUpdate()
    {
        if (player == null) return;

        Vector3 targetPos = transform.position;

        // X軸を範囲制限付きで追従
        targetPos.x = Mathf.Clamp(player.position.x, minX, maxX);

        // Z軸だけ追従
        targetPos.z = player.position.z + zOffset;

        // なめらか移動
        transform.position = Vector3.Lerp(
            transform.position,
            targetPos,
            smoothSpeed
        );
    }
}