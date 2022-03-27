using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Weapon : MonoBehaviour, IInterfaceUpdate
{
    [SerializeField] protected Camera _camera;
    [SerializeField] protected ParticleSystem _hitVFX;
    [SerializeField] protected int _maxBullets = 10;
    [SerializeField] protected Text _bulletText;
    [SerializeField] protected float _range = 5f;
    [SerializeField] protected float _timeBetweenShots = 0.1f;
    [SerializeField] protected float _rechargeTime = 1f;
    [SerializeField] protected int _damage = 1;
    [SerializeField] protected Animator _playerAnimator;
    protected int _currentBullets = 0;
    protected bool _isReady = true;
    protected IEnumerator HitVFX(RaycastHit2D rayHit)
    {
        ParticleSystem vfx = Instantiate(_hitVFX, new Vector3(rayHit.point.x, rayHit.point.y, 0), Quaternion.identity);
        yield return new WaitForSeconds(_hitVFX.time + 0.5f);
        Destroy(vfx.gameObject);
    }
    public void UpdateUI()
    {
        _bulletText.text = $"{_currentBullets}/{_maxBullets}";
    }
    protected IEnumerator ShotCooldown()
    {
        _isReady = false;
        yield return new WaitForSeconds(_timeBetweenShots);
        _isReady = true;
    }
    public void AddBullets(int value)
    {
        _currentBullets += value;
        if (_currentBullets > _maxBullets) _currentBullets = _maxBullets;
        UpdateUI();
    }
}
