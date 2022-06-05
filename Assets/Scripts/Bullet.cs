using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed = 20f;
    private Rigidbody2D _rb;
    private Transform _firePoint;
    void Start()
    {

        _rb=GetComponent<Rigidbody2D>();
        _firePoint = GetComponentInParent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
        _rb.velocity = Vector2.right * _speed;
    }

}
