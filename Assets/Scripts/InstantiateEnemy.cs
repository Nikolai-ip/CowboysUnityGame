using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public GameObject[] _targetStart;
    private int line;
    [SerializeField] private Robber _robberPrefab;
    [SerializeField] private float _timeRespawnRobber;
    void Start()
    {
       StartCoroutine(InstantiateCorutine());

    }
    IEnumerator InstantiateCorutine()
    {
        for(; ; )
        {
            line = Random.Range(0, _targetStart.Length);
            var robber = Instantiate(_robberPrefab, _targetStart[line].transform.position, _targetStart[line].transform.rotation);
            yield return new WaitForSeconds(_timeRespawnRobber);
        }
       
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
