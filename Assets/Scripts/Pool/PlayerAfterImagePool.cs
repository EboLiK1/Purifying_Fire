using UnityEngine;

public class PlayerAfterImagePool : MonoBehaviour
{
    public static PlayerAfterImagePool Instance { get; private set; }

    [SerializeField] private int _poolCount;
    [SerializeField] private bool _autoExpand;
    [SerializeField] private AfterImage _afterImage;

    private Transform _spawnPoint;

    private PoolMono<AfterImage> _pool;

    private void Start()
    {
        Instance = this;

        _spawnPoint = FindObjectOfType<Player>().transform;

        _pool = new PoolMono<AfterImage>(_afterImage, _poolCount, transform);
        _pool.AutoExpand = _autoExpand;
    }

    public void CreateAfterImage()
    {
        AfterImage afterImage = _pool.GetFreeElement();
        afterImage.transform.position = _spawnPoint.position;
        afterImage.transform.localScale = _spawnPoint.localScale;
    }
}