using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponSwitcher : MonoBehaviour
{
    [System.Serializable]
    struct PlayerWeapon
    {
        [SerializeField] public GameObject weapon;
        [SerializeField] public KeyCode _keyCode;
    }
    [SerializeField] private List<PlayerWeapon> _weaponList = new List<PlayerWeapon>();
    [SerializeField] private Animator _playerAnimator;
    [SerializeField] private SFXPlayer _sfxPlayer;
    private void Start()
    {
        _sfxPlayer = FindObjectOfType<SFXPlayer>();
        _weaponList[0].weapon.SetActive(true);
        for(int i = 1; i < _weaponList.Count; i++)
        {
            _weaponList[i].weapon.SetActive(false);
        }
    }
    private void Update()
    {
        foreach(PlayerWeapon weapon in _weaponList)
        {
            if (Input.GetKeyDown(weapon._keyCode))
            {
                SwitchWeapon(weapon);
            }
        }
    }
    private void SwitchWeapon(PlayerWeapon targetWeapon)
    {
        foreach(PlayerWeapon weapon in _weaponList)
        {
            if(weapon.weapon == targetWeapon.weapon)
            {
                weapon.weapon.gameObject.SetActive(true);
            }
            else
            {
                weapon.weapon.gameObject.SetActive(false);
            }
        }
        _sfxPlayer.PlayGunChange();
        targetWeapon.weapon.GetComponent<IInterfaceUpdate>().UpdateUI();
        GetComponentInParent<AnimationShooting>().UpdateReferences();

        if (targetWeapon.weapon.GetComponent<Knife>() != null)
        {
            _playerAnimator.SetBool("ppmShooting", false);
            _playerAnimator.SetBool("pistolShooting", false);
            _playerAnimator.SetTrigger("knifeIdle");
            return;
        }
        if(targetWeapon.weapon.GetComponent<PPM>() != null)
        {
            _playerAnimator.SetBool("knifeHitting", false);
            _playerAnimator.SetBool("pistolShooting", false);
            _playerAnimator.SetTrigger("ppmIdle");
            return;
        }
        if (targetWeapon.weapon.GetComponent<Shotgun>() != null)
        {
            _playerAnimator.SetBool("ppmShooting", false);
            _playerAnimator.SetBool("knifeHitting", false);
            _playerAnimator.SetTrigger("pistolIdle");
            return;
        }
    }
}
