using System.Collections;
using UnityEngine;

public class Robber : MonoBehaviour
{
    [SerializeField] private int _healt;
    public Animator _animator { get; private set; }
    [SerializeField] private float _speed;
    private SpriteRenderer _banditSpriteRender;
    private Rigidbody2D _rb;
    [SerializeField] private Color _color;
    [SerializeField] private float _timeReloadHit;
    [HideInInspector] public int line;
    [SerializeField] private Transform _hitPoit;
    [SerializeField] private int _hitDamage = 30;
    [SerializeField] private float _hitRange = 0.5f;

    private void Start()
    {
        _banditSpriteRender = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody2D>();
        Invoke("SetLayerOfRow", 0.2f);
        _animator.SetTrigger("walk");
    }

    private void SetLayerOfRow()
    {
        int layer = line + 9;
        gameObject.layer = layer;
        for (int i = 1; i < 5; i++)
        {
            Physics2D.IgnoreLayerCollision((i + 9), layer, true);
        }
    }

    public void TakeDamage(int damage)
    {
        ChangeColor();
        _healt -= damage;
        if (_healt <= 0)
        {
            Die();
        }
    }

    private void ChangeColor()
    {
        _banditSpriteRender.color = _color;
        Invoke("ReturnColor", 0.1f);
    }

    private void ReturnColor()
    {
        _banditSpriteRender.color = Color.white;
    }

    private void Die()
    {
        Destroy(gameObject);
    }

    public void Attack()
    {
        StartCoroutine(DoAttack());
    }

    public void StopAttack()
    {
        StopCoroutine(DoAttack());
        _animator.SetTrigger("walk");
    }

    private IEnumerator DoAttack()
    {
        var wait = new WaitForSeconds(_timeReloadHit);
        Vector2 vectorHit = _hitPoit.position;
        Collider2D collider;
        while (true)
        {
            collider = Physics2D.OverlapCircle(vectorHit, _hitRange);
            ICowboys cowboy = collider?.GetComponent<ICowboys>();
            if (cowboy != null)
            {
                cowboy.TakeDamage(_hitDamage);
                _animator.SetTrigger("hit");
            }
            else break;
            yield return wait;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(_hitPoit.position, _hitRange);
    }

    private void Update()
    {
        _rb.velocity = Vector2.left * _speed * Time.deltaTime;
    }
}