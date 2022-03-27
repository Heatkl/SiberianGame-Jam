using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerResources : MonoBehaviour, IDamagable
{
    [SerializeField] private int _startHealth = 100;
    [SerializeField] private int _currentHealth;
    [SerializeField] private Text _healthText;

    [SerializeField] private PPM _ppm;
    [SerializeField] private Shotgun _shotgun;
    [SerializeField] private SFXPlayer _sfxPlayer;
    private int CurrentHealth {
        get { return _currentHealth; }
        set
        {
            _currentHealth = value;
            if (_currentHealth > 100) _currentHealth = _startHealth;
            UpdateHealthUI();
        }
    }
    private void Start()
    {
        _sfxPlayer = FindObjectOfType<SFXPlayer>();
        _currentHealth = _startHealth;

        UpdateHealthUI();
    }
    public void GetDamage()
    {
        _currentHealth--;
        if (_currentHealth <= 0)
        {
            FindObjectOfType<LevelManager>().Lose();
        }
    }
    private void UpdateHealthUI()
    {
        _healthText.text = $"{_currentHealth}";
    }

    public void GetDamage(int damage)
    {
        _currentHealth -= damage;
        if(_currentHealth <= 0)
        {
            FindObjectOfType<LevelManager>().Lose();
        }
        UpdateHealthUI();
    }
    public void TakeItem(Item item)
    {
        _sfxPlayer.PlayAmmoPickUp();
        if(item.GetItemType() == ItemType.HEALTH)
        {
            CurrentHealth += item.GetRestoreAmount();
        }
        else if(item.GetItemType() == ItemType.PPM)
        {
            _ppm.AddBullets(item.GetRestoreAmount());
        }
        else if(item.GetItemType() == ItemType.SHOTGUN)
        {
            _shotgun.AddBullets(item.GetRestoreAmount());
        }
    }
}
