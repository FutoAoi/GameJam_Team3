using UnityEngine;

public class FutoPlayer : MonoBehaviour
{
    [SerializeField] private float _playerSpeed;
    private Rigidbody _rb;
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

}
