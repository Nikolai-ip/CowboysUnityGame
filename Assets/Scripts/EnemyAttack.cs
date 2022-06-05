using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    // Start is called before the first frame update
    private Robber parentRobber;

    void Start()
    {
        parentRobber= GetComponentInParent<Robber>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent<Cowboys>(out var collider))
        {
            parentRobber.Attack();
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent<Cowboys>(out var collider))
        {
            parentRobber.StopAttack();
        }
    }
}
