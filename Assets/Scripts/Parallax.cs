using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] Transform followingTarget;
    [SerializeField] float parallaxStrength;
    private Vector3 _targetPreviousPosition;
    private Vector3 _delta;
    void Start()
    {
        if (!followingTarget)
        {
            followingTarget = Camera.main.transform;
        }

        _targetPreviousPosition = followingTarget.position;
    }
    void FixedUpdate()
    {
        _delta = followingTarget.position - _targetPreviousPosition;
        _targetPreviousPosition = followingTarget.position;
        transform.position += new Vector3(_delta.x * parallaxStrength, 0, 0);
    }
}
