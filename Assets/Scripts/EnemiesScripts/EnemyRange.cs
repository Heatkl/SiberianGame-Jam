using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(ItemDropper))]
public class EnemyRange : MonoBehaviour, IDamagable
{
    [SerializeField] private GameObject player;
    [SerializeField] GameObject bulletPref;
    private Animator anim;
    private UnityEngine.AI.NavMeshAgent agent;
    private GameObject _bullet;
    private bool isActive = false;
    private bool _reCharge = false;
    private float dist;
    private int totalBullets = 10;
    private int currentBullets = 10;

    private float timeBetween = 0f;
    private float timeToRecharge;
    private float _speed = 4f;
    private Rigidbody2D rb;
    private float d1 = 6f;//ƒистанци€, при которой игрок обнаруживаетс€ и дистанци€, за которой враг бежит к игроку
    private float d2 = 3f;//ƒистанци€, дальше которой враг стоит на месте, и стрел€ет в игрока, и ближе которой враг начинает убегать от игрока
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false; //NavMesh
    }

    // Update is called once per frame
    void Update()
    {
        if (_reCharge) //≈сли перезар€дка, то перезар€жаетс€ отведенное врем€
        {
            reCharge();
            State = States.Recharge;
        }
        else
        {
            
            moveFunc();
        }
    }

    private void moveFunc()
    {
        //ѕровер€ет дистанцию до игрока
        dist = Vector2.Distance(player.transform.position, gameObject.transform.position);
        //≈сли игрок обнаружен, то поворачиваемс€ к нему, и выполн€ем действие в зависимости от дистанции
        if (isActive)
        {
            State = States.WalkRed;
            Vector2 _direction = player.transform.position;
            _direction -= rb.position;
            float _ang = Mathf.Atan2(_direction.y, _direction.x) * Mathf.Rad2Deg;
            rb.rotation = _ang-90f;
            if (dist > d1) toPlayer();
            else if (dist < d2) fromPlayer();
            else shootPlayer();
        }
        else
        {
            isActive = (!isActive && dist < d1) ? true : false; //≈сли не обнаружен, ждем пока будет обнаружен, или откроетс€ дверь*
            calmFunc();
            State = States.Idle;
        }
    }

    private void toPlayer()
    {
        agent.SetDestination(player.transform.position);
        //Vector3 delta = player.transform.position - transform.position;
        //transform.position += delta.normalized * _speed * Time.deltaTime;

        /*if (player.transform.position.x > gameObject.transform.position.x) gameObject.transform.Translate(_speed*Time.deltaTime, 0, 0);
        else if(player.transform.position.x < gameObject.transform.position.x) gameObject.transform.Translate(-1*_speed * Time.deltaTime, 0, 0);
        if (player.transform.position.y > gameObject.transform.position.y) gameObject.transform.Translate(0, _speed * Time.deltaTime, 0);
        else if(player.transform.position.y < gameObject.transform.position.y) gameObject.transform.Translate( 0, -1 * _speed* Time.deltaTime, 0);
        Debug.Log("Go to");*/
    }

    private void fromPlayer()
    {
        /* Debug.Log("Go out");*/
        Vector3 delta = player.transform.position - transform.position;
        transform.position -= delta.normalized * _speed * Time.deltaTime;
    }

    private void shootPlayer()
    {
        
        if (timeBetween < Time.time)//≈сли патрон еще не выпущен
        {
            Debug.Log(currentBullets);
            if (currentBullets == 0)//≈сли патронов нет
            {
                _reCharge = true;
                timeToRecharge = Time.time + 4f;//ѕерезар€жаемс€ 4 секунды
            }
            else//≈сли патроны есть
            {
                //—трел€ем
                //State = States.ShootRed;
                timeBetween = Time.time + 1f;
                anim.SetTrigger("Shoot");
                //Debug.Log("Shoot");
                _bullet = Instantiate(bulletPref) as GameObject;
                _bullet.transform.position = transform.TransformPoint(Vector3.forward * 1.5f);
                _bullet.transform.rotation = transform.rotation;
                _bullet.transform.Rotate(0, 0, 90f);
                //_bullet.transform.rotation = new Quaternion(transform.rotation.x, transform.rotation.y, transform.rotation.z+90f, transform.rotation.w);
                currentBullets--;
            }

        }
    }
    private void calmFunc()
    {
        timeBetween = Time.time + 0.2f;
        // Ќичего не делаем пока ничего не происходит
    }

    private void reCharge()
    {//ѕерезар€жаемс€ заданное врем€
        if (timeToRecharge < Time.time)
        {
            currentBullets = totalBullets;
            _reCharge = false;
        }
    }

    private void Die()
    {
        FindObjectOfType<LevelManager>().RedEnemies--;
        gameObject.GetComponent<ItemDropper>().DropItem();
        Destroy(gameObject);
    }


    //‘ункции анимации
    public enum States
    {
        Idle,
        WalkRed,
        Recharge
        
        
    }


    public void GetDamage(int damage)
    {
        Die();
    }


    private States State
    {
        get { return (States)anim.GetInteger("state"); }
        set { anim.SetInteger("state", (int)value); }
    }
}
