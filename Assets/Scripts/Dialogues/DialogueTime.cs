using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTime : MonoBehaviour
{
    private int spaceCounter = 0;
    private float StartTime = 3f;
    [SerializeField] private GameObject _boss;
    [SerializeField] private GameObject _judge;
    [SerializeField] private GameObject _nigger;
    private BossChange bc;
    private NiggerChange nc;
    private JudgeChange jc;

    void Start()
    {
        bc = _boss.GetComponent<BossChange>();
        nc = _nigger.GetComponent<NiggerChange>();
        jc = _judge.GetComponent<JudgeChange>();

    }
    // Update is called once per frame
    void Update()
    {
        if (StartTime < Time.time)
        {
            _judge.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            spaceCounter++;

            bc.changeSprite(spaceCounter);
            nc.changeSprite(spaceCounter);
            jc.changeSprite(spaceCounter);


        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            SceneLoader.LoadNextScene();
        }
    }
}
