using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robber : MonoBehaviour
{
    [SerializeField] private int _healt = 100;

    [SerializeField] private float _speed = 20f;
    private SpriteRenderer _banditSpriteRender;
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private Color _color;
    public int line;
   

    void Start()
    {
        _banditSpriteRender = GetComponent<SpriteRenderer>();  
        _rb=GetComponent<Rigidbody2D>();
        Invoke("SetLayerOfRow", 0.2f);
        

    }
    void SetLayerOfRow()
    {
        int layer = line + 9;
        gameObject.layer = layer;
        for (int i = 1; i < 5; i++)
        {
            if (line != i)
                Physics2D.IgnoreLayerCollision((i + 5), layer, true);

        }
    }
    public void TakeDamage(int damage)
    {
        ChangeColor();
        _healt-=damage;
        if (_healt <= 0)
        {
            Die();
        }
    }
  
    void ChangeColor()
    {
       _banditSpriteRender.color = _color;  
        Invoke("ReturnColor", 0.1f);
    }
    void ReturnColor()
    {
        _banditSpriteRender.color = Color.white;
    }
    void Die()
    {
        Destroy(gameObject);
    }

    void Update()
    {
        _rb.velocity = Vector2.left * _speed*Time.deltaTime;
    }
}
