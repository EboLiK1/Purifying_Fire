using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ExperimentalsScripts : MonoBehaviour
{
    //private void Move()
    //{
    //    float targetVelocityX = _moveDirection.x * _moveSpeed;

    //    Vector3 slopeNormal = CalculateSlopeNormal();
    //    Vector3 targetVelocity = Vector3.ProjectOnPlane(new Vector3(targetVelocityX, _rigidbody.velocity.y, 0f), slopeNormal);
    //    _rigidbody.velocity = Vector3.SmoothDamp(_rigidbody.velocity, targetVelocity, ref nullvec, _smoothTime);
    //}

    //private Vector3 CalculateSlopeNormal()
    //{

    //    Vector3 slopeNormal = Vector3.up;
    //    Vector2 rayOrigin = new Vector2(transform.position.x, transform.position.y - 0.4f);

    //    RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.down, raycastDistance, _slope);

    //    if (hit)
    //    {
    //        slopeNormal = hit.normal;
    //    }

    //    return slopeNormal;
    //}

    //public float raycastDistance;

    //private bool IsOnSlope()
    //{
    //    Vector2 rayOriginLeft = new Vector2(transform.position.x - 0.1f, transform.position.y - 0.4f);
    //    Vector2 rayOriginRight = new Vector2(transform.position.x + 0.1f, transform.position.y - 0.4f);

    //    RaycastHit2D hitLeft = Physics2D.Raycast(rayOriginLeft, Vector2.down, raycastDistance, _slope);
    //    RaycastHit2D hitRight = Physics2D.Raycast(rayOriginRight, Vector2.down, raycastDistance, _slope);

    //    Debug.DrawRay(rayOriginLeft, Vector2.down * raycastDistance, Color.red); // Отрисовываем линию для отладки
    //    Debug.DrawRay(rayOriginRight, Vector2.down * raycastDistance, Color.red); // Отрисовываем линию для отладки

    //    if (hitLeft || hitRight)
    //    {
    //        Debug.DrawRay(rayOriginLeft, Vector2.down * raycastDistance, hitLeft ? Color.green : Color.red); // Отрисовываем линию для отладки
    //        Debug.DrawRay(rayOriginRight, Vector2.down * raycastDistance, hitRight ? Color.green : Color.red); // Отрисовываем линию для отладки
    //        return true;
    //    }

    //    return false;
    //}

    //private float CalculateSlopeAngle()
    //{
    //    Vector2 rayOrigin = new Vector2(transform.position.x, transform.position.y - 0.4f);

    //    RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.down, raycastDistance, _slope);

    //    if (hit)
    //    {
    //        float slopeAngle = Mathf.Atan2(hit.normal.x, hit.normal.y) * Mathf.Rad2Deg;
    //        return slopeAngle;
    //    }

    //    return 0f;
    //}

    //private void Move()
    //{
    //    RaycastHit2D hitDirection = Physics2D.Raycast(transform.position, Vector2.down, 2f, _ground);
    //    Vector2 targetVelocity = new Vector2(0, 0);
    //    if (hitDirection.collider != null)
    //        targetVelocity = new Vector2(_moveDirection.x >= 0f ? hitDirection.normal.y : -hitDirection.normal.y,
    //                                     _moveDirection.x >= 0f ? -hitDirection.normal.x : hitDirection.normal.x);

    //    transform.Translate(targetVelocity * Mathf.Abs(_moveDirection.x) * _moveSpeed);
    //}

    //private void Move()
    //{
    //    float targetVelocityX = _moveDirection.x * _moveSpeed;

    //    Vector2 targetVelocity = new Vector2(targetVelocityX, _rigidbody.velocity.y);
    //    _rigidbody.velocity = Vector2.SmoothDamp(_rigidbody.velocity, targetVelocity, ref nullVector, _smoothTime);
    //}

    //private void Move()
    //{
    //    float targetVelocityX = _moveDirection.x * _moveSpeed;

    //    RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 2f, _slope);
    //    Debug.DrawRay(hit.point, hit.normal, Color.red); // Отрисовываем линию для отладки
    //    if (hit.collider != null) // Проверяем, есть ли коллайдер под персонажем
    //    {
    //        Debug.DrawRay(hit.point, hit.normal, Color.green); // Отрисовываем линию для отладки
    //        float slopeAngle = Vector2.Angle(hit.normal, Vector2.up); // Получаем угол наклона поверхности

    //        if (slopeAngle > 45f) // Проверяем, превышает ли угол наклона допустимый предел
    //        {
    //                                                             // Изменяем целевую скорость по оси X для учета наклона
    //            targetVelocityX = Mathf.Cos(slopeAngle * Mathf.Deg2Rad) * targetVelocityX;
    //        }
    //    }

    //    Vector2 targetVelocity = new Vector2(targetVelocityX, _rigidbody.velocity.y);
    //    _rigidbody.velocity = Vector2.SmoothDamp(_rigidbody.velocity, targetVelocity, ref nullVector, _smoothTime);
    //}

    //private void Move()
    //{
    //    float targetVelocityX = DetermineTargetVelocityX();

    //    Vector2 targetVelocity = new Vector2(targetVelocityX, _rigidbody.velocity.y);
    //    _rigidbody.velocity = Vector2.SmoothDamp(_rigidbody.velocity, targetVelocity, ref nullVector, _smoothTime);

    //    bool isWalking = _moveDirection != Vector2.zero;

    //    if (isWalking && Mathf.Sign(_moveDirection.x) != Mathf.Sign(transform.localScale.x))
    //        Flip();
    //}

    //private float DetermineTargetVelocityX()
    //{
    //    float targetVelocityX = _moveDirection.x * _moveSpeed;

    //    if (_isCrouching)
    //        targetVelocityX = _moveDirection.x * _crouchSpeed;

    //    if (_isDashing)
    //        targetVelocityX = _moveDirection.x * _dashSpeed;

    //    return targetVelocityX;
    //}



    //private void Move()
    //{
    //    float targetVelocityX = _moveDirection.x * _moveSpeed;

    //    Vector3 slopeNormal = CalculateSlopeNormal();
    //    Vector3 targetVelocity = Vector3.ProjectOnPlane(new Vector3(targetVelocityX, _rigidbody.velocity.y, 0f), slopeNormal);
    //    Vector2 targetVelocity2D = new Vector2(targetVelocity.x, targetVelocity.y);
    //    _rigidbody.velocity = Vector2.SmoothDamp(_rigidbody.velocity, targetVelocity2D, ref nulle, _smoothTime);
    //}


    //private Vector2 nulle = Vector2.zero;

    //private Vector3 CalculateSlopeNormal()
    //{
    //    Vector3 slopeNormal = Vector3.up;
    //    Vector2 rayOrigin = new Vector2(transform.position.x, transform.position.y - 0.4f);

    //    RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.down, raycastDistance, _slope);

    //    if (hit)
    //    {
    //        slopeNormal = hit.normal;
    //    }

    //    return slopeNormal;
    //}

    //public float raycastDistance;

    //private void Move()
    //{
    //    float targetVelocityX = _moveDirection.x * _moveSpeed;

    //    Vector2 targetVelocity = new Vector2(targetVelocityX, _rigidbody.velocity.y);
    //    _rigidbody.velocity = Vector2.SmoothDamp(_rigidbody.velocity, targetVelocity, ref nulle, _smoothTime);
    //}


    //private void Move()
    //{
    //    if (IsOnSlopee())
    //    {
    //        float slopeAngle = CalculateSlopeAngle();
    //        Debug.Log($"Градус наклонной: {slopeAngle}");
    //        float targetVelocityX = _moveDirection.x * _moveSpeed;

    //        Vector3 slopeNormal = CalculateSlopeNormal();
    //        Vector3 targetVelocity = Vector3.ProjectOnPlane(new Vector3(targetVelocityX, _rigidbody.velocity.y, 0f), slopeNormal);
    //        Vector2 targetVelocity2D = new Vector2(targetVelocity.x, targetVelocity.y);
    //        _rigidbody.velocity = Vector2.SmoothDamp(_rigidbody.velocity, targetVelocity2D, ref nullVectorr, _smoothTime);
    //    }
    //}

    //private Vector3 CalculateSlopeNormal()
    //{
    //    Vector3 slopeNormal = Vector3.up;
    //    Vector2 rayOrigin = new Vector2(transform.position.x, transform.position.y - 0.4f);

    //    RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.down, raycastDistance, _slope);

    //    if (hit)
    //    {
    //        slopeNormal = hit.normal;
    //    }

    //    return slopeNormal;
    //}

    //private bool IsOnSlopee()
    //{
    //    Vector2 rayOriginLeft = new Vector2(transform.position.x - 0.1f, transform.position.y - 0.4f);
    //    Vector2 rayOriginRight = new Vector2(transform.position.x + 0.1f, transform.position.y - 0.4f);

    //    RaycastHit2D hitLeft = Physics2D.Raycast(rayOriginLeft, Vector2.down, raycastDistance, _slope);
    //    RaycastHit2D hitRight = Physics2D.Raycast(rayOriginRight, Vector2.down, raycastDistance, _slope);

    //    Debug.DrawRay(rayOriginLeft, Vector2.down * raycastDistance, Color.red); // Отрисовываем линию для отладки
    //    Debug.DrawRay(rayOriginRight, Vector2.down * raycastDistance, Color.red); // Отрисовываем линию для отладки

    //    if (hitLeft || hitRight)
    //    {
    //        Debug.DrawRay(rayOriginLeft, Vector2.down * raycastDistance, hitLeft ? Color.green : Color.red); // Отрисовываем линию для отладки
    //        Debug.DrawRay(rayOriginRight, Vector2.down * raycastDistance, hitRight ? Color.green : Color.red); // Отрисовываем линию для отладки
    //        return true;
    //    }

    //    return false;
    //}

    //private float CalculateSlopeAngle()
    //{
    //    Vector2 rayOrigin = new Vector2(transform.position.x, transform.position.y - 0.4f);

    //    RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.down, raycastDistance, _slope);

    //    if (hit)
    //    {
    //        float slopeAngle = Mathf.Atan2(hit.normal.x, hit.normal.y) * Mathf.Rad2Deg;
    //        return slopeAngle;
    //    }

    //    return 0f;
    //}


    //private bool IsOnSlopee()
    //{
    //    Vector2 rayOriginLeft = new Vector2(transform.position.x - 0.1f, transform.position.y - 0.4f);
    //    Vector2 rayOriginRight = new Vector2(transform.position.x + 0.1f, transform.position.y - 0.4f);

    //    RaycastHit2D hitLeft = Physics2D.Raycast(rayOriginLeft, Vector2.down, raycastDistance, _slope);
    //    RaycastHit2D hitRight = Physics2D.Raycast(rayOriginRight, Vector2.down, raycastDistance, _slope);

    //    Debug.DrawRay(rayOriginLeft, Vector2.down * raycastDistance, Color.red); // Отрисовываем линию для отладки
    //    Debug.DrawRay(rayOriginRight, Vector2.down * raycastDistance, Color.red); // Отрисовываем линию для отладки

    //    if (hitLeft || hitRight)
    //    {
    //        Debug.DrawRay(rayOriginLeft, Vector2.down * raycastDistance, hitLeft ? Color.green : Color.red); // Отрисовываем линию для отладки
    //        Debug.DrawRay(rayOriginRight, Vector2.down * raycastDistance, hitRight ? Color.green : Color.red); // Отрисовываем линию для отладки
    //        return true;
    //    }

    //    return false;
    //}

    //private float CalculateSlopeAngle()
    //{
    //    Vector2 rayOrigin = new Vector2(transform.position.x, transform.position.y - 0.4f);

    //    RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.down, raycastDistance, _slope);

    //    if (hit)
    //    {
    //        float slopeAngle = Mathf.Atan2(hit.normal.x, hit.normal.y) * Mathf.Rad2Deg;
    //        return slopeAngle;
    //    }

    //    return 0f;
    //}









    //private void SlopeCheck()
    //{
    //    RaycastHit2D hit = Physics2D.Raycast(_groundCheck.position, Vector2.down, _groundCheckRadius, _ground);

    //    if (hit)
    //    {
    //        _slopeNormalPerpendicular = Vector2.Perpendicular(hit.normal).normalized;
    //        _slopeDownAngle = Vector2.Angle(hit.normal, Vector2.up);

    //        Debug.Log(_slopeDownAngle);
    //        Debug.DrawRay(hit.point, _slopeNormalPerpendicular, Color.blue);
    //        Debug.DrawRay(hit.point, hit.normal, Color.green);
    //    }

    //    _isOnSlope = _slopeDownAngle > 0f;
    //}
}
