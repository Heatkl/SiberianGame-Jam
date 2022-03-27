using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PPM : Weapon
{
    private void Awake()
    {
        _currentBullets = _maxBullets;
        UpdateUI();
    }
    private void Update()
    {
        if (Input.GetButton("Fire1") && _currentBullets > 0)
        {
            _playerAnimator.SetBool("ppmShooting", true);
        }
        else
        {
            _playerAnimator.SetBool("ppmShooting", false);
        }
    }
    public void Shoot()
    {
        if (_currentBullets <= 0) return;
        _currentBullets--;
        UpdateUI();

        Vector2 direction = _camera.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        RaycastHit2D rayHit = Physics2D.Raycast(
            new Vector2(transform.position.x, transform.position.y),
            direction, _range, ~((1 << 8)|(1 << 12))
            );
        if (rayHit.transform != null)
        {
            if (rayHit.transform.tag == "Enemy")
            {
                rayHit.transform.GetComponent<IDamagable>().GetDamage(_damage);
            }
        }
    }
}
