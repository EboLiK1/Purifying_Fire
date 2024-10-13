using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private ResidualImage _prefab;

    private Queue<ResidualImage> _pool;

    private void Awake()
    {
        _pool = new Queue<ResidualImage>();
    }

    public ResidualImage GetObject()
    {
        if (_pool.Count == 0)
        {
            var afterImage = Instantiate(_prefab);
            afterImage.transform.parent = transform;

            return afterImage;
        }

        return _pool.Dequeue();
    }

    public void PutObject(ResidualImage afterImage)
    {
        _pool.Enqueue(afterImage);
        afterImage.gameObject.SetActive(false);
    }

    public void Reset() => _pool.Clear();
}
