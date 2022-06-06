using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    // Start is called before the first frame update
    private Robber parentRobber;

    private void Start()
    {
        parentRobber = GetComponentInParent<Robber>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent<ICowboys>(out var collider))
        {
            parentRobber.Attack();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent<ICowboys>(out var collider))
        {
            parentRobber.StopAttack();
        }
    }
}