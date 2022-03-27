using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ItemDropper))]
public class EnemyBlue : MonoBehaviour, IDamagable
{
    [SerializeField] GameObject player;
    private Animator anim;
    private bool isActive = false;
    private float dist;
    private float _speed = 1f;
    private Rigidbody2D rb;
    private float d1 = 6f;//Дистанция, при которой игрок обнаруживается и враг убегает от него подальше
    private float d2 = 1f;//Дистанция, ближе которой враг дебафает,пытаясь при этом убежать
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        dist = Vector2.Distance(player.transform.position, gameObject.transform.position);
        if (isActive)
        {
            Vector2 _direction = player.transform.position;
            _direction -= rb.position;
            float _ang = Mathf.Atan2(_direction.y, _direction.x) * Mathf.Rad2Deg;
            rb.rotation = _ang + 180;
            if (dist < d2) hitPlayer();
            else if(dist >d2 && dist < d1) toPlayer();
            else State = States.Idle;
        }
        else
        {
            isActive = (!isActive && dist < d1) ? true : false;
            calmFunc();
        }
    }
    void toPlayer()
    {
        State = States.WalkGreen;
        Vector3 delta = player.transform.position - transform.position;
        transform.position -= delta.normalized * _speed * Time.deltaTime;
        /*if (player.transform.position.x > gameObject.transform.position.x) gameObject.transform.Translate(_speed*Time.deltaTime, 0, 0);
        else if(player.transform.position.x < gameObject.transform.position.x) gameObject.transform.Translate(-1*_speed * Time.deltaTime, 0, 0);
        if (player.transform.position.y > gameObject.transform.position.y) gameObject.transform.Translate(0, _speed * Time.deltaTime, 0);
        else if(player.transform.position.y < gameObject.transform.position.y) gameObject.transform.Translate( 0, -1 * _speed* Time.deltaTime, 0);
        Debug.Log("Go to");*/
    }


    void hitPlayer()
    {

        anim.SetTrigger("Hit");

    }
    void calmFunc()
    {
        //Debug.Log("Calm");
    }

    public void GetDamage(int damage)
    {
        Die();
    }
    private void Die()
    {
        FindObjectOfType<LevelManager>().BlueEnemies--;
        gameObject.GetComponent<ItemDropper>().DropItem();
        Destroy(gameObject);
    }

    //Функции анимации
    public enum States
    {
        Idle,
        WalkGreen


    }


    private States State
    {
        get { return (States)anim.GetInteger("state"); }
        set { anim.SetInteger("state", (int)value); }
    }

}