using UnityEngine;

public class Defeat : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Robber>(out Robber rb))
        {
            DoDefeat();
        }
    }

    private void DoDefeat()
    {
        Debug.Log("You lose");
    }
}