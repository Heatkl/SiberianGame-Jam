using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(BoxCollider2D))]
public class Knife : MonoBehaviour, IInterfaceUpdate
{
    [SerializeField] private int _damage = 1;
    [SerializeField] Animator _playerAnimator;
    private List<IDamagable> _enemiesInRange = new List<IDamagable>();

    private PolygonCollider2D _affectedAreaCollider;
    protected bool _isReady = true;

    private void Start()
    {
        _affectedAreaCollider = GetComponent<PolygonCollider2D>();
    }
    private void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            _playerAnimator.SetBool("knifeHitting", true);
        }
        else
        {
            _playerAnimator.SetBool("knifeHitting", false);
        }
        
    }
    public void Attack()
    {

        foreach(IDamagable enemies in _enemiesInRange)
        {
            enemies.GetDamage(_damage);
        }
    }

    /*protected IEnumerator ShotCooldown()
    {
        _isReady = false;
        yield return new WaitForSeconds(_timeBetweenShots);
        _isReady = true;
    }*/
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject otherGO = collision.gameObject;
        if (otherGO.GetComponent<IDamagable>() != null)
        {
            _enemiesInRange.Add(otherGO.GetComponent<IDamagable>());
        }
        Debug.Log(_enemiesInRange.Count);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        GameObject otherGO = collision.gameObject;
        if (otherGO.GetComponent<IDamagable>() != null)
        {
            _enemiesInRange.Remove(otherGO.GetComponent<IDamagable>());
        }
        Debug.Log(_enemiesInRange.Count);
    }
    public void UpdateUI()
    {
    }
}
