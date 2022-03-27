using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Spawner9 : MonoBehaviour
{
    [SerializeField] private GameObject[] greenPref = new GameObject[3];
    private int _red;
    private int _blue;
    private int _green;

    // Start is called before the first frame update;
    void Start()
    {
        string scene = SceneManager.GetActiveScene().name;
        switch (scene)
        {
            case "Level1":
                _red = 3;
                _blue = 1;
                _green = 3;
                break;
            case "Level2":
                _red = 3;
                _blue = 1;
                _green = 3;
                break;
            case "Level3":
                _red = 3;
                _blue = 1;
                _green = 3;
                break;
            case "Level4":
                _red = 2;
                _blue = 2;
                _green = 2;
                break;
        }
        for (int i = 0; i < _green; i++)
        {

            Instantiate(greenPref[0], new Vector3(transform.position.x + Random.Range(-4.5f, 4.5f), transform.position.y + Random.Range(-2.5f, 2.5f), 0), Quaternion.identity);
        }

        for (int i = 0; i < _red; i++)
        {

            Instantiate(greenPref[1], new Vector3(transform.position.x + Random.Range(-4.5f, 4.5f), transform.position.y + Random.Range(-2.5f, 2.5f), 0), Quaternion.identity);
        }

        for (int i = 0; i < _blue; i++)
        {

            Instantiate(greenPref[2], new Vector3(transform.position.x + Random.Range(-4.5f, 4.5f), transform.position.y + Random.Range(-2.5f, 2.5f), 0), Quaternion.identity);
        }
    }

}