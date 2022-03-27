using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private float speed = 10f;
    private int damage;

    void Start()
    {
        Destroy(gameObject, 2f);
    }

    void Update()
    {
        transform.Translate(speed * Time.deltaTime, 0, 0);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        //Destroy(gameObject);
        if (col.tag == "Player")
        {
            PlayerResources plres = col.gameObject.GetComponent<PlayerResources>();
            plres.GetDamage(1);
            //col.getComponent<PlayerControl>().health-=1;
        }
        if (col.tag != "Enemy" && col.tag != "Bullet")
            Destroy(gameObject);
    }
}
