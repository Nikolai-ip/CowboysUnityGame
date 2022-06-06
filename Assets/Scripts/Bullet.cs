using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed = 20f;
    private Rigidbody2D _rb;
    private Transform _firePoint;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _firePoint = GetComponentInParent<Transform>();
    }

    // Update is called once per frame
    private void Update()
    {
        _rb.velocity = Vector2.right * _speed;
    }
}