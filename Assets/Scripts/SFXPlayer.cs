using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXPlayer : MonoBehaviour
{
    [SerializeField] private AudioClip _ammoDrop;
    [SerializeField] private AudioClip _bodyShoot;
    [SerializeField] private AudioClip _ammoPickup;
    [SerializeField] private AudioClip _autogunShoot;
    [SerializeField] private AudioClip _gunChange;
    [SerializeField] private AudioClip _handgunShoot;
    [SerializeField] private AudioClip _shotgunShoot;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _knifeHit;
    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }
    public void PlayAmmoDrop()
    {
        _audioSource.PlayOneShot(_ammoDrop);
    }
    public void PlayBodyShoot()
    {
        _audioSource.PlayOneShot(_bodyShoot);
    }
    public void PlayAmmoPickUp()
    {
        _audioSource.PlayOneShot(_ammoPickup);
    }
    public void PlayAutogunShoot()
    {
        _audioSource.PlayOneShot(_autogunShoot);
    }
    public void PlayGunChange()
    {
        _audioSource.PlayOneShot(_gunChange);
    }
    public void PlayShotgunShoot()
    {
        _audioSource.PlayOneShot(_shotgunShoot);
    }
    public void PlayKnifeHit()
    {
        _audioSource.PlayOneShot(_knifeHit);
    }
}
