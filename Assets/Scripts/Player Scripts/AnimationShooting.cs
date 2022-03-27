using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationShooting : MonoBehaviour
{
    [SerializeField] private Knife _knife;
    [SerializeField] private PPM _ppm;
    [SerializeField] private Shotgun _shotgun;
    [SerializeField] private SFXPlayer _sfxPlayer;
    private void Start()
    {
        _sfxPlayer = FindObjectOfType<SFXPlayer>();
        UpdateReferences();
    }
    public void UpdateReferences()
    {
        _knife = GetComponentInChildren<WeaponSwitcher>().GetComponentInChildren<Knife>();
        _ppm = GetComponentInChildren<WeaponSwitcher>().GetComponentInChildren<PPM>();
        _shotgun = GetComponentInChildren<WeaponSwitcher>().GetComponentInChildren<Shotgun>();
    }
    public void KnifeHit()
    {
        _sfxPlayer.PlayKnifeHit();
        _knife.Attack();
    }
    public void PPMShooting()
    {
        _sfxPlayer.PlayAutogunShoot();
        _ppm.Shoot();
    }
    public void PistolShooting()
    {
        _sfxPlayer.PlayShotgunShoot();
        _shotgun.Shoot();
    }
}
