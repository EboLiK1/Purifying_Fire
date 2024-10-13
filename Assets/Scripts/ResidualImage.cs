using UnityEngine;

public class ResidualImage : MonoBehaviour
{
    [SerializeField] private float _activeTime;
    [SerializeField] private Sprite _residualImage;
    [SerializeField] private Transform _player;

    private SpriteRenderer _renderer;
    private float _elapsedTime;

    private void OnEnable()
    {
        _renderer = GetComponent<SpriteRenderer>();

        _player = GameObject.FindGameObjectWithTag("Player").transform;

        transform.position = _player.position;
        transform.rotation = _player.rotation;

        _renderer.sprite = _residualImage;
        _renderer.color = new Color(_renderer.color.r, _renderer.color.g, _renderer.color.b, 1f); // Установка полной непрозрачности
        _elapsedTime = 0f;
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        float fadeAmount = _elapsedTime / _activeTime;
        Color currentColor = _renderer.color;
        currentColor.a = Mathf.Lerp(1f, 0f, fadeAmount);
        _renderer.color = currentColor;

        if (_elapsedTime >= _activeTime)
            Destroy(gameObject);
    }
}