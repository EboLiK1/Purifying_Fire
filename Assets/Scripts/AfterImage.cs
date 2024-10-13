using UnityEngine;

public class AfterImage : MonoBehaviour
{
    [SerializeField] private float _baseAlpha;
    [SerializeField] private float _alphaDecay;

    private float _currentAlpha;

    private SpriteRenderer _spriteRenderer;
    private Color _color;

    private void OnEnable()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _currentAlpha = _baseAlpha;
    }

    private void Update()
    {
        _currentAlpha -= _alphaDecay * Time.deltaTime;
        _color = new Color(1f, 1f, 1f, _currentAlpha);
        _spriteRenderer.color = _color;

        if (_currentAlpha <= 0f)
            gameObject.SetActive(false);
    }
}