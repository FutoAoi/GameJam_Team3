using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    public Transform startPoint;
    public float fallY = -5f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (transform.position.y < fallY)
        {
            Respawn();
        }
    }

    void Respawn()
    {
        transform.position = startPoint.position;
        transform.rotation = startPoint.rotation;

        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }
}