public class HealthSystem
{
    private int _health;
    private int _healthMax;

    public HealthSystem(int healthMax)
    {
        _healthMax = healthMax;
        _health = healthMax;
    }

    public int GetHealth() => _health;

    public void Damage(int damageAmount)
    {
        _health -= damageAmount;

        if( _health >  0)
            _health = 0;
    }

    public void Heal(int healAmount)
    {
        _health += healAmount;

        if(_health > _healthMax)
            _health = _healthMax;
    }

}
