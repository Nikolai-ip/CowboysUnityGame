using System.Collections;
using UnityEngine;

public class InstantiateEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public GameObject[] _targetStart;

    private int line;
    [SerializeField] private Robber _robberPrefab;
    [SerializeField] private float _timeRespawnRobber;

    private void Start()
    {
        StartCoroutine(InstantiateCorutine());
    }

    private IEnumerator InstantiateCorutine()
    {
        var wait = new WaitForSeconds(_timeRespawnRobber);
        for (; ; )
        {
            line = Random.Range(0, _targetStart.Length);
            var robber = Instantiate(_robberPrefab, _targetStart[line].transform.position, _targetStart[line].transform.rotation);
            yield return wait;
        }
    }

    // Update is called once per frame
    private void Update()
    {
    }
}