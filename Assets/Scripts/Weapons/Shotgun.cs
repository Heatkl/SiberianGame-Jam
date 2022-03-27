using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Weapon
{
    [SerializeField] private float _sprayDegree = 15f;
    private void Awake()
    {
        _currentBullets = _maxBullets;
        UpdateUI();
    }
    private void Update()
    {
        if (Input.GetButton("Fire1") && _currentBullets > 0)
        {
            _playerAnimator.SetBool("pistolShooting", true);
        }
        else
        {
            _playerAnimator.SetBool("pistolShooting", false);
        }
    }
    public void Shoot() //стреляем тремя лучами сразу
    {
        if (_currentBullets <= 0) return;

        _currentBullets--;
        UpdateUI();

        Vector2 direction = _camera.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        Vector2 directionLeft = new Vector2(
            Mathf.Cos(Mathf.Deg2Rad * _sprayDegree) * direction.x - Mathf.Sin(Mathf.Deg2Rad * _sprayDegree) * direction.y,
            Mathf.Sin(Mathf.Deg2Rad * _sprayDegree) * direction.x + Mathf.Cos(Mathf.Deg2Rad * _sprayDegree) * direction.y);
        Vector2 directionRight = new Vector2(
            Mathf.Cos(Mathf.Deg2Rad * _sprayDegree) * direction.x + Mathf.Sin(Mathf.Deg2Rad * _sprayDegree) * direction.y,
            -1 * Mathf.Sin(Mathf.Deg2Rad * _sprayDegree) * direction.x + Mathf.Cos(Mathf.Deg2Rad * _sprayDegree) * direction.y);

        RaycastHit2D[] rayHitArray = new RaycastHit2D[3];

        RaycastHit2D rayHit = Physics2D.Raycast(
            new Vector2(transform.position.x, transform.position.y),
            direction, _range, ~((1 << 8) | (1 << 12)));
        rayHitArray[0] = rayHit;

        RaycastHit2D rayHitLeft = Physics2D.Raycast(
            new Vector2(transform.position.x, transform.position.y),
            directionLeft, _range, ~((1 << 8) | (1 << 12)));
        rayHitArray[1] = rayHitLeft;

        RaycastHit2D rayHitRight = Physics2D.Raycast(
            new Vector2(transform.position.x, transform.position.y),
            directionRight, _range, ~((1 << 8) | (1 << 12)));
        rayHitArray[2] = rayHitRight;

        foreach(RaycastHit2D hit in rayHitArray)
        {
            if (hit.transform != null)
            {
                if (hit.transform.tag == "Enemy")
                {
                    hit.transform.GetComponent<IDamagable>().GetDamage(_damage);
                }
            }
        }
    }
}
