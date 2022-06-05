using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Transform _firePoint;
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Animator _animator;
    private Cowboys _unit;

    // Update is called once per frame
    private void Start()
    {
        _unit = GetComponentInParent<Cowboys>();
        _animator=GetComponentInParent<Animator>();
        StartCoroutine("DoShoot");

    }
    void Update()
    {
        
      
    }
    IEnumerator DoShoot()
    {
        int k = 0;
        var wait = new WaitForSeconds(_unit.shootRepeatTime);
        for (; ; )
        {
            Shoot();
            k++;
            if (_unit.numbersOfBullet==k)
            {
                Invoke("Reload", 1.2f);
                k = 0;
            }
           
            yield return wait;
        }
    }
    void Reload()
    {
        _animator.SetTrigger("reload");
    }
    void Shoot()
    {
        _animator.SetTrigger("shoot");
        var obj= Instantiate(_bulletPrefab, _firePoint);
        obj.transform.localScale= Vector3.one;
    }
}
