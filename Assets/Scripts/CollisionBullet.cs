using UnityEngine;

public class CollisionBullet : MonoBehaviour
{
    // Start is called before the first frame update

    private void Start()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ICowboys unit = gameObject.GetComponentInParent<ICowboys>(); // берем того cowboys, который является родителем выпущенной bullet
        Robber enemy = collision.GetComponent<Robber>();
        if (enemy != null && unit.GetLine() == enemy.line)
        {
            int[] range = unit.GetRangeDamage();
            enemy.TakeDamage(Random.Range(range[0], range[1]));
            Destroy(gameObject);
        }
    }
}