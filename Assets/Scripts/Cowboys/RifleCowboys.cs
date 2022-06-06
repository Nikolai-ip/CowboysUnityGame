using UnityEngine;

public class RifleCowboys : MonoBehaviour, ICowboys
{
    // Start is called before the first frame update
    public int line;

    [SerializeField] private float _shootRepeatTime;
    [SerializeField] private int _maxDamage;
    [SerializeField] private int _minDamage;
    [SerializeField] private int _numbersOfBullet;
    [SerializeField] private int healt;

    public void TakeDamage(int damage)
    {
        healt -= damage;
        if (healt <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    public float GetShootRepeatTime()
    {
        return _shootRepeatTime;
    }

    public int GetNumberOfbullet()
    {
        return _numbersOfBullet;
    }

    public int[] GetRangeDamage()
    {
        return new int[] { _minDamage, _maxDamage };
    }

    public int GetLine()
    {
        return line;
    }

    public void SetLine(int line)
    {
        this.line = line;
    }
}