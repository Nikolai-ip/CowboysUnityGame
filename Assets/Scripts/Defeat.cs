using System.Collections;
using System.Collections.Generic;
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
    void DoDefeat()
    {
        Debug.Log("You lose");
    }
}
