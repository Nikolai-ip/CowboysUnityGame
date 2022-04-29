using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionBullet : MonoBehaviour
{
    // Start is called before the first frame update

    private void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
      
        Cowboys unit = gameObject.GetComponentInParent<Cowboys>(); // берем того rifleMen, который является родителем выпущенной bullet
        Robber enemy =  collision.GetComponent<Robber>();
        if(enemy!=null && unit.line == enemy.line)
        {
            enemy.TakeDamage(Random.Range(unit.minDamage,unit.maxDamage));
            Destroy(gameObject);
        }
       
    }
}
