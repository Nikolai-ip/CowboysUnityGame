public interface ICowboys
{
    void TakeDamage(int damage);

    void Die();

    float GetShootRepeatTime();

    int GetNumberOfbullet();

    int[] GetRangeDamage();

    int GetLine();

    void SetLine(int line);
}