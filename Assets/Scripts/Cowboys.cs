using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cowboys : MonoBehaviour
{
    // Start is called before the first frame update
    [HideInInspector] public int line;
    public float shootRepeatTime;
    public int maxDamage;
    public int minDamage;
    public int numbersOfBullet;
    [SerializeField] private int healt;

    void Start()
    {

    }
    public void TakeDamage(int damage)
    {
        healt -= damage;
        if (healt<=0)
        {
            Die();
        }
    }
    void  Die()
    {
        Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
