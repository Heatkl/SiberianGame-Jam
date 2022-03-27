using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pinjata : MonoBehaviour, IDamagable
{
    private float timeBetween = 0f;
    private float timeBetweenLaser = 0f;
    [SerializeField] private int health = 20;
    private GameObject bulletPref;
    private GameObject laserPref;
    [SerializeField] private GameObject _bullet;
        [SerializeField] private GameObject laser;
    [SerializeField] private GameObject red;
    [SerializeField] private GameObject green;
    [SerializeField] private GameObject blue;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0)
        {
            Die();
        }
        if (timeBetween < Time.time)//Если патрон еще не выпущен
        {
            
          
                //Стреляем
                //State = States.ShootRed;
                timeBetween = Time.time + 0.4f;
                //anim.SetTrigger("Shoot");
                //Debug.Log("Shoot");
                bulletPref = Instantiate(_bullet) as GameObject;
            bulletPref.transform.position = transform.TransformPoint(Vector3.forward * 1.5f);
            bulletPref.transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, Random.Range(0, 365));
                //_bullet.transform.Rotate(0, 0, 90f);
                //_bullet.transform.rotation = new Quaternion(transform.rotation.x, transform.rotation.y, transform.rotation.z+90f, transform.rotation.w);



        }

        if (timeBetweenLaser < Time.time)//Если патрон еще не выпущен
        {


            //Стреляем
            //State = States.ShootRed;
            timeBetweenLaser = Time.time + 0.3f;
            //anim.SetTrigger("Shoot");
            //Debug.Log("Shoot");
            laserPref = Instantiate(laser) as GameObject;
            laserPref.transform.position = transform.TransformPoint(Vector3.forward * 1.5f);
            laserPref.transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, Random.Range(0, 365));
            //_bullet.transform.Rotate(0, 0, 90f);
            //_bullet.transform.rotation = new Quaternion(transform.rotation.x, transform.rotation.y, transform.rotation.z+90f, transform.rotation.w);



        }
    }

    public void GetDamage(int damage)
    {
        health -= damage;
    }


    private void Die()
    {
        for (int i=0; i < 3; i++)
        {
            Instantiate(red, transform.position, Quaternion.identity);
            Instantiate(green, transform.position, Quaternion.identity);
            Instantiate(blue, transform.position, Quaternion.identity);
        }
        Destroy(gameObject);

    }
}
