using UnityEngine;

public static class MovementExtension
{
    public static Vector2 GetNormalPerpendicular(Transform origin, float distance, LayerMask layerMask, ref float slopeDownAngle)
    {
        RaycastHit2D hit = Physics2D.Raycast(origin.position, Vector2.down, distance, layerMask);
        slopeDownAngle = Vector2.Angle(hit.normal, Vector2.up);

        return Vector2.Perpendicular(hit.normal).normalized;
    }
}
