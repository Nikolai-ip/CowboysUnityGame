using System.Collections;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Transform _firePoint;

    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Animator _animator;
    private ICowboys _unit;

    // Update is called once per frame
    private void Start()
    {
        _unit = GetComponentInParent<ICowboys>();
        _animator = GetComponentInParent<Animator>();
        StartCoroutine("DoShoot");
    }

    private void Update()
    {
    }

    private IEnumerator DoShoot()
    {
        int k = 0;
        var wait = new WaitForSeconds(_unit.GetShootRepeatTime());
        for (; ; )
        {
            ShootBullet();
            k++;
            if (_unit.GetNumberOfbullet() == k)
            {
                Invoke("Reload", 1.2f);
                k = 0;
            }

            yield return wait;
        }
    }

    private void Reload()
    {
        _animator.SetTrigger("reload");
    }

    private void ShootBullet()
    {
        _animator.SetTrigger("shoot");
        var obj = Instantiate(_bulletPrefab, _firePoint);
        obj.transform.localScale = Vector3.one;
    }
}