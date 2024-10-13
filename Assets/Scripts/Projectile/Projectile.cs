using UnityEngine;

public class Projectile : MonoBehaviour
{
    private float _destroyTime = 2f;
    private float _speed;

    private Vector2 _direction;

    private void Start() => 
        Destroy(gameObject, _destroyTime);

    public void Init(Vector2 direction, float speed)
    {
        _direction = direction;
        _speed = speed;
    }

    private void Update() =>
        Move();

    private void Move()
    {
        // ��������� ����� ������� �� ������ ������� �������, ����������� � ��������
        Vector2 newPosition = (Vector2)transform.position + (_direction * _speed * Time.deltaTime);

        // ������������� ����� �������
        transform.position = newPosition;
    }
} 
