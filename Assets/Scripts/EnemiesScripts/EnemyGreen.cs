using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ItemDropper))]
public class EnemyGreen : MonoBehaviour, IDamagable

{
    [SerializeField] private GameObject player;
    private float oneHit = 0f;
    private Animator anim;
    private bool isActive = false;
    private PlayerResources plares;
    private UnityEngine.AI.NavMeshAgent agent;
    private float dist;
    private float _speed = 4f;
    private Rigidbody2D rb;
    private float d1 = 6f;//Дистанция, при которой игрок обнаруживается 
    private float d2 = 1f;//Дистанция, ближе которой враг стоит на месте, и бьет игрока ножом
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        plares = player.GetComponent<PlayerResources>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    // Update is called once per frame
    void Update()
    {
        dist = Vector2.Distance(player.transform.position, gameObject.transform.position);
        if (isActive)
        {
            State = States.WalkGreen;
            Vector2 _direction = player.transform.position;
            _direction -= rb.position;
            float _ang = Mathf.Atan2(_direction.y, _direction.x) * Mathf.Rad2Deg;
            rb.rotation = _ang - 90f;
            if (dist < d2) hitPlayer();
            else toPlayer();
        }
        else
        {
            isActive = (!isActive && dist < d1) ? true : false;
            calmFunc();
        }
    }


    void toPlayer()
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


    void hitPlayer()
    {
        //Debug.Log("Hit");
        anim.SetTrigger("Hit");
        if (Vector2.Distance(player.transform.position, transform.position) < 1f)
        {
            if (oneHit < Time.time)
            {
                oneHit = Time.time + 1f;
                plares.GetDamage(1);
            }
        }

    }
    void calmFunc()
    {
        //Debug.Log("Calm");
    }


    private void Die()
    {
        FindObjectOfType<LevelManager>().GreenEnemies--;
        gameObject.GetComponent<ItemDropper>().DropItem();
        Destroy(gameObject);
    }


    //Функции анимации
    public enum States
    {
        Idle,
        WalkGreen


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